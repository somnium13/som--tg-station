// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Subsystem_Diseases : Subsystem {

		public ByTable processing = new ByTable();

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Diseases";
			this.priority = 7;
		}

		// Function from file: diseases.dm
		public Subsystem_Diseases (  ) {
			
			if ( GlobalVars.SSdisease != this ) {
				
				if ( GlobalVars.SSdisease is Subsystem_Diseases ) {
					this.Recover();
					GlobalFuncs.qdel( GlobalVars.SSdisease );
				}
				GlobalVars.SSdisease = this;
			}
			return;
		}

		// Function from file: diseases.dm
		public override void fire(  ) {
			dynamic thing = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.processing )) {
				thing = _a;
				

				if ( Lang13.Bool( thing ) ) {
					((Game_Data)thing).process();
					continue;
				}
				this.processing.Remove( thing );
			}
			return;
		}

		// Function from file: diseases.dm
		public override void stat_entry( string msg = null ) {
			base.stat_entry( "P:" + this.processing.len );
			return;
		}

	}

}