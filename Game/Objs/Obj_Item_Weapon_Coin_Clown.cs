// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Coin_Clown : Obj_Item_Weapon_Coin {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.material = "$clown";
			this.credits = 1000;
			this.melt_temperature = 1773.1500244140625;
			this.icon_state = "coin_clown";
		}

		public Obj_Item_Weapon_Coin_Clown ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}