// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Storage_Belt_Mining : Obj_Item_Weapon_Storage_Belt {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "mining";
			this.w_class = 4;
			this.max_w_class = 4;
			this.max_combined_w_class = 28;
			this.can_hold = new ByTable(new object [] { 
				"/obj/item/weapon/storage/bag/ore", 
				"/obj/item/weapon/pickaxe/shovel", 
				"/obj/item/weapon/storage/box/samplebags", 
				"/obj/item/device/core_sampler", 
				"/obj/item/device/beacon_locator", 
				"/obj/item/beacon", 
				"/obj/item/device/gps", 
				"/obj/item/device/measuring_tape", 
				"/obj/item/device/flashlight", 
				"/obj/item/weapon/pickaxe", 
				"/obj/item/device/depth_scanner", 
				"/obj/item/weapon/paper", 
				"/obj/item/weapon/pen", 
				"/obj/item/clothing/glasses", 
				"/obj/item/weapon/wrench", 
				"/obj/item/device/mining_scanner", 
				"/obj/item/weapon/crowbar", 
				"/obj/item/weapon/storage/box/excavation", 
				"/obj/item/weapon/gun/energy/kinetic_accelerator", 
				"/obj/item/weapon/resonator", 
				"/obj/item/device/wormhole_jaunter", 
				"/obj/item/weapon/lazarus_injector", 
				"/obj/item/weapon/anobattery"
			 });
			this.icon_state = "miningbelt";
		}

		public Obj_Item_Weapon_Storage_Belt_Mining ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}