// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Consumable_HippiesDelight : Reagent_Consumable {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Hippie's Delight";
			this.id = "hippiesdelight";
			this.description = "You just don't get it maaaan.";
			this.color = "#664300";
			this.nutriment_factor = 0;
			this.metabolization_rate = 0.08;
		}

		// Function from file: drink_reagents.dm
		public override bool on_mob_life( dynamic M = null ) {
			
			if ( !( M.slurring != 0 ) ) {
				M.slurring = 1;
			}

			dynamic _a = this.current_cycle; // Was a switch-case, sorry for the mess.
			if ( 1<=_a&&_a<=5 ) {
				((Mob)M).Dizzy( 10 );
				((Mob)M).set_drugginess( 30 );

				if ( Rand13.PercentChance( 10 ) ) {
					((Mob)M).emote( Rand13.Pick(new object [] { "twitch", "giggle" }) );
				}
			} else if ( 5<=_a&&_a<=10 ) {
				((Mob)M).Jitter( 20 );
				((Mob)M).Dizzy( 20 );
				((Mob)M).set_drugginess( 45 );

				if ( Rand13.PercentChance( 20 ) ) {
					((Mob)M).emote( Rand13.Pick(new object [] { "twitch", "giggle" }) );
				}
			} else if ( 10<=_a&&_a<=200 ) {
				((Mob)M).Jitter( 40 );
				((Mob)M).Dizzy( 40 );
				((Mob)M).set_drugginess( 60 );

				if ( Rand13.PercentChance( 30 ) ) {
					((Mob)M).emote( Rand13.Pick(new object [] { "twitch", "giggle" }) );
				}
			} else if ( 200<=_a&&_a<=Double.PositiveInfinity ) {
				((Mob)M).Jitter( 60 );
				((Mob)M).Dizzy( 60 );
				((Mob)M).set_drugginess( 75 );

				if ( Rand13.PercentChance( 40 ) ) {
					((Mob)M).emote( Rand13.Pick(new object [] { "twitch", "giggle" }) );
				}

				if ( Rand13.PercentChance( 30 ) ) {
					((Mob_Living)M).adjustToxLoss( 2 );
				}
			}
			base.on_mob_life( (object)(M) );
			return false;
		}

	}

}