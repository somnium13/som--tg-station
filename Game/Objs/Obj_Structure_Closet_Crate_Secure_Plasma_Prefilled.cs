// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Closet_Crate_Secure_Plasma_Prefilled : Obj_Structure_Closet_Crate_Secure_Plasma {

		public int? count = 10;

		// Function from file: crates.dm
		public Obj_Structure_Closet_Crate_Secure_Plasma_Prefilled ( dynamic loc = null ) : base( (object)(loc) ) {
			int? i = null;

			i = null;
			i = 0;

			while (( i ??0) < ( this.count ??0)) {
				new Obj_Item_Weapon_Tank_Plasma( this );
				i++;
			}
			return;
		}

	}

}