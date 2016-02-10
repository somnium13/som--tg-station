// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Atmospherics_Unary_Tank_Air : Obj_Machinery_Atmospherics_Unary_Tank {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.default_colour = "#0000b7";
			this.icon_state = "air";
		}

		// Function from file: tank.dm
		public Obj_Machinery_Atmospherics_Unary_Tank_Air ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.air_contents.oxygen = this.starting_volume * 531.9562377929688 / ( ( this.air_contents.temperature ??0) * 8.314 );
			this.air_contents.nitrogen = this.starting_volume * 2001.1688232421875 / ( ( this.air_contents.temperature ??0) * 8.314 );
			return;
		}

	}

}