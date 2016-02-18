// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class RoundEvent_Slaughter : RoundEvent {

		public string key_of_slaughter = null;

		// Function from file: slaughterevent.dm
		public override bool start(  ) {
			this.get_slaughter();
			return false;
		}

		// Function from file: slaughterevent.dm
		public void find_slaughter(  ) {
			GlobalFuncs.message_admins( "Attempted to spawn a slaughter demon but there was no players available. Will try again momentarily." );
			Task13.Schedule( 50, (Task13.Closure)(() => {
				
				if ( this.get_slaughter( true ) ) {
					GlobalFuncs.message_admins( "Situation has been resolved, " + this.key_of_slaughter + " has been spawned as a slaughter demon." );
					GlobalFuncs.log_game( "" + this.key_of_slaughter + " was spawned as a slaughter demon by an event." );
					return;
				}
				GlobalFuncs.message_admins( "Unfortunately, no candidates were available for becoming a slaughter demon. Shutting down." );
				return;
			}));
			this.kill(); return;
		}

		// Function from file: slaughterevent.dm
		public bool get_slaughter( bool? end_if_fail = null ) {
			end_if_fail = end_if_fail ?? false;

			ByTable candidates = null;
			dynamic C = null;
			Mind player_mind = null;
			ByTable spawn_locs = null;
			Obj_Effect_Landmark L = null;
			dynamic holder = null;
			Mob_Living_SimpleAnimal_Slaughter S = null;

			this.key_of_slaughter = null;

			if ( !Lang13.Bool( this.key_of_slaughter ) ) {
				candidates = GlobalFuncs.get_candidates( "xenomorph" );

				if ( !( candidates.len != 0 ) ) {
					
					if ( end_if_fail == true ) {
						return false;
					}
					this.find_slaughter(); return false;
				}
				C = Rand13.PickFromTable( candidates );
				this.key_of_slaughter = C.key;
			}

			if ( !Lang13.Bool( this.key_of_slaughter ) ) {
				
				if ( end_if_fail == true ) {
					return false;
				}
				this.find_slaughter(); return false;
			}
			player_mind = new Mind( this.key_of_slaughter );
			player_mind.active = true;
			spawn_locs = new ByTable();

			foreach (dynamic _b in Lang13.Enumerate( GlobalVars.landmarks_list, typeof(Obj_Effect_Landmark) )) {
				L = _b;
				

				if ( L.loc is Tile ) {
					
					switch ((string)( L.name )) {
						case "carpspawn":
							spawn_locs.Add( L.loc );
							break;
					}
				}
			}

			if ( !( spawn_locs != null ) ) {
				this.find_slaughter(); return false;
			}
			holder = GlobalFuncs.PoolOrNew( typeof(Obj_Effect_Dummy_Slaughter), Rand13.PickFromTable( spawn_locs ) );
			S = new Mob_Living_SimpleAnimal_Slaughter( holder );
			S.holder = holder;
			player_mind.transfer_to( S );
			player_mind.assigned_role = "Slaughter Demon";
			player_mind.special_role = "Slaughter Demon";
			GlobalVars.ticker.mode.traitors.Or( player_mind );
			S.WriteMsg( S.playstyle_string );
			S.WriteMsg( "<B>You are currently not currently in the same plane of existence as the station. Blood Crawl near a blood pool to manifest.</B>" );
			S.WriteMsg( "sound/magic/demon_dies.ogg" );
			GlobalFuncs.message_admins( "" + this.key_of_slaughter + " has been made into a slaughter demon by an event." );
			GlobalFuncs.log_game( "" + this.key_of_slaughter + " was spawned as a slaughter demon by an event." );
			return true;
		}

	}

}