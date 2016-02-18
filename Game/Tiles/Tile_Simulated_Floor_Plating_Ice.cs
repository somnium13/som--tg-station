// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Tile_Simulated_Floor_Plating_Ice : Tile_Simulated_Floor_Plating {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.temperature = 180;
			this.baseturf = typeof(Tile_Simulated_Floor_Plating_Ice);
			this.slowdown = 1;
			this.wet = 3;
			this.icon = "icons/turf/snow.dmi";
			this.icon_state = "ice";
		}

		public Tile_Simulated_Floor_Plating_Ice ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: misc_floor.dm
		public override void burn_tile(  ) {
			return;
		}

		// Function from file: misc_floor.dm
		public override void break_tile(  ) {
			return;
		}

	}

}