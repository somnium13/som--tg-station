// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Recruiter : Game_Data {

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_BorerEgg subject = null;
		public ByTable currently_querying = null;
		public bool searching = false;
		public string display_name = null;
		public string role = null;
		public ByTable jobban_roles = new ByTable();
		public bool reject_antag_hud = true;
		public string alien_whitelist_id = null;
		public int recruitment_timeout = 600;
		public _Event player_volunteering = new _Event();
		public _Event player_not_volunteering = new _Event();
		public _Event recruited = new _Event();

		// Function from file: recruiter.dm
		public Recruiter ( Obj_Item_Weapon_ReagentContainers_Food_Snacks_BorerEgg _subject = null ) {
			this.subject = _subject;
			return;
		}

		// Function from file: recruiter.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			dynamic O = null;

			
			if ( Lang13.Bool( href_list["signup"] ) ) {
				O = Lang13.FindObj( href_list["signup"] );

				if ( !Lang13.Bool( O ) ) {
					return null;
				}
				this.volunteer( O );
			}
			return null;
		}

		// Function from file: recruiter.dm
		public dynamic check_observer( dynamic O = null ) {
			dynamic jbrole = null;

			
			if ( this.reject_antag_hud && O.has_enabled_antagHUD == 1 && GlobalVars.config.antag_hud_restricted ) {
				return 0;
			}

			if ( this.jobban_roles.len > 0 ) {
				
				foreach (dynamic _a in Lang13.Enumerate( this.jobban_roles )) {
					jbrole = _a;
					

					if ( Lang13.Bool( GlobalFuncs.jobban_isbanned( O, jbrole ) ) ) {
						return 0;
					}
				}
			}

			if ( Lang13.Bool( this.alien_whitelist_id ) && !GlobalFuncs.is_alien_whitelisted( this, this.alien_whitelist_id ) && GlobalVars.config.usealienwhitelist ) {
				return 0;
			}
			return O.client;
		}

		// Function from file: recruiter.dm
		public void volunteer( dynamic O = null ) {
			
			if ( !this.searching || !( O is Mob_Dead_Observer ) ) {
				return;
			}

			if ( !Lang13.Bool( this.check_observer( O ) ) ) {
				GlobalFuncs.to_chat( O, "<span class='warning'>You cannot be " + this.display_name + ".</span>" );
				return;
			}
			Interface13.Stat( null, this.currently_querying.Contains( O ) );

			if ( !Lang13.Bool( this.check_observer( O ) ) ) {
				GlobalFuncs.to_chat( O, "<span class='notice'>Removed from registration list.</span>" );
				this.currently_querying.Remove( O );
			} else {
				GlobalFuncs.to_chat( O, "<span class='notice'>Added to registration list.</span>" );
				this.currently_querying.Add( O );
			}
			return;
		}

		// Function from file: recruiter.dm
		public void request_player(  ) {
			ByTable active_candidates = null;
			Mob_Dead_Observer O = null;
			Mob_Dead_Observer O2 = null;
			dynamic O3 = null;

			this.currently_querying = new ByTable();
			this.searching = true;
			active_candidates = GlobalFuncs.get_active_candidates( this.role );

			foreach (dynamic _a in Lang13.Enumerate( active_candidates, typeof(Mob_Dead_Observer) )) {
				O = _a;
				

				if ( !Lang13.Bool( this.check_observer( O ) ) ) {
					continue;
				}
				this.currently_querying.Or( O );
				this.recruiting_player( O );
			}

			foreach (dynamic _b in Lang13.Enumerate( GlobalVars.dead_mob_list - active_candidates, typeof(Mob_Dead_Observer) )) {
				O2 = _b;
				

				if ( !Lang13.Bool( this.check_observer( O2 ) ) ) {
					continue;
				}
				this.nonrecruiting_player( O2 );
			}
			Task13.Schedule( this.recruitment_timeout, (Task13.Closure)(() => {
				
				if ( !( this.currently_querying != null ) || this.currently_querying.len == 0 ) {
					
					if ( this.recruited is _Event ) {
						this.recruited.Invoke( new ByTable().Set( "player", null ) );
					}
					return;
				}
				O3 = null;
				O3 = Rand13.PickFromTable( this.currently_querying );

				while (this.currently_querying.len != 0 && !Lang13.Bool( this.check_observer( O3 ) )) {
					this.currently_querying.Remove( O3 );
					O3 = Rand13.PickFromTable( this.currently_querying );
				}

				if ( !Lang13.Bool( this.check_observer( O3 ) ) ) {
					
					if ( this.recruited is _Event ) {
						this.recruited.Invoke( new ByTable().Set( "player", null ) );
					}
				} else if ( this.recruited is _Event ) {
					this.recruited.Invoke( new ByTable().Set( "player", O3 ) );
				}
				return;
			}));
			return;
		}

		// Function from file: recruiter.dm
		public void nonrecruiting_player( Mob_Dead_Observer O = null ) {
			
			if ( this.player_not_volunteering is _Event ) {
				this.player_not_volunteering.Invoke( new ByTable()
					.Set( "player", O )
					.Set( "controls", new Txt( "<a href='?src=" ).Ref( O ).str( ";jump=" ).Ref( this.subject ).str( "'>Teleport</a> | <a href='?src=" ).Ref( this ).str( ";signup=" ).Ref( O ).str( "'>Sign up</a>" ).ToString() )
				 );
			}
			return;
		}

		// Function from file: recruiter.dm
		public void recruiting_player( Mob_Dead_Observer O = null ) {
			
			if ( this.player_volunteering is _Event ) {
				this.player_volunteering.Invoke( new ByTable()
					.Set( "player", O )
					.Set( "controls", new Txt( "<a href='?src=" ).Ref( O ).str( ";jump=" ).Ref( this.subject ).str( "'>Teleport</a> | <a href='?src=" ).Ref( this ).str( ";signup=" ).Ref( O ).str( "'>Retract</a>" ).ToString() )
				 );
			}
			return;
		}

	}

}