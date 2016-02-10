// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Ore_Cerenkite : Obj_Item_Weapon_Ore {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.material = "cerenkite";
			this.icon_state = "cerenkite";
		}

		public Obj_Item_Weapon_Ore_Cerenkite ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: ores_coins.dm
		public override int? bullet_act( dynamic Proj = null, dynamic def_zone = null ) {
			dynamic L = null;
			Mob_Living_Carbon_Human M = null;

			L = GlobalFuncs.get_turf( this );

			foreach (dynamic _a in Lang13.Enumerate( Map13.FetchViewers( null, L ), typeof(Mob_Living_Carbon_Human) )) {
				M = _a;
				
				M.apply_effect( Rand13.Int( 10, 50 ), "irradiate", 0 );
			}
			GlobalFuncs.qdel( this );
			return null;
		}

		// Function from file: ores_coins.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic L = null;
			Mob_Living_Carbon_Human M = null;

			L = GlobalFuncs.get_turf( a );

			foreach (dynamic _a in Lang13.Enumerate( Map13.FetchViewers( null, L ), typeof(Mob_Living_Carbon_Human) )) {
				M = _a;
				
				M.apply_effect( Rand13.Int( 10, 50 ), "irradiate", 0 );
			}
			GlobalFuncs.qdel( this );
			return null;
		}

		// Function from file: ores_coins.dm
		public override bool ex_act( double? severity = null, dynamic child = null ) {
			dynamic L = null;
			Mob_Living_Carbon_Human M = null;

			L = GlobalFuncs.get_turf( this );

			foreach (dynamic _a in Lang13.Enumerate( Map13.FetchViewers( null, L ), typeof(Mob_Living_Carbon_Human) )) {
				M = _a;
				
				M.apply_effect( Rand13.Int( 10, 50 ), "irradiate", 0 );
			}
			GlobalFuncs.qdel( this );
			return false;
		}

	}

}