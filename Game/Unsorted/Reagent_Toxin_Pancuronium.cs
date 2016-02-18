// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Toxin_Pancuronium : Reagent_Toxin {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Pancuronium";
			this.id = "pancuronium";
			this.description = "An undetectable toxin that swiftly incapacitates its victim. May also cause breathing failure.";
			this.metabolization_rate = 0.1;
			this.toxpwr = 0;
		}

		// Function from file: toxin_reagents.dm
		public override bool on_mob_life( dynamic M = null ) {
			
			if ( this.current_cycle >= 10 ) {
				((Mob)M).Paralyse( 1 );
			}

			if ( Rand13.PercentChance( 20 ) ) {
				M.losebreath += 4;
			}
			base.on_mob_life( (object)(M) );
			return false;
		}

	}

}