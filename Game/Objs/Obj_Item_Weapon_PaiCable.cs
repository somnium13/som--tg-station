// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_PaiCable : Obj_Item_Weapon {

		public dynamic machine = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon = "icons/obj/power.dmi";
			this.icon_state = "wire1";
		}

		public Obj_Item_Weapon_PaiCable ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: paiwire.dm
		public override bool? attack( dynamic M = null, dynamic user = null, string def_zone = null, bool? eat_override = null ) {
			this.plugin( M, user );
			return null;
		}

		// Function from file: paiwire.dm
		public void plugin( dynamic M = null, dynamic user = null ) {
			
			if ( M is Obj_Machinery_Door || M is Obj_Machinery_Camera ) {
				((Ent_Static)user).visible_message( "" + user + " inserts " + this + " into a data port on " + M + ".", "You insert " + this + " into a data port on " + M + ".", "You hear the satisfying click of a wire jack fastening into place." );

				if ( Lang13.Bool( user ) && ((Mob)user).get_active_hand() == this ) {
					user.drop_item( this, M, 1 );
				}
				this.machine = M;
			} else {
				((Ent_Static)user).visible_message( "" + user + " dumbly fumbles to find a place on " + M + " to plug in " + this + ".", "There aren't any ports on " + M + " that match the jack belonging to " + this + "." );
			}
			return;
		}

	}

}