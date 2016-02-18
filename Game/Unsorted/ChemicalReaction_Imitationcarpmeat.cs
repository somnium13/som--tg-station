// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Imitationcarpmeat : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Imitation Carpmeat";
			this.id = "imitationcarpmeat";
			this.required_reagents = new ByTable().Set( "carpotoxin", 5 );
			this.result_amount = 1;
			this.required_container = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Tofu);
			this.mix_message = "The mixture becomes similar to carp meat.";
		}

		// Function from file: food_mixtures.dm
		public override void on_reaction( Reagents holder = null, double? created_volume = null ) {
			Obj_Item_Weapon_ReagentContainers_Food_Snacks_Carpmeat_Imitation S = null;

			S = new Obj_Item_Weapon_ReagentContainers_Food_Snacks_Carpmeat_Imitation();
			S.loc = GlobalFuncs.get_turf( holder.my_atom );

			if ( holder != null && Lang13.Bool( holder.my_atom ) ) {
				GlobalFuncs.qdel( holder.my_atom );
			}
			return;
		}

	}

}