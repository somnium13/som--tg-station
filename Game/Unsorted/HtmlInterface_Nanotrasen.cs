// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class HtmlInterface_Nanotrasen : HtmlInterface {

		// Function from file: nanotrasen.dm
		public HtmlInterface_Nanotrasen ( Game_Data _ref = null, string title = null, int? width = null, int? height = null, string head = null ) : base( _ref, title, width, height, head ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.head = this.head + "<link rel=\"stylesheet\" type=\"text/css\" href=\"hi-nanotrasen.css\" />";
			this.updateLayout( "" );
			return;
		}

		// Function from file: tgstation.dme
		public void setEyeColor( string color = null, dynamic hclient = null ) {
			string resource = null;

			hclient = this.getClient( hclient );

			if ( hclient is HtmlInterfaceClient ) {
				
				switch ((string)( color )) {
					case "green":
						resource = "uiEyeGreen.png";
						break;
					case "orange":
						resource = "uiEyeOrange.png";
						break;
					case "red":
						resource = "uiEyeRed.png";
						break;
					default:
						Task13.Crash( "Invalid color: " + color );
						break;
				}

				if ( ((HtmlInterfaceClient)hclient).getExtraVar( "eye_color" ) != color ) {
					((HtmlInterfaceClient)hclient).putExtraVar( "eye_color", color );
					Interface13.WindowSet( hclient.client, new Txt( "browser_" ).Ref( this ).str( ".uiTitleEye" ).ToString(), String13.MakeUrlParams( new ByTable().Set( "image", "" + resource ) ) );
				}
			} else {
				GlobalFuncs.warning( "" + "Invalid object passed to /datum/html_interface/nanotrasen/proc/setEyeColor" + " in " + "tgstation.dme" + " at line " + 1078 + " src: " + this + " usr: " + Task13.User + "." );
			}
			return;
		}

		// Function from file: nanotrasen.dm
		public override void disableFor( dynamic hclient = null ) {
			hclient.active = GlobalVars.FALSE;
			this.setEyeColor( "red", hclient );
			return;
		}

		// Function from file: nanotrasen.dm
		public override dynamic enableFor( dynamic hclient = null ) {
			dynamic _default = null;

			_default = base.enableFor( (object)(hclient) );
			this.setEyeColor( "green", hclient );
			return _default;
		}

		// Function from file: nanotrasen.dm
		public override dynamic createWindow( dynamic hclient = null ) {
			dynamic _default = null;

			_default = base.createWindow( (object)(hclient) );
			Interface13.WindowSet( hclient.client, new Txt( "browser_" ).Ref( this ).ToString(), String13.MakeUrlParams( new ByTable().Set( "titlebar", "false" ) ) );
			Interface13.WindowSet( hclient.client, new Txt( "browser_" ).Ref( this ).str( ".browser" ).ToString(), String13.MakeUrlParams( new ByTable().Set( "pos", "0,35" ).Set( "size", "" + this.width + "x" + ( ( this.height ??0) - 35 ) ) ) );
			Interface13.WindowSet( hclient.client, new Txt( "browser_" ).Ref( this ).str( ".topbg" ).ToString(), String13.MakeUrlParams( new ByTable()
				.Set( "parent", new Txt( "browser_" ).Ref( this ).ToString() )
				.Set( "type", "label" )
				.Set( "pos", "0,0" )
				.Set( "size", "" + this.width + "x35" )
				.Set( "anchor1", "0,0" )
				.Set( "anchor2", "100,0" )
				.Set( "image", "" + "uiBgtop.png" )
				.Set( "image-mode", "tile" )
				.Set( "is-disabled", "true" )
			 ) );
			Interface13.WindowSet( hclient.client, new Txt( "browser_" ).Ref( this ).str( ".uiTitleFluff" ).ToString(), String13.MakeUrlParams( new ByTable()
				.Set( "parent", new Txt( "browser_" ).Ref( this ).ToString() )
				.Set( "type", "label" )
				.Set( "pos", "" + ( ( this.width ??0) - 42 - 4 - 24 - 4 - 24 - 4 ) + ",5" )
				.Set( "size", "42x24" )
				.Set( "anchor1", "100,0" )
				.Set( "anchor2", "100,0" )
				.Set( "image", "" + "uiTitleFluff.png" )
				.Set( "image-mode", "tile" )
				.Set( "is-disabled", "true" )
			 ) );
			Interface13.WindowSet( hclient.client, new Txt( "browser_" ).Ref( this ).str( ".uiTitleEye" ).ToString(), String13.MakeUrlParams( new ByTable()
				.Set( "parent", new Txt( "browser_" ).Ref( this ).ToString() )
				.Set( "type", "label" )
				.Set( "pos", "8,5" )
				.Set( "size", "42x24" )
				.Set( "anchor1", "0,0" )
				.Set( "anchor2", "0,0" )
				.Set( "image", "" + "uiEyeGreen.png" )
				.Set( "image-mode", "tile" )
				.Set( "is-disabled", "true" )
			 ) );
			Interface13.WindowSet( hclient.client, new Txt( "browser_" ).Ref( this ).str( ".uiTitle" ).ToString(), String13.MakeUrlParams( new ByTable()
				.Set( "parent", new Txt( "browser_" ).Ref( this ).ToString() )
				.Set( "type", "label" )
				.Set( "is-transparent", "true" )
				.Set( "pos", "64,0" )
				.Set( "size", "580x35" )
				.Set( "anchor1", "0,0" )
				.Set( "anchor2", "100,0" )
				.Set( "is-disabled", "true" )
				.Set( "text", "" + this.title )
				.Set( "align", "left" )
				.Set( "font-family", "verdana,Geneva,sans-serif" )
				.Set( "font-size", "12" )
				.Set( "text-color", "#E9C183" )
			 ) );
			Interface13.WindowSet( hclient.client, new Txt( "browser_" ).Ref( this ).str( ".uiTitleMinimize" ).ToString(), String13.MakeUrlParams( new ByTable()
				.Set( "parent", new Txt( "browser_" ).Ref( this ).ToString() )
				.Set( "type", "button" )
				.Set( "is-flat", "true" )
				.Set( "background-color", "#383838" )
				.Set( "text-color", "#FFFFFF" )
				.Set( "is-transparent", "true" )
				.Set( "pos", "" + ( ( this.width ??0) - 24 - 4 - 24 - 4 ) + ",5" )
				.Set( "size", "24x24" )
				.Set( "anchor1", "100,0" )
				.Set( "anchor2", "100,0" )
				.Set( "text", "-" )
				.Set( "font-family", "verdana,Geneva,sans-serif" )
				.Set( "font-size", "12" )
				.Set( "command", new Txt( ".winset \"browser_" ).Ref( this ).str( ".can-resize=false;browser_" ).Ref( this ).str( ".is-minimized=true;browser_" ).Ref( this ).str( ".on-size=\".swinset \\\"browser_" ).Ref( this ).str( ".can-resize=true;browser_" ).Ref( this ).str( ".on-size=\\\"\"\"" ).ToString() )
			 ) );
			Interface13.WindowSet( hclient.client, new Txt( "browser_" ).Ref( this ).str( ".uiTitleClose" ).ToString(), String13.MakeUrlParams( new ByTable()
				.Set( "parent", new Txt( "browser_" ).Ref( this ).ToString() )
				.Set( "type", "button" )
				.Set( "is-flat", "true" )
				.Set( "background-color", "#383838" )
				.Set( "text-color", "#FFFFFF" )
				.Set( "command", new Txt( "byond://?src=" ).Ref( this ).str( ";html_interface_action=onclose" ).ToString() )
				.Set( "is-transparent", "true" )
				.Set( "pos", "" + ( ( this.width ??0) - 24 - 4 ) + ",5" )
				.Set( "size", "24x24" )
				.Set( "anchor1", "100,0" )
				.Set( "anchor2", "100,0" )
				.Set( "text", "X" )
				.Set( "font-family", "verdana,Geneva,sans-serif" )
				.Set( "font-size", "12" )
			 ) );
			return _default;
		}

		// Function from file: nanotrasen.dm
		public override void registerResources( ByTable resources = null ) {
			resources = resources ?? new ByTable();

			resources["uiBg.png"] = "uiBg.png";
			resources["uiBgcenter.png"] = "uiBgcenter.png";
			resources["hi-nanotrasen.css"] = "hi-nanotrasen.css";
			base.registerResources( resources );
			return;
		}

		// Function from file: nanotrasen.dm
		public override void updateLayout( string layout = null ) {
			base.updateLayout( "<div id=\"ntbgcenter\"></div><div id=\"content\">" + layout + "</div>" ); return;
		}

	}

}