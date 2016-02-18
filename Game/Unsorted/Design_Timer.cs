// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_Timer : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Timer";
			this.id = "timer";
			this.build_type = 4;
			this.materials = new ByTable().Set( "$metal", 500 ).Set( "$glass", 50 );
			this.build_path = typeof(Obj_Item_Device_Assembly_Timer);
			this.category = new ByTable(new object [] { "initial", "Misc" });
		}

	}

}