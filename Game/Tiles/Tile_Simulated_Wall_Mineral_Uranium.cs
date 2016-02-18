// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Tile_Simulated_Wall_Mineral_Uranium : Tile_Simulated_Wall_Mineral {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.walltype = "uranium";
			this.mineral = "uranium";
			this.sheet_type = typeof(Obj_Item_Stack_Sheet_Mineral_Uranium);
			this.canSmoothWith = new ByTable(new object [] { typeof(Tile_Simulated_Wall_Mineral_Uranium), typeof(Obj_Structure_Falsewall_Uranium) });
			this.icon = "icons/turf/walls/uranium_wall.dmi";
			this.icon_state = "uranium";
		}

		public Tile_Simulated_Wall_Mineral_Uranium ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: walls_mineral.dm
		public override bool Bumped( dynamic AM = null ) {
			this.radiate();
			base.Bumped( (object)(AM) );
			return false;
		}

		// Function from file: walls_mineral.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			this.radiate();
			base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
			return null;
		}

		// Function from file: walls_mineral.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			this.radiate();
			base.attack_hand( (object)(a), b, c );
			return null;
		}

		// Function from file: walls_mineral.dm
		public void radiate(  ) {
			Tile_Simulated_Wall_Mineral_Uranium T = null;

			
			if ( !( this.active == true ) ) {
				
				if ( Game13.time > this.last_event + 15 ) {
					this.active = true;
					GlobalFuncs.radiation_pulse( GlobalFuncs.get_turf( this ), 3, 3, 4, false );

					foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInRangeExcludeThis( this, 1 ), typeof(Tile_Simulated_Wall_Mineral_Uranium) )) {
						T = _a;
						
						T.radiate();
					}
					this.last_event = Game13.time;
					this.active = null;
					return;
				}
			}
			return;
		}

	}

}