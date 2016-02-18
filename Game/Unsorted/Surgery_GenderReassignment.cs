// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Surgery_GenderReassignment : Surgery {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "gender reassignment";
			this.steps = new ByTable(new object [] { typeof(SurgeryStep_Incise), typeof(SurgeryStep_ClampBleeders), typeof(SurgeryStep_ReshapeGenitals), typeof(SurgeryStep_Close) });
			this.species = new ByTable(new object [] { typeof(Mob_Living_Carbon_Human) });
			this.possible_locs = new ByTable(new object [] { "groin" });
		}

	}

}