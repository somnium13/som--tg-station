// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Storage_Box_SyndieKit_Ammo : Obj_Item_Weapon_Storage_Box_SyndieKit {

		// Function from file: uplink_kits.dm
		public Obj_Item_Weapon_Storage_Box_SyndieKit_Ammo ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			new Obj_Item_AmmoStorage_Speedloader_A357( this );
			return;
		}

	}

}