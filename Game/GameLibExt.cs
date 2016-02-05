// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Game;

// THIS EXTENDS THE ENGINE'S GAME CLASS!

namespace Somnium.Engine.ByImpl {
	static partial class Game13 {
		public static string name = "/tg/ Station 13";
		private static double _tick_lag = 1;
		public const int icon_size = 32;

		public static readonly Type default_mob = typeof(Mob_NewPlayer);
		public static readonly Type default_tile = typeof(Tile_Space);
		public static readonly Type default_zone = typeof(Zone_Space);


		public static void New(  ) {
			string date_string = null;
			GlobalVars.map_ready = true;
			date_string = String13.formatTime( Game13.realtime, "YYYY/MM-Month/DD-Day" );
			GlobalVars.href_logfile = new File( "data/logs/" + date_string + " hrefs.htm" );
			GlobalVars.diary = new File( "data/logs/" + date_string + ".log" );
			GlobalVars.diaryofmeanpeople = new File( "data/logs/" + date_string + " Attack.log" );
			GlobalVars.diary.WriteMsg( "\n\nStarting up. " + String13.formatTime( Game13.timeofday, "hh:mm.ss" ) + "\n---------------------" );
			GlobalVars.diaryofmeanpeople.WriteMsg( "\n\nStarting up. " + String13.formatTime( Game13.timeofday, "hh:mm.ss" ) + "\n---------------------" );
			GlobalVars.changelog_hash = Num13.Md5( File13.read( "html/changelog.html" ) );
			GlobalFuncs.make_datum_references_lists();
			Game13.load_configuration();
			Game13.load_mode();
			Game13.load_motd();
			GlobalFuncs.load_admins();
			if ( GlobalVars.config.usewhitelist ) {
				GlobalFuncs.load_whitelist();
			}
			GlobalFuncs.appearance_loadbanfile();
			GlobalFuncs.LoadBans();
			GlobalFuncs.investigate_reset();
			if ( GlobalVars.config != null && GlobalVars.config.server_name != null && GlobalVars.config.server_suffix && Game13.port > 0 ) {
				GlobalVars.config.server_name += " #" + Game13.port % 1000 / 100;
			}
			GlobalVars.timezoneOffset = ( String13.ParseNumber( String13.formatTime( 0, "hh" ) ) ??0) * 36000;
			if ( GlobalVars.config.sql_enabled ) {
				if ( !GlobalFuncs.setup_database_connection() ) {
					Game13.log.WriteMsg( "Your server failed to establish a connection with the database." );
				} else {
					Game13.log.WriteMsg( "Database connection established." );
				}
			}
			GlobalVars.data_core = new Datacore();
			Task13.schedule( -1, (Task13.Closure)(() => {
				GlobalVars.Master.Setup();
				return;
			}));
			GlobalFuncs.process_teleport_locs();
			GlobalFuncs.SortAreas();
			GlobalVars.map_name = "" + "Box Station";
			return;
		}

