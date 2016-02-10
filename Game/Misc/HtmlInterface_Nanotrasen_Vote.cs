// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class HtmlInterface_Nanotrasen_Vote : HtmlInterface_Nanotrasen {

		public HtmlInterface_Nanotrasen_Vote ( Game_Data _ref = null, string title = null, int? width = null, int? height = null, string head = null ) : base( _ref, title, width, height, head ) {
			
		}

		// Function from file: voting.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			dynamic hclient2 = null;

			base.Topic( href, href_list, (object)(hclient) );

			if ( href_list["html_interface_action"] == "onclose" ) {
				hclient2 = this.getClient( Task13.User.client );

				if ( hclient2 is HtmlInterfaceClient ) {
					this.hide( hclient2 );
					GlobalVars.vote.voting.Remove( Task13.User.client );
				}
			}
			return null;
		}

		// Function from file: voting.dm
		public override bool sendAssets( Client client = null ) {
			base.sendAssets( client );
			GlobalFuncs.send_asset( client, "voting.js" );
			GlobalFuncs.send_asset( client, "voting.css" );
			return false;
		}

		// Function from file: voting.dm
		public override dynamic registerResources(  ) {
			dynamic _default = null;

			_default = base.registerResources();
			GlobalFuncs.register_asset( "voting.js", "voting.js" );
			GlobalFuncs.register_asset( "voting.css", "voting.css" );
			return _default;
		}

	}

}