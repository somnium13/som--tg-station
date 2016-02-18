// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Slimefire : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Slime fire";
			this.id = "m_fire";
			this.required_reagents = new ByTable().Set( "plasma", 1 );
			this.result_amount = 1;
			this.required_container = typeof(Obj_Item_SlimeExtract_Orange);
			this.required_other = true;
		}

		// Function from file: slime_extracts.dm
		public override void on_reaction( Reagents holder = null, double? created_volume = null ) {
			dynamic TU = null;
			dynamic T = null;

			GlobalFuncs.feedback_add_details( "slime_cores_used", "" + this.type );
			TU = GlobalFuncs.get_turf( holder.my_atom );
			((Ent_Static)TU).visible_message( "<span class='danger'>The slime extract begins to vibrate adorably !</span>" );
			Task13.Schedule( 50, (Task13.Closure)(() => {
				
				if ( holder != null && Lang13.Bool( holder.my_atom ) ) {
					T = GlobalFuncs.get_turf( holder.my_atom );

					if ( T is Tile_Simulated ) {
						T.atmos_spawn_air( 5, 50 );
					}
				}
				return;
			}));
			return;
		}

	}

}