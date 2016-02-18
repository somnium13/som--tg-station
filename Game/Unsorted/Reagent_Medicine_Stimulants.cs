// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Medicine_Stimulants : Reagent_Medicine {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Stimulants";
			this.id = "stimulants";
			this.description = "Increases stun resistance and movement speed in addition to restoring minor damage and weakness. Overdose causes weakness and toxin damage.";
			this.color = "#C8A5DC";
			this.metabolization_rate = 0.2;
			this.overdose_threshold = 60;
		}

		// Function from file: medicine_reagents.dm
		public override void overdose_process( dynamic M = null ) {
			
			if ( Rand13.PercentChance( 33 ) ) {
				((Mob_Living)M).adjustStaminaLoss( 2.5 );
				((Mob_Living)M).adjustToxLoss( 1 );
				M.losebreath++;
			}
			base.overdose_process( (object)(M) );
			return;
		}

		// Function from file: medicine_reagents.dm
		public override bool on_mob_life( dynamic M = null ) {
			M.status_flags |= 32;

			if ( Convert.ToDouble( M.health ) < 50 && Convert.ToDouble( M.health ) > 0 ) {
				((Mob_Living)M).adjustOxyLoss( -1 );
				((Mob_Living)M).adjustToxLoss( -1 );
				((Mob_Living)M).adjustBruteLoss( -1 );
				((Mob_Living)M).adjustFireLoss( -1 );
			}
			((Mob)M).AdjustParalysis( -3 );
			((Mob)M).AdjustStunned( -3 );
			((Mob)M).AdjustWeakened( -3 );
			((Mob_Living)M).adjustStaminaLoss( -5 );
			base.on_mob_life( (object)(M) );
			return false;
		}

	}

}