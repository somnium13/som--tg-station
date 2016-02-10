// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Circuitboard_RustInjector : Obj_Item_Weapon_Circuitboard {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.build_path = "/obj/machinery/power/rust_fuel_injector";
			this.board_type = "machine";
			this.origin_tech = "powerstorage=3;engineering=4;plasmatech=4;materials=6";
			this.frame_desc = "Requires 2 Pico Manipulators, 1 Phasic Scanning Module, 1 Super Matter Bin, 1 Console Screen and 5 Pieces of Cable.";
			this.req_components = new ByTable()
				.Set( "/obj/item/weapon/stock_parts/manipulator/pico", 2 )
				.Set( "/obj/item/weapon/stock_parts/scanning_module/phasic", 1 )
				.Set( "/obj/item/weapon/stock_parts/matter_bin/super", 1 )
				.Set( "/obj/item/weapon/stock_parts/console_screen", 1 )
				.Set( "/obj/item/stack/cable_coil", 5 )
			;
		}

		public Obj_Item_Weapon_Circuitboard_RustInjector ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}