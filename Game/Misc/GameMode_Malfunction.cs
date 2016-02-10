// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class GameMode_Malfunction : GameMode {

		public int waittime_l = 600;
		public int waittime_h = 1800;
		public double AI_win_timeleft = 1800;
		public bool malf_mode_declared = false;
		public bool station_captured = false;
		public bool to_nuke_or_not_to_nuke = false;
		public int apcs = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "AI malfunction";
			this.config_tag = "malfunction";
			this.required_players = 2;
			this.required_players_secret = 15;
			this.required_enemies = 1;
			this.recommended_enemies = 1;
			this.uplink_welcome = "Crazy AI Uplink Console:";
		}

		// Function from file: malfunction.dm
		public override bool declare_completion( bool? ragin = null ) {
			bool malf_dead = false;
			bool crew_evacuated = false;

			malf_dead = this.is_malf_ai_dead();
			crew_evacuated = GlobalVars.emergency_shuttle.location == 2;

			if ( this.station_captured && this.station_was_nuked ) {
				GlobalFuncs.feedback_set_details( "round_end_result", "win - AI win - nuke" );
				this.completion_text += "<FONT size = 3><B>AI Victory</B></FONT>";
				this.completion_text += "<BR><B>Everyone was killed by the self-destruct!</B>";
			} else if ( this.station_captured && malf_dead && !this.station_was_nuked ) {
				GlobalFuncs.feedback_set_details( "round_end_result", "halfwin - AI killed, staff lost control" );
				this.completion_text += "<FONT size = 3><B>Neutral Victory</B></FONT>";
				this.completion_text += "<BR><B>The AI has been killed!</B> The staff has lost control over the station.";
			} else if ( this.station_captured && !malf_dead && !this.station_was_nuked ) {
				GlobalFuncs.feedback_set_details( "round_end_result", "win - AI win - no explosion" );
				this.completion_text += "<FONT size = 3><B>AI Victory</B></FONT>";
				this.completion_text += "<BR><B>The AI has chosen not to explode you all!</B>";
			} else if ( !this.station_captured && this.station_was_nuked ) {
				GlobalFuncs.feedback_set_details( "round_end_result", "halfwin - everyone killed by nuke" );
				this.completion_text += "<FONT size = 3><B>Neutral Victory</B></FONT>";
				this.completion_text += "<BR><B>Everyone was killed by the nuclear blast!</B>";
			} else if ( !this.station_captured && malf_dead && !this.station_was_nuked ) {
				GlobalFuncs.feedback_set_details( "round_end_result", "loss - staff win" );
				this.completion_text += "<FONT size = 3><B>Human Victory</B></FONT>";
				this.completion_text += "<BR><B>The AI has been killed!</B> The staff is victorious.";
			} else if ( !this.station_captured && !malf_dead && !this.station_was_nuked && crew_evacuated ) {
				GlobalFuncs.feedback_set_details( "round_end_result", "halfwin - evacuated" );
				this.completion_text += "<FONT size = 3><B>Neutral Victory</B></FONT>";
				this.completion_text += "<BR><B>The Corporation has lose " + GlobalFuncs.station_name() + "! All survived personnel will be fired!</B>";
			} else if ( !this.station_captured && !malf_dead && !this.station_was_nuked && !crew_evacuated ) {
				GlobalFuncs.feedback_set_details( "round_end_result", "nalfwin - interrupted" );
				this.completion_text += "<FONT size = 3><B>Neutral Victory</B></FONT>";
				this.completion_text += "<BR><B>Round was mysteriously interrupted!</B>";
			}
			base.declare_completion( ragin );
			return true;
		}

		// Function from file: malfunction.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			base.Topic( href, href_list, (object)(hclient) );

			if ( Lang13.Bool( href_list["ai_win"] ) ) {
				this.ai_win();
			}
			return null;
		}

		// Function from file: malfunction.dm
		public override bool check_finished(  ) {
			
			if ( this.station_captured && !this.to_nuke_or_not_to_nuke ) {
				return true;
			}

			if ( this.is_malf_ai_dead() ) {
				
				if ( GlobalVars.config.continous_rounds ) {
					
					if ( GlobalVars.emergency_shuttle != null ) {
						GlobalVars.emergency_shuttle.always_fake_recall = false;
					}
					this.malf_mode_declared = false;
				} else {
					return true;
				}
			}
			return base.check_finished();
		}

		// Function from file: malfunction.dm
		public override bool check_win(  ) {
			
			if ( this.AI_win_timeleft <= 0 && !this.station_captured ) {
				this.station_captured = true;
				this.capture_the_station();
				return true;
			} else {
				return false;
			}
		}

		// Function from file: malfunction.dm
		public override bool process(  ) {
			
			if ( this.apcs >= 3 && this.malf_mode_declared ) {
				this.AI_win_timeleft -= this.apcs / 6 * GlobalVars.tickerProcess.getLastTickerTimeDuration();
			}
			base.process();

			if ( this.AI_win_timeleft <= 0 ) {
				this.check_win();
			}
			return false;
		}

		// Function from file: malfunction.dm
		// Warning, this is probably a verb! It is in a place that a verb probably shouldn't be! This should probably be fixed!
		[VerbInfo( name: "Explode", desc: "Station goes boom", group: "Malfunction" )]
		public void ai_win(  ) {
			Mind AI_mind = null;
			dynamic M = null;
			double i = 0;

			
			if ( !GlobalVars.ticker.mode.station_captured ) {
				GlobalFuncs.to_chat( Task13.User, "<span class='warning'>You are unable to access the self-destruct system as you don't control the station yet.</span>" );
				return;
			}

			if ( GlobalVars.ticker.mode.explosion_in_progress || GlobalVars.ticker.mode.station_was_nuked ) {
				GlobalFuncs.to_chat( Task13.User, "<span class='notice'>The self-destruct countdown was already triggered!</span>" );
				return;
			}

			if ( !GlobalVars.ticker.mode.to_nuke_or_not_to_nuke ) {
				GlobalFuncs.to_chat( Task13.User, "<span class='warning'>Cannot interface, it seems a neutralization signal was sent!</span>" );
				return;
			}
			GlobalFuncs.to_chat( Task13.User, "<span class='danger'>Detonation signal sent!</span>" );
			GlobalVars.ticker.mode.to_nuke_or_not_to_nuke = false;

			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.ticker.mode.malf_ai, typeof(Mind) )) {
				AI_mind = _a;
				
				AI_mind.current.verbs -= typeof(GameMode_Malfunction).GetMethod( "ai_win" );
			}
			GlobalVars.ticker.mode.explosion_in_progress = true;

			foreach (dynamic _b in Lang13.Enumerate( GlobalVars.player_list )) {
				M = _b;
				

				if ( Lang13.Bool( M.client ) ) {
					GlobalFuncs.to_chat( M, "sound/machines/Alarm.ogg" );
				}
			}
			GlobalFuncs.to_chat( typeof(Game13), "<span class='danger'>Self-destruction signal received. Self-destructing in 10...</span>" );

			foreach (dynamic _c in Lang13.IterateRange( 9, 1, -1 )) {
				i = _c;
				
				Task13.Sleep( 10 );
				GlobalFuncs.to_chat( typeof(Game13), "<span class='danger'>" + i + "...</span>" );
			}
			Task13.Sleep( 10 );
			GlobalVars.enter_allowed = false;

			if ( GlobalVars.ticker != null ) {
				GlobalVars.ticker.station_explosion_cinematic( 0, null );

				if ( Lang13.Bool( GlobalVars.ticker.mode ) ) {
					GlobalVars.ticker.mode.station_was_nuked = true;
					GlobalVars.ticker.mode.explosion_in_progress = false;
				}
			}
			return;
		}

		// Function from file: malfunction.dm
		// Warning, this is probably a verb! It is in a place that a verb probably shouldn't be! This should probably be fixed!
		[VerbInfo( name: "System Override", desc: "Start the victory timer", group: "Malfunction" )]
		public void takeover(  ) {
			Mind AI_mind = null;
			dynamic M = null;

			
			if ( !( GlobalVars.ticker.mode is GameMode_Malfunction ) ) {
				GlobalFuncs.to_chat( Task13.User, "<span class='warning'>You cannot begin a takeover in this round type!</span>" );
				return;
			}

			if ( GlobalVars.ticker.mode.malf_mode_declared ) {
				GlobalFuncs.to_chat( Task13.User, "<span class='warning'>You've already begun your takeover.</span>" );
				return;
			}

			if ( GlobalVars.ticker.mode.apcs < 3 ) {
				GlobalFuncs.to_chat( Task13.User, "<span class='notice'>You don't have enough hacked APCs to take over the station yet. You need to hack at least 3, however hacking more will make the takeover faster. You have hacked " + GlobalVars.ticker.mode.apcs + " APCs so far.</span>" );
				return;
			}

			if ( Interface13.Alert( Task13.User, "Are you sure you wish to initiate the takeover? The station hostile runtime detection software is bound to alert everyone. You have hacked " + GlobalVars.ticker.mode.apcs + " APCs.", "Takeover:", "Yes", "No" ) != "Yes" ) {
				return;
			}
			GlobalFuncs.command_alert( "Hostile runtimes detected in all station systems, please deactivate your AI to prevent possible damage to its morality core.", "Anomaly Alert" );
			GlobalFuncs.set_security_level( "delta" );
			GlobalVars.ticker.mode.malf_mode_declared = true;

			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.ticker.mode.malf_ai, typeof(Mind) )) {
				AI_mind = _a;
				
				AI_mind.current.verbs -= typeof(GameMode_Malfunction).GetMethod( "takeover" );
			}

			foreach (dynamic _b in Lang13.Enumerate( GlobalVars.player_list )) {
				M = _b;
				

				if ( !( M is Mob_NewPlayer ) && Lang13.Bool( M.client ) ) {
					M.WriteMsg( new Sound( "sound/AI/aimalf.ogg" ) );
				}
			}
			return;
		}

		// Function from file: malfunction.dm
		public void capture_the_station(  ) {
			Mind AI_mind = null;

			GlobalFuncs.to_chat( typeof(Game13), "<FONT size = 3><B>The AI has won!</B></FONT><br>\n<B>It has fully taken control of " + GlobalFuncs.station_name() + "'s systems.</B>" );
			this.to_nuke_or_not_to_nuke = true;

			foreach (dynamic _a in Lang13.Enumerate( this.malf_ai, typeof(Mind) )) {
				AI_mind = _a;
				
				GlobalFuncs.to_chat( AI_mind.current, "<span class='notice'>Congratulations! The station is now under your exclusive control.<br>\nYou may decide to blow up the station. You have 60 seconds to choose.<br>\nYou should now be able to use your Explode verb to interface with the nuclear fission device.</span>" );
				AI_mind.current.verbs += typeof(GameMode_Malfunction).GetMethod( "ai_win" );
			}
			Task13.Schedule( 600, (Task13.Closure)(() => {
				this.to_nuke_or_not_to_nuke = false;
				return;
			}));
			return;
		}

		// Function from file: malfunction.dm
		public void hack_intercept(  ) {
			this.intercept_hacked = true;
			return;
		}

		// Function from file: malfunction.dm
		public override bool post_setup(  ) {
			Mind AI_mind = null;
			dynamic laws = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.malf_ai, typeof(Mind) )) {
				AI_mind = _a;
				

				if ( this.malf_ai.len < 1 ) {
					GlobalFuncs.to_chat( typeof(Game13), "Uh oh, its malfunction and there is no AI! Please report this.<br>\nRebooting world in 5 seconds." );
					GlobalFuncs.feedback_set_details( "end_error", "malf - no AI" );

					if ( GlobalVars.blackbox != null ) {
						GlobalVars.blackbox.save_all_data_to_sql();
					}
					GlobalFuncs.CallHook( "Reboot", new ByTable() );

					if ( GlobalVars.watchdog.waiting ) {
						GlobalFuncs.to_chat( typeof(Game13), "<span class='notice'><B>Server will shut down for an automatic update in a few seconds.</B></span>" );
						GlobalVars.watchdog.signal_ready();
						return false;
					}
					Task13.Sleep( 50 );
					Game13.Reboot();
					return false;
				}
				AI_mind.current.verbs += typeof(Mob_Living_Silicon_Ai).GetMethod( "choose_modules" );
				((Mob_Living_Silicon_Robot)AI_mind.current).laws_sanity_check();
				laws = AI_mind.current.laws;
				laws.malfunction();
				AI_mind.current.malf_picker = new ModulePicker();
				AI_mind.current.show_laws();
				this.greet_malf( AI_mind );
				AI_mind.special_role = "malfunction";
				AI_mind.current.verbs += typeof(GameMode_Malfunction).GetMethod( "takeover" );
				AI_mind.current.verbs += typeof(GameMode_Malfunction).GetMethod( "ai_win" );
			}

			if ( GlobalVars.emergency_shuttle != null ) {
				GlobalVars.emergency_shuttle.always_fake_recall = true;
			}
			Task13.Schedule( Rand13.Int( GlobalVars.waittime_l, GlobalVars.waittime_h ), (Task13.Closure)(() => {
				
				if ( !this.mixed ) {
					this.send_intercept();
				}
				return;
			}));
			base.post_setup();
			return false;
		}

		// Function from file: malfunction.dm
		public override bool pre_setup(  ) {
			Mob_NewPlayer player = null;

			
			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.player_list, typeof(Mob_NewPlayer) )) {
				player = _a;
				

				if ( player.mind != null && player.mind.assigned_role == "AI" && Lang13.Bool( player.client.desires_role( "malf AI" ) ) ) {
					this.malf_ai.Add( player.mind );
				}
			}

			if ( this.malf_ai.len != 0 ) {
				GlobalFuncs.log_admin( "Starting a round of AI malfunction." );
				GlobalFuncs.message_admins( "Starting a round of AI malfunction." );
				return true;
			}
			GlobalFuncs.log_admin( "Failed to set-up a round of AI malfunction. Didn't find any malf-volunteer AI." );
			GlobalFuncs.message_admins( "Failed to set-up a round of AI malfunction. Didn't find any malf-volunteer AI." );
			return false;
		}

		// Function from file: malfunction.dm
		public override void announce(  ) {
			GlobalFuncs.to_chat( typeof(Game13), "<B>The current game mode is - AI Malfunction!</B><br>\n<B>The onboard AI is malfunctioning and must be destroyed.</B><br>\n<B>If the AI manages to take over the station, it will most likely blow it up. You have " + this.AI_win_timeleft / 60 + " minutes to disable it.</B><br>\n<B>You have no chance to survive, make your time.</B>" );
			return;
		}

	}

}