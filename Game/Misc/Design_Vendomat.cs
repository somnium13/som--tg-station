// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_Vendomat : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Circuit Design (Vending Machine)";
			this.desc = "Allows for the construction of circuit boards used to build a vending machines.";
			this.id = "vendomat";
			this.req_tech = new ByTable().Set( "materials", 1 ).Set( "engineering", 1 ).Set( "powerstorage", 1 );
			this.build_type = 1;
			this.materials = new ByTable().Set( "$glass", 2000 ).Set( "sacid", 20 );
			this.build_path = typeof(Obj_Item_Weapon_Circuitboard_Vendomat);
		}

	}

}