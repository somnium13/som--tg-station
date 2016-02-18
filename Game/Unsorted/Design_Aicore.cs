// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_Aicore : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "AI Design (AI Core)";
			this.desc = "Allows for the construction of circuit boards used to build new AI cores.";
			this.id = "aicore";
			this.req_tech = new ByTable().Set( "programming", 4 ).Set( "biotech", 3 );
			this.build_type = 1;
			this.materials = new ByTable().Set( "$glass", 1000 ).Set( "sacid", 20 );
			this.build_path = typeof(Obj_Item_Weapon_Circuitboard_Aicore);
			this.category = new ByTable(new object [] { "Computer Boards" });
		}

	}

}