// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Glass_Kettle : Obj_Item_Weapon_ReagentContainers_Glass {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.starting_materials = new ByTable().Set( "$iron", 200 );
			this.volume = 75;
			this.icon_state = "kettle";
		}

		public Obj_Item_Weapon_ReagentContainers_Glass_Kettle ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}