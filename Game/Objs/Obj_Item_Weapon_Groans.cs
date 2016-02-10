// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Groans : Obj_Item_Weapon {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "toddler";
		}

		public Obj_Item_Weapon_Groans ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: drinks.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			dynamic T = null;
			Obj_Item_Weapon_ReagentContainers_Food_Drinks_Groans A = null;

			GlobalFuncs.to_chat( user, "Now spawning groans." );
			T = GlobalFuncs.get_turf( user.loc );
			A = new Obj_Item_Weapon_ReagentContainers_Food_Drinks_Groans( T );
			A.desc += " It also smells like a toddler.";
			return null;
		}

	}

}