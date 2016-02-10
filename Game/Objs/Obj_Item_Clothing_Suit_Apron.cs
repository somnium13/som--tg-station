// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Suit_Apron : Obj_Item_Clothing_Suit {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "apron";
			this.blood_overlay_type = "armor";
			this.body_parts_covered = 6;
			this.v_allowed = new ByTable(new object [] { 
				typeof(Obj_Item_Weapon_ReagentContainers_Spray_Plantbgone), 
				typeof(Obj_Item_Device_Analyzer_PlantAnalyzer), 
				typeof(Obj_Item_Seeds), 
				typeof(Obj_Item_Weapon_ReagentContainers_Glass_Fertilizer), 
				typeof(Obj_Item_Weapon_Wirecutters_Clippers), 
				typeof(Obj_Item_Weapon_Minihoe)
			 });
			this.species_fit = new ByTable(new object [] { "Vox" });
			this.icon_state = "apron";
		}

		public Obj_Item_Clothing_Suit_Apron ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}