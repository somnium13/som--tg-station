// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Toxin_Spore : Reagent_Toxin {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Spore Toxin";
			this.id = "spore";
			this.description = "A natural toxin produced by blob spores that inhibits vision when ingested.";
			this.color = "#9ACD32";
			this.toxpwr = 1;
		}

		// Function from file: toxin_reagents.dm
		public override bool on_mob_life( dynamic M = null ) {
			M.damageoverlaytemp = 60;
			((Mob_Living)M).update_damage_hud();
			((Mob)M).blur_eyes( 3 );
			base.on_mob_life( (object)(M) );
			return false;
		}

	}

}