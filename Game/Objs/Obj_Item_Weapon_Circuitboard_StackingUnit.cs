// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Circuitboard_StackingUnit : Obj_Item_Weapon_Circuitboard {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.build_path = "/obj/machinery/mineral/stacking_machine";
			this.board_type = "machine";
			this.origin_tech = "materials=3;engineering=2;programming=2";
			this.frame_desc = "Requires 3 Matter Bins and 1 Capacitor";
			this.req_components = new ByTable().Set( "/obj/item/weapon/stock_parts/matter_bin", 3 ).Set( "/obj/item/weapon/stock_parts/capacitor", 1 );
		}

		public Obj_Item_Weapon_Circuitboard_StackingUnit ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}