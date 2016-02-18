// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_DurandPeri : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Exosuit Module (\"Durand\" Peripherals Control module)";
			this.desc = "Allows for the construction of a \"Durand\" Peripheral Control module.";
			this.id = "durand_peri";
			this.req_tech = new ByTable().Set( "programming", 4 );
			this.build_type = 1;
			this.materials = new ByTable().Set( "$glass", 1000 ).Set( "sacid", 20 );
			this.build_path = typeof(Obj_Item_Weapon_Circuitboard_Mecha_Durand_Peripherals);
			this.category = new ByTable(new object [] { "Exosuit Modules" });
		}

	}

}