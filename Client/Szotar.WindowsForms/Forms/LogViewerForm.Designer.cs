﻿namespace Szotar.WindowsForms.Forms {
	partial class LogViewerForm {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogViewerForm));
			this.viewer = new Szotar.WindowsForms.Controls.LogViewer();
			this.SuspendLayout();
			// 
			// viewer
			// 
			resources.ApplyResources(this.viewer, "viewer");
			this.viewer.Name = "viewer";
			// 
			// LogViewerForm
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.viewer);
			this.Name = "LogViewerForm";
			this.ResumeLayout(false);

		}

		#endregion

		private Szotar.WindowsForms.Controls.LogViewer viewer;
	}
}