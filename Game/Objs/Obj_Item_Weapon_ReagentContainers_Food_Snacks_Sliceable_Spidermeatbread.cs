// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Sliceable_Spidermeatbread : Obj_Item_Weapon_ReagentContainers_Food_Snacks_Sliceable {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.slice_path = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Spidermeatbreadslice);
			this.slices_num = 5;
			this.food_flags = 1;
			this.icon_state = "spidermeatbread";
		}

		// Function from file: snacks.dm
		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Sliceable_Spidermeatbread ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			((Reagents)this.reagents).add_reagent( "nutriment", 30 );
			this.bitesize = 2;
			return;
		}

	}

}