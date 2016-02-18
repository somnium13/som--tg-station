// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_ProxSensor : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Proximity sensor";
			this.id = "prox_sensor";
			this.build_type = 4;
			this.materials = new ByTable().Set( "$metal", 800 ).Set( "$glass", 200 );
			this.build_path = typeof(Obj_Item_Device_Assembly_ProxSensor);
			this.category = new ByTable(new object [] { "initial", "Misc" });
		}

	}

}