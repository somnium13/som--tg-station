// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Tile_Simulated_Wall_Rust : Tile_Simulated_Wall {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.walltype = "arust";
			this.hardness = 45;
			this.icon = "icons/turf/walls/rusty_wall.dmi";
			this.icon_state = "arust";
		}

		public Tile_Simulated_Wall_Rust ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}