// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Circuitboard_Diseaseanalyser : Obj_Item_Weapon_Circuitboard {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.build_path = "/obj/machinery/disease2/diseaseanalyser";
			this.board_type = "machine";
			this.origin_tech = "engineering=3;biotech=3;programming=3";
			this.frame_desc = "Requires 1 Micro-Laser, 1 Manipulator, and 3 Scanning Modules.";
			this.req_components = new ByTable().Set( "/obj/item/weapon/stock_parts/manipulator", 1 ).Set( "/obj/item/weapon/stock_parts/micro_laser", 1 ).Set( "/obj/item/weapon/stock_parts/scanning_module", 3 );
		}

		public Obj_Item_Weapon_Circuitboard_Diseaseanalyser ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}