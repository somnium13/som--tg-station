// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Gun_Energy_Laser_LaserAK : Obj_Item_Weapon_Gun_Energy_Laser {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.inhand_states = new ByTable().Set( "left_hand", "icons/mob/in-hand/left/guninhands_left.dmi" ).Set( "right_hand", "icons/mob/in-hand/right/guninhands_right.dmi" );
			this.projectile_type = typeof(Obj_Item_Projectile_Beam);
			this.charge_cost = 75;
			this.icon_state = "LaserAK";
		}

		public Obj_Item_Weapon_Gun_Energy_Laser_LaserAK ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}