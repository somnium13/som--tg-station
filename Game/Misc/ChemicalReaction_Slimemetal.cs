// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Slimemetal : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Slime Metal";
			this.id = "m_metal";
			this.required_reagents = new ByTable().Set( "plasma", 5 );
			this.result_amount = 1;
			this.required_container = typeof(Obj_Item_SlimeExtract_Metal);
			this.required_other = true;
		}

		// Function from file: Chemistry-Recipes.dm
		public override void on_reaction( Reagents holder = null, int? created_volume = null ) {
			Game_Data M = null;
			Obj_Item_Stack_Sheet_Plasteel P = null;

			M = GlobalFuncs.getFromPool( typeof(Obj_Item_Stack_Sheet_Metal), GlobalFuncs.get_turf( holder.my_atom ) );
			((dynamic)M).amount = 15;
			P = new Obj_Item_Stack_Sheet_Plasteel();
			P.amount = 5;
			P.loc = GlobalFuncs.get_turf( holder.my_atom );
			return;
		}

	}

}