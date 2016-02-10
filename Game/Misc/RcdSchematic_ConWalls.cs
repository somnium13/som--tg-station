// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class RcdSchematic_ConWalls : RcdSchematic {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Build walls";
			this.icon = "icons/turf/walls.dmi";
			this.icon_state = "metal0";
			this.category = "Construction";
			this.energy_cost = 3;
		}

		public RcdSchematic_ConWalls ( dynamic n_master = null ) : base( (object)(n_master) ) {
			
		}

		// Function from file: engi.dm
		public override dynamic attack( dynamic A = null, dynamic user = null ) {
			dynamic T = null;

			
			if ( !( A is Tile_Simulated_Floor ) ) {
				return 1;
			}
			T = A;
			GlobalFuncs.to_chat( user, "Building wall" );
			GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/machines/click.ogg", 50, 1 );

			if ( GlobalFuncs.do_after( user, A, 20 ) ) {
				
				if ( this.master.get_energy( user ) < this.energy_cost ) {
					return 1;
				}
				GlobalFuncs.playsound( GlobalFuncs.get_turf( this.master ), "sound/items/Deconstruct.ogg", 50, 1 );
				((Tile)T).ChangeTurf( typeof(Tile_Simulated_Wall) );
				return 0;
			}
			return 1;
		}

	}

}