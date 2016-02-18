// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Construction_Mecha : Construction {

		public Construction_Mecha ( Game_Data atom = null ) : base( atom ) {
			
		}

		// Function from file: mecha_construction_paths.dm
		public override bool custom_action( int? index = null, dynamic diff = null, dynamic used_atom = null, dynamic user = null ) {
			dynamic W = null;
			dynamic C = null;
			dynamic S = null;

			
			if ( diff is Obj_Item_Weapon_Weldingtool ) {
				W = diff;

				if ( ((Obj_Item_Weapon_Weldingtool)W).remove_fuel( 0, used_atom ) ) {
					GlobalFuncs.playsound( this.holder, "sound/items/welder2.ogg", 50, 1 );
				} else {
					return false;
				}
			} else if ( diff is Obj_Item_Weapon_Wrench ) {
				GlobalFuncs.playsound( this.holder, "sound/items/ratchet.ogg", 50, 1 );
			} else if ( diff is Obj_Item_Weapon_Screwdriver ) {
				GlobalFuncs.playsound( this.holder, "sound/items/Screwdriver.ogg", 50, 1 );
			} else if ( diff is Obj_Item_Weapon_Wirecutters ) {
				GlobalFuncs.playsound( this.holder, "sound/items/Wirecutter.ogg", 50, 1 );
			} else if ( diff is Obj_Item_Stack_CableCoil ) {
				C = diff;

				if ( ((Obj_Item_Stack)C).use( 4 ) != 0 ) {
					GlobalFuncs.playsound( this.holder, "sound/items/Deconstruct.ogg", 50, 1 );
				} else {
					used_atom.WriteMsg( "<span class='warning'>There's not enough cable to finish the task!</span>" );
					return false;
				}
			} else if ( diff is Obj_Item_Stack ) {
				S = diff;

				if ( Convert.ToDouble( S.amount ) < 5 ) {
					used_atom.WriteMsg( "<span class='warning'>There's not enough material in this stack!</span>" );
					return false;
				} else {
					((Obj_Item_Stack)S).use( 5 );
				}
			}
			return true;
		}

	}

}