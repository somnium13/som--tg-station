// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_DroneShell : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Drone Shell";
			this.desc = "A shell of a maintenance drone, an expendable robot built to perform station repairs.";
			this.id = "drone_shell";
			this.req_tech = new ByTable().Set( "programming", 2 ).Set( "biotech", 4 );
			this.build_type = 16;
			this.materials = new ByTable().Set( "$metal", 800 ).Set( "$glass", 350 );
			this.construction_time = 150;
			this.build_path = typeof(Obj_Item_DroneShell);
			this.category = new ByTable(new object [] { "Misc" });
		}

	}

}