// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_IgnitionSwitch : Obj_Machinery {

		public dynamic id_tag = null;
		public bool active = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.idle_power_usage = 2;
			this.active_power_usage = 4;
			this.ghost_read = false;
			this.icon = "icons/obj/objects.dmi";
			this.icon_state = "launcherbtt";
		}

		public Obj_Machinery_IgnitionSwitch ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: igniter.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			Obj_Machinery_Sparker M = null;
			Obj_Machinery_Igniter M2 = null;

			
			if ( ( this.stat & 3 ) != 0 ) {
				return null;
			}

			if ( this.active ) {
				return null;
			}
			this.f_use_power( 5 );
			this.active = true;
			this.icon_state = "launcheract";

			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.igniters, typeof(Obj_Machinery_Sparker) )) {
				M = _a;
				

				if ( M.id_tag == this.id_tag ) {
					Task13.Schedule( 0, (Task13.Closure)(() => {
						M.spark();
						return;
					}));
				}
			}

			foreach (dynamic _b in Lang13.Enumerate( GlobalVars.igniters, typeof(Obj_Machinery_Igniter) )) {
				M2 = _b;
				

				if ( M2.id_tag == this.id_tag ) {
					this.f_use_power( 50 );
					M2.on = !M2.on;
					M2.icon_state = "igniter" + M2.on;
				}
			}
			Task13.Sleep( 50 );
			this.icon_state = "launcherbtt";
			this.active = false;
			return null;
		}

		// Function from file: igniter.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			return this.attack_hand( b );
		}

		// Function from file: igniter.dm
		public override dynamic attack_paw( Mob a = null, dynamic b = null, dynamic c = null ) {
			return this.attack_hand( a );
		}

		// Function from file: igniter.dm
		public override dynamic attack_ai( dynamic user = null ) {
			this.add_hiddenprint( user );
			return this.attack_hand( user );
		}

	}

}