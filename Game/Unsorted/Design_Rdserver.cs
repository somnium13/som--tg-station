// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_Rdserver : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Machine Design (R&D Server Board)";
			this.desc = "The circuit board for an R&D Server.";
			this.id = "rdserver";
			this.req_tech = new ByTable().Set( "programming", 3 );
			this.build_type = 1;
			this.materials = new ByTable().Set( "$glass", 1000 ).Set( "sacid", 20 );
			this.build_path = typeof(Obj_Item_Weapon_Circuitboard_Rdserver);
			this.category = new ByTable(new object [] { "Research Machinery" });
		}

	}

}