// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Diseasedisk : Obj_Item_Weapon {

		public dynamic effect = null;
		public bool stage = true;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon = "icons/obj/cloning.dmi";
			this.icon_state = "datadisk0";
		}

		public Obj_Item_Weapon_Diseasedisk ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}