// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class RoundEventControl_Wizard_Summonguns : RoundEventControl_Wizard {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Summon Guns";
			this.weight = 1;
			this.typepath = typeof(RoundEvent_Wizard_Summonguns);
			this.max_occurrences = 1;
			this.earliest_start = 0;
		}

		// Function from file: summons.dm
		public RoundEventControl_Wizard_Summonguns (  ) {
			
			if ( GlobalVars.config.no_summon_guns ) {
				this.weight = 0;
			}
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

	}

}