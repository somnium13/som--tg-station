// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class RoundEvent_MassHallucination : RoundEvent {

		// Function from file: mass_hallucination.dm
		public override bool start(  ) {
			Mob_Living_Carbon C = null;

			
			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.living_mob_list, typeof(Mob_Living_Carbon) )) {
				C = _a;
				
				C.hallucination += Rand13.Int( 20, 50 );
			}
			return false;
		}

	}

}