// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_DoorAssembly_DoorAssemblyHatch : Obj_Structure_DoorAssembly {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.base_icon_state = "hatch";
			this.base_name = "Airtight Hatch";
			this.airlock_type = "/hatch";
			this.glass = -1;
		}

		public Obj_Structure_DoorAssembly_DoorAssemblyHatch ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}