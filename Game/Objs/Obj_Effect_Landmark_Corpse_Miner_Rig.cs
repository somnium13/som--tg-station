// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Landmark_Corpse_Miner_Rig : Obj_Effect_Landmark_Corpse_Miner {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.corpsesuit = typeof(Obj_Item_Clothing_Suit_Space_Rig_Mining);
			this.corpsemask = typeof(Obj_Item_Clothing_Mask_Breath);
			this.corpsehelmet = typeof(Obj_Item_Clothing_Head_Helmet_Space_Rig_Mining);
		}

		public Obj_Effect_Landmark_Corpse_Miner_Rig ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}