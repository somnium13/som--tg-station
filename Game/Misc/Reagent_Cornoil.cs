// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Cornoil : Reagent {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Corn Oil";
			this.id = "cornoil";
			this.description = "An oil derived from various types of corn.";
			this.reagent_state = 2;
			this.nutriment_factor = 4;
			this.color = "#302000";
		}

		// Function from file: Chemistry-Reagents.dm
		public override bool reaction_turf( dynamic T = null, double volume = 0 ) {
			dynamic hotspot = null;
			dynamic lowertemp = null;

			
			if ( base.reaction_turf( (object)(T), volume ) ) {
				return true;
			}

			if ( volume >= 3 ) {
				((Tile_Simulated)T).f_wet( 800 );
			}
			hotspot = Lang13.FindIn( typeof(Obj_Fire), T );

			if ( Lang13.Bool( hotspot ) ) {
				lowertemp = ((Ent_Static)T).remove_air( ((GasMixture)T.air).f_total_moles() );
				lowertemp.temperature = Num13.MaxInt( Num13.MinInt( Convert.ToInt32( lowertemp.temperature - 2000 ), Convert.ToInt32( lowertemp.temperature / 2 ) ), 0 );
				((GasMixture)lowertemp).react();
				((Ent_Static)T).assume_air( lowertemp );
				GlobalFuncs.qdel( hotspot );
			}
			return false;
		}

		// Function from file: Chemistry-Reagents.dm
		public override bool on_mob_life( Mob_Living M = null, int? alien = null ) {
			
			if ( base.on_mob_life( M, alien ) ) {
				return true;
			}
			M.nutrition += this.nutriment_factor;
			return false;
		}

	}

}