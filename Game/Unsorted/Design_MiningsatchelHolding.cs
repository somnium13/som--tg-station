// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_MiningsatchelHolding : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Mining Satchel of Holding";
			this.desc = "A mining satchel that can hold an infinite amount of ores.";
			this.id = "minerbag_holding";
			this.req_tech = new ByTable().Set( "bluespace", 3 ).Set( "materials", 4 );
			this.build_type = 2;
			this.materials = new ByTable().Set( "$gold", 250 ).Set( "$uranium", 500 );
			this.build_path = typeof(Obj_Item_Weapon_Storage_Bag_Ore_Holding);
			this.category = new ByTable(new object [] { "Bluespace Designs" });
		}

	}

}