// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Weather : Game_Data {

		public string name = "storm";
		public int start_up_time = 300;
		public string start_up_message = "The wind begins to pick up.";
		public int duration = 120;
		public int duration_lower = 120;
		public int duration_upper = 120;
		public string duration_message = "A storm has started!";
		public int wind_down = 300;
		public string wind_down_message = "The storm is passing.";
		public int target_z = 1;
		public bool exclude_walls = true;
		public Type area_type = typeof(Zone_Space);
		public int stage = 1;
		public string start_up_overlay = "lava";
		public string duration_overlay = "lava";
		public int overlay_layer = 10;
		public bool purely_aesthetic = false;
		public ByTable impacted_areas = new ByTable();

		// Function from file: weather.dm
		public virtual void update_areas(  ) {
			dynamic N = null;

			
			foreach (dynamic _b in Lang13.Enumerate( this.impacted_areas )) {
				N = _b;
				
				N.layer = this.overlay_layer;
				N.icon = "icons/effects/weather_effects.dmi";
				N.invisibility = 0;

				switch ((int)( this.stage )) {
					case 1:
						N.icon_state = this.start_up_overlay;
						break;
					case 2:
						N.icon_state = this.duration_overlay;
						break;
					case 3:
						N.icon_state = this.start_up_overlay;
						break;
					case 4:
						N.icon_state = Lang13.Initial( N, "icon_state" );
						N.icon = "icons/turf/areas.dmi";
						N.layer = 10;
						N.invisibility = 100;
						N.opacity = 0;
						break;
				}
			}
			return;
		}

		// Function from file: weather.dm
		public virtual void storm_act( Mob_Living L = null ) {
			
			if ( Rand13.PercentChance( 30 ) ) {
				L.WriteMsg( "You're buffeted by the storm!" );
				L.adjustBruteLoss( 1 );
			}
			return;
		}

		// Function from file: weather.dm
		public void weather_wind_down(  ) {
			dynamic M = null;

			this.update_areas();

			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.player_list )) {
				M = _a;
				

				if ( Convert.ToInt32( M.z ) == this.target_z ) {
					M.WriteMsg( this.wind_down_message );
				}
			}
			Task13.Sleep( this.wind_down );
			this.stage = 4;
			this.update_areas();
			return;
		}

		// Function from file: weather.dm
		public void weather_main(  ) {
			dynamic M = null;
			double i = 0;
			Mob_Living L = null;
			dynamic storm_area = null;

			this.update_areas();

			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.player_list )) {
				M = _a;
				

				if ( Convert.ToInt32( M.z ) == this.target_z ) {
					M.WriteMsg( "" + this.duration_message );
				}
			}

			if ( this.purely_aesthetic ) {
				Task13.Sleep( this.duration * 10 );
			} else {
				
				foreach (dynamic _c in Lang13.IterateRange( 1, this.duration - 1 )) {
					i = _c;
					

					foreach (dynamic _b in Lang13.Enumerate( GlobalVars.living_mob_list, typeof(Mob_Living) )) {
						L = _b;
						
						storm_area = GlobalFuncs.get_area( L );

						if ( this.impacted_areas.Contains( storm_area ) ) {
							this.storm_act( L );
						}
					}
					Task13.Sleep( 10 );
				}
			}
			this.stage = 3;
			this.weather_wind_down();
			return;
		}

		// Function from file: weather.dm
		public void weather_start_up(  ) {
			dynamic N = null;
			dynamic M = null;

			
			foreach (dynamic _a in Lang13.Enumerate( GlobalFuncs.get_areas( this.area_type ) )) {
				N = _a;
				

				if ( Convert.ToInt32( N.z ) == this.target_z ) {
					this.impacted_areas.Add( N );
				}
			}
			this.duration = Rand13.Int( this.duration_lower, this.duration_upper );
			this.update_areas();

			foreach (dynamic _b in Lang13.Enumerate( GlobalVars.player_list )) {
				M = _b;
				

				if ( Convert.ToInt32( M.z ) == this.target_z ) {
					M.WriteMsg( this.start_up_message );
				}
			}
			Task13.Schedule( this.start_up_time, (Task13.Closure)(() => {
				this.stage = 2;
				this.weather_main();
				return;
			}));
			return;
		}

	}

}