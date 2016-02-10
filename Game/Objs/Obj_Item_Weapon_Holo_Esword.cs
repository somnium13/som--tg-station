// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Holo_Esword : Obj_Item_Weapon_Holo {

		public bool active = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.force = 3;
			this.throw_speed = 1;
			this.throw_range = 5;
			this.throwforce = 0;
			this.w_class = 2;
			this.icon_state = "sword0";
		}

		// Function from file: HolodeckControl.dm
		public Obj_Item_Weapon_Holo_Esword ( dynamic loc = null ) : base( (object)(loc) ) {
			this.AddToProfiler();
			this._color = Rand13.Pick(new object [] { "red", "blue", "green", "purple" });
			return;
		}

		// Function from file: HolodeckControl.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			this.active = !this.active;

			if ( this.active ) {
				this.force = 30;
				this.icon_state = "sword" + this._color;
				this.w_class = 4;
				GlobalFuncs.playsound( user, "sound/weapons/saberon.ogg", 50, 1 );
				GlobalFuncs.to_chat( user, "<span class='notice'>" + this + " is now active.</span>" );
			} else {
				this.force = 3;
				this.icon_state = "sword0";
				this.w_class = 2;
				GlobalFuncs.playsound( user, "sound/weapons/saberoff.ogg", 50, 1 );
				GlobalFuncs.to_chat( user, "<span class='notice'>" + this + " can now be concealed.</span>" );
			}
			this.add_fingerprint( user );
			return null;
		}

		// Function from file: HolodeckControl.dm
		public override bool? attack( dynamic M = null, dynamic user = null, string def_zone = null, bool? eat_override = null ) {
			base.attack( (object)(M), (object)(user), def_zone, eat_override );
			return null;
		}

		// Function from file: HolodeckControl.dm
		public override bool IsShield(  ) {
			
			if ( this.active ) {
				return true;
			}
			return false;
		}

	}

}