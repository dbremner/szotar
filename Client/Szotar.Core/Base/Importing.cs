using System;
using System.ComponentModel;

namespace Szotar {
	[Serializable]
	public class ImportException : Exception {
		public ImportException(string message)
			: base(message)
		{ }

		public ImportException() { }
	}

	#region Attributes
	[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
	public sealed class ImporterAttribute : Attribute {
		// See the attribute guidelines at 
		//  http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconusingattributeclasses.asp

	    public ImporterAttribute(string name, Type type) {
			this.Name = name;
			this.Type = type;
		}

		public string Name { get; }

	    public Type Type { get; }
	}

	[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
	public sealed class ImporterUIAttribute : Attribute {
		// See the attribute guidelines at 
		//  http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconusingattributeclasses.asp

	    public ImporterUIAttribute(Type importerType) {
			this.ImporterType = importerType;
		}

		public Type ImporterType { get; }
	}

	[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
	public sealed class ImporterDescriptionAttribute : Attribute {
		// See the attribute guidelines at 
		//  http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconusingattributeclasses.asp

	    public ImporterDescriptionAttribute(string description) {
			this.Description = description;
		}

		public ImporterDescriptionAttribute(string description, string resourceIdentifier) {
			this.Description = description;
			this.ResourceIdentifier = resourceIdentifier;
		}

		public string Description { get; }

	    public string ResourceIdentifier { get; }
	}
	#endregion

	public interface INotifyProgress {
		void SetProgressMessage(string message, int? percent);
	}

	public class ProgressMessageEventArgs : EventArgs {
	    public ProgressMessageEventArgs(string message, int? percentage) {
			this.Message = message;
			this.Percentage = percentage;
		}

		public string Message { get; }

	    public int? Percentage { get; }
	}

	public class ImportCompletedEventArgs<T> : AsyncCompletedEventArgs {
		readonly T importedObject;

		public ImportCompletedEventArgs(T importedObject, Exception e, bool cancelled, object state)
			: base(e, cancelled, state) {
			this.importedObject = importedObject;
		}

		public T ImportedObject {
			get {
				RaiseExceptionIfNecessary();
				return importedObject;
			}
		}
	}

	public interface IImporter<T> : IDisposable {
		void BeginImport();
		void Cancel();

		event EventHandler<ImportCompletedEventArgs<T>> Completed;
		event EventHandler<ProgressMessageEventArgs> ProgressChanged;
	}

	public interface IImporterUI<T> {
		void Apply();
		event EventHandler Finished;

		IImporter<T> Importer { get; }
	}
}
