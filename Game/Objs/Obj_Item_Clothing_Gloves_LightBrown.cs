// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Gloves_LightBrown : Obj_Item_Clothing_Gloves {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "lightbrown";
			this._color = "light brown";
			this.species_fit = new ByTable(new object [] { "Vox" });
			this.icon_state = "lightbrown";
		}

		public Obj_Item_Clothing_Gloves_LightBrown ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}