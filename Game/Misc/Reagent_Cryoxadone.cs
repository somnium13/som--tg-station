// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Cryoxadone : Reagent {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Cryoxadone";
			this.id = "cryoxadone";
			this.description = "A chemical mixture with almost magical healing powers. Its main limitation is that the targets body temperature must be under 170K for it to metabolise correctly.";
			this.reagent_state = 2;
			this.color = "#C8A5DC";
		}

		// Function from file: Chemistry-Reagents.dm
		public override bool on_mob_life( Mob_Living M = null, int? alien = null ) {
			
			if ( base.on_mob_life( M, alien ) ) {
				return true;
			}

			if ( Convert.ToDouble( M.bodytemperature ) < 170 ) {
				M.adjustCloneLoss( -1 );
				M.adjustOxyLoss( -1 );
				M.heal_organ_damage( 1, 1 );
				M.adjustToxLoss( -1 );
			}
			return false;
		}

		// Function from file: hydroponics_reagents.dm
		public override void on_plant_life( Obj_Machinery_PortableAtmospherics_Hydroponics T = null ) {
			base.on_plant_life( T );
			T.toxins -= 3;

			if ( T.seed != null && !T.dead ) {
				T.health += 3;
			}
			return;
		}

	}

}