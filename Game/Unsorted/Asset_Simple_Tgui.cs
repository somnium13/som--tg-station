// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Asset_Simple_Tgui : Asset_Simple {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.assets = new ByTable().Set( "tgui.css", "tgui/assets/tgui.css" ).Set( "tgui.js", "tgui/assets/tgui.js" );
		}

	}

}