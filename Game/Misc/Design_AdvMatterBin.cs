// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_AdvMatterBin : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Advanced Matter Bin";
			this.desc = "A stock part used in the construction of various devices.";
			this.id = "adv_matter_bin";
			this.req_tech = new ByTable().Set( "materials", 3 );
			this.build_type = 2;
			this.materials = new ByTable().Set( "$iron", 80 );
			this.category = "Stock Parts";
			this.build_path = typeof(Obj_Item_Weapon_StockParts_MatterBin_Adv);
		}

	}

}