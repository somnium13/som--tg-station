// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Toxin_Initropidril : Reagent_Toxin {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Initropidril";
			this.id = "initropidril";
			this.description = "A powerful poison with insidious effects. It can cause stuns, lethal breathing failure, and cardiac arrest.";
			this.metabolization_rate = 0.2;
			this.toxpwr = 2.5;
		}

		// Function from file: toxin_reagents.dm
		public override bool on_mob_life( dynamic M = null ) {
			int picked_option = 0;
			dynamic H = null;

			
			if ( Rand13.PercentChance( 25 ) ) {
				picked_option = Rand13.Int( 1, 3 );

				switch ((int)( picked_option )) {
					case 1:
						((Mob)M).Stun( 3 );
						((Mob)M).Weaken( 3 );
						break;
					case 2:
						M.losebreath += 10;
						((Mob_Living)M).adjustOxyLoss( Rand13.Int( 5, 25 ) );
						break;
					case 3:
						
						if ( M is Mob_Living_Carbon_Human ) {
							H = M;

							if ( !H.heart_attack ) {
								H.heart_attack = true;

								if ( Lang13.Bool( H.stat ) == false ) {
									((Ent_Static)H).visible_message( "<span class='userdanger'>" + H + " clutches at their chest as if their heart stopped!</span>" );
								}
							} else {
								H.losebreath += 10;
								((Mob_Living)H).adjustOxyLoss( Rand13.Int( 5, 25 ) );
							}
						}
						break;
				}
			}
			base.on_mob_life( (object)(M) );
			return false;
		}

	}

}