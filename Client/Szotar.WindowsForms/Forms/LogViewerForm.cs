using System.Windows.Forms;

namespace Szotar.WindowsForms.Forms {
	public partial class LogViewerForm : Form {
		public LogViewerForm() {
			InitializeComponent();

			ProgramLog.Default.MessageAdded += LogMessageAdded;
			FormClosed += delegate {
				ProgramLog.Default.MessageAdded -= LogMessageAdded;
			};
		}

		void LogMessageAdded(object sender, LogEventArgs e) {
			viewer.AddMessage(e.Message);
		}
	}
}
