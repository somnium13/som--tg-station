// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Ears : Obj_Item_Clothing {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.w_class = 1;
			this.throwforce = 2;
			this.slot_flags = 16;
		}

		public Obj_Item_Clothing_Ears ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: clothing.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic H = null;
			Obj_Item_Clothing_Ears O = null;

			
			if ( !Lang13.Bool( a ) ) {
				return null;
			}

			if ( this.loc != a || !( a is Mob_Living_Carbon_Human ) ) {
				base.attack_hand( (object)(a), (object)(b), (object)(c) );
				return null;
			}
			H = a;

			if ( H.ears != this ) {
				base.attack_hand( (object)(a), (object)(b), (object)(c) );
				return null;
			}

			if ( !this.canremove ) {
				return null;
			}
			O = this;
			((Mob)a).u_equip( this, false );

			if ( O != null ) {
				((Mob)a).put_in_hands( O );
				O.add_fingerprint( a );
			}
			return null;
		}

	}

}