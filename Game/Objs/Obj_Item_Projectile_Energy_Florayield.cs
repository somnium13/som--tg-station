// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Projectile_Energy_Florayield : Obj_Item_Projectile_Energy {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.damage_type = "tox";
			this.nodamage = true;
			this.icon_state = "energy2";
		}

		public Obj_Item_Projectile_Energy_Florayield ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: special.dm
		public override bool on_hit( dynamic atarget = null, int? blocked = null ) {
			blocked = blocked ?? 0;

			dynamic M = null;
			dynamic H = null;

			M = atarget;

			if ( atarget is Mob_Living_Carbon_Human ) {
				H = M;

				if ( Lang13.Bool( H.species.flags & 512 ) && M.nutrition < 500 ) {
					M.nutrition += 30;
				} else {
					M.show_message( "<span class='notice'>The radiation beam dissipates harmlessly through your body.</span>" );
				}
			} else if ( atarget is Mob_Living_Carbon ) {
				M.show_message( "<span class='notice'>The radiation beam dissipates harmlessly through your body.</span>" );
			} else {
				return true;
			}
			return false;
		}

	}

}