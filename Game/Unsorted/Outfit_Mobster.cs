// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Outfit_Mobster : Outfit {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Mobster";
			this.uniform = typeof(Obj_Item_Clothing_Under_SuitJacket_ReallyBlack);
			this.head = typeof(Obj_Item_Clothing_Head_Fedora);
			this.shoes = typeof(Obj_Item_Clothing_Shoes_Laceup);
			this.gloves = typeof(Obj_Item_Clothing_Gloves_Color_Black);
			this.ears = typeof(Obj_Item_Device_Radio_Headset);
			this.glasses = typeof(Obj_Item_Clothing_Glasses_Sunglasses);
			this.r_hand = typeof(Obj_Item_Weapon_Gun_Projectile_Automatic_Tommygun);
			this.id = typeof(Obj_Item_Weapon_Card_Id);
		}

		// Function from file: standard.dm
		public override void post_equip( Mob H = null, int? visualsOnly = null ) {
			visualsOnly = visualsOnly ?? GlobalVars.FALSE;

			Obj_Item_Weapon_Card_Id W = null;

			
			if ( Lang13.Bool( visualsOnly ) ) {
				return;
			}
			W = ((dynamic)H).wear_id;
			W.assignment = "Assistant";
			W.registered_name = H.real_name;
			W.update_label();
			return;
		}

	}

}