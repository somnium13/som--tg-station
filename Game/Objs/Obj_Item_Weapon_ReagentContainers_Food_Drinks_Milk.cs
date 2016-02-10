// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Drinks_Milk : Obj_Item_Weapon_ReagentContainers_Food_Drinks {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "carton";
			this.vending_cat = "dairy products";
			this.icon_state = "milk";
		}

		// Function from file: drinks.dm
		public Obj_Item_Weapon_ReagentContainers_Food_Drinks_Milk ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			((Reagents)this.reagents).add_reagent( "milk", 50 );
			this.pixel_x = Rand13.Int( -10, 10 );
			this.pixel_y = Rand13.Int( -10, 10 );
			return;
		}

	}

}