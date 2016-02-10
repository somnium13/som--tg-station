// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Disease2_Effect_Gunck : Disease2_Effect {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Flemmingtons";
			this.stage = 1;
		}

		// Function from file: effect.dm
		public override bool activate( Mob_Living mob = null, bool multiplier = false ) {
			GlobalFuncs.to_chat( mob, "<span class = 'notice'> Mucous runs down the back of your throat.</span>" );
			return false;
		}

	}

}