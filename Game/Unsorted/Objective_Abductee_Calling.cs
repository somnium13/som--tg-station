// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Objective_Abductee_Calling : Objective_Abductee {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.explanation_text = "Call forth a spirit from the other side.";
		}

		// Function from file: abduction.dm
		public Objective_Abductee_Calling ( string text = null ) : base( text ) {
			dynamic D = null;

			D = Rand13.PickFromTable( GlobalVars.dead_mob_list );

			if ( Lang13.Bool( D ) ) {
				this.explanation_text = "You know that " + D + " has perished. Call them from the spirit realm.";
			}
			return;
		}

	}

}