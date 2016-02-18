// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Slimemutate : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Mutation Toxin";
			this.id = "mutationtoxin";
			this.result = "mutationtoxin";
			this.required_reagents = new ByTable().Set( "plasma", 1 );
			this.result_amount = 1;
			this.required_other = true;
			this.required_container = typeof(Obj_Item_SlimeExtract_Green);
		}

		// Function from file: slime_extracts.dm
		public override void on_reaction( Reagents holder = null, double? created_volume = null ) {
			GlobalFuncs.feedback_add_details( "slime_cores_used", "" + this.type );
			return;
		}

	}

}