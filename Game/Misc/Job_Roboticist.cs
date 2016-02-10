// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Job_Roboticist : Job {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.title = "Roboticist";
			this.flag = 256;
			this.department_flag = 2;
			this.faction = "Station";
			this.total_positions = 2;
			this.spawn_positions = 2;
			this.supervisors = "research director";
			this.selection_color = "#ffeeff";
			this.idtype = typeof(Obj_Item_Weapon_Card_Id_Research);
			this.access = new ByTable(new object [] { 29, 7, 8, 23, 6, 47 });
			this.minimal_access = new ByTable(new object [] { 29, 23, 6, 47 });
			this.alt_titles = new ByTable(new object [] { "Biomechanical Engineer", "Mechatronic Engineer" });
			this.pdatype = typeof(Obj_Item_Device_Pda_Roboticist);
			this.department = "Science";
		}

		// Function from file: science.dm
		public override bool equip( dynamic H = null ) {
			
			if ( !Lang13.Bool( H ) ) {
				return false;
			}
			((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_Device_Radio_Headset_HeadsetSci(  ), 8 );

			if ( Convert.ToInt32( H.backbag ) == 2 ) {
				((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_Weapon_Storage_Backpack( H ), 1 );
			}

			if ( Convert.ToInt32( H.backbag ) == 3 ) {
				((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_Weapon_Storage_Backpack_SatchelNorm( H ), 1 );
			}

			switch ((string)( H.mind.role_alt_title )) {
				case "Roboticist":
					((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_Clothing_Under_Rank_Roboticist( H ), 14 );
					break;
				case "Mechatronic Engineer":
					((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_Clothing_Under_Rank_Mechatronic( H ), 14 );
					break;
				case "Biomechanical Engineer":
					((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_Clothing_Under_Rank_Biomechanical( H ), 14 );
					break;
			}
			((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_Clothing_Shoes_Black( H ), 12 );
			((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_Clothing_Suit_Storage_Labcoat( H ), 13 );
			((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_Weapon_Storage_Toolbox_Mechanical( H ), 4 );

			if ( Lang13.Bool( H.backbag ) == true ) {
				((Mob_Living_Carbon_Human)H).equip_or_collect( Lang13.Call( H.species.survival_gear, H ), 5 );
			} else {
				((Mob_Living_Carbon_Human)H).equip_or_collect( Lang13.Call( H.species.survival_gear, H.back ), 18 );
			}
			return true;
		}

	}

}