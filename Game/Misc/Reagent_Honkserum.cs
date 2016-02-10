// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Honkserum : Reagent {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Honk Serum";
			this.id = "honkserum";
			this.description = "Concentrated honking";
			this.reagent_state = 2;
			this.color = "#F2C900";
			this.custom_metabolism = 0.01;
		}

		// Function from file: Chemistry-Reagents.dm
		public override bool on_mob_life( Mob_Living M = null, int? alien = null ) {
			
			if ( base.on_mob_life( M, alien ) ) {
				return true;
			}

			if ( Rand13.PercentChance( ((int)( 081 )) ) ) {
				M.say( Rand13.Pick(new object [] { "Honk", "HONK", "Hoooonk", "Honk?", "Henk", "Hunke?", "Honk!" }) );
			}
			return false;
		}

	}

}