// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Consumable_Ethanol_ManhattanProj : Reagent_Consumable_Ethanol {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Manhattan Project";
			this.id = "manhattan_proj";
			this.description = "A scientist's drink of choice, for pondering ways to blow up the station.";
			this.color = "#664300";
			this.boozepwr = 15;
		}

		// Function from file: alcohol_reagents.dm
		public override bool on_mob_life( dynamic M = null ) {
			((Mob)M).set_drugginess( 30 );
			base.on_mob_life( (object)(M) );
			return false;
		}

	}

}