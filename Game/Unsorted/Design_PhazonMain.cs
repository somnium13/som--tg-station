// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_PhazonMain : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Exosuit Module (\"Phazon\" Central Control module)";
			this.desc = "Allows for the construction of a \"Phazon\" Central Control module.";
			this.id = "phazon_main";
			this.req_tech = new ByTable().Set( "programming", 5 ).Set( "materials", 7 ).Set( "powerstorage", 6 );
			this.build_type = 1;
			this.materials = new ByTable().Set( "$glass", 1000 ).Set( "sacid", 20 );
			this.build_path = typeof(Obj_Item_Weapon_Circuitboard_Mecha_Phazon_Main);
			this.category = new ByTable(new object [] { "Exosuit Modules" });
		}

	}

}