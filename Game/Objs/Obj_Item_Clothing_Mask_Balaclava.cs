// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Mask_Balaclava : Obj_Item_Clothing_Mask {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "balaclava";
			this.body_parts_covered = 45057;
			this.w_class = 2;
			this.species_fit = new ByTable(new object [] { "Vox" });
			this.icon_state = "balaclava";
		}

		public Obj_Item_Clothing_Mask_Balaclava ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}