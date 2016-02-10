// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Landmark_Corpse_Syndicatecommando : Obj_Effect_Landmark_Corpse {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.corpseuniform = typeof(Obj_Item_Clothing_Under_Syndicate);
			this.corpsesuit = typeof(Obj_Item_Clothing_Suit_Space_Rig_Syndi);
			this.corpseshoes = typeof(Obj_Item_Clothing_Shoes_Swat);
			this.corpsegloves = typeof(Obj_Item_Clothing_Gloves_Swat);
			this.corpseradio = typeof(Obj_Item_Device_Radio_Headset);
			this.corpsemask = typeof(Obj_Item_Clothing_Mask_Gas_Syndicate);
			this.corpsehelmet = typeof(Obj_Item_Clothing_Head_Helmet_Space_Rig_Syndi);
			this.corpseback = typeof(Obj_Item_Weapon_Tank_Jetpack_Oxygen);
			this.corpsepocket1 = typeof(Obj_Item_Weapon_Tank_EmergencyOxygen);
			this.corpseid = true;
			this.corpseidjob = "Operative";
			this.corpseidaccess = "Syndicate";
		}

		public Obj_Effect_Landmark_Corpse_Syndicatecommando ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}