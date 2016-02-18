// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_BasicScanning : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Basic Scanning Module";
			this.desc = "A stock part used in the construction of various devices.";
			this.id = "basic_scanning";
			this.req_tech = new ByTable().Set( "magnets", 1 );
			this.build_type = 6;
			this.materials = new ByTable().Set( "$metal", 50 ).Set( "$glass", 20 );
			this.build_path = typeof(Obj_Item_Weapon_StockParts_ScanningModule);
			this.category = new ByTable(new object [] { "Stock Parts", "Machinery", "initial" });
		}

	}

}