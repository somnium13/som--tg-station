// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Consumable_Carrotjuice : Reagent_Consumable {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Carrot juice";
			this.id = "carrotjuice";
			this.description = "It is just like a carrot but without crunching.";
			this.color = "#973800";
		}

		// Function from file: drink_reagents.dm
		public override bool on_mob_life( dynamic M = null ) {
			((Mob)M).adjust_blurriness( -1 );
			((Mob)M).adjust_blindness( -1 );

			dynamic _a = this.current_cycle; // Was a switch-case, sorry for the mess.
			if ( 1<=_a&&_a<=20 ) {
				
			} else if ( 21<=_a&&_a<=Double.PositiveInfinity ) {
				
				if ( Rand13.PercentChance( ((int)( this.current_cycle - 10 )) ) ) {
					((Mob)M).cure_nearsighted();
				}
			}
			base.on_mob_life( (object)(M) );
			return false;
		}

	}

}