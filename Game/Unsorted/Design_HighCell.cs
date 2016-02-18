// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_HighCell : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "High-Capacity Power Cell";
			this.desc = "A power cell that holds 10000 units of energy.";
			this.id = "high_cell";
			this.req_tech = new ByTable().Set( "powerstorage", 2 );
			this.build_type = 22;
			this.materials = new ByTable().Set( "$metal", 700 ).Set( "$glass", 60 );
			this.construction_time = 100;
			this.build_path = typeof(Obj_Item_Weapon_StockParts_Cell_High);
			this.category = new ByTable(new object [] { "Misc", "Power Designs" });
		}

	}

}