// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Circuitboard_Microwave : Obj_Item_Weapon_Circuitboard {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.build_path = "/obj/machinery/microwave";
			this.board_type = "machine";
			this.origin_tech = "programming=2;engineering=2;magnets=3";
			this.frame_desc = "Requires 1 Micro-Laser, 1 Scanning Module, and 1 Console Screens.   ";
			this.req_components = new ByTable().Set( "/obj/item/weapon/stock_parts/micro_laser", 1 ).Set( "/obj/item/weapon/stock_parts/scanning_module", 1 ).Set( "/obj/item/weapon/stock_parts/console_screen", 1 );
		}

		public Obj_Item_Weapon_Circuitboard_Microwave ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}