// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Door_Airlock_GlassSecurity : Obj_Machinery_Door_Airlock {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.assembly_type = typeof(Obj_Structure_DoorAssembly_DoorAssemblySec);
			this.glass = true;
			this.penetration_dampening = 3;
			this.icon = "icons/obj/doors/Doorsecglass.dmi";
		}

		public Obj_Machinery_Door_Airlock_GlassSecurity ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}