		public static dynamic IsBanned( string key = null, dynamic address = null, string computer_id = null ) {
			dynamic _default = null;
			bool admin = false;
			string ckey = null;
			string ckeytext = null;
			string ipquery = null;
			string cidquery = null;
			DBQuery query = null;
			string pckey = null;
			dynamic ackey = null;
			dynamic reason = null;
			dynamic expiration = null;
			string duration = null;
			dynamic bantime = null;
			string bantype = null;
			string expires = null;
			string desc = null;
			if ( !Lang13.Bool( key ) || !Lang13.Bool( address ) || !Lang13.Bool( computer_id ) ) {
				GlobalFuncs.log_access( "Failed Login (invalid data): " + key + " " + address + "-" + computer_id );
				return new ByTable()
					.Set( "reason", "invalid login data" )
					.Set( "desc", "Error: Could not check ban status, Please try again. Error message: Your computer provided invalid or blank information to the server on connection (byond username, IP, and Computer ID.) Provided information for reference: Username:'" + key + "' IP:'" + address + "' Computer ID:'" + computer_id + "'. (If you continue to get this error, please restart byond or contact byond support.)" )
				;
			}
			if ( String13.ParseNumber( computer_id ) == 2147483648 ) {
				GlobalFuncs.log_access( "Failed Login (invalid cid): " + key + " " + address + "-" + computer_id );
				return new ByTable().Set( "reason", "invalid login data" ).Set( "desc", "Error: Could not check ban status, Please try again. Error message: Your computer provided an invalid Computer ID.)" );
			}
			admin = false;
			ckey = String13.ckey( key );
			if ( GlobalVars.admin_datums.Contains( ckey ) || GlobalVars.deadmins.Contains( ckey ) ) {
				admin = true;
			}
			if ( GlobalFuncs.IsGuestKey( key ) ) {
				if ( !GlobalVars.guests_allowed ) {
					GlobalFuncs.log_access( "Failed Login: " + key + " - Guests not allowed" );
					return new ByTable().Set( "reason", "guest" ).Set( "desc", "\nReason: Guests not allowed. Please sign in with a byond account." );
				}
				if ( GlobalVars.config.panic_bunker && GlobalVars.dbcon != null && GlobalVars.dbcon.IsConnected() ) {
					GlobalFuncs.log_access( "Failed Login: " + key + " - Guests not allowed during panic bunker" );
					return new ByTable()
						.Set( "reason", "guest" )
						.Set( "desc", "\nReason: Sorry but the server is currently not accepting connections from never before seen players or guests. If you have played on this server with a byond account before, please log in to the byond account you have played from." )
					;
				}
			}
			if ( Lang13.Bool( GlobalVars.config.extreme_popcap ) && GlobalFuncs.living_player_count() >= ( GlobalVars.config.extreme_popcap ??0) && !admin ) {
				GlobalFuncs.log_access( "Failed Login: " + key + " - Population cap reached" );
				return new ByTable().Set( "reason", "popcap" ).Set( "desc", "\nReason: " + GlobalVars.config.extreme_popcap_message );
			}
			if ( GlobalVars.config.ban_legacy_system ) {
				_default = GlobalFuncs.CheckBan( String13.ckey( key ), computer_id, address );
				if ( Lang13.Bool( _default ) ) {
					if ( admin ) {
						GlobalFuncs.log_admin( "The admin " + key + " has been allowed to bypass a matching ban on " + _default["key"] );
						GlobalFuncs.message_admins( "<span class='adminnotice'>The admin " + key + " has been allowed to bypass a matching ban on " + _default["key"] + "</span>" );
						GlobalFuncs.addclientmessage( ckey, "<span class='adminnotice'>You have been allowed to bypass a matching ban on " + _default["key"] + "</span>" );
					} else {
						GlobalFuncs.log_access( "Failed Login: " + key + " " + computer_id + " " + address + " - Banned " + _default["reason"] );
						return _default;
					}
				}
			} else {
				ckeytext = String13.ckey( key );
				if ( !GlobalFuncs.establish_db_connection() ) {
					Game13.log.WriteMsg( "Ban database connection failure. Key " + ckeytext + " not checked" );
					GlobalVars.diary.WriteMsg( "Ban database connection failure. Key " + ckeytext + " not checked" );
					return _default;
				}
				ipquery = "";
				cidquery = "";
				if ( Lang13.Bool( address ) ) {
					ipquery = " OR ip = '" + address + "' ";
				}
				if ( Lang13.Bool( computer_id ) ) {
					cidquery = " OR computerid = '" + computer_id + "' ";
				}
				query = GlobalVars.dbcon.NewQuery( "SELECT ckey, ip, computerid, a_ckey, reason, expiration_time, duration, bantime, bantype FROM " + GlobalFuncs.format_table_name( "ban" ) + " WHERE (ckey = '" + ckeytext + "' " + ipquery + " " + cidquery + ") AND (bantype = 'PERMABAN' OR bantype = 'ADMIN_PERMABAN' OR ((bantype = 'TEMPBAN' OR bantype = 'ADMIN_TEMPBAN') AND expiration_time > Now())) AND isnull(unbanned)" );
				query.Execute();
				while (query.NextRow()) {
					pckey = query.item[1];
					ackey = query.item[4];
					reason = query.item[5];
					expiration = query.item[6];
					duration = query.item[7];
					bantime = query.item[8];
					bantype = query.item[9];
					if ( bantype == "ADMIN_PERMABAN" || bantype == "ADMIN_TEMPBAN" ) {
						if ( pckey != ckey ) {
							continue;
						}
					}
					if ( admin ) {
						if ( bantype == "ADMIN_PERMABAN" || bantype == "ADMIN_TEMPBAN" ) {
							GlobalFuncs.log_admin( "The admin " + key + " is admin banned, and has been disallowed access" );
							GlobalFuncs.message_admins( "<span class='adminnotice'>The admin " + key + " is admin banned, and has been disallowed access</span>" );
						} else {
							GlobalFuncs.log_admin( "The admin " + key + " has been allowed to bypass a matching ban on " + pckey );
							GlobalFuncs.message_admins( "<span class='adminnotice'>The admin " + key + " has been allowed to bypass a matching ban on " + pckey + "</span>" );
							GlobalFuncs.addclientmessage( ckey, "<span class='adminnotice'>You have been allowed to bypass a matching ban on " + pckey + "</span>" );
							continue;
						}
					}
					expires = "";
					if ( ( String13.ParseNumber( duration ) ??0) > 0 ) {
						expires = " The ban is for " + duration + " minutes and expires on " + expiration + " (server time).";
					} else {
						expires = " The is a permanent ban.";
					}
					desc = "\nReason: You, or another user of this computer or connection (" + pckey + ") is banned from playing here. The ban reason is:\n" + reason + "\nThis ban was applied by " + ackey + " on " + bantime + ", " + expires;
					_default = new ByTable().Set( "reason", "" + bantype ).Set( "desc", "" + desc );
					GlobalFuncs.log_access( "Failed Login: " + key + " " + computer_id + " " + address + " - Banned " + _default["reason"] );
					return _default;
				}
			}
			_default = Game13._internal_IsBanned( key, address, computer_id );
			if ( Lang13.Bool( _default ) ) {
				if ( admin ) {
					GlobalFuncs.log_admin( "The admin " + key + " has been allowed to bypass a matching host/sticky ban" );
					GlobalFuncs.message_admins( "<span class='adminnotice'>The admin " + key + " has been allowed to bypass a matching host/sticky ban</span>" );
					GlobalFuncs.addclientmessage( ckey, "<span class='adminnotice'>You have been allowed to bypass a matching host/sticky ban</span>" );
					return null;
				} else {
					GlobalFuncs.log_access( "Failed Login: " + key + " " + computer_id + " " + address + " - Banned " + _default["message"] );
				}
			}
			return _default;
		}

