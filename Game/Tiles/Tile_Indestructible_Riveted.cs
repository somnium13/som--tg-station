// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Tile_Indestructible_Riveted : Tile_Indestructible {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "riveted";
		}

		// Function from file: turf.dm
		public Tile_Indestructible_Riveted ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( this.smooth != 0 ) {
				GlobalFuncs.smooth_icon( this );
				this.icon_state = "";
			}
			return;
		}

	}

}