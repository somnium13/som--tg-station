// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SupplyPack_Misc_Foamforce : SupplyPack_Misc {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Foam Force Crate";
			this.cost = 10;
			this.contains = new ByTable(new object [] { 
				typeof(Obj_Item_Weapon_Gun_Projectile_Shotgun_Toy), 
				typeof(Obj_Item_Weapon_Gun_Projectile_Shotgun_Toy), 
				typeof(Obj_Item_Weapon_Gun_Projectile_Shotgun_Toy), 
				typeof(Obj_Item_Weapon_Gun_Projectile_Shotgun_Toy), 
				typeof(Obj_Item_Weapon_Gun_Projectile_Shotgun_Toy), 
				typeof(Obj_Item_Weapon_Gun_Projectile_Shotgun_Toy), 
				typeof(Obj_Item_Weapon_Gun_Projectile_Shotgun_Toy), 
				typeof(Obj_Item_Weapon_Gun_Projectile_Shotgun_Toy)
			 });
			this.crate_name = "foam force crate";
		}

	}

}