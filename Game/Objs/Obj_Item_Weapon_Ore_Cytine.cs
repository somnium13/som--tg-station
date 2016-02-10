// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Ore_Cytine : Obj_Item_Weapon_Ore {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.material = "cytine";
			this.icon_state = "cytine";
		}

		// Function from file: ores_coins.dm
		public Obj_Item_Weapon_Ore_Cytine ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.color = Rand13.Pick(new object [] { "#FF0000", "#0000FF", "#008000", "#FFFF00" });
			return;
		}

		// Function from file: ores_coins.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			Obj_Item_Weapon_Glowstick G = null;

			G = new Obj_Item_Weapon_Glowstick( a.loc );
			G.color = this.color;
			G.light_color = this.color;
			GlobalFuncs.qdel( this );
			return null;
		}

	}

}