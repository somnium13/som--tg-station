// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Singularity_Narsie_Wizard_ScNarsie : Obj_Machinery_Singularity_Narsie_Wizard {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.move_self = false;
		}

		public Obj_Machinery_Singularity_Narsie_Wizard_ScNarsie ( dynamic loc = null, int? starting_energy = null, bool? temp = null ) : base( (object)(loc), starting_energy, temp ) {
			
		}

		// Function from file: stationCollision.dm
		public override dynamic process(  ) {
			this.eat();

			if ( Rand13.PercentChance( 25 ) ) {
				this.mezzer();
			}
			return null;
		}

		// Function from file: stationCollision.dm
		public override void admin_investigate_setup(  ) {
			return;
		}

	}

}