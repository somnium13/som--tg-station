// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Carbondioxide : Reagent {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Carbon Dioxide";
			this.id = "co2";
			this.reagent_state = 3;
			this.description = "A gas commonly produced by burning carbon fuels.";
			this.color = "#B0B0B0";
		}

		// Function from file: other_reagents.dm
		public override void reaction_turf( dynamic T = null, double? volume = null ) {
			
			if ( T is Tile_Simulated ) {
				((Tile_Simulated)T).atmos_spawn_air( 18, ( volume ??0) / 5 );
			}
			return;
		}

		// Function from file: other_reagents.dm
		public override bool reaction_obj( dynamic O = null, double? volume = null ) {
			
			if ( !Lang13.Bool( O ) || !Lang13.Bool( volume ) ) {
				return false;
			}
			((Ent_Dynamic)O).atmos_spawn_air( 18, ( volume ??0) / 5 );
			return false;
		}

	}

}