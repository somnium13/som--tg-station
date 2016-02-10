// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Circuitboard_Clonescanner : Obj_Item_Weapon_Circuitboard {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.build_path = "/obj/machinery/dna_scannernew";
			this.board_type = "machine";
			this.origin_tech = "programming=3;biotech=2";
			this.frame_desc = "Requires 1 Scanning Module, 1 Manipulator, 1 Micro-Laser, and 1 Console Screen.";
			this.req_components = new ByTable()
				.Set( "/obj/item/weapon/stock_parts/scanning_module", 1 )
				.Set( "/obj/item/weapon/stock_parts/manipulator", 1 )
				.Set( "/obj/item/weapon/stock_parts/micro_laser", 1 )
				.Set( "/obj/item/weapon/stock_parts/console_screen", 1 )
			;
		}

		public Obj_Item_Weapon_Circuitboard_Clonescanner ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}