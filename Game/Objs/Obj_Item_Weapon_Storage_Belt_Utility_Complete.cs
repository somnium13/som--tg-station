// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Storage_Belt_Utility_Complete : Obj_Item_Weapon_Storage_Belt_Utility {

		// Function from file: belt.dm
		public Obj_Item_Weapon_Storage_Belt_Utility_Complete ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			new Obj_Item_Weapon_Screwdriver( this );
			new Obj_Item_Weapon_Wrench( this );
			new Obj_Item_Weapon_Weldingtool( this );
			new Obj_Item_Weapon_Crowbar( this );
			new Obj_Item_Weapon_Wirecutters( this );
			new Obj_Item_Device_Multitool( this );
			new Obj_Item_Stack_CableCoil( this, 30, Rand13.Pick(new object [] { "red", "yellow", "orange" }) );
			return;
		}

	}

}