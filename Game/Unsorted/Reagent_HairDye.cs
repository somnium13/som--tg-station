// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_HairDye : Reagent {

		public ByTable potential_colors = new ByTable(new object [] { "0ad", "a0f", "f73", "d14", "d14", "0b5", "0ad", "f73", "fc2", "084", "05e", "d22", "fa0" });

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Quantum Hair Dye";
			this.id = "hair_dye";
			this.description = "A solution.";
			this.color = "#C8A5DC";
		}

		// Function from file: other_reagents.dm
		public override double reaction_mob( dynamic M = null, int? method = null, double? reac_volume = null, bool? show_message = null, dynamic touch_protection = null, Mob_Camera_Blob O = null ) {
			method = method ?? GlobalVars.TOUCH;

			dynamic H = null;

			
			if ( method == GlobalVars.TOUCH || method == GlobalVars.VAPOR ) {
				
				if ( Lang13.Bool( M ) && M is Mob_Living_Carbon_Human ) {
					H = M;
					H.hair_color = Rand13.PickFromTable( this.potential_colors );
					H.facial_hair_color = Rand13.PickFromTable( this.potential_colors );
					((Mob)H).update_hair();
				}
			}
			return 0;
		}

	}

}