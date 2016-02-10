// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class GameMode_Wizard : GameMode {

		public bool finished = false;
		public int waittime_l = 600;
		public int waittime_h = 1800;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "wizard";
			this.config_tag = "wizard";
			this.required_players = 2;
			this.required_players_secret = 10;
			this.required_enemies = 1;
			this.recommended_enemies = 1;
			this.uplink_welcome = "Wizardly Uplink Console:";
		}

		// Function from file: wizard.dm
		public override bool declare_completion( bool? ragin = null ) {
			ragin = ragin ?? false;

			
			if ( this.finished && !( ragin == true ) ) {
				GlobalFuncs.feedback_set_details( "round_end_result", "loss - wizard killed" );
				this.completion_text += "<br><span class='warning'><FONT size = 3><B> The wizard" + ( this.wizards.len > 1 ? "s" : "" ) + " has been killed by the crew! The Space Wizards Federation has been taught a lesson they will not soon forget!</B></FONT></span>";
			}
			base.declare_completion( ragin );
			return true;
		}

		// Function from file: wizard.dm
		public override bool check_finished(  ) {
			int wizards_alive = 0;
			int traitors_alive = 0;
			Mind wizard = null;
			Mind traitor = null;

			
			if ( GlobalVars.ticker.mode is GameMode_Mixed ) {
				this.mixed = true;
			}

			if ( GlobalVars.config.continous_rounds || this.mixed ) {
				return base.check_finished();
			}
			wizards_alive = 0;
			traitors_alive = 0;

			foreach (dynamic _a in Lang13.Enumerate( this.wizards, typeof(Mind) )) {
				wizard = _a;
				

				if ( !( wizard.current is Mob_Living_Carbon ) ) {
					continue;
				}

				if ( Convert.ToInt32( wizard.current.stat ) == 2 ) {
					continue;
				}
				wizards_alive++;
			}

			if ( !( wizards_alive != 0 ) ) {
				
				foreach (dynamic _b in Lang13.Enumerate( this.traitors, typeof(Mind) )) {
					traitor = _b;
					

					if ( !( traitor.current is Mob_Living_Carbon ) ) {
						continue;
					}

					if ( Convert.ToInt32( traitor.current.stat ) == 2 ) {
						continue;
					}
					traitors_alive++;
				}
			}

			if ( wizards_alive != 0 || traitors_alive != 0 || this.rage && Lang13.Bool( ((dynamic)this).making_mage ) ) {
				return base.check_finished();
			} else {
				this.finished = true;
				return true;
			}
		}

		// Function from file: wizard.dm
		public override bool post_setup(  ) {
			Mind wizard = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.wizards, typeof(Mind) )) {
				wizard = _a;
				
				this.forge_wizard_objectives( wizard );
				this.equip_wizard( wizard.current );
				this.name_wizard( wizard.current );
				this.greet_wizard( wizard );
				this.update_wizard_icons_added( wizard );
			}
			this.update_all_wizard_icons();

			if ( !this.mixed ) {
				Task13.Schedule( Rand13.Int( GlobalVars.waittime_l, GlobalVars.waittime_h ), (Task13.Closure)(() => {
					
					if ( !this.mixed ) {
						this.send_intercept();
					}
					return;
				}));
				base.post_setup();
			}
			return false;
		}

		// Function from file: wizard.dm
		public override bool pre_setup(  ) {
			ByTable possible_wizards = null;
			dynamic wizard = null;
			Mind wwizard = null;

			possible_wizards = this.get_players_for_role( "wizard" );

			if ( possible_wizards.len == 0 ) {
				GlobalFuncs.log_admin( "Failed to set-up a round of wizard. Couldn't find any volunteers to be wizards." );
				GlobalFuncs.message_admins( "Failed to set-up a round of wizard. Couldn't find any volunteers to be wizards." );
				return false;
			}

			while (possible_wizards.len != 0) {
				wizard = Rand13.PickFromTable( possible_wizards );

				if ( Lang13.Bool( wizard.special_role ) || this.mixed && false ) {
					possible_wizards.Remove( wizard );
					wizard = null;
					continue;
				} else {
					break;
				}
			}

			if ( wizard == null ) {
				GlobalFuncs.log_admin( "COULD NOT MAKE A WIZARD, Mixed mode is " + ( this.mixed ? "enabled" : "disabled" ) );
				GlobalFuncs.message_admins( "COULD NOT MAKE A WIZARD, Mixed mode is " + ( this.mixed ? "enabled" : "disabled" ) );
				return false;
			}
			this.wizards.Add( wizard );
			this.modePlayer.Add( wizard );

			if ( this.mixed ) {
				GlobalVars.ticker.mode.modePlayer.Add( this.wizards );
				GlobalVars.ticker.mode.wizards.Add( this.wizards );
			}
			wizard.assigned_role = "MODE";
			wizard.special_role = "Wizard";
			wizard.original = wizard.current;

			if ( GlobalVars.wizardstart.len == 0 ) {
				GlobalFuncs.to_chat( wizard.current, "<span class='danger'>A starting location for you could not be found, please report this bug!</span>" );
				GlobalFuncs.log_admin( "Failed to set-up a round of wizard. Couldn't find any wizard spawn points." );
				GlobalFuncs.message_admins( "Failed to set-up a round of wizard. Couldn't find any wizard spawn points." );
				return false;
			}

			foreach (dynamic _a in Lang13.Enumerate( this.wizards, typeof(Mind) )) {
				wwizard = _a;
				
				wwizard.current.loc = Rand13.PickFromTable( GlobalVars.wizardstart );
			}
			GlobalFuncs.log_admin( "Starting a round of wizard with " + this.wizards.len + " wizards." );
			GlobalFuncs.message_admins( "Starting a round of wizard with " + this.wizards.len + " wizards." );
			return true;
		}

		// Function from file: raginmages.dm
		public override void announce(  ) {
			GlobalFuncs.to_chat( typeof(Game13), "<B>The current game mode is - Ragin' Mages!</B>" );
			GlobalFuncs.to_chat( typeof(Game13), "<B>The <span class='danger'>Space Wizard Federation is pissed, help defeat all the space wizards!</span>" );
			return;
		}

	}

}