// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_MessageServer : Obj_Machinery {

		public ByTable pda_msgs = new ByTable();
		public ByTable rc_msgs = new ByTable();
		public bool active = true;
		public string decryptkey = "password";

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.idle_power_usage = 10;
			this.active_power_usage = 100;
			this.ghost_read = false;
			this.icon = "icons/obj/machines/research.dmi";
			this.icon_state = "server";
		}

		// Function from file: message_server.dm
		public Obj_Machinery_MessageServer ( dynamic loc = null ) : base( (object)(loc) ) {
			GlobalVars.message_servers.Add( this );
			this.decryptkey = this.GenerateKey();
			this.send_pda_message( "System Administrator", "system", "This is an automated message. The messaging system is functioning correctly." );
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

		// Function from file: message_server.dm
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			
			if ( ( this.stat & 3 ) != 0 ) {
				this.icon_state = "server-nopower";
			} else if ( !this.active ) {
				this.icon_state = "server-off";
			} else {
				this.icon_state = "server-on";
			}
			return null;
		}

		// Function from file: message_server.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( a is Mob_Dead_Observer && !GlobalFuncs.isAdminGhost( a ) ) {
				return 0;
			}
			GlobalFuncs.to_chat( a, "You toggle PDA message passing from " + ( this.active ? "On" : "Off" ) + " to " + ( this.active ? "Off" : "On" ) );
			this.active = !this.active;
			this.update_icon();
			return null;
		}

		// Function from file: message_server.dm
		public override dynamic process(  ) {
			
			if ( this.active && ( this.stat & 3 ) != 0 ) {
				this.active = false;
				return null;
			}
			this.update_icon();
			return null;
		}

		// Function from file: message_server.dm
		public void send_rc_message( string recipient = null, dynamic sender = null, string message = null, string stamp = null, string id_auth = null, int? priority = null ) {
			recipient = recipient ?? "";
			sender = sender ?? "";
			message = message ?? "";
			stamp = stamp ?? "";
			id_auth = id_auth ?? "";
			priority = priority ?? 1;

			this.rc_msgs.Add( new DataRcMsg( recipient, sender, message, stamp, id_auth ) );
			return;
		}

		// Function from file: message_server.dm
		public void send_pda_message( string recipient = null, string sender = null, string message = null ) {
			recipient = recipient ?? "";
			sender = sender ?? "";
			message = message ?? "";

			this.pda_msgs.Add( new DataPdaMsg( recipient, sender, message ) );
			return;
		}

		// Function from file: message_server.dm
		public dynamic GenerateKey(  ) {
			dynamic newKey = null;

			newKey += Rand13.Pick(new object [] { "the", "if", "of", "as", "in", "a", "you", "from", "to", "an", "too", "little", "snow", "dead", "drunk", "rosebud", "duck", "al", "le" });
			newKey += Rand13.Pick(new object [] { "diamond", "beer", "mushroom", "assistant", "clown", "captain", "twinkie", "security", "nuke", "small", "big", "escape", "yellow", "gloves", "monkey", "engine", "nuclear", "ai" });
			newKey += Rand13.Pick(new object [] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" });
			return newKey;
		}

		// Function from file: message_server.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			GlobalVars.message_servers.Remove( this );
			base.Destroy( (object)(brokenup) );
			return null;
		}

	}

}