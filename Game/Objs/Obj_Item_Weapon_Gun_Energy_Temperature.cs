// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Gun_Energy_Temperature : Obj_Item_Weapon_Gun_Energy {

		public double temperature = 300;
		public double target_temperature = 300;
		public string powercost = "";
		public string powercostcolor = "";
		public bool emagged = false;
		public string dat = "";

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "tempgun_4";
			this.slot_flags = 1024;
			this.w_class = 4;
			this.fire_sound = "sound/weapons/pulse3.ogg";
			this.charge_cost = 90;
			this.origin_tech = "combat=3;materials=4;powerstorage=3;magnets=2";
			this.projectile_type = "/obj/item/projectile/temp";
			this.cell_type = "/obj/item/weapon/cell/temperaturegun";
			this.icon = "icons/obj/gun_temperature.dmi";
			this.icon_state = "tempgun_4";
		}

		// Function from file: temperature.dm
		public Obj_Item_Weapon_Gun_Energy_Temperature ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.update_icon();
			GlobalVars.processing_objects.Add( this );
			return;
		}

		// Function from file: temperature.dm
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			this.overlays = 0;
			this.update_temperature();
			this.update_user();
			this.update_charge();
			return null;
		}

		// Function from file: temperature.dm
		public void update_user(  ) {
			Ent_Static M = null;

			
			if ( this.loc is Mob_Living_Carbon ) {
				M = this.loc;
				((dynamic)M).update_inv_back();
				((dynamic)M).update_inv_l_hand();
				((dynamic)M).update_inv_r_hand();
			}
			return;
		}

		// Function from file: temperature.dm
		public void update_charge(  ) {
			double charge = 0;

			charge = Convert.ToDouble( this.power_supply.charge );

			dynamic _a = charge; // Was a switch-case, sorry for the mess.
			if ( 900<=_a&&_a<=Double.PositiveInfinity ) {
				this.overlays.Add( "900" );
			} else if ( 800<=_a&&_a<=900 ) {
				this.overlays.Add( "800" );
			} else if ( 700<=_a&&_a<=800 ) {
				this.overlays.Add( "700" );
			} else if ( 600<=_a&&_a<=700 ) {
				this.overlays.Add( "600" );
			} else if ( 500<=_a&&_a<=600 ) {
				this.overlays.Add( "500" );
			} else if ( 400<=_a&&_a<=500 ) {
				this.overlays.Add( "400" );
			} else if ( 300<=_a&&_a<=400 ) {
				this.overlays.Add( "300" );
			} else if ( 200<=_a&&_a<=300 ) {
				this.overlays.Add( "200" );
			} else if ( 100<=_a&&_a<=200 ) {
				this.overlays.Add( "100" );
			} else if ( Double.NegativeInfinity<=_a&&_a<=100 ) {
				this.overlays.Add( "0" );
			}
			return;
		}

		// Function from file: temperature.dm
		public void update_temperature(  ) {
			
			dynamic _a = this.temperature; // Was a switch-case, sorry for the mess.
			if ( 501<=_a&&_a<=Double.PositiveInfinity ) {
				this.item_state = "tempgun_8";
			} else if ( 400<=_a&&_a<=500 ) {
				this.item_state = "tempgun_7";
			} else if ( 360<=_a&&_a<=400 ) {
				this.item_state = "tempgun_6";
			} else if ( 335<=_a&&_a<=360 ) {
				this.item_state = "tempgun_5";
			} else if ( 295<=_a&&_a<=335 ) {
				this.item_state = "tempgun_4";
			} else if ( 260<=_a&&_a<=295 ) {
				this.item_state = "tempgun_3";
			} else if ( 200<=_a&&_a<=260 ) {
				this.item_state = "tempgun_2";
			} else if ( 120<=_a&&_a<=260 ) {
				this.item_state = "tempgun_1";
			} else if ( Double.NegativeInfinity<=_a&&_a<=120 ) {
				this.item_state = "tempgun_0";
			}
			this.icon_state = this.item_state;
			return;
		}

		// Function from file: temperature.dm
		public void update_dat(  ) {
			this.dat = "";
			this.dat += "Current output temperature: ";

			if ( this.temperature > 500 ) {
				this.dat += "<FONT color=red><B>" + this.temperature + "</B> (" + Num13.Floor( this.temperature - 273.41 ) + "&deg;C) (" + Num13.Floor( this.temperature * 171 - 459.6700134277344 ) + "&deg;F) </FONT>";
				this.dat += "<FONT color=red><B>SEARING!!</B></FONT>";
			} else if ( this.temperature > 323.41 ) {
				this.dat += "<FONT color=red><B>" + this.temperature + "</B> (" + Num13.Floor( this.temperature - 273.41 ) + "&deg;C) (" + Num13.Floor( this.temperature * 171 - 459.6700134277344 ) + "&deg;F)</FONT>";
			} else if ( this.temperature > 223.41 ) {
				this.dat += "<FONT color=black><B>" + this.temperature + "</B> (" + Num13.Floor( this.temperature - 273.41 ) + "&deg;C) (" + Num13.Floor( this.temperature * 171 - 459.6700134277344 ) + "&deg;F)</FONT>";
			} else {
				this.dat += "<FONT color=blue><B>" + this.temperature + "</B> (" + Num13.Floor( this.temperature - 273.41 ) + "&deg;C) (" + Num13.Floor( this.temperature * 171 - 459.6700134277344 ) + "&deg;F)</FONT>";
			}
			this.dat += "<BR>";
			this.dat += "Target output temperature: ";
			this.dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";temp=-100'>-</A> " ).ToString();
			this.dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";temp=-10'>-</A> " ).ToString();
			this.dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";temp=-1'>-</A> " ).ToString();
			this.dat += "" + this.target_temperature + " ";
			this.dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";temp=1'>+</A> " ).ToString();
			this.dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";temp=10'>+</A> " ).ToString();
			this.dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";temp=100'>+</A>" ).ToString();
			this.dat += "<BR>";
			this.dat += "Power cost: ";
			this.dat += "<FONT color=" + this.powercostcolor + "><B>" + this.powercost + "</B></FONT>";
			return;
		}

		// Function from file: temperature.dm
		public override dynamic process(  ) {
			double difference = 0;
			Ent_Static M = null;

			
			dynamic _a = this.temperature; // Was a switch-case, sorry for the mess.
			if ( 0<=_a&&_a<=100 ) {
				this.charge_cost = 300;
				this.powercost = "High";
			} else if ( 100<=_a&&_a<=250 ) {
				this.charge_cost = 180;
				this.powercost = "Medium";
			} else if ( 251<=_a&&_a<=300 ) {
				this.charge_cost = 90;
				this.powercost = "Low";
			} else if ( 301<=_a&&_a<=400 ) {
				this.charge_cost = 180;
				this.powercost = "Medium";
			} else if ( 401<=_a&&_a<=1000 ) {
				this.charge_cost = 300;
				this.powercost = "High";
			}

			switch ((string)( this.powercost )) {
				case "High":
					this.powercostcolor = "orange";
					break;
				case "Medium":
					this.powercostcolor = "green";
					break;
				default:
					this.powercostcolor = "blue";
					break;
			}

			if ( this.target_temperature != this.temperature ) {
				difference = Math.Abs( this.target_temperature - this.temperature );

				if ( difference >= ( this.emagged ?1:0) * 40 + 10 ) {
					
					if ( this.target_temperature < this.temperature ) {
						this.temperature -= ( this.emagged ?1:0) * 40 + 10;
					} else {
						this.temperature += ( this.emagged ?1:0) * 40 + 10;
					}
				} else {
					this.temperature = this.target_temperature;
				}
				this.update_icon();

				if ( this.loc is Mob_Living_Carbon ) {
					M = this.loc;

					if ( this == ((dynamic)M).machine ) {
						this.update_dat();
						Interface13.Browse( M, "<TITLE>Temperature Gun Configuration</TITLE><HR>" + this.dat, "window=tempgun;size=510x102" );
					}
				}
			}

			if ( Lang13.Bool( this.power_supply ) ) {
				((Obj_Item_Weapon_Cell)this.power_supply).give( 50 );
				this.update_icon();
			}
			return null;
		}

		// Function from file: temperature.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			double? amount = null;

			
			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hclient) ) ) ) {
				return null;
			}
			Task13.User.set_machine( this );
			this.add_fingerprint( Task13.User );

			if ( Lang13.Bool( href_list["temp"] ) ) {
				amount = String13.ParseNumber( href_list["temp"] );

				if ( ( amount ??0) > 0 ) {
					this.target_temperature = Num13.MinInt( ( this.emagged ?1:0) * 500 + 500, ((int)( this.target_temperature + ( amount ??0) )) );
				} else {
					this.target_temperature = Num13.MaxInt( 0, ((int)( this.target_temperature + ( amount ??0) )) );
				}
			}

			if ( this.loc is Mob ) {
				this.attack_self( this.loc );
			}
			this.add_fingerprint( Task13.User );
			return null;
		}

		// Function from file: temperature.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( a is Obj_Item_Weapon_Card_Emag && !this.emagged ) {
				this.emagged = true;
				GlobalFuncs.to_chat( b, "<span class='caution'>You double the gun's temperature cap ! Targets hit by searing beams will burst into flames !</span>" );
				this.desc = "A gun that changes the body temperature of its targets. Its temperature cap has been hacked";
			}
			return null;
		}

		// Function from file: temperature.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			((Mob)user).set_machine( this );
			this.update_dat();
			Interface13.Browse( user, "<TITLE>Temperature Gun Configuration</TITLE><HR>" + this.dat, "window=tempgun;size=510x102" );
			GlobalFuncs.onclose( user, "tempgun" );
			return null;
		}

		// Function from file: temperature.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			GlobalVars.processing_objects.Remove( this );
			base.Destroy( (object)(brokenup) );
			return null;
		}

	}

}