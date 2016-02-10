// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_DockingPort_Destination : Obj_Structure_DockingPort {

		public dynamic base_turf_type = typeof(Tile_Space);
		public string base_turf_icon = null;
		public string base_turf_icon_state = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "docking_station";
		}

		// Function from file: docking_port.dm
		public Obj_Structure_DockingPort_Destination ( dynamic loc = null ) : base( (object)(loc) ) {
			dynamic L = null;
			dynamic T = null;
			dynamic A = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( Lang13.IsInRange( this.z, 1, GlobalVars.map.zLevels.len ) ) {
				this.base_turf_type = GlobalFuncs.get_base_turf( this.z );
			}
			L = GlobalFuncs.get_z_level( this );

			if ( L is ZLevel_Centcomm ) {
				T = GlobalFuncs.get_turf( this );

				if ( T is Tile_Space ) {
					this.base_turf_type = T.type;
				} else {
					A = GlobalFuncs.get_area( this );

					if ( A is Zone_SyndicateMothership ) {
						this.base_turf_type = T.type;
						this.base_turf_icon = T.icon;
						this.base_turf_icon_state = T.icon_state;
					}
				}
			}
			return;
		}

		// Function from file: docking_port.dm
		public override bool shuttle_act( Shuttle S = null ) {
			return false;
		}

		// Function from file: docking_port.dm
		public override bool can_shuttle_move( Shuttle S = null ) {
			Interface13.Stat( null, S.docking_ports_aboard.Contains( this ) );

			if ( false ) {
				return true;
			}
			return false;
		}

		// Function from file: docking_port.dm
		public override dynamic unlink_from_shuttle( dynamic S = null ) {
			base.unlink_from_shuttle( (object)(S) );
			S.docking_ports.Remove( this );
			return null;
		}

		// Function from file: docking_port.dm
		public override dynamic link_to_shuttle( dynamic S = null ) {
			base.link_to_shuttle( (object)(S) );
			S.docking_ports.Or( this );
			return null;
		}

	}

}