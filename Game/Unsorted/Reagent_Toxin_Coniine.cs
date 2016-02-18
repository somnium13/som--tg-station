// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Toxin_Coniine : Reagent_Toxin {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Coniine";
			this.id = "coniine";
			this.description = "Coniine metabolizes extremely slowly, but deals high amounts of toxin damage and stops breathing.";
			this.metabolization_rate = 0.024;
			this.toxpwr = 1.75;
		}

		// Function from file: toxin_reagents.dm
		public override bool on_mob_life( dynamic M = null ) {
			M.losebreath += 5;
			base.on_mob_life( (object)(M) );
			return false;
		}

	}

}