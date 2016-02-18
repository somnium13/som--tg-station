// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_Geiger : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Geiger counter";
			this.id = "geigercounter";
			this.build_type = 4;
			this.materials = new ByTable().Set( "$metal", 150 ).Set( "$glass", 150 );
			this.build_path = typeof(Obj_Item_Device_GeigerCounter);
			this.category = new ByTable(new object [] { "initial", "Tools" });
		}

	}

}