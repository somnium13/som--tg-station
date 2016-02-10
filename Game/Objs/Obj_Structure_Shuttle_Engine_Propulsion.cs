// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Shuttle_Engine_Propulsion : Obj_Structure_Shuttle_Engine {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "propulsion";
		}

		public Obj_Structure_Shuttle_Engine_Propulsion ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: shuttle_engines.dm
		public override dynamic cultify(  ) {
			dynamic T = null;

			T = GlobalFuncs.get_turf( this );

			if ( Lang13.Bool( T ) ) {
				((Tile)T).ChangeTurf( typeof(Tile_Simulated_Wall_Cult) );
			}
			base.cultify();
			return null;
		}

	}

}