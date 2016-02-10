// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Suit_Space_Rig_Deathsquad : Obj_Item_Clothing_Suit_Space_Rig {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "rig-deathsquad";
			this.v_allowed = new ByTable(new object [] { 
				typeof(Obj_Item_Weapon_Gun), 
				typeof(Obj_Item_AmmoStorage), 
				typeof(Obj_Item_AmmoCasing), 
				typeof(Obj_Item_Weapon_Melee_Baton), 
				typeof(Obj_Item_Weapon_Handcuffs), 
				typeof(Obj_Item_Weapon_Tank_EmergencyOxygen), 
				typeof(Obj_Item_Weapon_Tank_EmergencyNitrogen), 
				typeof(Obj_Item_Weapon_Pinpointer), 
				typeof(Obj_Item_Weapon_Shield_Energy), 
				typeof(Obj_Item_Weapon_Plastique), 
				typeof(Obj_Item_Weapon_Disk_Nuclear)
			 });
			this.armor = new ByTable().Set( "melee", 80 ).Set( "bullet", 60 ).Set( "laser", 50 ).Set( "energy", 25 ).Set( "bomb", 60 ).Set( "bio", 100 ).Set( "rad", 60 );
			this.max_heat_protection_temperature = 30000;
			this.siemens_coefficient = 0.5;
			this.species_restricted = new ByTable(new object [] { "exclude", "Vox" });
			this.flags = 16640;
			this.icon_state = "rig-deathsquad";
		}

		public Obj_Item_Clothing_Suit_Space_Rig_Deathsquad ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}