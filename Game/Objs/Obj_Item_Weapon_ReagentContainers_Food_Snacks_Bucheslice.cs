// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Bucheslice : Obj_Item_Weapon_ReagentContainers_Food_Snacks {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.trash = typeof(Obj_Item_Trash_Plate);
			this.bitesize = 2;
			this.food_flags = 6;
			this.icon_state = "buche_slice";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Bucheslice ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}