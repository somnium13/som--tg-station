// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_Borgupload : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Circuit Design (Cyborg Upload)";
			this.desc = "Allows for the construction of circuit boards used to build a Cyborg Upload Console.";
			this.id = "borgupload";
			this.req_tech = new ByTable().Set( "programming", 4 );
			this.build_type = 1;
			this.materials = new ByTable().Set( "$glass", 2000 ).Set( "sacid", 20 );
			this.category = "Console Boards";
			this.build_path = typeof(Obj_Item_Weapon_Circuitboard_Borgupload);
			this.locked = true;
			this.req_lock_access = new ByTable(new object [] { 7, 29, 30 });
		}

	}

}