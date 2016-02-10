// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Gun_Projectile_Silenced : Obj_Item_Weapon_Gun_Projectile {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.inhand_states = new ByTable().Set( "left_hand", "icons/mob/in-hand/left/guninhands_left.dmi" ).Set( "right_hand", "icons/mob/in-hand/right/guninhands_right.dmi" );
			this.max_shells = 10;
			this.caliber = new ByTable().Set( ".45", 1 );
			this.silenced = 1;
			this.origin_tech = "combat=2;materials=2;syndicate=8";
			this.ammo_type = "/obj/item/ammo_casing/c45";
			this.mag_type = "/obj/item/ammo_storage/magazine/c45";
			this.load_method = 2;
			this.icon_state = "silenced_pistol";
		}

		public Obj_Item_Weapon_Gun_Projectile_Silenced ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}