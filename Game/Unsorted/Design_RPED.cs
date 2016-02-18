// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_RPED : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Rapid Part Exchange Device";
			this.desc = "Special mechanical module made to store, sort, and apply standard machine parts.";
			this.id = "rped";
			this.req_tech = new ByTable().Set( "engineering", 3 ).Set( "materials", 3 );
			this.build_type = 2;
			this.materials = new ByTable().Set( "$metal", 10000 ).Set( "$glass", 5000 );
			this.build_path = typeof(Obj_Item_Weapon_Storage_PartReplacer);
			this.category = new ByTable(new object [] { "Stock Parts" });
		}

	}

}