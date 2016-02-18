// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Objective_Hijackclone : Objective {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.explanation_text = "Hijack the emergency shuttle by ensuring only you (or your copies) escape.";
			this.dangerrating = 25;
		}

		public Objective_Hijackclone ( string text = null ) : base( text ) {
			
		}

		// Function from file: objective.dm
		public override int check_completion(  ) {
			dynamic A = null;
			Mob_Living player = null;
			Mob_Living player2 = null;

			
			if ( !Lang13.Bool( this.owner.current ) ) {
				return 0;
			}

			if ( GlobalVars.SSshuttle.emergency.mode < 6 ) {
				return 0;
			}
			A = GlobalVars.SSshuttle.emergency.areaInstance;

			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.player_list, typeof(Mob_Living) )) {
				player = _a;
				

				if ( player.mind != null && player.mind != this.owner ) {
					
					if ( player.stat != 2 ) {
						
						if ( player is Mob_Living_Silicon ) {
							continue;
						}

						if ( GlobalFuncs.get_area( player ) == A ) {
							
							if ( player.real_name != this.owner.current.real_name && !( GlobalFuncs.get_turf( player.mind.current ) is Tile_Simulated_Floor_Plasteel_Shuttle_Red ) ) {
								return 0;
							}
						}
					}
				}
			}

			foreach (dynamic _b in Lang13.Enumerate( GlobalVars.player_list, typeof(Mob_Living) )) {
				player2 = _b;
				

				if ( player2.mind != null && player2.mind != this.owner ) {
					
					if ( player2.stat != 2 ) {
						
						if ( player2 is Mob_Living_Silicon ) {
							continue;
						}

						if ( GlobalFuncs.get_area( player2 ) == A ) {
							
							if ( player2.real_name == this.owner.current.real_name && !( GlobalFuncs.get_turf( player2.mind.current ) is Tile_Simulated_Floor_Plasteel_Shuttle_Red ) ) {
								return 1;
							}
						}
					}
				}
			}
			return 0;
		}

	}

}