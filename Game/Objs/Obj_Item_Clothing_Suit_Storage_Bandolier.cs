// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Suit_Storage_Bandolier : Obj_Item_Clothing_Suit_Storage {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "bandolier";
			this.storage_slots = 8;
			this.max_combined_w_class = 20;
			this.can_hold = new ByTable(new object [] { "/obj/item/ammo_casing/shotgun" });
			this.icon_state = "bandolier";
		}

		public Obj_Item_Clothing_Suit_Storage_Bandolier ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}