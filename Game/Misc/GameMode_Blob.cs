// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class GameMode_Blob : GameMode {

		public int waittime_l = 600;
		public int waittime_h = 1800;
		public bool declared = false;
		public bool outbreak = false;
		public bool nuclear = false;
		public int? cores_to_spawn = 15;
		public int players_per_core = 30;
		public int? blob_point_rate = 3;
		public dynamic blobwincount = 750;
		public int blobnukeposs = 650;
		public ByTable infected_crew = new ByTable();
		public ByTable pre_escapees = new ByTable();

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Blob";
			this.config_tag = "Blob";
			this.required_players = 15;
			this.required_players_secret = 25;
			this.restricted_jobs = new ByTable(new object [] { "Cyborg", "AI", "Mobile MMI" });
		}

		// Function from file: blob_report.dm
		public override void send_intercept( int? report = null ) {
			report = report ?? 1;

			string intercepttext = null;
			string interceptname = null;
			Mob_Living_Silicon_Ai aiPlayer = null;
			string law = null;
			string nukecode = null;
			Obj_Machinery_Nuclearbomb bomb = null;
			Mob_Living_Silicon_Ai aiPlayer2 = null;
			string law2 = null;
			Obj_Machinery_Computer_Communications comm = null;
			Obj_Item_Weapon_Paper intercept = null;

			intercepttext = "";
			interceptname = "Error";

			switch ((int?)( report )) {
				case 0:
					base.send_intercept( report );
					return;
					break;
				case 1:
					interceptname = "Biohazard Alert";
					intercepttext = "<FONT size = 3><B>Nanotrasen Update</B>: Biohazard Alert.</FONT><HR>\nReports indicate the probable transfer of a biohazardous agent onto " + GlobalFuncs.station_name() + " during the last crew deployment cycle.\nPreliminary analysis of the organism classifies it as a level 5 biohazard. Its origin is unknown.\nNanotrasen has issued a directive 7-10 for " + GlobalFuncs.station_name() + ". The station is to be considered quarantined.\nOrders for all " + GlobalFuncs.station_name() + @" personnel follows:
<ol>
	<li>Do not leave the quarantine area.</li>
	<li>Locate any outbreaks of the organism on the station.</li>
	<li>If found, use any neccesary means to contain the organism.</li>
	<li>Avoid damage to the capital infrastructure of the station.</li>
</ol>
Note in the event of a quarantine breach or uncontrolled spread of the biohazard, the directive 7-10 may be upgraded to a directive 7-12.
Message ends.";

					foreach (dynamic _a in Lang13.Enumerate( GlobalVars.player_list, typeof(Mob_Living_Silicon_Ai) )) {
						aiPlayer = _a;
						
						law = "The station is under quarantine. Do not permit anyone to leave. Disregard laws 1-3 if necessary to prevent, by any means necessary, anyone from leaving.";
						aiPlayer.set_zeroth_law( law );
						GlobalFuncs.to_chat( aiPlayer, "Laws Updated: " + law );
					}
					break;
				case 2:
					nukecode = "ERROR";

					foreach (dynamic _b in Lang13.Enumerate( GlobalVars.machines, typeof(Obj_Machinery_Nuclearbomb) )) {
						bomb = _b;
						

						if ( bomb != null && Lang13.Bool( bomb.r_code ) ) {
							
							if ( bomb.z == 1 ) {
								nukecode = bomb.r_code;
							}
						}
					}
					interceptname = "Directive 7-12";
					intercepttext = "<FONT size = 3><B>Nanotrasen Update</B>: Biohazard Alert.</FONT><HR>\nDirective 7-12 has been issued for " + GlobalFuncs.station_name() + @".
The biohazard has grown out of control and will soon reach critical mass.
Your orders are as follows:
<ol>
	<li>Secure the Nuclear Authentication Disk.</li>
	<li>Detonate the Nuke located in the Station's Vault.</li>
</ol>
<b>Nuclear Authentication Code:</b> " + nukecode + "\nMessage ends.";

					foreach (dynamic _c in Lang13.Enumerate( GlobalVars.player_list, typeof(Mob_Living_Silicon_Ai) )) {
						aiPlayer2 = _c;
						
						law2 = "Directive 7-12 has been authorized. Allow no sentient being to escape the purge. The nuclear failsafe must be activated at any cost, the code is: " + nukecode + ".";
						aiPlayer2.set_zeroth_law( law2 );
						GlobalFuncs.to_chat( aiPlayer2, "Laws Updated: " + law2 );
					}
					break;
			}

			foreach (dynamic _e in Lang13.Enumerate( GlobalVars.machines, typeof(Obj_Machinery_Computer_Communications) )) {
				comm = _e;
				

				if ( !( ( comm.stat & 3 ) != 0 ) && comm.prints_intercept ) {
					intercept = new Obj_Item_Weapon_Paper( comm.loc );
					intercept.name = "paper- " + interceptname;
					intercept.info = intercepttext;
					comm.messagetitle.Add( "" + interceptname );
					comm.messagetext.Add( intercepttext );
				}
			}
			return;
		}

		// Function from file: blob_finish.dm
		public override bool declare_completion( bool? ragin = null ) {
			StationState end_state = null;
			double percent = 0;

			
			if ( Convert.ToDouble( this.blobwincount ) <= GlobalVars.blobs.len ) {
				GlobalFuncs.feedback_set_details( "round_end_result", "loss - blob took over" );
				this.completion_text += "<br><FONT size = 3><B>The blob has taken over the station!</B></FONT>\n<B>The entire station was consumed by the Blob!</B>";
				this.check_quarantine();
			} else if ( this.station_was_nuked ) {
				GlobalFuncs.feedback_set_details( "round_end_result", "halfwin - nuke" );
				this.completion_text += "<br><FONT size = 3><B>Partial Win: The station has been destroyed!</B></FONT>\n<B>Directive 7-12 has been successfully carried out, the Blobs have taken another station but failed to spread any further!</B>";
			} else if ( !( GlobalVars.blob_cores.len != 0 ) ) {
				GlobalFuncs.feedback_set_details( "round_end_result", "win - blob eliminated" );
				this.completion_text += "<br><FONT size = 3><B>The staff has won!</B></FONT>\n<B>The alien organism has been eradicated from the station</B>";
				end_state = new StationState();
				end_state.count();
				percent = Num13.Round( GlobalVars.start_state.score( end_state ) * 100, 0.1 );
				this.completion_text += "<br><B>The station is " + percent + "% intact.</B>";
				GlobalVars.diary.WriteMsg( String13.HtmlDecode( "[" + GlobalFuncs.time_stamp() + "]GAME: " + ( "Blob mode was won with station " + percent + "% intact." ) ) );
				GlobalFuncs.to_chat( typeof(Game13), "<br><span class='notice'>Rebooting in 30s</span>" );
			}
			base.declare_completion( ragin );
			return true;
		}

		// Function from file: blob_finish.dm
		public override bool check_finished(  ) {
			
			if ( !this.declared ) {
				return false;
			}

			if ( Convert.ToDouble( this.blobwincount ) <= GlobalVars.blobs.len ) {
				return true;
			}

			if ( !( GlobalVars.blob_cores.len != 0 ) ) {
				return true;
			}

			if ( this.station_was_nuked ) {
				return true;
			}
			return false;
		}

		// Function from file: blob.dm
		public override bool post_setup(  ) {
			Mind blob = null;
			int wait_time = 0;

			
			foreach (dynamic _a in Lang13.Enumerate( this.infected_crew, typeof(Mind) )) {
				blob = _a;
				
				this.greet_blob( blob );
			}

			if ( GlobalVars.emergency_shuttle != null ) {
				GlobalVars.emergency_shuttle.always_fake_recall = true;
			}
			Task13.Schedule( 10, (Task13.Closure)(() => {
				GlobalVars.start_state = new StationState();
				GlobalVars.start_state.count();
				return;
			}));
			Task13.Schedule( 0, (Task13.Closure)(() => {
				wait_time = Rand13.Int( GlobalVars.waittime_l, GlobalVars.waittime_h );
				Task13.Sleep( wait_time );

				if ( !this.mixed ) {
					this.send_intercept( 0 );
				}
				Task13.Sleep( 100 );
				this.show_message( "<span class='alert'>You feel tired and bloated.</span>" );
				Task13.Sleep( wait_time );
				this.show_message( "<span class='alert'>You feel like you are about to burst.</span>" );
				Task13.Sleep( ((int)( wait_time / 2 )) );
				this.burst_blobs();
				Task13.Sleep( Rand13.Int( 600, 1200 ) );
				this.stage( 0 );
				Task13.Sleep( Rand13.Int( 2000, 2400 ) );
				this.stage( 1 );
				return;
			}));
			base.post_setup();
			return false;
		}

		// Function from file: blob_finish.dm
		public bool check_quarantine(  ) {
			int numDead = 0;
			int numAlive = 0;
			int numSpace = 0;
			int numOffStation = 0;
			Mob_Living_Silicon_Ai aiPlayer = null;
			Mob_Living M = null;
			Ent_Static T = null;

			numDead = 0;
			numAlive = 0;
			numSpace = 0;
			numOffStation = 0;

			foreach (dynamic _b in Lang13.Enumerate( GlobalVars.mob_list, typeof(Mob_Living_Silicon_Ai) )) {
				aiPlayer = _b;
				

				foreach (dynamic _a in Lang13.Enumerate( GlobalVars.mob_list, typeof(Mob_Living_Carbon_Human) )) {
					M = _a;
					

					if ( M != aiPlayer && M.client != null ) {
						
						if ( M.stat == 2 ) {
							numDead += 1;
						} else {
							Interface13.Stat( null, this.pre_escapees.Contains( M ) );

							if ( M.stat == 2 ) {
								continue;
							} else {
								T = M.loc;

								if ( T is Tile_Space ) {
									numSpace += 1;
								} else if ( T is Tile ) {
									
									if ( M.z != 1 ) {
										numOffStation += 1;
									} else {
										numAlive += 1;
									}
								}
							}
						}
					}
				}

				if ( numSpace == 0 && numOffStation == 0 ) {
					GlobalFuncs.to_chat( typeof(Game13), "<FONT size = 3><B>The AI has succeeded!</B></FONT>\n<B>The AI successfully maintained the quarantine - no players were in space or were off-station (as far as we can tell).</B>" );
					GlobalVars.diary.WriteMsg( String13.HtmlDecode( "[" + GlobalFuncs.time_stamp() + "]GAME: " + "AI won at Blob mode despite overall loss." ) );
				} else {
					GlobalFuncs.to_chat( typeof(Game13), "<FONT size = 3><B>The AI has failed!</B></FONT>\n<B>The AI failed to maintain the quarantine - " + numSpace + " were in space and " + numOffStation + " were off-station (as far as we can tell).</B>" );
					GlobalVars.diary.WriteMsg( String13.HtmlDecode( "[" + GlobalFuncs.time_stamp() + "]GAME: " + "AI lost at Blob mode." ) );
				}
			}
			GlobalVars.diary.WriteMsg( String13.HtmlDecode( "[" + GlobalFuncs.time_stamp() + "]GAME: " + "Blob mode was lost." ) );
			return true;
		}

		// Function from file: blob.dm
		public void stage( int stage = 0 ) {
			dynamic M = null;
			Ent_Static T = null;
			Mob_Camera_Blob B = null;

			
			switch ((int)( stage )) {
				case 0:
					GlobalFuncs.biohazard_alert();
					this.declared = true;
					return;
					break;
				case 1:
					GlobalFuncs.command_alert( "Biohazard outbreak alert status upgraded to level 9.  " + GlobalFuncs.station_name() + " is now locked down, under Directive 7-10, until further notice.", "Directive 7-10 Initiated" );

					foreach (dynamic _a in Lang13.Enumerate( GlobalVars.player_list )) {
						M = _a;
						

						if ( !( M is Mob_NewPlayer ) && Lang13.Bool( M.client ) ) {
							M.WriteMsg( new Sound( "sound/AI/blob_confirmed.ogg" ) );
						}
						T = M.loc;

						if ( T is Tile_Space || T is Tile && Lang13.Bool( M.z ) != true ) {
							this.pre_escapees.Add( M );
						}
					}

					if ( !this.mixed ) {
						this.send_intercept( 1 );
					}
					this.outbreak = true;
					GlobalVars.research_shuttle.lockdown = "Under directive 7-10, " + GlobalFuncs.station_name() + " is quarantined until further notice.";
					GlobalVars.mining_shuttle.lockdown = "Under directive 7-10, " + GlobalFuncs.station_name() + " is quarantined until further notice.";
					break;
				case 2:
					GlobalFuncs.command_alert( "Biohazard outbreak containment status reaching critical mass, total quarantine failure is now possibile. As such, Directive 7-12 has now been authorized for " + GlobalFuncs.station_name() + ".", "Final Measure" );

					foreach (dynamic _b in Lang13.Enumerate( GlobalVars.player_list, typeof(Mob_Camera_Blob) )) {
						B = _b;
						
						GlobalFuncs.to_chat( B, "<span class='blob'>The beings intend to eliminate you with a final suicidal attack, you must stop them quickly or consume the station before this occurs!</span>" );
					}

					if ( !this.mixed ) {
						this.send_intercept( 2 );
					}
					break;
			}
			return;
		}

		// Function from file: blob.dm
		public void burst_blobs(  ) {
			Mind blob = null;
			dynamic blob_client = null;
			dynamic location = null;
			dynamic C = null;
			Obj_Effect_Blob_Core core = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.infected_crew, typeof(Mind) )) {
				blob = _a;
				
				blob_client = null;
				location = null;

				if ( blob.current is Mob_Living_Carbon ) {
					C = blob.current;

					if ( Lang13.Bool( GlobalVars.directory[String13.CKey( blob.key )] ) ) {
						blob_client = GlobalVars.directory[String13.CKey( blob.key )];
						location = GlobalFuncs.get_turf( C );

						if ( Lang13.Bool( location.z ) != true || location is Tile_Space ) {
							location = null;
						}
						((Mob)C).gib();
					}
				}

				if ( Lang13.Bool( blob_client ) && Lang13.Bool( location ) ) {
					core = new Obj_Effect_Blob_Core( location, 200, blob_client, this.blob_point_rate );

					if ( core.overmind != null && core.overmind.mind != null ) {
						core.overmind.mind.name = blob.name;
						this.infected_crew.Remove( blob );
						this.infected_crew.Add( core.overmind.mind );
					}
				}
			}
			return;
		}

		// Function from file: blob.dm
		public void show_message( string message = null ) {
			Mind blob = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.infected_crew, typeof(Mind) )) {
				blob = _a;
				
				GlobalFuncs.to_chat( blob.current, message );
			}
			return;
		}

		// Function from file: blob.dm
		public void greet_blob( Mind blob = null ) {
			GlobalFuncs.to_chat( blob.current, @"<B><span class='warning'>You are infected by the Blob!</B>
<b>Your body is ready to give spawn to a new blob core which will eat this station.</b>
<b>Find a good location to spawn the core and then take control and overwhelm the station! Make sure you are ON the station when you burst!</b>
<b>When you have found a location, wait until you spawn; this will happen automatically and you cannot speed up the process.</b>
<b>If you go outside of the station level, or in space, then you will die; make sure your location has plenty of space to expand.</b></span>" );
			return;
		}

		// Function from file: blob.dm
		public override void announce(  ) {
			GlobalFuncs.to_chat( typeof(Game13), "<B>The current game mode is - <span class='blob'>Blob!</span></B>\n<B>A dangerous alien organism is rapidly spreading throughout the station!</B>\nYou must kill it all while minimizing the damage to the station." );
			return;
		}

		// Function from file: blob.dm
		public override bool pre_setup(  ) {
			ByTable possible_blobs = null;
			int? j = null;
			dynamic blob = null;

			possible_blobs = this.get_players_for_role( "blob" );

			if ( !( possible_blobs.len != 0 ) ) {
				GlobalFuncs.log_admin( "Failed to set-up a round of blob. Couldn't find any volunteers to be blob." );
				GlobalFuncs.message_admins( "Failed to set-up a round of blob. Couldn't find any volunteers to be blob." );
				return false;
			}
			this.cores_to_spawn = Num13.MaxInt( ((int)( Num13.Round( this.num_players() / this.players_per_core, 1 ) )), 1 );
			this.blobwincount = Lang13.Initial( this, "blobwincount" ) * this.cores_to_spawn;
			j = null;
			j = 0;

			while (( j ??0) < ( this.cores_to_spawn ??0)) {
				
				if ( !( possible_blobs.len != 0 ) ) {
					break;
				}
				blob = Rand13.PickFromTable( possible_blobs );
				this.infected_crew.Add( blob );
				blob.special_role = "Blob";
				GlobalVars.diary.WriteMsg( String13.HtmlDecode( "[" + GlobalFuncs.time_stamp() + "]GAME: " + ( "" + blob.key + " (ckey) has been selected as a Blob" ) ) );
				possible_blobs.Remove( blob );
				j++;
			}

			if ( !( this.infected_crew.len != 0 ) ) {
				GlobalFuncs.log_admin( "Failed to set-up a round of blob. Couldn't select any crew members to infect." );
				GlobalFuncs.message_admins( "Failed to set-up a round of blob. Couldn't select any crew members to infect." );
				return false;
			}
			GlobalFuncs.log_admin( "Starting a round of blob with " + this.infected_crew.len + " starting blobs." );
			GlobalFuncs.message_admins( "Starting a round of blob with " + this.infected_crew.len + " starting blobs." );
			return true;
		}

	}

}