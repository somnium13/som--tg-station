// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Closet_Syndicate_Nuclear : Obj_Structure_Closet_Syndicate {

		// Function from file: syndicate.dm
		public Obj_Structure_Closet_Syndicate_Nuclear ( dynamic loc = null ) : base( (object)(loc) ) {
			Obj_Item_Device_Radio_Uplink U = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			Task13.Sleep( 2 );
			new Obj_Item_AmmoStorage_Magazine_A12mm( this );
			new Obj_Item_AmmoStorage_Magazine_A12mm( this );
			new Obj_Item_AmmoStorage_Magazine_A12mm( this );
			new Obj_Item_AmmoStorage_Magazine_A12mm( this );
			new Obj_Item_AmmoStorage_Magazine_A12mm( this );
			new Obj_Item_Weapon_Storage_Box_Handcuffs( this );
			new Obj_Item_Weapon_Storage_Box_Flashbangs( this );
			new Obj_Item_Weapon_Storage_Box_Emps( this );
			new Obj_Item_Weapon_Gun_Energy_Gun( this );
			new Obj_Item_Weapon_Gun_Energy_Gun( this );
			new Obj_Item_Weapon_Gun_Energy_Gun( this );
			new Obj_Item_Weapon_Gun_Energy_Gun( this );
			new Obj_Item_Weapon_Gun_Energy_Gun( this );
			new Obj_Item_Weapon_Pinpointer_Nukeop( this );
			new Obj_Item_Weapon_Pinpointer_Nukeop( this );
			new Obj_Item_Weapon_Pinpointer_Nukeop( this );
			new Obj_Item_Weapon_Pinpointer_Nukeop( this );
			new Obj_Item_Weapon_Pinpointer_Nukeop( this );
			new Obj_Item_Device_Pda_Syndicate( this );
			U = new Obj_Item_Device_Radio_Uplink(  );
			U.hidden_uplink.uses = 40;
			return;
		}

	}

}