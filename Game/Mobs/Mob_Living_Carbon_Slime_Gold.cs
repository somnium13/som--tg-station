// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_Carbon_Slime_Gold : Mob_Living_Carbon_Slime {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.colour = "gold";
			this.primarytype = typeof(Mob_Living_Carbon_Slime_Gold);
			this.adulttype = typeof(Mob_Living_Carbon_Slime_Adult_Gold);
			this.coretype = typeof(Obj_Item_SlimeExtract_Gold);
			this.icon_state = "gold baby slime";
		}

		public Mob_Living_Carbon_Slime_Gold ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}