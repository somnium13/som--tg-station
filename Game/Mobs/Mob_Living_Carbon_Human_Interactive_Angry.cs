// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_Carbon_Human_Interactive_Angry : Mob_Living_Carbon_Human_Interactive {

		// Function from file: interactive.dm
		public Mob_Living_Carbon_Human_Interactive_Angry ( dynamic loc = null ) : base( (object)(loc) ) {
			this.TRAITS |= 2;
			this.TRAITS |= 32;
			this.faction = new ByTable(new object [] { "bot_angry" });
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

	}

}