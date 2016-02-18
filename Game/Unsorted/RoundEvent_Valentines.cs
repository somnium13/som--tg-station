// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class RoundEvent_Valentines : RoundEvent {

		// Function from file: vday.dm
		public override void announce(  ) {
			GlobalFuncs.priority_announce( "It's Valentine's Day! Give a valentine to that special someone!" );
			return;
		}

		// Function from file: vday.dm
		public override bool start(  ) {
			Mob_Living_Carbon_Human H = null;
			dynamic b = null;

			base.start();

			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.mob_list, typeof(Mob_Living_Carbon_Human) )) {
				H = _a;
				
				H.put_in_hands( new Obj_Item_Weapon_Valentine() );
				b = Lang13.FindIn( typeof(Obj_Item_Weapon_Storage_Backpack), H.contents );
				new Obj_Item_Weapon_ReagentContainers_Food_Snacks_Candyheart( b );
			}
			return false;
		}

	}

}