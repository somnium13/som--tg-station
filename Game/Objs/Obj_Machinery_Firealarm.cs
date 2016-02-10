// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Firealarm : Obj_Machinery {

		public bool detecting = true;
		public bool working = true;
		public double time = 10;
		public double? timing = 0;
		public bool lockdownbyai = false;
		public int last_process = 0;
		public bool wiresexposed = false;
		public int buildstage = 2;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.idle_power_usage = 2;
			this.active_power_usage = 6;
			this.power_channel = 3;
			this.icon = "icons/obj/monitors.dmi";
			this.icon_state = "fire0";
		}

		// Function from file: alarm.dm
		public Obj_Machinery_Firealarm ( dynamic loc = null, int dir = 0, bool building = false ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.name = "" + this.areaMaster.name + " fire alarm";

			if ( Lang13.Bool( loc ) ) {
				this.loc = loc;
			}

			if ( dir != 0 ) {
				this.dir = dir;
			}

			if ( building ) {
				this.buildstage = 0;
				this.wiresexposed = true;
				this.pixel_x = ( ( dir & 3 ) != 0 ? 0 : ( dir == 4 ? -24 : 24 ) );
				this.pixel_y = ( ( dir & 3 ) != 0 ? ( dir == 1 ? -24 : 24 ) : 0 );
			}

			if ( this.z == 1 ) {
				
				if ( GlobalVars.security_level != 0 ) {
					this.overlays.Add( new Image( "icons/obj/monitors.dmi", "overlay_" + GlobalFuncs.get_security_level() ) );
				} else {
					this.overlays.Add( new Image( "icons/obj/monitors.dmi", "overlay_green" ) );
				}
			}
			GlobalVars.machines.Remove( this );
			this.update_icon();
			return;
		}

		// Function from file: alarm.dm
		public override void change_area( dynamic oldarea = null, dynamic newarea = null ) {
			base.change_area( (object)(oldarea), (object)(newarea) );
			this.name = GlobalFuncs.replacetext( this.name, oldarea, newarea );
			return;
		}

		// Function from file: alarm.dm
		public void alarm(  ) {
			
			if ( !this.working ) {
				return;
			}
			((Zone)this.areaMaster).firealert();
			this.update_icon();
			return;
		}

		// Function from file: alarm.dm
		public void reset(  ) {
			
			if ( !this.working ) {
				return;
			}
			((Zone)this.areaMaster).firereset();
			this.update_icon();
			return;
		}

		// Function from file: alarm.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			double? tp = null;

			
			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hclient) ) ) ) {
				return 1;
			}

			if ( Lang13.Bool( Task13.User.stat ) || ( this.stat & 3 ) != 0 ) {
				return null;
			}

			if ( this.buildstage != 2 ) {
				return null;
			}

			if ( Task13.User.contents.Find( this ) != 0 || Map13.GetDistance( this, Task13.User ) <= 1 && this.loc is Tile || Task13.User is Mob_Living_Silicon ) {
				Task13.User.set_machine( this );

				if ( Lang13.Bool( href_list["reset"] ) ) {
					this.reset();
				} else if ( Lang13.Bool( href_list["alarm"] ) ) {
					this.alarm();
				} else if ( Lang13.Bool( href_list["time"] ) ) {
					this.timing = String13.ParseNumber( href_list["time"] );
					this.last_process = Game13.timeofday;
					GlobalVars.processing_objects.Add( this );
				} else if ( Lang13.Bool( href_list["tp"] ) ) {
					tp = String13.ParseNumber( href_list["tp"] );
					this.time += tp ??0;
					this.time = Num13.MinInt( Num13.MaxInt( Num13.Floor( this.time ), 0 ), 120 );
				}
				this.updateUsrDialog();
				this.add_fingerprint( Task13.User );
			} else {
				Interface13.Browse( Task13.User, null, "window=firealarm" );
				return null;
			}
			return null;
		}

		// Function from file: alarm.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			string d1 = null;
			string d2 = null;
			int second = 0;
			double minute = 0;
			string dat = null;
			int second2 = 0;
			double minute2 = 0;
			string dat2 = null;

			
			if ( Lang13.Bool( a.stat ) && !( a is Mob_Dead_Observer ) || ( this.stat & 3 ) != 0 ) {
				return null;
			}

			if ( this.buildstage != 2 ) {
				return null;
			}
			((Mob)a).set_machine( this );

			if ( a is Mob_Living_Carbon_Human || a is Mob_Living_Silicon || a is Mob_Dead_Observer ) {
				
				if ( Lang13.Bool( this.areaMaster.fire ) ) {
					d1 = new Txt( "<A href='?src=" ).Ref( this ).str( ";reset=1'>Reset - Lockdown</A>" ).ToString();
				} else {
					d1 = new Txt( "<A href='?src=" ).Ref( this ).str( ";alarm=1'>Alarm - Lockdown</A>" ).ToString();
				}

				if ( Lang13.Bool( this.timing ) ) {
					d2 = new Txt( "<A href='?src=" ).Ref( this ).str( ";time=0'>Stop Time Lock</A>" ).ToString();
				} else {
					d2 = new Txt( "<A href='?src=" ).Ref( this ).str( ";time=1'>Initiate Time Lock</A>" ).ToString();
				}
				second = Num13.Floor( this.time ) % 60;
				minute = ( Num13.Floor( this.time ) - second ) / 60;
				dat = new Txt( "<HTML><HEAD></HEAD><BODY><TT><B>Fire alarm</B> " ).item( d1 ).str( "\n<HR>The current alert level is: " ).item( GlobalFuncs.get_security_level() ).str( "</b><br><br>\nTimer System: " ).item( d2 ).str( "<BR>\nTime Left: " ).item( ( minute != 0 ? "" + minute + ":" : null ) ).item( second ).str( " <A href='?src=" ).Ref( this ).str( ";tp=-30'>-</A> <A href='?src=" ).Ref( this ).str( ";tp=-1'>-</A> <A href='?src=" ).Ref( this ).str( ";tp=1'>+</A> <A href='?src=" ).Ref( this ).str( ";tp=30'>+</A>\n</TT></BODY></HTML>" ).ToString();
				Interface13.Browse( a, dat, "window=firealarm" );
				GlobalFuncs.onclose( a, "firealarm" );
			} else {
				
				if ( Lang13.Bool( this.areaMaster.fire ) ) {
					d1 = new Txt( "<A href='?src=" ).Ref( this ).str( ";reset=1'>" ).item( GlobalFuncs.stars( "Reset - Lockdown" ) ).str( "</A>" ).ToString();
				} else {
					d1 = new Txt( "<A href='?src=" ).Ref( this ).str( ";alarm=1'>" ).item( GlobalFuncs.stars( "Alarm - Lockdown" ) ).str( "</A>" ).ToString();
				}

				if ( Lang13.Bool( this.timing ) ) {
					d2 = new Txt( "<A href='?src=" ).Ref( this ).str( ";time=0'>" ).item( GlobalFuncs.stars( "Stop Time Lock" ) ).str( "</A>" ).ToString();
				} else {
					d2 = new Txt( "<A href='?src=" ).Ref( this ).str( ";time=1'>" ).item( GlobalFuncs.stars( "Initiate Time Lock" ) ).str( "</A>" ).ToString();
				}
				second2 = Num13.Floor( this.time ) % 60;
				minute2 = ( Num13.Floor( this.time ) - second2 ) / 60;
				dat2 = new Txt( "<HTML><HEAD></HEAD><BODY><TT><B>" ).item( GlobalFuncs.stars( "Fire alarm" ) ).str( "</B> " ).item( d1 ).str( "\n<HR><b>The current alert level is: " ).item( GlobalFuncs.stars( GlobalFuncs.get_security_level() ) ).str( "</b><br><br>\nTimer System: " ).item( d2 ).str( "<BR>\nTime Left: " ).item( ( minute2 != 0 ? "" + minute2 + ":" : null ) ).item( second2 ).str( " <A href='?src=" ).Ref( this ).str( ";tp=-30'>-</A> <A href='?src=" ).Ref( this ).str( ";tp=-1'>-</A> <A href='?src=" ).Ref( this ).str( ";tp=1'>+</A> <A href='?src=" ).Ref( this ).str( ";tp=30'>+</A>\n</TT></BODY></HTML>" ).ToString();
				Interface13.Browse( a, dat2, "window=firealarm" );
				GlobalFuncs.onclose( a, "firealarm" );
			}
			return null;
		}

		// Function from file: alarm.dm
		public override dynamic power_change(  ) {
			
			if ( Lang13.Bool( this.powered( 3 ) ) ) {
				this.stat &= 65533;
				this.update_icon();
			} else {
				Task13.Schedule( Rand13.Int( 0, 15 ), (Task13.Closure)(() => {
					this.stat |= 2;
					this.update_icon();
					return;
				}));
			}
			return null;
		}

		// Function from file: alarm.dm
		public override dynamic process(  ) {
			
			if ( ( this.stat & 3 ) != 0 ) {
				return null;
			}

			if ( Lang13.Bool( this.timing ) ) {
				
				if ( this.time > 0 ) {
					this.time = this.time - ( Game13.timeofday - this.last_process ) / 10;
				} else {
					this.alarm();
					this.time = 0;
					this.timing = 0;
					GlobalVars.processing_objects.Remove( this );
				}
				this.updateDialog();
			}
			this.last_process = Game13.timeofday;

			if ( Lang13.Bool( Lang13.FindIn( typeof(Obj_Fire), this.loc ) ) ) {
				this.alarm();
			}
			return null;
		}

		// Function from file: alarm.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic coil = null;

			this.add_fingerprint( b );

			if ( a is Obj_Item_Weapon_Screwdriver && this.buildstage == 2 ) {
				this.wiresexposed = !this.wiresexposed;
				GlobalFuncs.to_chat( b, "The wires have been " + ( this.wiresexposed ? "exposed" : "unexposed" ) + "." );
				GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/items/Screwdriver.ogg", 50, 1 );
				this.update_icon();
				return null;
			}

			if ( this.wiresexposed ) {
				
				switch ((int)( this.buildstage )) {
					case 2:
						
						if ( a is Obj_Item_Device_Multitool ) {
							this.detecting = !this.detecting;
							((Ent_Static)b).visible_message( "<span class='attack'>" + b + " has " + ( this.detecting ? "re" : "dis" ) + "connected " + this + "'s detecting unit!</span>", "You have " + ( this.detecting ? "re" : "dis" ) + "reconnected " + this + "'s detecting unit." );
							GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/items/healthanalyzer.ogg", 50, 1 );
						}

						if ( a is Obj_Item_Weapon_Wirecutters ) {
							GlobalFuncs.to_chat( b, "You begin to cut the wiring..." );
							GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/items/Wirecutter.ogg", 50, 1 );

							if ( GlobalFuncs.do_after( b, this, 50 ) && this.buildstage == 2 && this.wiresexposed ) {
								this.buildstage = 1;
								((Ent_Static)b).visible_message( new Txt( "<span class='attack'>" ).item( b ).str( " has cut the wiring from " ).the( this ).item().str( "!</span>" ).ToString(), new Txt( "You have cut the last of the wiring from " ).the( this ).item().str( "." ).ToString() );
								this.update_icon();
								GlobalFuncs.getFromPool( typeof(Obj_Item_Stack_CableCoil), GlobalFuncs.get_turf( b ), 5 );
							}
						}
						break;
					case 1:
						
						if ( a is Obj_Item_Stack_CableCoil ) {
							coil = a;

							if ( Convert.ToDouble( coil.amount ) < 5 ) {
								GlobalFuncs.to_chat( b, "You need more cable for this!" );
								return null;
							}
							coil.use( 5 );
							this.buildstage = 2;
							GlobalFuncs.to_chat( b, new Txt( "You wire " ).the( this ).item().str( "!" ).ToString() );
							this.update_icon();
						} else if ( a is Obj_Item_Weapon_Crowbar ) {
							GlobalFuncs.to_chat( b, "You start prying out the circuit..." );
							GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/items/Crowbar.ogg", 50, 1 );

							if ( GlobalFuncs.do_after( b, this, 20 ) && this.buildstage == 1 ) {
								GlobalFuncs.to_chat( b, "You pry out the circuit!" );
								new Obj_Item_Weapon_Circuitboard_FireAlarm( GlobalFuncs.get_turf( b ) );
								this.buildstage = 0;
								this.update_icon();
							}
						}
						break;
					case 0:
						
						if ( a is Obj_Item_Weapon_Circuitboard_FireAlarm ) {
							GlobalFuncs.to_chat( b, "You insert the circuit!" );
							GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/items/Deconstruct.ogg", 50, 1 );
							GlobalFuncs.qdel( a );
							this.buildstage = 1;
							this.update_icon();
						} else if ( a is Obj_Item_Weapon_Wrench ) {
							GlobalFuncs.to_chat( b, "You remove the fire alarm assembly from the wall!" );
							new Obj_Item_Mounted_Frame_Firealarm( GlobalFuncs.get_turf( b ) );
							GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/items/Ratchet.ogg", 50, 1 );
							GlobalFuncs.qdel( this );
						}
						break;
				}
				return null;
			}
			this.alarm();
			return null;
		}

		// Function from file: alarm.dm
		public override dynamic emp_act( int severity = 0 ) {
			
			if ( Rand13.PercentChance( ((int)( 50 / severity )) ) ) {
				this.alarm();
			}
			base.emp_act( severity );
			return null;
		}

		// Function from file: alarm.dm
		public override dynamic attack_paw( Mob a = null, dynamic b = null, dynamic c = null ) {
			return this.attack_hand( a );
		}

		// Function from file: alarm.dm
		public override int? bullet_act( dynamic Proj = null, dynamic def_zone = null ) {
			this.alarm(); return null;
		}

		// Function from file: alarm.dm
		public override dynamic attack_ai( dynamic user = null ) {
			this.add_hiddenprint( user );
			return this.attack_hand( user );
		}

		// Function from file: alarm.dm
		public override bool fire_act( GasMixture air = null, double? exposed_temperature = null, int exposed_volume = 0 ) {
			
			if ( this.detecting ) {
				
				if ( ( exposed_temperature ??0) > 473.41 ) {
					this.alarm();
				}
			}
			return false;
		}

		// Function from file: alarm.dm
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			
			if ( this.wiresexposed ) {
				
				switch ((int)( this.buildstage )) {
					case 2:
						this.icon_state = "fire_b2";
						break;
					case 1:
						this.icon_state = "fire_b1";
						break;
					case 0:
						this.icon_state = "fire_b0";
						break;
				}
				return null;
			}

			if ( ( this.stat & 1 ) != 0 ) {
				this.icon_state = "firex";
			} else if ( ( this.stat & 2 ) != 0 ) {
				this.icon_state = "firep";
			} else if ( !this.detecting ) {
				this.icon_state = "fire1";
			} else {
				this.icon_state = "fire0";
			}
			return null;
		}

		// Function from file: trash_machinery.dm
		public override dynamic cultify(  ) {
			GlobalFuncs.qdel( this );
			return null;
		}

	}

}