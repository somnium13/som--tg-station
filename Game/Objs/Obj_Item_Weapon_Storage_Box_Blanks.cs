// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Storage_Box_Blanks : Obj_Item_Weapon_Storage_Box {

		// Function from file: boxes.dm
		public Obj_Item_Weapon_Storage_Box_Blanks ( dynamic loc = null ) : base( (object)(loc) ) {
			int? i = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			i = null;
			i = 0;

			while (( i ??0) < 7) {
				new Obj_Item_AmmoCasing_Shotgun_Blank( this );
				i++;
			}
			return;
		}

	}

}