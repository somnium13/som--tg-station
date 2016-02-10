// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Disease2_Effect_Horsethroat : Disease2_Effect {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Horse Throat";
			this.stage = 3;
		}

		// Function from file: effect.dm
		public override bool activate( Mob_Living mob = null, bool multiplier = false ) {
			Obj_Item_Clothing_Mask_Horsehead_Magic magichead = null;

			Interface13.Stat( null, GlobalVars.compatible_mobs.Contains( mob.type ) );

			if ( !false ) {
				return false;
			}
			magichead = new Obj_Item_Clothing_Mask_Horsehead_Magic();

			if ( Lang13.Bool( mob.wear_mask ) && !( mob.wear_mask is Obj_Item_Clothing_Mask_Horsehead_Magic ) ) {
				mob.u_equip( mob.wear_mask, true );
				mob.equip_to_slot( magichead, 2 );
			}

			if ( !Lang13.Bool( mob.wear_mask ) ) {
				mob.equip_to_slot( magichead, 2 );
			}
			GlobalFuncs.to_chat( mob, "<span class='warning'>You feel a little horse!</span>" );
			return false;
		}

	}

}