		public static void update_status(  ) {
			string s = null;
			ByTable features = null;
			int n = 0;
			dynamic M = null;
			s = "";
			if ( GlobalVars.config != null && Lang13.Bool( GlobalVars.config.server_name ) ) {
				s += "<b>" + GlobalVars.config.server_name + "</b> &#8212; ";
			}
			s += "<b>" + GlobalFuncs.station_name() + "</b>";
			s += " (";
			s += "<a href=\"http://\">";
			s += "Default";
			s += "</a>";
			s += ")";
			features = new ByTable();
			if ( GlobalVars.ticker != null ) {
				if ( Lang13.Bool( GlobalVars.master_mode ) ) {
					features.Add( GlobalVars.master_mode );
				}
			} else {
				features.Add( "<b>STARTING</b>" );
			}
			if ( !GlobalVars.enter_allowed ) {
				features.Add( "closed" );
			}
			features.Add( ( GlobalVars.abandon_allowed ? "respawn" : "no respawn" ) );
			if ( GlobalVars.config != null && GlobalVars.config.allow_vote_mode ) {
				features.Add( "vote" );
			}
			if ( GlobalVars.config != null && GlobalVars.config.allow_ai ) {
				features.Add( "AI allowed" );
			}
			n = 0;
			M = null;
			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.player_list )) {
				M = _a;
				if ( Lang13.Bool( M.client ) ) {
					n++;
				}
			}
			if ( n > 1 ) {
				features.Add( "~" + n + " players" );
			} else if ( n > 0 ) {
				features.Add( "~" + n + " player" );
			}
			if ( !Lang13.Bool( Game13.host ) && GlobalVars.config != null && Lang13.Bool( GlobalVars.config.hostedby ) ) {
				features.Add( "hosted by <b>" + GlobalVars.config.hostedby + "</b>" );
			}
			if ( features != null ) {
				s += ": " + GlobalFuncs.list2text( features, ", " );
			}
			if ( Game13.status != s ) {
				Game13.status = s;
			}
			return;
		}

		public static void load_configuration(  ) {
			GlobalVars.protected_config = new ProtectedConfiguration();
			GlobalVars.config = new Configuration();
			GlobalVars.config.load( "config/config.txt" );
			GlobalVars.config.load( "config/game_options.txt", "game_options" );
			GlobalVars.config.loadsql( "config/dbconfig.txt" );
			if ( GlobalVars.config.maprotation && false ) {
				GlobalVars.config.loadmaplist( "config/maps.txt" );
			}
			GlobalVars.abandon_allowed = GlobalVars.config.respawn;
			return;
		}

		public static void load_motd(  ) {
			GlobalVars.join_motd = File13.read( "config/motd.txt" );
			return;
		}

		public static void save_mode( dynamic the_mode = null ) {
			dynamic F = null;
			F = new File( "data/mode.txt" );
			File13.delete( F );
			F.WriteMsg( the_mode );
			return;
		}

		public static void load_mode(  ) {
			ByTable Lines = null;
			Lines = GlobalFuncs.file2list( "data/mode.txt" );
			if ( Lines.len != 0 ) {
				if ( Lang13.Bool( Lines[1] ) ) {
					GlobalVars.master_mode = Lines[1];
					GlobalVars.diary.WriteMsg( "Saved mode is '" + GlobalVars.master_mode + "'" );
				}
			}
			return;
		}

		public static dynamic Reboot( dynamic reason = null, string feedback_c = null, string feedback_r = null, int? time = null ) {
			double? delay = null;
			dynamic C = null;
			if ( reason == 1 ) {
				if ( Task13.user != null ) {
					GlobalFuncs.log_admin( "" + GlobalFuncs.key_name( Task13.user ) + " Has requested an immediate world restart via client side debugging tools" );
					GlobalFuncs.message_admins( "" + GlobalFuncs.key_name_admin( Task13.user ) + " Has requested an immediate world restart via client side debugging tools" );
				}
				Game13.WriteMsg( "<span class='boldannounce'>Rebooting World immediately due to host request</span>" );
				return Game13._internal_Reboot( 1, feedback_c, feedback_r, time );
			}
			if ( Lang13.Bool( time ) ) {
				delay = time;
			} else {
				delay = ( GlobalVars.config.round_end_countdown ??0) * 10;
			}
			if ( GlobalVars.ticker.delay_end ) {
				Game13.WriteMsg( "<span class='boldannounce'>An admin has delayed the round end.</span>" );
				return null;
			}
			Game13.WriteMsg( "<span class='boldannounce'>Rebooting World in " + ( delay ??0) / 10 + " " + ( ( delay ??0) > 10 ? "seconds" : "second" ) + ". " + reason + "</span>" );
			Task13.sleep( ((int)( delay ??0 )) );
			if ( GlobalVars.blackbox != null ) {
				GlobalVars.blackbox.save_all_data_to_sql();
			}
			if ( GlobalVars.ticker.delay_end ) {
				Game13.WriteMsg( "<span class='boldannounce'>Reboot was cancelled by an admin.</span>" );
				return null;
			}
			GlobalFuncs.feedback_set_details( "" + feedback_c, "" + feedback_r );
			GlobalFuncs.log_game( "<span class='boldannounce'>Rebooting World. " + reason + "</span>" );
			GlobalFuncs.kick_clients_in_lobby( "<span class='boldannounce'>The round came to an end with you in the lobby.</span>", 1 );
			Task13.schedule( 0, (Task13.Closure)(() => {
				if ( GlobalVars.ticker != null && Lang13.Bool( GlobalVars.ticker.round_end_sound ) ) {
					Game13.WriteMsg( new Sound( GlobalVars.ticker.round_end_sound ) );
				} else {
					Game13.WriteMsg( new Sound( Rand13.Pick(new object [] { "sound/AI/newroundsexy.ogg", "sound/misc/apcdestroyed.ogg", "sound/misc/bangindonk.ogg", "sound/misc/leavingtg.ogg" }) ) );
				}
				return;
			}));
			C = null;
			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.clients )) {
				C = _a;
				if ( !Lang13.Bool( ((dynamic)typeof(Client)).IsInstanceOfType( C ) ) ) {
					continue;
				}
				if ( Lang13.Bool( GlobalVars.config.server ) ) {
					Interface13.link( C, "byond://" + GlobalVars.config.server );
				}
			}
			Game13._internal_Reboot( 0, feedback_c, feedback_r, time );
			return null;
		}

		public static dynamic Topic( string T = null, dynamic addr = null, dynamic master = null, dynamic key = null ) {
			int x = 0;
			dynamic C = null;
			int n = 0;
			dynamic M = null;
			ByTable s = null;
			int admins = 0;
			dynamic C2 = null;
			ByTable input = null;
			dynamic C3 = null;
			GlobalVars.diary.WriteMsg( "TOPIC: \"" + T + "\", from:" + addr + ", master:" + master + ", key:" + key );
			if ( T == "ping" ) {
				x = 1;
				C = null;
				foreach (dynamic _a in Lang13.Enumerate( GlobalVars.clients )) {
					C = _a;
					if ( !Lang13.Bool( ((dynamic)typeof(Client)).IsInstanceOfType( C ) ) ) {
						continue;
					}
					x++;
				}
				return x;
			} else if ( T == "players" ) {
				n = 0;
				M = null;
				foreach (dynamic _b in Lang13.Enumerate( GlobalVars.player_list )) {
					M = _b;
					if ( Lang13.Bool( M.client ) ) {
						n++;
					}
				}
				return n;
			} else if ( T == "status" ) {
				s = new ByTable();
				s["version"] = GlobalVars.game_version;
				s["mode"] = GlobalVars.master_mode;
				s["respawn"] = ( GlobalVars.config != null ? GlobalVars.abandon_allowed : false );
				s["enter"] = GlobalVars.enter_allowed;
				s["vote"] = GlobalVars.config.allow_vote_mode;
				s["ai"] = GlobalVars.config.allow_ai;
				s["host"] = ( Lang13.Bool( Game13.host ) ? Game13.host : null );
				admins = 0;
				C2 = null;
				foreach (dynamic _c in Lang13.Enumerate( GlobalVars.clients )) {
					C2 = _c;
					if ( !Lang13.Bool( ((dynamic)typeof(Client)).IsInstanceOfType( C2 ) ) ) {
						continue;
					}
					if ( Lang13.Bool( C2.holder ) ) {
						if ( Lang13.Bool( C2.holder.fakekey ) ) {
							continue;
						}
						admins++;
					}
				}
				s["active_players"] = GlobalFuncs.get_active_player_count();
				s["players"] = GlobalVars.clients.len;
				s["revision"] = GlobalVars.revdata.revision;
				s["revision_date"] = GlobalVars.revdata.date;
				s["admins"] = admins;
				s["gamestate"] = 1;
				if ( GlobalVars.ticker != null ) {
					s["gamestate"] = GlobalVars.ticker.current_state;
				}
				s["map_name"] = ( Lang13.Bool( GlobalVars.map_name ) ? GlobalVars.map_name : "Unknown" );
				return String13.conv_list2urlParams( s );
			} else if ( String13.substr( T, 1, 9 ) == "announce" ) {
				input = String13.conv_urlParams2list( T );
				if ( GlobalVars.comms_allowed ) {
					if ( input["key"] != GlobalVars.comms_key ) {
						return "Bad Key";
					} else {
						C3 = null;
						foreach (dynamic _d in Lang13.Enumerate( GlobalVars.clients )) {
							C3 = _d;
							if ( !Lang13.Bool( ((dynamic)typeof(Client)).IsInstanceOfType( C3 ) ) ) {
								continue;
							}
							if ( C3.prefs != null && ( C3.prefs.chat_toggles & 64 ) != 0 ) {
								C3.WriteMsg( "<span class='announce'>PR: " + input["announce"] + "</span>" );
							}
						}
					}
				}
			}
			return null;
		}

	}
}