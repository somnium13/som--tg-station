// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_Carbon_Slime_Adult_Sepia : Mob_Living_Carbon_Slime_Adult {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.colour = "sepia";
			this.primarytype = typeof(Mob_Living_Carbon_Slime_Sepia);
			this.adulttype = typeof(Mob_Living_Carbon_Slime_Adult_Sepia);
			this.coretype = typeof(Obj_Item_SlimeExtract_Sepia);
			this.icon_state = "sepia adult slime";
		}

		// Function from file: subtypes.dm
		public Mob_Living_Carbon_Slime_Adult_Sepia ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.slime_mutation[1] = typeof(Mob_Living_Carbon_Slime_Sepia);
			this.slime_mutation[2] = typeof(Mob_Living_Carbon_Slime_Sepia);
			this.slime_mutation[3] = typeof(Mob_Living_Carbon_Slime_Sepia);
			this.slime_mutation[4] = typeof(Mob_Living_Carbon_Slime_Sepia);
			return;
		}

	}

}