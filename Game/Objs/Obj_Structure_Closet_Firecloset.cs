// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Closet_Firecloset : Obj_Structure_Closet {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_closed = "firecloset";
			this.icon_opened = "fireclosetopen";
			this.icon_state = "firecloset";
		}

		// Function from file: utility_closets.dm
		public Obj_Structure_Closet_Firecloset ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			new Obj_Item_Clothing_Suit_Fire_Firefighter( this );
			new Obj_Item_Clothing_Mask_Gas( this );
			new Obj_Item_Weapon_Tank_Oxygen_Red( this );
			new Obj_Item_Weapon_Extinguisher( this );
			new Obj_Item_Clothing_Head_Hardhat_Red( this );
			return;
		}

		// Function from file: utility_closets.dm
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			
			if ( !this.opened ) {
				this.icon_state = this.icon_closed;
			} else {
				this.icon_state = this.icon_opened;
			}
			return null;
		}

	}

}