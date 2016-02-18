// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class TableRecipe_SpookyCamera : TableRecipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Camera Obscura";
			this.result = typeof(Obj_Item_Device_Camera_Spooky);
			this.time = 15;
			this.reqs = new ByTable().Set( typeof(Obj_Item_Device_Camera), 1 ).Set( typeof(Reagent_Water_Holywater), 10 );
			this.parts = new ByTable().Set( typeof(Obj_Item_Device_Camera), 1 );
			this.category = "Misc";
		}

	}

}