// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Unlockable_Borer_GeneUnlock_Run : Unlockable_Borer_GeneUnlock {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.id = "run";
			this.name = "Enhanced Metabolism";
			this.desc = "Modifies your host to run faster.";
			this.cost = 150;
			this.time = 200;
			this.gene_name = "INCREASERUN";
			this.prerequisites = new ByTable(new object [] { "sober" });
		}

	}

}