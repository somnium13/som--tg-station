// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Door_Unpowered_Shuttle : Obj_Machinery_Door_Unpowered {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.animation_delay = 5;
			this.explosion_block = 1;
			this.icon = "icons/obj/doors/shuttle.dmi";
		}

		public Obj_Machinery_Door_Unpowered_Shuttle ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: unpowered.dm
		public override dynamic cultify(  ) {
			new Obj_Machinery_Door_Mineral_Wood( this.loc );
			base.cultify();
			return null;
		}

	}

}