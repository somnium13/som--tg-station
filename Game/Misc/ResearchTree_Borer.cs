// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ResearchTree_Borer : ResearchTree {

		public Mob_Living_SimpleAnimal_Borer borer = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.title = "Evolutions";
			this.blurb = "Select which path to evolve.";
		}

		// Function from file: unlocks.dm
		public ResearchTree_Borer ( Mob_Living_SimpleAnimal_Borer B = null ) {
			this.borer = B;
			return;
		}

		// Function from file: unlocks.dm
		public override ByTable get_avail_unlocks(  ) {
			return this.borer.borer_avail_unlocks;
		}

	}

}