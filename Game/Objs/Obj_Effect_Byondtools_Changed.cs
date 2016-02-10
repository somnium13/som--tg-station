// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Byondtools_Changed : Obj_Effect_Byondtools {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.alpha = 64;
			this.color = "#ff0000";
			this.icon = "icons/effects/tile_effects.dmi";
			this.icon_state = "changed";
			this.layer = 10;
		}

		// Function from file: byondtools.dm
		public Obj_Effect_Byondtools_Changed ( dynamic loc = null ) : base( (object)(loc) ) {
			this.layer = GlobalVars.TURF_LAYER;
			Game13.log.WriteMsg( "## WARNING: " + ( "Some dipshit left a " + this.type + " at " + this.x + "," + this.y + "," + this.z + ".  Might want to fix that (dmmfix map.dmm)" ) );
			Lang13.Delete( this );
			Task13.Source = null;
			return;
		}

	}

}