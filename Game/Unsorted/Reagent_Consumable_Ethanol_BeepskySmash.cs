// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Consumable_Ethanol_BeepskySmash : Reagent_Consumable_Ethanol {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Beepsky Smash";
			this.id = "beepskysmash";
			this.description = "Deny drinking this and prepare for THE LAW.";
			this.color = "#664300";
			this.boozepwr = 25;
			this.metabolization_rate = 0.8;
		}

		// Function from file: alcohol_reagents.dm
		public override bool on_mob_life( dynamic M = null ) {
			((Mob)M).Stun( 1 );
			base.on_mob_life( (object)(M) );
			return false;
		}

	}

}