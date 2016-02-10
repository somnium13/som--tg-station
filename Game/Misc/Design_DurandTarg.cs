// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_DurandTarg : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Circuit Design (\"Durand\" Weapons & Targeting Control module)";
			this.desc = "Allows for the construction of a \"Durand\" Weapons & Targeting Control module.";
			this.id = "durand_targ";
			this.req_tech = new ByTable().Set( "programming", 4 ).Set( "combat", 2 );
			this.build_type = 1;
			this.materials = new ByTable().Set( "$glass", 2000 ).Set( "sacid", 20 );
			this.category = "Mecha Boards";
			this.build_path = typeof(Obj_Item_Weapon_Circuitboard_Mecha_Durand_Targeting);
		}

	}

}