// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Decal_Cleanable_ClayFragments : Obj_Effect_Decal_Cleanable {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon = "icons/effects/tomatodecal.dmi";
			this.icon_state = "clay_fragments";
		}

		// Function from file: misc.dm
		public Obj_Effect_Decal_Cleanable_ClayFragments ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.pixel_x = Rand13.Int( -3, 3 );
			this.pixel_y = Rand13.Int( -3, 3 );
			return;
		}

	}

}