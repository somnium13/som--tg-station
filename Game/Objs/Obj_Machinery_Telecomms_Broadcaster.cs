// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Telecomms_Broadcaster : Obj_Machinery_Telecomms {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.idle_power_usage = 25;
			this.machinetype = 5;
			this.heatgen = 0;
			this.delay = 7;
			this.circuitboard = "/obj/item/weapon/circuitboard/telecomms/broadcaster";
			this.icon_state = "broadcaster";
		}

		public Obj_Machinery_Telecomms_Broadcaster ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: broadcaster.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			
			if ( GlobalVars.message_delay ) {
				GlobalVars.message_delay = false;
			}
			base.Destroy( (object)(brokenup) );
			return null;
		}

		// Function from file: broadcaster.dm
		public override void receive_information( Game_Data signal = null, Obj_Machinery_Telecomms machine_from = null ) {
			dynamic original = null;
			string signal_message = null;
			Game_Data speech = null;
			Game_Data speech2 = null;
			Game_Data speech3 = null;

			
			if ( Lang13.Bool( ((dynamic)signal).data["reject"] ) ) {
				return;
			}

			if ( Lang13.Bool( ((dynamic)signal).data["message"] ) ) {
				((dynamic)signal).data["done"] = 1;
				original = ((dynamic)signal).data["original"];

				if ( Lang13.Bool( original ) ) {
					original.data["done"] = 1;
					original.data["compression"] = ((dynamic)signal).data["compression"];
					original.data["level"] = ((dynamic)signal).data["level"];
				}
				signal_message = "" + ((dynamic)signal).frequency + ":" + ((dynamic)signal).data["message"] + ":" + ((dynamic)signal).data["realname"];
				Interface13.Stat( null, GlobalVars.recentmessages.Contains( signal_message ) );

				if ( Lang13.Bool( original ) ) {
					return;
				}
				GlobalVars.recentmessages.Add( signal_message );

				if ( Convert.ToDouble( ((dynamic)signal).data["slow"] ) > 0 ) {
					Task13.Sleep( Convert.ToInt32( ((dynamic)signal).data["slow"] ) );
				}
				((dynamic)signal).data["level"] |= this.listening_level;

				if ( Lang13.Bool( ((dynamic)signal).data["type"] ) == false ) {
					speech = GlobalFuncs.getFromPool( typeof(Speech) );
					((dynamic)speech).from_signal( signal );
					GlobalFuncs.Broadcast_Message( speech, Lang13.BoolNullable( ((dynamic)signal).data["vmask"] ), 0, ((dynamic)signal).data["compression"], ((dynamic)signal).data["level"] );
				}

				if ( Lang13.Bool( ((dynamic)signal).data["type"] ) == true ) {
					speech2 = GlobalFuncs.getFromPool( typeof(Speech) );
					((dynamic)speech2).from_signal( signal );
					GlobalFuncs.Broadcast_Message( speech2, Lang13.BoolNullable( ((dynamic)signal).data["vmask"] ), null, ((dynamic)signal).data["compression"], ((dynamic)signal).data["level"] );
				}

				if ( Convert.ToInt32( ((dynamic)signal).data["type"] ) == 2 ) {
					speech3 = GlobalFuncs.getFromPool( typeof(Speech) );
					((dynamic)speech3).from_signal( signal );
					GlobalFuncs.Broadcast_Message( speech3, Lang13.BoolNullable( ((dynamic)signal).data["vmask"] ), 4, ((dynamic)signal).data["compression"], ((dynamic)signal).data["level"] );
				}

				if ( !GlobalVars.message_delay ) {
					GlobalVars.message_delay = true;
					Task13.Schedule( 10, (Task13.Closure)(() => {
						GlobalVars.message_delay = false;
						GlobalVars.recentmessages = new ByTable();
						return;
					}));
				}
				Icon13.Flick( "broadcaster_send", this );
			}
			return;
		}

	}

}