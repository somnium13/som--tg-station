// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Drug_Aranesp : Reagent_Drug {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Aranesp";
			this.id = "aranesp";
			this.description = "Amps you up and gets you going, fixes all stamina damage you might have but can cause toxin and oxygen damage..";
			this.color = "#60A584";
		}

		// Function from file: drug_reagents.dm
		public override bool on_mob_life( dynamic M = null ) {
			dynamic high_message = null;

			high_message = Rand13.Pick(new object [] { "You feel amped up.", "You feel ready.", "You feel like you can push it to the limit." });

			if ( Rand13.PercentChance( 5 ) ) {
				M.WriteMsg( "<span class='notice'>" + high_message + "</span>" );
			}
			((Mob_Living)M).adjustStaminaLoss( -18 );
			((Mob_Living)M).adjustToxLoss( 0.5 );

			if ( Rand13.PercentChance( 50 ) ) {
				M.losebreath++;
				((Mob_Living)M).adjustOxyLoss( 1 );
			}
			base.on_mob_life( (object)(M) );
			return false;
		}

	}

}