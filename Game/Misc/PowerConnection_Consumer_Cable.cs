// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class PowerConnection_Consumer_Cable : PowerConnection_Consumer {

		public Obj_Structure_Cable cable = null;

		public PowerConnection_Consumer_Cable ( Obj_Machinery_Media_Transmitter_Broadcast loc = null, int parent = 0 ) : base( loc, parent ) {
			
		}

		// Function from file: components.dm
		public override bool powered( bool? chan = null ) {
			chan = chan ?? this.channel;

			
			if ( !( this.parent != null ) || !( this.parent.loc != null ) ) {
				return false;
			}

			if ( this.powernet == null || !( this.powernet != null ) || !( this.cable != null ) ) {
				return false;
			}

			if ( ( ( this.machine_flags ?1:0) & 16 ) != 0 && !Lang13.Bool( this.parent.anchored ) ) {
				return false;
			}
			return true;
		}

		// Function from file: components.dm
		public override bool connect(  ) {
			dynamic T = null;

			T = GlobalFuncs.get_turf( this.parent );
			this.cable = ((Tile)T).get_cable_node();

			if ( !( this.cable != null ) || !( this.cable.get_powernet() != null ) ) {
				return false;
			}
			this.cable.powernet.add_component( this );
			this.connected = true;
			return true;
		}

		// Function from file: components.dm
		public override bool use_power( dynamic amount = null, bool? chan = null ) {
			this.add_load( amount );
			return false;
		}

	}

}