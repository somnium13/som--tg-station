// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Chempack_Override : Obj_Item_Weapon_ReagentContainers_Chempack {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.safety = true;
		}

		// Function from file: chempack.dm
		public Obj_Item_Weapon_ReagentContainers_Chempack_Override ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.icon_state = "" + Lang13.Initial( this, "icon_state" ) + "1";
			return;
		}

	}

}