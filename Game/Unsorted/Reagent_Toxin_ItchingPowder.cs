// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Toxin_ItchingPowder : Reagent_Toxin {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Itching Powder";
			this.id = "itching_powder";
			this.description = "A powder that induces itching upon contact with the skin. Causes the victim to scratch at their itches and has a very low chance to decay into Histamine.";
			this.metabolization_rate = 0.16;
			this.toxpwr = 0;
		}

		// Function from file: toxin_reagents.dm
		public override bool on_mob_life( dynamic M = null ) {
			
			if ( Rand13.PercentChance( 15 ) ) {
				M.WriteMsg( "You scratch at your head." );
				((Mob_Living)M).adjustBruteLoss( 0.2 );
			}

			if ( Rand13.PercentChance( 15 ) ) {
				M.WriteMsg( "You scratch at your leg." );
				((Mob_Living)M).adjustBruteLoss( 0.2 );
			}

			if ( Rand13.PercentChance( 15 ) ) {
				M.WriteMsg( "You scratch at your arm." );
				((Mob_Living)M).adjustBruteLoss( 0.2 );
			}

			if ( Rand13.PercentChance( 3 ) ) {
				((Reagents)M.reagents).add_reagent( "histamine", Rand13.Int( 1, 3 ) );
				((Reagents)M.reagents).remove_reagent( "itching_powder", 1.2 );
				return false;
			}
			base.on_mob_life( (object)(M) );
			return false;
		}

		// Function from file: toxin_reagents.dm
		public override double reaction_mob( dynamic M = null, int? method = null, double? reac_volume = null, bool? show_message = null, dynamic touch_protection = null, Mob_Camera_Blob O = null ) {
			method = method ?? GlobalVars.TOUCH;

			
			if ( method == GlobalVars.TOUCH || method == GlobalVars.VAPOR ) {
				((Reagents)M.reagents).add_reagent( "itching_powder", reac_volume );
			}
			return 0;
		}

	}

}