// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Atmospherics_Unary_Tank_Nitrogen : Obj_Machinery_Atmospherics_Unary_Tank {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.default_colour = "#00b8b8";
			this.icon_state = "n2";
		}

		// Function from file: tank.dm
		public Obj_Machinery_Atmospherics_Unary_Tank_Nitrogen ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.air_contents.nitrogen = this.starting_volume * 2533.125 / ( ( this.air_contents.temperature ??0) * 8.314 );
			return;
		}

	}

}