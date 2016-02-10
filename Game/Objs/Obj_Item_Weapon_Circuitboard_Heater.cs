// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Circuitboard_Heater : Obj_Item_Weapon_Circuitboard {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.build_path = "/obj/machinery/atmospherics/unary/heat_reservoir/heater";
			this.board_type = "machine";
			this.origin_tech = "powerstorage=3;engineering=5;biotech=4";
			this.frame_desc = "Requires 3 micro-lasers and 1 console screen.";
			this.req_components = new ByTable().Set( "/obj/item/weapon/stock_parts/micro_laser", 3 ).Set( "/obj/item/weapon/stock_parts/console_screen", 1 );
		}

		public Obj_Item_Weapon_Circuitboard_Heater ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}