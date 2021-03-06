using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Szotar {
	/// <summary>
	/// Reads lines from a UTF-8 encoded file, keeping detailed positional information.
	/// It is a thus specialized version of StreamReader.
	/// </summary>
	public class Utf8LineReader : IDisposable {
	    readonly bool disposeStream;
	    readonly Encoding encoding;
	    long position;

		// The default buffer size is quite big, I believe. It's probably best to keep 
		// it around between ReadLine calls to avoid big allocations every time.
	    readonly StringBuilder lineBuilder;
	    readonly Decoder decoder;

	    readonly byte[] buffer;
		char[] decodedChars;
		int bytesInBuffer;
		int offset;

		// If we're starting from the beginning of the file, we need to skip the BOM since it's
		// not part of the file. If we're starting partway through, there's no need to do that.
		//
		// It may seem strange allowing specifying the FileAccess, but it is useful as a safeguard
		// against other people already having the file open with e.g. FileAccess.Write and FileShare.Read.
		Utf8LineReader(string path, bool skipBOM, FileAccess access, FileShare share) {
			disposeStream = true;
			BaseStream = new FileStream(path, FileMode.Open, access, share);

			encoding = Encoding.UTF8;
			decoder = encoding.GetDecoder();
			lineBuilder = new StringBuilder();

			offset = 0;
			buffer = new byte[BufferSize];
			bytesInBuffer = 0;
			Line = 0;

			if (skipBOM)
				SkipBOM();
		}

		public Utf8LineReader(string path, FileAccess access, FileShare share)
			: this(path, true, access, share)
		{ }

		public Utf8LineReader(string path, long bytePosition, FileAccess access, FileShare share)
			: this(path, false, access, share) 
		{
			BaseStream.Seek(bytePosition, SeekOrigin.Begin);
			position = bytePosition;
			offset = 0;
			bytesInBuffer = 0;
		}

		#region IDisposable implementation
		public void Dispose() {
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing) {
			if (disposing) {
				if (disposeStream)
					BaseStream.Dispose();
			}
		}

		~Utf8LineReader() {
			Dispose(false);
		}
		#endregion

		long Line { get; set; }

		int BufferSize { get { return 1024; } }

		public bool EndOfStream { get; private set; }

	    public Stream BaseStream { get; }

	    // Skip the UTF-8 byte order mark, EF BB BF.
		// It doesn't actually identify the byte order, since UTF-8 doesn't have byte order issues,
		// but it does identify that it's UTF-8. That's pretty useless to us, considering we already know that.
		void SkipBOM() {
			BufferNextPart();

			if (buffer[0] == 0xEF && buffer[1] == 0xBB && buffer[2] == 0xBF) {
				position = 3;
				offset = 3;
			}
		}

		public void Seek(long bytePosition) {
			long bufferBegin = position - offset;
			long bufferEnd = bufferBegin + bytesInBuffer; // IOW, bufferEnd is not inside the buffer

			// If the target position is inside the buffer, simply adjust the offset.
			if (bytePosition >= bufferBegin && bytePosition < bufferEnd) {
				checked { offset += (int)(bytePosition - position); }
				System.Diagnostics.Debug.Assert(offset >= 0 && offset < bytesInBuffer);
			} else {
				BaseStream.Seek(bytePosition, SeekOrigin.Begin);
				offset = 0;
				bytesInBuffer = 0;
				EndOfStream = false;
			}

			Line = -1; // There's no efficient way to tell. 
			position = bytePosition;

			// SkipBOM expects no buffer to exist yet.
			if (position == 0) {
				BaseStream.Seek(0, SeekOrigin.Begin);
				offset = 0;
				bytesInBuffer = 0;

				SkipBOM();
			}
		}

		public string ReadLine() {
			long unused;
			return ReadLine(out unused);
		}

		public string ReadLine(out long bytePosition) {
			bytePosition = position;

			if (EndOfStream)
				return null;

			bool lineBreakFound = false;
			lineBuilder.Length = 0;
			decoder.Reset();

			while (true) {
				int start = offset;

				// We need to know how many characters were in the linebreak, in order to remove
				// the CR too, if it exists.
				// There's no reason to preserve this across buffer boundaries like before.
				// That actually breaks things with the older code (lbChars = 2 in CR case, reset 
				// to 0 on normal char) anyway, when the CRLF line breaks straddled a boundary.
				int lbChars = 0;

				for (; offset < bytesInBuffer; ++offset, ++position) {
					byte b = buffer[offset];

					if (b == 13) {
						// CR on its own doesn't count as a line break.
						lbChars = 1;
					} else if (b == 10) {
						if (lbChars == 0)
							lbChars = 1;
						else if (lbChars == 1) // There's already a CR.
							lbChars = 2;
						lineBreakFound = true;
						++position; // Important! This throws partway-through reads out of sync otherwise...
						++offset;
						break;
					} else {
						// If we got a CR but not an LF, it's counted as an actual character.
						lbChars = 0;
					}
				}

				if (decodedChars == null)
					decodedChars = new char[BufferSize]; // Decoding 1000 bytes can only use at most 1000 chars.

				// Decode the new bytes from the buffer and add them into the lineBuilder.
				// It seems to be faster using GetChars instead of Convert (takes about 2/3 of the time).
				int charsUsed = decoder.GetChars(buffer, start, offset - start - lbChars, decodedChars, 0);
				lineBuilder.Append(decodedChars, 0, charsUsed);
				lbChars = 0;

				if (lineBreakFound)
					break;

				if (!BufferNextPart())
					break;
			}

			if (!EndOfStream) {
				// Make sure that the EOF flag is properly set.
				// This allows us to assume this in the next read, and to assume that offset != bytesInBuffer,
				// which is useful because it stops Decoder.Convert from throwing a wobbler.
				// XXX what if it already failed to buffer at the end of the above loop?
				if (offset == bytesInBuffer)
					BufferNextPart();
			}

			if (Line != -1)
				Line++;

			// Now, we have all the bytes in the line.
			return lineBuilder.ToString();
		}

		bool BufferNextPart() {
			offset = 0;
			bytesInBuffer = BaseStream.Read(buffer, 0, buffer.Length);

			if (bytesInBuffer == 0) {
				EndOfStream = true;
				return false;
			}

			return true;
		}
	}
}