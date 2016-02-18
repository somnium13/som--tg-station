// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_CameraAssembly : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Camera assembly";
			this.id = "camera_assembly";
			this.build_type = 4;
			this.materials = new ByTable().Set( "$metal", 400 ).Set( "$glass", 250 );
			this.build_path = typeof(Obj_Item_Wallframe_Camera);
			this.category = new ByTable(new object [] { "initial", "Construction" });
		}

	}

}