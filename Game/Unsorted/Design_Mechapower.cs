// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_Mechapower : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Computer Design (Mech Bay Power Control Console)";
			this.desc = "Allows for the construction of circuit boards used to build a mech bay power control console.";
			this.id = "mechapower";
			this.req_tech = new ByTable().Set( "programming", 2 ).Set( "powerstorage", 3 );
			this.build_type = 1;
			this.materials = new ByTable().Set( "$glass", 1000 ).Set( "sacid", 20 );
			this.build_path = typeof(Obj_Item_Weapon_Circuitboard_MechBayPowerConsole);
			this.category = new ByTable(new object [] { "Computer Boards" });
		}

	}

}