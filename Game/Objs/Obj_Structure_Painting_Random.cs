// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Painting_Random : Obj_Structure_Painting {

		// Function from file: paintings.dm
		public Obj_Structure_Painting_Random ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.icon_state = Rand13.PickFromTable( GlobalVars.available_paintings );
			this.update_painting();
			return;
		}

	}

}