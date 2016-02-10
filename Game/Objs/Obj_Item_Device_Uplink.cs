// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Device_Uplink : Obj_Item_Device {

		public string welcome = null;
		public dynamic uses = null;
		public ByTable purchase_log = new ByTable();
		public double? show_description = null;
		public bool active = false;
		public dynamic job = null;

		// Function from file: uplinks.dm
		public Obj_Item_Device_Uplink ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.welcome = GlobalVars.ticker.mode.uplink_welcome;
			this.uses = GlobalVars.ticker.mode.uplink_uses;
			return;
		}

		// Function from file: uplinks.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			dynamic item = null;
			ByTable split = null;
			dynamic category = null;
			double? number = null;
			ByTable buyable_items = null;
			ByTable uplink = null;
			dynamic I = null;
			string text = null;
			string textalt = null;

			base.Topic( href, href_list, (object)(hclient) );

			if ( !this.active ) {
				return null;
			}

			if ( Lang13.Bool( href_list["buy_item"] ) ) {
				item = href_list["buy_item"];
				split = GlobalFuncs.text2list( item, ":" );

				if ( split.len == 2 ) {
					category = split[1];
					number = String13.ParseNumber( split[2] );
					buyable_items = GlobalFuncs.get_uplink_items();
					uplink = buyable_items[category];

					if ( uplink != null && uplink.len >= ( number ??0) ) {
						I = uplink[number];

						if ( Lang13.Bool( I ) ) {
							I.buy( this, Task13.User );
						}
					} else {
						text = "" + GlobalFuncs.key_name( Task13.User ) + " tried to purchase an uplink item that doesn't exist";
						textalt = "" + GlobalFuncs.key_name( Task13.User ) + " tried to purchase an uplink item that doesn't exist " + item;
						GlobalFuncs.message_admins( text );
						GlobalVars.diary.WriteMsg( String13.HtmlDecode( "[" + GlobalFuncs.time_stamp() + "]GAME: " + textalt ) );
						GlobalVars.admin_log.Add( textalt );
					}
				}
			} else if ( Lang13.Bool( href_list["show_desc"] ) ) {
				this.show_description = String13.ParseNumber( href_list["show_desc"] );
				this.interact( Task13.User );
			}
			return null;
		}

		// Function from file: uplinks.dm
		public override dynamic interact( dynamic user = null, bool? flag1 = null ) {
			string dat = null;

			dat = "<body link='yellow' alink='white' bgcolor='#601414'><font color='white'>";
			dat += this.generate_menu( user );
			dat += new Txt( "<A href='byond://?src=" ).Ref( this ).str( ";lock=1'>Lock</a>\n		</font></body>" ).ToString();
			Interface13.Browse( user, dat, "window=hidden" );
			GlobalFuncs.onclose( user, "hidden" );
			return null;
		}

		// Function from file: uplinks.dm
		public string generate_menu( dynamic user = null ) {
			string dat = null;
			ByTable buyable_items = null;
			int index = 0;
			dynamic category = null;
			int i = 0;
			UplinkItem item = null;
			string cost_text = null;
			string desc = null;

			
			if ( !Lang13.Bool( this.job ) ) {
				this.job = user.mind.assigned_role;
			}
			dat = "<B>" + this.welcome + "</B><BR>";
			dat += "Tele-Crystals left: " + this.uses + "<BR>\n		<HR>\n		<B>Request item:</B><BR>\n		<I>Each item costs a number of tele-crystals as indicated by the number following their name.</I><br><BR>";
			buyable_items = GlobalFuncs.get_uplink_items();
			index = 0;

			foreach (dynamic _b in Lang13.Enumerate( buyable_items )) {
				category = _b;
				
				index++;
				dat += "<b>" + category + "</b><br>";
				i = 0;

				foreach (dynamic _a in Lang13.Enumerate( buyable_items[category], typeof(UplinkItem) )) {
					item = _a;
					
					i++;
					cost_text = "";
					desc = "" + item.desc;

					if ( item.job != null && item.job.len != 0 ) {
						
						if ( !( item.job.Find( this.job ) != 0 ) ) {
							continue;
						}
					}

					if ( item.cost > 0 ) {
						cost_text = "(" + item.cost + ")";
					}

					if ( item.cost <= Convert.ToDouble( this.uses ) ) {
						dat += new Txt( "<A href='byond://?src=" ).Ref( this ).str( ";buy_item=" ).item( category ).str( ":" ).item( i ).str( ";'>" ).item( item.name ).str( "</A> " ).item( cost_text ).str( " " ).ToString();
					} else {
						dat += "<font color='grey'><i>" + item.name + " " + cost_text + " </i></font>";
					}

					if ( Lang13.Bool( item.desc ) ) {
						
						if ( this.show_description == 2 ) {
							dat += new Txt( "<A href='byond://?src=" ).Ref( this ).str( ";show_desc=1'><font size=2>[-]</font></A><BR><font size=2>" ).item( desc ).str( "</font>" ).ToString();
						} else {
							dat += new Txt( "<A href='byond://?src=" ).Ref( this ).str( ";show_desc=2'><font size=2>[?]</font></A>" ).ToString();
						}
					}
					dat += "<BR>";
				}

				if ( buyable_items.len != index ) {
					dat += "<br>";
				}
			}
			dat += "<HR>";
			return dat;
		}

	}

}