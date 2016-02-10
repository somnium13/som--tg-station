// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Shuttle_Syndicate : Shuttle {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "syndicate shuttle";
			this.cant_leave_zlevel = new ByTable();
			this.cooldown = 200;
			this.transit_delay = 210;
			this.pre_flight_delay = 30;
			this.stable = true;
			this.can_rotate = 0;
			this.req_access = new ByTable(new object [] { 150 });
			this.dir = 2;
		}

		public Shuttle_Syndicate ( dynamic starting_area = null ) : base( (object)(starting_area) ) {
			
		}

		// Function from file: syndicate.dm
		public override int initialize(  ) {
			int _default = 0;

			_default = base.initialize();
			this.add_dock( typeof(Obj_Structure_DockingPort_Destination_Syndicate_Start) );
			this.add_dock( typeof(Obj_Structure_DockingPort_Destination_Syndicate_Northwest) );
			this.add_dock( typeof(Obj_Structure_DockingPort_Destination_Syndicate_Northeast) );
			this.add_dock( typeof(Obj_Structure_DockingPort_Destination_Syndicate_Southwest) );
			this.add_dock( typeof(Obj_Structure_DockingPort_Destination_Syndicate_South) );
			this.add_dock( typeof(Obj_Structure_DockingPort_Destination_Syndicate_Southeast) );
			this.add_dock( typeof(Obj_Structure_DockingPort_Destination_Syndicate_Commssat) );
			this.add_dock( typeof(Obj_Structure_DockingPort_Destination_Syndicate_Mining) );
			this.set_transit_dock( typeof(Obj_Structure_DockingPort_Destination_Syndicate_Transit) );
			return _default;
		}

	}

}