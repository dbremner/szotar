using System;

namespace Szotar.WindowsForms {
	public class ImporterItem {
	    public ImporterItem(Type type, string name, string description) {
			this.Type = type;
			this.Name = name;
			this.Description = description;
		}

		public Type Type { get; }
	    public string Name { get; }
	    public string Description { get; }

	    public override string ToString() {
			return Name + " - " + Description;
		}
	}
}