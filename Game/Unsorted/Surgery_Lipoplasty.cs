// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Surgery_Lipoplasty : Surgery {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "lipoplasty";
			this.steps = new ByTable(new object [] { typeof(SurgeryStep_Incise), typeof(SurgeryStep_ClampBleeders), typeof(SurgeryStep_CutFat), typeof(SurgeryStep_RemoveFat), typeof(SurgeryStep_Close) });
			this.possible_locs = new ByTable(new object [] { "chest" });
		}

		// Function from file: lipoplasty.dm
		public override bool can_start( dynamic user = null, dynamic target = null ) {
			
			if ( Lang13.Bool( target.disabilities & 32 ) ) {
				return true;
			}
			return false;
		}

	}

}