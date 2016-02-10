// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Veilrender_Vealrender : Obj_Item_Weapon_Veilrender {

		public Obj_Item_Weapon_Veilrender_Vealrender ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: artefact.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			
			if ( this.charged ) {
				new Obj_Effect_Rend_Cow( GlobalFuncs.get_turf( Task13.User ) );
				this.charged = false;
				this.visible_message( "<span class='danger'>" + this + " hums with power as " + Task13.User + " deals a blow to hunger itself!</span>" );
			} else {
				GlobalFuncs.to_chat( user, "<span class='warning'>The unearthly energies that powered the blade are now dormant.</span>" );
			}
			return null;
		}

	}

}