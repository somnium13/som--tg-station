// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Mask_Gas_Golem : Obj_Item_Clothing_Mask_Gas {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "golem";
			this.canremove = false;
			this.unacidable = true;
			this.icon_state = "golem";
		}

		public Obj_Item_Clothing_Mask_Gas_Golem ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}