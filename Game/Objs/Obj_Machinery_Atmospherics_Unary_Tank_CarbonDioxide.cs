// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Atmospherics_Unary_Tank_CarbonDioxide : Obj_Machinery_Atmospherics_Unary_Tank {

		// Function from file: tank.dm
		public Obj_Machinery_Atmospherics_Unary_Tank_CarbonDioxide ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.air_contents.carbon_dioxide = this.starting_volume * 2533.125 / ( ( this.air_contents.temperature ??0) * 8.314 );
			return;
		}

	}

}