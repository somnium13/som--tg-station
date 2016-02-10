// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Sundae : Obj_Item_Weapon_ReagentContainers_Food_Snacks {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.food_flags = 6;
			this.icon_state = "sundae";
		}

		// Function from file: snacks.dm
		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Sundae ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			((Reagents)this.reagents).add_reagent( "nutriment", 5 );
			((Reagents)this.reagents).add_reagent( "sugar", 5 );
			((Reagents)this.reagents).add_reagent( "ice", 5 );
			this.bitesize = 3;
			return;
		}

	}

}