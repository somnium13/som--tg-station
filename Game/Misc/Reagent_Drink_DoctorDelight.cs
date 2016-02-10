// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Drink_DoctorDelight : Reagent_Drink {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "The Doctor's Delight";
			this.id = "doctorsdelight";
			this.description = "A gulp a day keeps the MediBot away. That's probably for the best.";
			this.nutriment_factor = 0.4;
			this.color = "#664300";
		}

		// Function from file: Chemistry-Reagents.dm
		public override bool on_mob_life( Mob_Living M = null, int? alien = null ) {
			Mob_Living H = null;

			
			if ( base.on_mob_life( M, alien ) ) {
				return true;
			}

			if ( M is Mob_Living_Carbon_Human ) {
				H = M;
				H.nutrition += this.nutriment_factor;

				if ( Lang13.Bool( H.getOxyLoss() ) && Rand13.PercentChance( 50 ) ) {
					H.adjustOxyLoss( -2 );
				}

				if ( H.getBruteLoss() != 0 && Rand13.PercentChance( 60 ) ) {
					H.heal_organ_damage( 2, 0 );
				}

				if ( H.getFireLoss() != 0 && Rand13.PercentChance( 50 ) ) {
					H.heal_organ_damage( 0, 2 );
				}

				if ( Lang13.Bool( H.getToxLoss() ) && Rand13.PercentChance( 50 ) ) {
					H.adjustToxLoss( -2 );
				}

				if ( H.dizziness != 0 ) {
					H.dizziness = Num13.MaxInt( 0, H.dizziness - 15 );
				}

				if ( H.confused != 0 ) {
					H.confused = Num13.MaxInt( 0, H.confused - 5 );
				}
			}
			return false;
		}

	}

}