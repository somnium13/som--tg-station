// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Device_Aicard : Obj_Item_Device {

		public bool flush = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "electronic";
			this.w_class = 2;
			this.slot_flags = 512;
			this.origin_tech = "programming=4;materials=4";
			this.icon = "icons/obj/pda.dmi";
			this.icon_state = "aicard";
		}

		public Obj_Item_Device_Aicard ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: aicard.dm
		public override bool ex_act( double? severity = null, dynamic child = null ) {
			
			switch ((double?)( severity )) {
				case 1:
					GlobalFuncs.qdel( this );
					break;
				case 2:
					
					if ( Rand13.PercentChance( 50 ) ) {
						GlobalFuncs.qdel( this );
					}
					break;
				case 3:
					
					if ( Rand13.PercentChance( 25 ) ) {
						GlobalFuncs.qdel( this );
					}
					break;
			}
			return false;
		}

		// Function from file: aicard.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			Mob U = null;
			string confirm = null;
			Mob_Living_Silicon_Ai A = null;
			Mob_Living_Silicon_Ai A2 = null;

			U = Task13.User;

			if ( !GlobalFuncs.in_range( this, U ) || U.machine != this ) {
				Interface13.Browse( U, null, "window=aicard" );
				U.unset_machine();
				return null;
			}
			this.add_fingerprint( U );
			U.set_machine( this );

			dynamic _c = href_list["choice"]; // Was a switch-case, sorry for the mess.
			if ( _c=="Close" ) {
				Interface13.Browse( U, null, "window=aicard" );
				U.unset_machine();
				return null;
			} else if ( _c=="Wipe" ) {
				confirm = Interface13.Alert( "Are you sure you want to wipe this card's memory? This cannot be undone once started.", "Confirm Wipe", "Yes", "No" );

				if ( confirm == "Yes" ) {
					
					if ( this == null || !GlobalFuncs.in_range( this, U ) || U.machine != this ) {
						Interface13.Browse( U, null, "window=aicard" );
						U.unset_machine();
						return null;
					} else {
						this.flush = true;

						foreach (dynamic _a in Lang13.Enumerate( this, typeof(Mob_Living_Silicon_Ai) )) {
							A = _a;
							
							A.suiciding = true;
							GlobalFuncs.to_chat( A, "Your core files are being wiped!" );
							A.attack_log.Add( "[" + GlobalFuncs.time_stamp() + "] <font color='orange'>Has been wiped with an " + this.name + " by " + U.name + " (" + U.ckey + ")</font>" );
							U.attack_log.Add( "[" + GlobalFuncs.time_stamp() + "] <font color='red'>Used an " + this.name + " to wipe " + A.name + " (" + A.ckey + ")</font>" );
							GlobalVars.diaryofmeanpeople.WriteMsg( String13.HtmlDecode( "[" + GlobalFuncs.time_stamp() + "]ATTACK: " + ( "" + GlobalFuncs.key_name( U ) + " Used an " + this.name + " to wipe " + GlobalFuncs.key_name( A ) ) ) );

							while (A.stat != 2) {
								A.adjustOxyLoss( 2 );
								A.updatehealth();
								Task13.Sleep( 10 );
							}
							this.flush = false;
						}
					}
				}
			} else if ( _c=="Wireless" ) {
				
				foreach (dynamic _b in Lang13.Enumerate( this, typeof(Mob_Living_Silicon_Ai) )) {
					A2 = _b;
					
					A2.control_disabled = !A2.control_disabled;
					GlobalFuncs.to_chat( A2, "The intelicard's wireless port has been " + ( A2.control_disabled ? "disabled" : "enabled" ) + "!" );

					if ( A2.control_disabled ) {
						this.overlays.Remove( new Image( "icons/obj/pda.dmi", "aicard-on" ) );
					} else {
						this.overlays.Add( new Image( "icons/obj/pda.dmi", "aicard-on" ) );
					}
				}
			}
			this.attack_self( U );
			return null;
		}

		// Function from file: aicard.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			string dat = null;
			dynamic laws = null;
			Mob_Living_Silicon_Ai A = null;
			int number = 0;
			int? index = null;
			dynamic law = null;
			int? index2 = null;
			dynamic law2 = null;

			
			if ( !GlobalFuncs.in_range( this, user ) ) {
				return null;
			}
			((Mob)user).set_machine( this );
			dat = "<TT><B>Intelicard</B><BR>";

			foreach (dynamic _a in Lang13.Enumerate( this, typeof(Mob_Living_Silicon_Ai) )) {
				A = _a;
				
				dat += "Stored AI: " + A.name + "<br>System integrity: " + A.system_integrity() + "%<br>";
				number = 1;
				index = null;
				index = 1;

				while (( index ??0) <= A.laws.inherent.len) {
					law = A.laws.inherent[index];

					if ( Lang13.Length( law ) > 0 ) {
						laws += "" + number + ": " + law + "<BR>";
						number++;
					}
					index++;
				}
				index2 = null;
				index2 = 1;

				while (( index2 ??0) <= A.laws.supplied.len) {
					law2 = A.laws.supplied[index2];

					if ( Lang13.Length( law2 ) > 0 ) {
						laws += "" + number + ": " + law2 + "<BR>";
						number++;
					}
					index2++;
				}
				dat += "Laws:<br>" + laws + "<br>";

				if ( A.stat == 2 ) {
					dat += "<b>AI nonfunctional</b>";
				} else {
					
					if ( !this.flush ) {
						dat += new Txt( "<A href='byond://?src=" ).Ref( this ).str( ";choice=Wipe'>Wipe AI</A>" ).ToString();
					} else {
						dat += "<b>Wipe in progress</b>";
					}
					dat += "<br>";
					dat += new Txt( "<a href='byond://?src=" ).Ref( this ).str( ";choice=Wireless'>" ).item( ( A.control_disabled ? "Enable" : "Disable" ) ).str( " Wireless Activity</a>" ).ToString();
					dat += "<br>";
					dat += new Txt( "<a href='byond://?src=" ).Ref( this ).str( ";choice=Close'> Close</a>" ).ToString();
				}
			}
			Interface13.Browse( user, dat, "window=aicard" );
			GlobalFuncs.onclose( user, "aicard" );
			return null;
		}

		// Function from file: aicard.dm
		public override bool? attack( dynamic M = null, dynamic user = null, string def_zone = null, bool? eat_override = null ) {
			
			if ( !( M is Mob_Living_Silicon_Ai ) ) {
				return base.attack( (object)(M), (object)(user), def_zone, eat_override );
			}
			M.attack_log.Add( "[" + GlobalFuncs.time_stamp() + "] <font color='orange'>Has been carded with " + this.name + " by " + user.name + " (" + user.ckey + ")</font>" );
			user.attack_log.Add( "[" + GlobalFuncs.time_stamp() + "] <font color='red'>Used the " + this.name + " to card " + M.name + " (" + M.ckey + ")</font>" );
			GlobalVars.diaryofmeanpeople.WriteMsg( String13.HtmlDecode( "[" + GlobalFuncs.time_stamp() + "]ATTACK: " + ( "<font color='red'>" + user.name + " (" + user.ckey + ") used the " + this.name + " to card " + M.name + " (" + M.ckey + ")</font>" ) ) );
			this.transfer_ai( "AICORE", "AICARD", M, user );
			GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/machines/paistartup.ogg", 50, 1 );
			return null;
		}

	}

}