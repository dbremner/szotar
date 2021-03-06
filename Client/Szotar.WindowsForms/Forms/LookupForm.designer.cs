﻿namespace Szotar.WindowsForms.Forms {
	partial class LookupForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.ToolStripMenuItem addToList;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LookupForm));
			System.Windows.Forms.ToolStripMenuItem reverseLookup;
			System.Windows.Forms.ToolStripMenuItem showStartPage;
			System.Windows.Forms.ToolStripSeparator fileSep;
			System.Windows.Forms.ToolStripMenuItem searchMenu;
			System.Windows.Forms.ToolStripMenuItem switchModeMenuItem;
			System.Windows.Forms.ToolStripSeparator searchSep1;
			System.Windows.Forms.ToolStripMenuItem focusSearchFieldMenuItem;
			System.Windows.Forms.ToolStripMenuItem clearSearch;
			System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
			System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
			System.Windows.Forms.ToolStripMenuItem nextPerfectMatch;
			System.Windows.Forms.ToolStripMenuItem previousPerfectMatch;
			System.Windows.Forms.ToolStripMenuItem listMenu;
			System.Windows.Forms.ToolStripMenuItem newList;
			System.Windows.Forms.ToolStripMenuItem openList;
			System.Windows.Forms.ToolStripMenuItem importList;
			System.Windows.Forms.ToolStripSeparator listsSep;
			System.Windows.Forms.ToolStripMenuItem dummyItem1;
			System.Windows.Forms.ToolStripMenuItem dictionaryMenu;
			System.Windows.Forms.ToolStripMenuItem editInformation;
			System.Windows.Forms.ToolStripMenuItem addEntry;
			System.Windows.Forms.ToolStripMenuItem importDictionary;
			System.Windows.Forms.ToolStripMenuItem toolsMenu;
			System.Windows.Forms.ToolStripMenuItem dictsFolder;
			System.Windows.Forms.ToolStripMenuItem charMap;
			System.Windows.Forms.ToolStripMenuItem debugLog;
			System.Windows.Forms.ToolStripSeparator toolsSep;
			System.Windows.Forms.ToolStripMenuItem options;
			System.Windows.Forms.ToolStripSeparator contextMenuSeparator;
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.forwards = new System.Windows.Forms.ToolStripMenuItem();
			this.backwards = new System.Windows.Forms.ToolStripMenuItem();
			this.ignoreAccentsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ignoreCaseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.recentLists = new System.Windows.Forms.ToolStripMenuItem();
			this.copyMI = new System.Windows.Forms.ToolStripMenuItem();
			this.dictSep1 = new System.Windows.Forms.ToolStripSeparator();
			this.copyCM = new System.Windows.Forms.ToolStripMenuItem();
			this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.closeWindow = new System.Windows.Forms.ToolStripMenuItem();
			this.grid = new System.Windows.Forms.DataGridView();
			this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.addTo = new System.Windows.Forms.ToolStripMenuItem();
			this.newItemCM = new System.Windows.Forms.ToolStripMenuItem();
			this.editMI = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteMI = new System.Windows.Forms.ToolStripMenuItem();
			this.switchMode = new System.Windows.Forms.Button();
			this.ignoreLabel = new System.Windows.Forms.Label();
			this.searchPanel = new System.Windows.Forms.Panel();
			this.searchBox = new Szotar.WindowsForms.Controls.SearchBox();
			this.ignoreCaseCheck = new System.Windows.Forms.CheckBox();
			this.ignoreAccentsCheck = new System.Windows.Forms.CheckBox();
			this.toolStripPanel = new System.Windows.Forms.ToolStripPanel();
			this.mainMenu = new System.Windows.Forms.MenuStrip();
			addToList = new System.Windows.Forms.ToolStripMenuItem();
			reverseLookup = new System.Windows.Forms.ToolStripMenuItem();
			showStartPage = new System.Windows.Forms.ToolStripMenuItem();
			fileSep = new System.Windows.Forms.ToolStripSeparator();
			searchMenu = new System.Windows.Forms.ToolStripMenuItem();
			switchModeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			searchSep1 = new System.Windows.Forms.ToolStripSeparator();
			focusSearchFieldMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			clearSearch = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
			toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			nextPerfectMatch = new System.Windows.Forms.ToolStripMenuItem();
			previousPerfectMatch = new System.Windows.Forms.ToolStripMenuItem();
			listMenu = new System.Windows.Forms.ToolStripMenuItem();
			newList = new System.Windows.Forms.ToolStripMenuItem();
			openList = new System.Windows.Forms.ToolStripMenuItem();
			importList = new System.Windows.Forms.ToolStripMenuItem();
			listsSep = new System.Windows.Forms.ToolStripSeparator();
			dummyItem1 = new System.Windows.Forms.ToolStripMenuItem();
			dictionaryMenu = new System.Windows.Forms.ToolStripMenuItem();
			editInformation = new System.Windows.Forms.ToolStripMenuItem();
			addEntry = new System.Windows.Forms.ToolStripMenuItem();
			importDictionary = new System.Windows.Forms.ToolStripMenuItem();
			toolsMenu = new System.Windows.Forms.ToolStripMenuItem();
			dictsFolder = new System.Windows.Forms.ToolStripMenuItem();
			charMap = new System.Windows.Forms.ToolStripMenuItem();
			debugLog = new System.Windows.Forms.ToolStripMenuItem();
			toolsSep = new System.Windows.Forms.ToolStripSeparator();
			options = new System.Windows.Forms.ToolStripMenuItem();
			contextMenuSeparator = new System.Windows.Forms.ToolStripSeparator();
			((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
			this.contextMenu.SuspendLayout();
			this.searchPanel.SuspendLayout();
			this.toolStripPanel.SuspendLayout();
			this.mainMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// addToList
			// 
			addToList.Name = "addToList";
			resources.ApplyResources(addToList, "addToList");
			addToList.Click += new System.EventHandler(this.AddToListClick);
			// 
			// reverseLookup
			// 
			reverseLookup.Name = "reverseLookup";
			resources.ApplyResources(reverseLookup, "reverseLookup");
			reverseLookup.Click += new System.EventHandler(this.ReverseLookupToolStripMenuItemClick);
			// 
			// showStartPage
			// 
			showStartPage.Name = "showStartPage";
			resources.ApplyResources(showStartPage, "showStartPage");
			showStartPage.Click += new System.EventHandler(this.ShowStartPageClick);
			// 
			// fileSep
			// 
			fileSep.Name = "fileSep";
			resources.ApplyResources(fileSep, "fileSep");
			// 
			// searchMenu
			// 
			searchMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.forwards,
            this.backwards,
            switchModeMenuItem,
            searchSep1,
            focusSearchFieldMenuItem,
            clearSearch,
            toolStripMenuItem3,
            this.ignoreAccentsMenuItem,
            this.ignoreCaseMenuItem,
            toolStripSeparator1,
            nextPerfectMatch,
            previousPerfectMatch});
			searchMenu.Name = "searchMenu";
			resources.ApplyResources(searchMenu, "searchMenu");
			// 
			// forwards
			// 
			this.forwards.Name = "forwards";
			resources.ApplyResources(this.forwards, "forwards");
			this.forwards.Click += new System.EventHandler(this.ForwardsClick);
			// 
			// backwards
			// 
			this.backwards.Name = "backwards";
			resources.ApplyResources(this.backwards, "backwards");
			this.backwards.Click += new System.EventHandler(this.BackwardsClick);
			// 
			// switchModeMenuItem
			// 
			switchModeMenuItem.Name = "switchModeMenuItem";
			resources.ApplyResources(switchModeMenuItem, "switchModeMenuItem");
			switchModeMenuItem.Click += new System.EventHandler(this.SwitchModeMenuItemClick);
			// 
			// searchSep1
			// 
			searchSep1.Name = "searchSep1";
			resources.ApplyResources(searchSep1, "searchSep1");
			// 
			// focusSearchFieldMenuItem
			// 
			focusSearchFieldMenuItem.Name = "focusSearchFieldMenuItem";
			resources.ApplyResources(focusSearchFieldMenuItem, "focusSearchFieldMenuItem");
			focusSearchFieldMenuItem.Click += new System.EventHandler(this.FocusSearchFieldClick);
			// 
			// clearSearch
			// 
			clearSearch.Name = "clearSearch";
			resources.ApplyResources(clearSearch, "clearSearch");
			clearSearch.Click += new System.EventHandler(this.ClearSearchClick);
			// 
			// toolStripMenuItem3
			// 
			toolStripMenuItem3.Name = "toolStripMenuItem3";
			resources.ApplyResources(toolStripMenuItem3, "toolStripMenuItem3");
			// 
			// ignoreAccentsMenuItem
			// 
			this.ignoreAccentsMenuItem.CheckOnClick = true;
			this.ignoreAccentsMenuItem.Name = "ignoreAccentsMenuItem";
			resources.ApplyResources(this.ignoreAccentsMenuItem, "ignoreAccentsMenuItem");
			this.ignoreAccentsMenuItem.Click += new System.EventHandler(this.IgnoreAccentsMenuItemClick);
			// 
			// ignoreCaseMenuItem
			// 
			this.ignoreCaseMenuItem.Checked = true;
			this.ignoreCaseMenuItem.CheckOnClick = true;
			this.ignoreCaseMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ignoreCaseMenuItem.Name = "ignoreCaseMenuItem";
			resources.ApplyResources(this.ignoreCaseMenuItem, "ignoreCaseMenuItem");
			this.ignoreCaseMenuItem.Click += new System.EventHandler(this.IgnoreCaseMenuItemClick);
			// 
			// toolStripSeparator1
			// 
			toolStripSeparator1.Name = "toolStripSeparator1";
			resources.ApplyResources(toolStripSeparator1, "toolStripSeparator1");
			// 
			// nextPerfectMatch
			// 
			nextPerfectMatch.Name = "nextPerfectMatch";
			resources.ApplyResources(nextPerfectMatch, "nextPerfectMatch");
			nextPerfectMatch.Click += new System.EventHandler(this.NextPerfectMatchClick);
			// 
			// previousPerfectMatch
			// 
			previousPerfectMatch.Name = "previousPerfectMatch";
			resources.ApplyResources(previousPerfectMatch, "previousPerfectMatch");
			previousPerfectMatch.Click += new System.EventHandler(this.PreviousPerfectMatchClick);
			// 
			// listMenu
			// 
			listMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            newList,
            openList,
            importList,
            listsSep,
            this.recentLists});
			listMenu.Name = "listMenu";
			resources.ApplyResources(listMenu, "listMenu");
			// 
			// newList
			// 
			newList.Image = global::Szotar.WindowsForms.Properties.Resources.GenericDocument16;
			newList.Name = "newList";
			resources.ApplyResources(newList, "newList");
			newList.Click += new System.EventHandler(this.NewListClick);
			// 
			// openList
			// 
			openList.Name = "openList";
			resources.ApplyResources(openList, "openList");
			openList.Click += new System.EventHandler(this.OpenListClick);
			// 
			// importList
			// 
			importList.Name = "importList";
			resources.ApplyResources(importList, "importList");
			importList.Click += new System.EventHandler(this.ImportListClick);
			// 
			// listsSep
			// 
			listsSep.Name = "listsSep";
			resources.ApplyResources(listsSep, "listsSep");
			// 
			// recentLists
			// 
			this.recentLists.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            dummyItem1});
			this.recentLists.Name = "recentLists";
			resources.ApplyResources(this.recentLists, "recentLists");
			this.recentLists.DropDownOpening += new System.EventHandler(this.RecentListsDropDownOpening);
			// 
			// dummyItem1
			// 
			dummyItem1.Name = "dummyItem1";
			resources.ApplyResources(dummyItem1, "dummyItem1");
			// 
			// dictionaryMenu
			// 
			dictionaryMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyMI,
            this.dictSep1,
            editInformation,
            addEntry,
            importDictionary});
			dictionaryMenu.Name = "dictionaryMenu";
			resources.ApplyResources(dictionaryMenu, "dictionaryMenu");
			dictionaryMenu.DropDownOpening += new System.EventHandler(this.DictionaryMenuDropDownOpening);
			// 
			// copyMI
			// 
			this.copyMI.Name = "copyMI";
			resources.ApplyResources(this.copyMI, "copyMI");
			this.copyMI.Click += new System.EventHandler(this.CopyMIClick);
			// 
			// dictSep1
			// 
			this.dictSep1.Name = "dictSep1";
			resources.ApplyResources(this.dictSep1, "dictSep1");
			// 
			// editInformation
			// 
			editInformation.Name = "editInformation";
			resources.ApplyResources(editInformation, "editInformation");
			editInformation.Click += new System.EventHandler(this.EditInformationClick);
			// 
			// addEntry
			// 
			addEntry.Name = "addEntry";
			resources.ApplyResources(addEntry, "addEntry");
			addEntry.Click += new System.EventHandler(this.AddEntryClick);
			// 
			// importDictionary
			// 
			importDictionary.Name = "importDictionary";
			resources.ApplyResources(importDictionary, "importDictionary");
			importDictionary.Click += new System.EventHandler(this.ImportDictionaryClick);
			// 
			// toolsMenu
			// 
			toolsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            dictsFolder,
            charMap,
            debugLog,
            toolsSep,
            options});
			toolsMenu.Name = "toolsMenu";
			resources.ApplyResources(toolsMenu, "toolsMenu");
			// 
			// dictsFolder
			// 
			dictsFolder.Name = "dictsFolder";
			resources.ApplyResources(dictsFolder, "dictsFolder");
			dictsFolder.Click += new System.EventHandler(this.DictsFolderClick);
			// 
			// charMap
			// 
			charMap.Name = "charMap";
			resources.ApplyResources(charMap, "charMap");
			charMap.Click += new System.EventHandler(this.CharMapClick);
			// 
			// debugLog
			// 
			debugLog.Name = "debugLog";
			resources.ApplyResources(debugLog, "debugLog");
			debugLog.Click += new System.EventHandler(this.DebugLogClick);
			// 
			// toolsSep
			// 
			toolsSep.Name = "toolsSep";
			resources.ApplyResources(toolsSep, "toolsSep");
			// 
			// options
			// 
			options.Name = "options";
			resources.ApplyResources(options, "options");
			options.Click += new System.EventHandler(this.OptionsClick);
			// 
			// contextMenuSeparator
			// 
			contextMenuSeparator.Name = "contextMenuSeparator";
			resources.ApplyResources(contextMenuSeparator, "contextMenuSeparator");
			// 
			// copyCM
			// 
			this.copyCM.Name = "copyCM";
			resources.ApplyResources(this.copyCM, "copyCM");
			this.copyCM.Click += new System.EventHandler(this.CopyCMClick);
			// 
			// exitMenuItem
			// 
			this.exitMenuItem.Name = "exitMenuItem";
			resources.ApplyResources(this.exitMenuItem, "exitMenuItem");
			this.exitMenuItem.Click += new System.EventHandler(this.ExitMenuItemClick);
			// 
			// fileMenu
			// 
			this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            showStartPage,
            this.closeWindow,
            fileSep,
            this.exitMenuItem});
			this.fileMenu.Name = "fileMenu";
			resources.ApplyResources(this.fileMenu, "fileMenu");
			// 
			// closeWindow
			// 
			this.closeWindow.Name = "closeWindow";
			resources.ApplyResources(this.closeWindow, "closeWindow");
			this.closeWindow.Click += new System.EventHandler(this.CloseWindowClick);
			// 
			// grid
			// 
			this.grid.AllowUserToAddRows = false;
			this.grid.AllowUserToDeleteRows = false;
			this.grid.AllowUserToResizeRows = false;
			resources.ApplyResources(this.grid, "grid");
			this.grid.BackgroundColor = System.Drawing.SystemColors.Control;
			this.grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
			this.grid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			this.grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(2);
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grid.ContextMenuStrip = this.contextMenu;
			this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.grid.EnableHeadersVisualStyles = false;
			this.grid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.grid.Name = "grid";
			this.grid.ReadOnly = true;
			this.grid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			this.grid.RowHeadersVisible = false;
			this.grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.grid.RowTemplate.Height = 24;
			this.grid.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.grid.VirtualMode = true;
			this.grid.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridCellMouseDoubleClick);
			// 
			// contextMenu
			// 
			this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            addToList,
            this.addTo,
            this.copyCM,
            reverseLookup,
            contextMenuSeparator,
            this.newItemCM,
            this.editMI,
            this.deleteMI});
			this.contextMenu.Name = "listBuilderMenu";
			resources.ApplyResources(this.contextMenu, "contextMenu");
			this.contextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuOpening);
			// 
			// addTo
			// 
			this.addTo.Name = "addTo";
			resources.ApplyResources(this.addTo, "addTo");
			// 
			// newItemCM
			// 
			this.newItemCM.Name = "newItemCM";
			resources.ApplyResources(this.newItemCM, "newItemCM");
			this.newItemCM.Click += new System.EventHandler(this.AddEntryClick);
			// 
			// editMI
			// 
			this.editMI.Name = "editMI";
			resources.ApplyResources(this.editMI, "editMI");
			this.editMI.Click += new System.EventHandler(this.EditMIClick);
			// 
			// deleteMI
			// 
			this.deleteMI.Name = "deleteMI";
			resources.ApplyResources(this.deleteMI, "deleteMI");
			this.deleteMI.Click += new System.EventHandler(this.DeleteMIClick);
			// 
			// switchMode
			// 
			resources.ApplyResources(this.switchMode, "switchMode");
			this.switchMode.Name = "switchMode";
			this.switchMode.UseVisualStyleBackColor = true;
			this.switchMode.Click += new System.EventHandler(this.SwitchModeClick);
			// 
			// ignoreLabel
			// 
			resources.ApplyResources(this.ignoreLabel, "ignoreLabel");
			this.ignoreLabel.Name = "ignoreLabel";
			// 
			// searchPanel
			// 
			resources.ApplyResources(this.searchPanel, "searchPanel");
			this.searchPanel.BackColor = System.Drawing.Color.Transparent;
			this.searchPanel.Controls.Add(this.searchBox);
			this.searchPanel.Controls.Add(this.switchMode);
			this.searchPanel.Controls.Add(this.ignoreLabel);
			this.searchPanel.Controls.Add(this.ignoreCaseCheck);
			this.searchPanel.Controls.Add(this.ignoreAccentsCheck);
			this.searchPanel.Name = "searchPanel";
			// 
			// searchBox
			// 
			resources.ApplyResources(this.searchBox, "searchBox");
			this.searchBox.ForeColor = System.Drawing.SystemColors.GrayText;
			this.searchBox.Name = "searchBox";
			// 
			// ignoreCaseCheck
			// 
			resources.ApplyResources(this.ignoreCaseCheck, "ignoreCaseCheck");
			this.ignoreCaseCheck.Checked = true;
			this.ignoreCaseCheck.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ignoreCaseCheck.Name = "ignoreCaseCheck";
			this.ignoreCaseCheck.UseVisualStyleBackColor = true;
			// 
			// ignoreAccentsCheck
			// 
			resources.ApplyResources(this.ignoreAccentsCheck, "ignoreAccentsCheck");
			this.ignoreAccentsCheck.Name = "ignoreAccentsCheck";
			this.ignoreAccentsCheck.UseVisualStyleBackColor = true;
			// 
			// toolStripPanel
			// 
			this.toolStripPanel.Controls.Add(this.mainMenu);
			resources.ApplyResources(this.toolStripPanel, "toolStripPanel");
			this.toolStripPanel.Name = "toolStripPanel";
			this.toolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
			this.toolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
			// 
			// mainMenu
			// 
			resources.ApplyResources(this.mainMenu, "mainMenu");
			this.mainMenu.GripMargin = new System.Windows.Forms.Padding(2);
			this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            searchMenu,
            listMenu,
            dictionaryMenu,
            toolsMenu});
			this.mainMenu.Name = "mainMenu";
			// 
			// LookupForm
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.toolStripPanel);
			this.Controls.Add(this.searchPanel);
			this.Controls.Add(this.grid);
			this.DoubleBuffered = true;
			this.KeyPreview = true;
			this.Name = "LookupForm";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LookupFormKeyDown);
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			this.contextMenu.ResumeLayout(false);
			this.searchPanel.ResumeLayout(false);
			this.searchPanel.PerformLayout();
			this.toolStripPanel.ResumeLayout(false);
			this.toolStripPanel.PerformLayout();
			this.mainMenu.ResumeLayout(false);
			this.mainMenu.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView grid;
		private System.Windows.Forms.Button switchMode;
		private System.Windows.Forms.ContextMenuStrip contextMenu;
		private System.Windows.Forms.CheckBox ignoreCaseCheck;
		private System.Windows.Forms.CheckBox ignoreAccentsCheck;
		private System.Windows.Forms.Label ignoreLabel;
		private Szotar.WindowsForms.Controls.SearchBox searchBox;
		private System.Windows.Forms.Panel searchPanel;
		private System.Windows.Forms.ToolStripPanel toolStripPanel;
		private System.Windows.Forms.MenuStrip mainMenu;
		private System.Windows.Forms.ToolStripMenuItem forwards;
		private System.Windows.Forms.ToolStripMenuItem backwards;
		private System.Windows.Forms.ToolStripMenuItem ignoreAccentsMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ignoreCaseMenuItem;
		private System.Windows.Forms.ToolStripMenuItem recentLists;
		private System.Windows.Forms.ToolStripMenuItem fileMenu;
		private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addTo;
		private System.Windows.Forms.ToolStripMenuItem closeWindow;
		private System.Windows.Forms.ToolStripMenuItem copyMI;
		private System.Windows.Forms.ToolStripSeparator dictSep1;
		private System.Windows.Forms.ToolStripMenuItem copyCM;
		private System.Windows.Forms.ToolStripMenuItem editMI;
		private System.Windows.Forms.ToolStripMenuItem deleteMI;
		private System.Windows.Forms.ToolStripMenuItem newItemCM;
	}
}

