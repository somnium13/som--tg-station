// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mineral_Gibtonite : Mineral {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.display_name = "Gibtonite";
			this.name = "Gibtonite";
			this.result_amount = 1;
			this.ore = typeof(Obj_Item_Weapon_Gibtonite);
		}

		// Function from file: minerals.dm
		public override void UpdateTurf( Tile_Unsimulated_Mineral T = null ) {
			
			if ( !( T is Tile_Unsimulated_Mineral_Gibtonite ) ) {
				T.ChangeTurf( typeof(Tile_Unsimulated_Mineral_Gibtonite) );
			} else {
				base.UpdateTurf( T );
			}
			return;
		}

	}

}