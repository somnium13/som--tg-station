// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Drug_Nicotine : Reagent_Drug {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Nicotine";
			this.id = "nicotine";
			this.description = "Slightly reduces stun times. If overdosed it will deal toxin and oxygen damage.";
			this.color = "#60A584";
			this.addiction_threshold = 30;
		}

		// Function from file: drug_reagents.dm
		public override bool on_mob_life( dynamic M = null ) {
			dynamic smoke_message = null;

			
			if ( Rand13.PercentChance( 1 ) ) {
				smoke_message = Rand13.Pick(new object [] { "You feel relaxed.", "You feel calmed.", "You feel alert.", "You feel rugged." });
				M.WriteMsg( "<span class='notice'>" + smoke_message + "</span>" );
			}
			((Mob)M).AdjustStunned( -1 );
			((Mob_Living)M).adjustStaminaLoss( -0.5 );
			base.on_mob_life( (object)(M) );
			return false;
		}

	}

}