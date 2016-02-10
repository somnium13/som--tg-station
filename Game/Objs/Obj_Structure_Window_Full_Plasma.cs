// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Window_Full_Plasma : Obj_Structure_Window_Full {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.base_state = "plasmawindow";
			this.shardtype = typeof(Obj_Item_Weapon_Shard_Plasma);
			this.sheettype = typeof(Obj_Item_Stack_Sheet_Glass_Plasmaglass);
			this.health = 120;
			this.fire_temp_threshold = 32000;
			this.fire_volume_mod = 1000;
			this.icon_state = "plasmawindow0";
		}

		public Obj_Structure_Window_Full_Plasma ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}