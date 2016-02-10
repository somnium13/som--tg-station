// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Storage_Belt : Obj_Item_Weapon_Storage {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "utility";
			this.slot_flags = 512;
			this.attack_verb = new ByTable(new object [] { "whipped", "lashed", "disciplined" });
			this.icon = "icons/obj/clothing/belts.dmi";
			this.icon_state = "utilitybelt";
		}

		public Obj_Item_Weapon_Storage_Belt ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: belt.dm
		public bool can_use(  ) {
			Ent_Static M = null;

			
			if ( !( this.loc is Mob ) ) {
				return false;
			}
			M = this.loc;
			Interface13.Stat( null, ((dynamic)M).get_equipped_items().Contains( this ) );

			if ( !( this.loc is Mob ) ) {
				return true;
			} else {
				return false;
			}
		}

	}

}