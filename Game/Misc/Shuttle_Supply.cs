// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Shuttle_Supply : Shuttle {

		public dynamic dock_centcom = null;
		public dynamic dock_station = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "supply shuttle";
			this.pre_flight_delay = 0;
			this.cooldown = 0;
			this.stable = true;
			this.dir = 2;
		}

		public Shuttle_Supply ( dynamic starting_area = null ) : base( (object)(starting_area) ) {
			
		}

		// Function from file: cargo.dm
		public override int initialize(  ) {
			int _default = 0;

			_default = base.initialize();
			this.dock_centcom = this.add_dock( typeof(Obj_Structure_DockingPort_Destination_Supply_Centcom) );
			this.dock_station = this.add_dock( typeof(Obj_Structure_DockingPort_Destination_Supply_Station) );
			return _default;
		}

		// Function from file: cargo.dm
		public override bool is_special(  ) {
			return true;
		}

	}

}