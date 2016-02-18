// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Tile_Simulated_Floor_Holofloor : Tile_Simulated_Floor {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.thermal_conductivity = 0;
			this.broken_states = new ByTable(new object [] { "engine" });
			this.burnt_states = new ByTable(new object [] { "engine" });
			this.icon_state = "floor";
		}

		public Tile_Simulated_Floor_Holofloor ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: turfs.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			return null;
		}

	}

}