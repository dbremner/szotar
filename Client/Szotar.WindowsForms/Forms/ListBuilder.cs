using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Szotar.WindowsForms.Forms {
	public partial class ListBuilder : Form {
	    readonly bool isNewList;

		Control queuedUpdateControl;
		Action queuedUpdateAction;
	    readonly Timer queuedUpdateTimer;

		public WordList WordList { get; }

	    public ListBuilder() :
			this(
				DataStore.Database.CreateSet(
					Properties.Resources.DefaultListName,
					GuiConfiguration.UserNickname,
					null, null, DateTime.Now)) 
		{
			isNewList = true;
			MakeRecent();
		}

		// Constructor is protected in order to make sure no other word lists are open for this list.
		protected ListBuilder(WordList wordList) {
			InitializeComponent();

			WordList = wordList;
			grid.DataSource = wordList;

			UpdateTitle();
			name.Text = WordList.Name;
			author.Text = WordList.Author;
			url.Text = WordList.Url;
			UpdateEntryCount();

			grid.ColumnRatio = GuiConfiguration.ListBuilderColumnRatio;
			meta.Height = GuiConfiguration.ListBuilderMetadataSectionHeight;

			Layout += ListBuilderLayout;
			Closing += ListBuilderClosing;
			editMetadata.Click += EditMetadataClick;
			copyAsCsv.Click += CopyAsCsvClick;
			sort.Click += SortItems;
			swapAll.Click += SwapAll;
			shadow.MouseDown += ShadowMouseDown;
			shadow.MouseMove += ShadowMouseMove;
			name.TextChanged += NameTextChanged;
			author.TextChanged += AuthorTextChanged;
			url.TextChanged += UrlTextChanged;
			showStartPage.Click += showStartPage_Click;
			close.Click += CloseClick;
			deleteList.Click += DeleteListClick;
			grid.ColumnRatioChanged += GridColumnRatioChanged;

			undo.Click += delegate { WordList.Undo(); };
			redo.Click += delegate { WordList.Redo(); };
			editMenu.DropDownOpening += EditMenuDropDownOpening;
			itemContextMenu.Opening += ItemContextMenuOpening;
			mainMenu.Items.Add(new TagMenu { WordList = WordList });

			grid.ColumnHeaderMouseClick += ColumnHeaderClicked;

			cutMI.Click += delegate { grid.Cut(); };
			copyMI.Click += delegate { grid.Copy(); };
			pasteMI.Click += delegate { grid.Paste(); };
			cutCM.Click += delegate { grid.Cut(); };
			copyCM.Click += delegate { grid.Copy(); };
			pasteCM.Click += delegate { grid.Paste(); };

			swap.Click += SwapItems;

			deleteMI.Click += RemoveItems;
			deleteCM.Click += RemoveItems;

			WireListEvents();
			MakeRecent();

			queuedUpdateTimer = new Timer { Interval = 150, Enabled = false };
			components.Add(queuedUpdateTimer);
			queuedUpdateTimer.Tick += QueuedUpdateTimerTick; 
		}

		/// <summary>Opens a ListBuilder for the given Word List, or focusses an existing ListBuilder 
		/// if one exists.</summary>
		public static ListBuilder Open(long setID) {
			foreach (Form f in Application.OpenForms) {
				var lb = f as ListBuilder;
			    if (lb == null || lb.WordList.ID != setID)
			        continue;

			    lb.BringToFront();
			    return lb;
			}

			var list = DataStore.Database.GetWordList(setID);
			if (list == null)
				return null;

			var form = new ListBuilder(list);
			form.Show();
			return form;
		}

		private void WireListEvents() {
			WordList.PropertyChanged += ListPropertyChanged;
			WordList.ListDeleted += ListDeleted;
			WordList.ListChanged += ListChanged;
		}

		private void UnwireListEvents() {
			WordList.PropertyChanged -= ListPropertyChanged;
			WordList.ListDeleted -= ListDeleted;
			WordList.ListChanged -= ListChanged;
		}

		void GridColumnRatioChanged(object sender, EventArgs e) {
			GuiConfiguration.ListBuilderColumnRatio = grid.ColumnRatio;
		}

		void ListDeleted(object sender, EventArgs e) {
			// Suppress the "would you like to keep this list?" message.
			Closing -= ListBuilderClosing;
			UnwireListEvents();

			Close();
		}

		void MakeRecent() {
			WordList.Accessed = DateTime.Now;
			DataStore.Database.RaiseWordListOpened(WordList.ID);
		}

		void RemoveItems(object sender, EventArgs e) {
			WordList.RemoveAt(new List<int>(grid.SelectedEntryIndices));
		}

		void SwapItems(object sender, EventArgs e) {
			WordList.SwapRows(new List<int>(grid.SelectedEntryIndices));
		}

		void SwapAll(object sender, EventArgs e) {
			var rows = new List<int>();
			for (int i = 0; i < WordList.Count; ++i)
				rows.Add(i);

			WordList.SwapRows(rows);
		}

		void SortItems(object sender, EventArgs e) {
			WordList.Sort((a, b) => string.Compare(a.Phrase, b.Phrase, StringComparison.CurrentCultureIgnoreCase));
		}

		int? sortColumn;
		bool sortAscending;
		void ColumnHeaderClicked(object sender, DataGridViewCellMouseEventArgs e) {
			int direction = 1;

			if (sortColumn == e.ColumnIndex) {
				sortAscending = !sortAscending;
				direction = sortAscending ? 1 : -1;
			} else {
				sortAscending = true;
			}

			switch (e.ColumnIndex) {
			    case 0:
			        WordList.Sort((a, b) => direction * string.Compare(a.Phrase, b.Phrase, StringComparison.CurrentCultureIgnoreCase));
			        sortColumn = 0;
			        break;
			    case 1:
			        WordList.Sort((a, b) => direction * string.Compare(a.Translation, b.Translation, StringComparison.CurrentCultureIgnoreCase));
			        sortColumn = 1;
			        break;
			}
		}

		void ListChanged(object sender, ListChangedEventArgs e) {
			sortColumn = null;

			if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.Reset)
				UpdateEntryCount();
		}

		private void UpdateTitle() {
			Text = string.Format("{0} - {1}", WordList.Name, Application.ProductName);
		}

		bool CanCut() {
			return CanCopy();
		}

		bool CanCopy() {
			return grid.SelectedEntryCount > 0;
		}

		bool CanPaste() {
			return grid.CanPaste;
		}

		void EditMenuDropDownOpening(object sender, EventArgs e) {
			string undoDesc = WordList.UndoDescription;
			string redoDesc = WordList.RedoDescription;

			if (undoDesc == null) {
				undo.Enabled = false;
				undo.Text = Properties.Resources.Undo;
			} else {
				undo.Enabled = true;
				undo.Text = string.Format(Properties.Resources.UndoSpecific, undoDesc);
			}

			if (redoDesc == null) {
				redo.Enabled = false;
				redo.Text = Properties.Resources.Redo;
			} else {
				redo.Enabled = true;
				redo.Text = string.Format(Properties.Resources.RedoSpecific, redoDesc);
			}

			cutMI.Enabled = CanCut();
			copyMI.Enabled = CanCopy();
			pasteMI.Enabled = CanPaste();
		}

		void ItemContextMenuOpening(object sender, CancelEventArgs e) {
			cutCM.Enabled = CanCut();
			copyCM.Enabled = CanCopy();
			pasteCM.Enabled = CanPaste();
		}

		#region Metadata Bindings
		void QueuedUpdateTimerTick(object sender, EventArgs e) {
			queuedUpdateTimer.Stop();

			if (queuedUpdateControl != null && queuedUpdateAction != null) {
				queuedUpdateControl = null;
				queuedUpdateAction();
			}
		}

		void QueueControlUpdate(Control control, Action action) {
			if (queuedUpdateControl == control) {
				queuedUpdateTimer.Stop();
				queuedUpdateTimer.Start();
				return;
			}

			// If there's already a queued update on a different control, execute it.
			if (queuedUpdateControl != null) {
				queuedUpdateTimer.Stop();
				queuedUpdateAction();
			}

			queuedUpdateAction = action;
			queuedUpdateControl = control;
			queuedUpdateTimer.Start();
		}

		// TODO: The database will be updated every time a character is typed... not good.
		// It would be better if the database update were delayed until no keys have been
		// pressed for, say, 200 milliseconds.
		void UrlTextChanged(object sender, EventArgs e) {
			WordList.Url = url.Text;
		}

		void AuthorTextChanged(object sender, EventArgs e) {
			WordList.Author = author.Text;
		}

		void NameTextChanged(object sender, EventArgs e) {
			WordList.Name = name.Text;
			MakeRecent();
		}

		void UpdateEntryCount() {
			entriesLabel.Text = string.Format(Properties.Resources.NEntries, WordList.Count);
		}

		void ListPropertyChanged(object sender, PropertyChangedEventArgs e) {
			switch (e.PropertyName) {
				case "Name":
					if (!name.Text.Equals(WordList.Name))
						name.Text = WordList.Name;
					UpdateTitle();
					break;
				case "Author":
					if (!author.Text.Equals(WordList.Author))
						author.Text = WordList.Author;
					break;
				case "Url":
					if (!url.Text.Equals(WordList.Url))
						url.Text = WordList.Url;
					break;
			}
		}
		#endregion

		#region Drop Shadow
		public class ShadowTag {
			public System.Drawing.Point Down { get; set; }
			public int OriginalHeight { get; set; }
		}

		private void ShadowMouseMove(object sender, MouseEventArgs e) {
			var tag = shadow.Tag as ShadowTag;
			if (e.Button == MouseButtons.Left && tag != null) {
				System.Drawing.Point down = tag.Down;
				meta.Height += down.Y - e.Y;
				UpdateGridHeight();
				GuiConfiguration.ListBuilderMetadataSectionHeight = meta.Height;
			}
		}

		private void ShadowMouseDown(object sender, MouseEventArgs e) {
			shadow.Tag = new ShadowTag { Down = e.Location, OriginalHeight = shadow.Height };
		}
		#endregion

		private void ListBuilderClosing(object sender, CancelEventArgs e) {
			UnwireListEvents();

		    if (!isNewList || WordList.Count != 0)
		        return;
		    
            var dr = MessageBox.Show(
		        Properties.Resources.ConfirmKeepNewWordList,
		        Properties.Resources.ConfirmKeepNewWordListCaption,
		        MessageBoxButtons.YesNoCancel,
		        MessageBoxIcon.Question,
		        MessageBoxDefaultButton.Button1);

		    if (dr == DialogResult.Cancel) {
		        e.Cancel = true;
		    } else if (dr == DialogResult.No) {
		        WordList.DeleteWordList();
		    }
		}

		private void EditMetadataClick(object sender, EventArgs e) {
			editMetadata.Checked = !editMetadata.Checked;
			if (editMetadata.Checked)
				ShowMeta();
			else
				HideMeta();
		}

		private void CopyAsCsvClick(object sender, EventArgs e) {
			var sb = new StringBuilder();

			foreach (WordListEntry pair in WordList) {
				var phrase = pair.Phrase;
				var translation = pair.Translation;

				bool quotePhrase = phrase.Contains("\"") || phrase.Contains(",") || phrase.Contains("\n"),
					quoteTranslation = translation.Contains("\"") || translation.Contains(",") || translation.Contains("\n");
				if (quotePhrase)
					sb.Append('"');
				sb.Append(phrase.Replace("\"", "\"\""));
				if (quotePhrase)
					sb.Append('"');

				sb.Append(',');

				if (quoteTranslation)
					sb.Append('"');
				sb.Append(translation.Replace("\"", "\"\""));
				if (quoteTranslation)
					sb.Append('"');

				sb.AppendLine();
			}

			if (sb.Length > 0)
				Clipboard.SetText(sb.ToString());
		}

		private void ListBuilderLayout(object sender, LayoutEventArgs e) {
			grid.Top = mainMenu.Bottom;
			UpdateGridHeight();
			grid.Width = ClientSize.Width;
		}

		private void UpdateGridHeight() {
			grid.Height = ClientSize.Height - grid.Top - (meta.Visible ? meta.Height : 0);
		}

		private void ShowMeta() {
			meta.Visible = true;
			grid.Height -= meta.Height;
		}

		private void HideMeta() {
			meta.Visible = false;
			grid.Height += meta.Height;
		}

		public void AddPair(string phrase, string translation) {
			System.Diagnostics.Debug.Assert(!InvokeRequired);

			WordList.Add(new WordListEntry(WordList, phrase, translation));
			grid.DataSource = WordList;
		}

		public void AddEntries(IEnumerable<TranslationPair> entries) {
			System.Diagnostics.Debug.Assert(!InvokeRequired);

			var realEntries = new List<WordListEntry>();
			foreach (var entry in entries)
				realEntries.Add(new WordListEntry(WordList, entry.Phrase, entry.Translation));

			WordList.Insert(WordList.Count, realEntries);

			grid.DataSource = WordList;
		}

		public bool ShowMetadata {
			get {
				return meta.Visible;
			}
			set {
			    // Don't do anything it if it hasn't changed since Show/HideMeta will break in such cases.
			    if (value == ShowMetadata)
			        return;
			    
                if (value)
			        ShowMeta();
			    else
			        HideMeta();
			}
		}

		public void ScrollToResult(ListSearchResult result) {
			if (result.PositionHint.HasValue) {
				var hint = result.PositionHint.Value;
				if (hint >= 0 && hint < WordList.Count && WordList[hint].Phrase == result.Phrase && WordList[hint].Translation == result.Translation) {
					ScrollToPosition(hint);
					return;
				}
			}

			for (int i = 0; i < WordList.Count; i++) {
				var item = WordList[i];
				if (item.Phrase == result.Phrase && item.Translation == result.Translation) {
					ScrollToPosition(i);
					return;
				}
			}

			// Couldn't find the item... just scroll to where it was last
			if(result.PositionHint.HasValue)
				ScrollToPosition(result.PositionHint.Value);
		}

		public void ScrollToPosition(int position) {
			grid.ScrollToIndex(position);
			grid.SelectRow(position);
		}

		public bool ScrollToItem(string phrase, string translation) {
			for (int i = 0; i < WordList.Count; i++) {
				if (WordList[i].Phrase == phrase && WordList[i].Translation == translation) {
					ScrollToPosition(i);
					return true;
				}
			}
			return false;
		}

		void showStartPage_Click(object sender, EventArgs e) {
			ShowForm.Show<StartPage>();
		}

		private void DeleteListClick(object sender, EventArgs e) {
			var dr = MessageBox.Show(
				Properties.Resources.ConfirmDeleteWordList,
				Properties.Resources.ConfirmDeleteWordListCaption,
				MessageBoxButtons.OKCancel,
				MessageBoxIcon.Question,
				MessageBoxDefaultButton.Button1);

			if (dr == DialogResult.OK) {
				WordList.DeleteWordList();

				// The form will close automatically, because deleting the list will 
				// fire the list's ListDeleted event, which this form subscribes to.
			}
		}

		private void CloseClick(object sender, EventArgs e) {
			Close();
		}

		// For now, simply insert the new items at the end of the list.
		// There might be a better way to do this.
		void Paste(IEnumerable<List<string>> lines, int? row) {
			var entries = (from line in lines
			               where line.Count >= 2
			               select new WordListEntry(WordList, line[0], line[1])).ToList();

		    if (entries.Count > 0) {
				WordList.Insert(row ?? WordList.Count, entries);
				grid.Refresh(); // XXX Is this necessary?
			}
		}

		// Detect comma-separated/tab-separated based on the paste content.
		private void PasteCsvClick(object sender, EventArgs e) {
			int validCSV, validTSV;
			List<List<string>> csv, tsv;

			// TODO: Look at getting CSV directly from the clipboard.
			// It's more work than it sounds: there doesn't seem to be a consensus on what the exact
			// format of that data is.
			// Excel in particular writes it in UTF-8 (or the windows code page, according to some)
			// with a null terminator.

			// It's plain text: use guesswork to figure out if it's TSV or CSV.
			// Tab-separated is rarer, so if it works with tabs, it's probably that.
			string text = Clipboard.GetText();
			csv = CsvUtilities.ParseCSV(',', text, out validCSV);
			tsv = CsvUtilities.ParseCSV('\t', text, out validTSV);

		    Paste(validTSV >= validCSV ? tsv : csv, null);
		}

		private void Practice(PracticeMode mode) {
			if (!WordList.ID.HasValue) {
				ProgramLog.Default.AddMessage(LogType.Error, "WordList {0} has no ID", WordList.Name);
				return;
			}

			PracticeWindow.OpenNewSession(mode, new[] { new ListSearchResult(WordList.ID.Value) });
		}

		private void FlashcardsClick(object sender, EventArgs e) {
			Practice(PracticeMode.Flashcards);
		}

		private void LearnClick(object sender, EventArgs e) {
			Practice(PracticeMode.Learn);
		}
	}
}
