// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_StockParts_ScanningModule_Adv_Phasic : Obj_Item_Weapon_StockParts_ScanningModule_Adv {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.origin_tech = "magnets=5";
			this.rating = 3;
			this.starting_materials = new ByTable().Set( "$plastic", 300 );
			this.icon_state = "super_scan_module";
		}

		public Obj_Item_Weapon_StockParts_ScanningModule_Adv_Phasic ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}