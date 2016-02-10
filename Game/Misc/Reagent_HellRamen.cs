// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_HellRamen : Reagent {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Hell Ramen";
			this.id = "hell_ramen";
			this.description = "The noodles are boiled, the flavors are artificial, just like being back in school.";
			this.reagent_state = 2;
			this.nutriment_factor = 1;
			this.color = "#302000";
		}

		// Function from file: Chemistry-Reagents.dm
		public override bool on_mob_life( Mob_Living M = null, int? alien = null ) {
			
			if ( base.on_mob_life( M, alien ) ) {
				return true;
			}
			M.nutrition += this.nutriment_factor;
			M.bodytemperature += 15;
			return false;
		}

	}

}