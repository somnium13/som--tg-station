// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_HonkerMain : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Exosuit Module (\"H.O.N.K\" Central Control module)";
			this.desc = "Allows for the construction of a \"H.O.N.K\" Central Control module.";
			this.id = "honker_main";
			this.req_tech = new ByTable().Set( "programming", 3 );
			this.build_type = 1;
			this.materials = new ByTable().Set( "$glass", 1000 ).Set( "sacid", 20 );
			this.build_path = typeof(Obj_Item_Weapon_Circuitboard_Mecha_Honker_Main);
			this.category = new ByTable(new object [] { "Exosuit Modules" });
		}

	}

}