// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_DoorAssembly_DoorAssemblyHighsecurity : Obj_Structure_DoorAssembly {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.base_icon_state = "highsec";
			this.base_name = "High Security Airlock";
			this.airlock_type = "/highsecurity";
			this.glass = -1;
		}

		public Obj_Structure_DoorAssembly_DoorAssemblyHighsecurity ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}