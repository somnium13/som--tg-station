// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Slider_Toxiccarp : Obj_Item_Weapon_ReagentContainers_Food_Snacks_Slider {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "slider_carp";
		}

		// Function from file: snacks.dm
		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Slider_Toxiccarp ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			((Reagents)this.reagents).add_reagent( "nutriment", 1 );
			((Reagents)this.reagents).add_reagent( "carpotoxin", 2 );
			this.bitesize = 2.5;
			return;
		}

	}

}