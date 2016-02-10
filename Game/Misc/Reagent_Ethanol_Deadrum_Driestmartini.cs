// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Ethanol_Deadrum_Driestmartini : Reagent_Ethanol_Deadrum {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Driest Martini";
			this.id = "driestmartini";
			this.description = "Only for the experienced. You think you see sand floating in the glass.";
			this.nutriment_factor = 0.4;
			this.color = "#2E6671";
			this.data = 1;
		}

		// Function from file: Chemistry-Reagents.dm
		public override bool on_mob_life( Mob_Living M = null, int? alien = null ) {
			
			if ( base.on_mob_life( M, alien ) ) {
				return true;
			}
			M.dizziness += 10;

			if ( Convert.ToDouble( this.data ) >= 55 && Convert.ToDouble( this.data ) < 115 ) {
				M.stuttering += 10;
			} else if ( Convert.ToDouble( this.data ) >= 115 && Rand13.PercentChance( 33 ) ) {
				M.confused = Num13.MaxInt( M.confused + 15, 15 );
			}
			this.data++;
			return false;
		}

	}

}