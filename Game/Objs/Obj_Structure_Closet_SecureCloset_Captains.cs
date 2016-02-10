// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Closet_SecureCloset_Captains : Obj_Structure_Closet_SecureCloset {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.req_access = new ByTable(new object [] { 20 });
			this.icon_closed = "capsecure";
			this.icon_locked = "capsecure1";
			this.icon_opened = "capsecureopen";
			this.icon_broken = "capsecurebroken";
			this.icon_off = "capsecureoff";
			this.icon_state = "capsecure1";
		}

		// Function from file: security.dm
		public Obj_Structure_Closet_SecureCloset_Captains ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			Task13.Sleep( 2 );

			if ( Rand13.PercentChance( 50 ) ) {
				new Obj_Item_Weapon_Storage_Backpack_Captain( this );
			} else {
				new Obj_Item_Weapon_Storage_Backpack_SatchelCap( this );
			}
			new Obj_Item_Clothing_Suit_Captunic( this );
			new Obj_Item_Clothing_Suit_Storage_Capjacket( this );
			new Obj_Item_Clothing_Head_Helmet_Cap( this );
			new Obj_Item_Clothing_Under_Rank_Captain( this );
			new Obj_Item_Clothing_Suit_Armor_Vest( this );
			new Obj_Item_Weapon_Cartridge_Captain( this );
			new Obj_Item_Clothing_Head_Helmet_Swat( this );
			new Obj_Item_Clothing_Shoes_Brown( this );
			new Obj_Item_Device_Radio_Headset_Heads_Captain(  );
			new Obj_Item_Clothing_Gloves_Captain( this );
			new Obj_Item_Weapon_Gun_Energy_Gun( this );
			new Obj_Item_Clothing_Suit_Armor_Captain( this );
			new Obj_Item_Weapon_Melee_Telebaton( this );
			new Obj_Item_Clothing_Under_Dress_DressCap( this );
			new Obj_Item_Device_Gps_Secure( this );
			return;
		}

	}

}