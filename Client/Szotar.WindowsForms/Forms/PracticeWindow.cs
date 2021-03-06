﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Szotar.WindowsForms.Forms {
	// TODO: Set window title based on what is being practiced, and what mode is being used.
	//       However, this may need word list combos and named combos.
	public partial class PracticeWindow : Form, IPracticeWindow {
		PracticeQueue queue;
		IPracticeMode mode;

		public PracticeWindow(IList<ListSearchResult> items, PracticeMode whichMode)
			: this(DataStore.Database.GetItems(items), whichMode) { }

		public PracticeWindow(List<PracticeItem> terms, PracticeMode whichMode) {
			InitializeComponent();

			mainMenu.Renderer = new ToolStripAeroRenderer(ToolbarTheme.MediaToolbar);

			if (terms.Count > 0) {
				queue = new PracticeQueue(terms);

				// TODO: Decided the default based on a setting.
				switch (whichMode) {
					case PracticeMode.Flashcards:
						SetMode(new FlashcardMode());
						break;

					case PracticeMode.Default:
					case PracticeMode.Learn:
					default:
						SetMode(new LearnMode());
						break;
				}
			}

			this.FormClosed += delegate {
				if (mode != null)
					mode.Stop();
			};

			components = components ?? new Container();
			if(mode != null)
				components.Add(new DisposableComponent(mode));
		}

		public void SetMode(IPracticeMode mode) {
			if (this.mode == mode)
				return;

			if (this.mode != null)
				this.mode.Stop();

			this.mode = mode;
			mode.Start(this);
		}

		public PracticeWindow()
			: this(new ListSearchResult[] { }, PracticeMode.SearchMode) { }

		public static void OpenNewSession(PracticeMode mode, IList<ListSearchResult> items) {
			new PracticeWindow(items, mode).Show();
		}

		public void MarkSuccess(PracticeItem item) {
		}

		public void MarkFailure(PracticeItem item) {
		}

		public PracticeItem FetchNextItem() {
			return queue.TakeOne();
		}

		public IList<PracticeItem> GetAllItems() {
			return queue.AllItems;
		}

		public void ReplaceItem(PracticeItem existing, PracticeItem replacement) {
			var items = queue.AllItems;
			for (int i = 0; i < items.Count; i++)
				if (items[i] == existing)
					items[i] = replacement;
		}

		ToolStrip IPracticeWindow.Controls {
			get { return mainMenu; }
		}

		Panel IPracticeWindow.GameArea {
			get { return panel; }
		}

		int IPracticeWindow.ItemCount {
			get { return queue.Length; }
		}

		int IPracticeWindow.Position {
			get { return queue.Index; }
		}

		private void exit_Click(object sender, EventArgs e) {
			Close();
		}

		private void showStartPage_Click(object sender, EventArgs e) {
			ShowForm.Show<StartPage>();
		}

		private void flashcardsMI_Click(object sender, EventArgs e) {
			SetMode(new FlashcardMode());
		}

		private void learnMI_Click(object sender, EventArgs e) {
			SetMode(new LearnMode());
		}

		private void practiceWeakPoints_Click(object sender, EventArgs e) {
			mode.Stop();
			queue = new PracticeQueue(DataStore.Database.GetSuggestedPracticeItems(GuiConfiguration.PracticeDefaultCount));
			SetMode(new LearnMode());
		}
	}
}
