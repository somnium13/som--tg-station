// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Screen_Close : Obj_Screen {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.globalscreen = true;
		}

		public Obj_Screen_Close ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: screen_objects.dm
		public override bool Click( dynamic loc = null, string control = null, string _params = null ) {
			Ent_Static S = null;
			Ent_Static S2 = null;
			Ent_Static rcd = null;

			
			if ( this.master != null ) {
				
				if ( this.master is Obj_Item_Weapon_Storage ) {
					S = this.master;
					((dynamic)S).close( Task13.User );
				} else if ( this.master is Obj_Item_Clothing_Suit_Storage ) {
					S2 = this.master;
					((dynamic)S2).close( Task13.User );
				} else if ( this.master is Obj_Item_Device_Rcd ) {
					rcd = this.master;
					((dynamic)rcd).show_default( Task13.User );
				}
			}
			return true;
		}

	}

}