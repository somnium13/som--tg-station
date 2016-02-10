// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Urinal : Obj_Structure {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.icon = "icons/obj/watercloset.dmi";
			this.icon_state = "urinal";
		}

		public Obj_Structure_Urinal ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: watercloset.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic G = null;
			Ent_Static GM = null;

			
			if ( a is Obj_Item_Weapon_Grab ) {
				G = a;

				if ( G.affecting is Mob_Living ) {
					GM = G.affecting;

					if ( Convert.ToDouble( G.state ) > 1 ) {
						
						if ( !( GM.loc != null ) == GlobalFuncs.get_turf( this ) ) {
							GlobalFuncs.to_chat( b, "<span class='notice'>" + GM.name + " needs to be on the urinal.</span>" );
							return null;
						}
						((Ent_Static)b).visible_message( "<span class='danger'>" + b + " slams " + GM.name + " into the " + this + "!</span>", "<span class='notice'>You slam " + GM.name + " into the " + this + "!</span>" );
						((dynamic)GM).adjustBruteLoss( 8 );
					} else {
						GlobalFuncs.to_chat( b, "<span class='notice'>You need a tighter grip.</span>" );
					}
				}
			}
			return null;
		}

	}

}