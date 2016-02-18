// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Consumable_Ethanol_Thirteenloko : Reagent_Consumable_Ethanol {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Thirteen Loko";
			this.id = "thirteenloko";
			this.description = "A potent mixture of caffeine and alcohol.";
			this.color = "#102000";
			this.boozepwr = 35;
		}

		// Function from file: alcohol_reagents.dm
		public override bool on_mob_life( dynamic M = null ) {
			M.drowsyness = Num13.MaxInt( 0, M.drowsyness - 7 );
			((Mob)M).AdjustSleeping( -2 );

			if ( Convert.ToDouble( M.bodytemperature ) > 310 ) {
				M.bodytemperature = Num13.MaxInt( 310, Convert.ToInt32( M.bodytemperature - 7.5 ) );
			}
			((Mob)M).Jitter( 5 );
			base.on_mob_life( (object)(M) );
			return false;
		}

	}

}