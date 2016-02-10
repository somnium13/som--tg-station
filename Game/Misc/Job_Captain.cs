// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Job_Captain : Job {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.title = "Captain";
			this.flag = 1;
			this.department_flag = 1;
			this.faction = "Station";
			this.total_positions = 1;
			this.spawn_positions = 1;
			this.supervisors = "Nanotrasen officials and Space law";
			this.selection_color = "#ccccff";
			this.idtype = typeof(Obj_Item_Weapon_Card_Id_Gold);
			this.req_admin_notify = 1;
			this.access = new ByTable();
			this.minimal_access = new ByTable();
			this.minimal_player_age = 14;
			this.pdaslot = 15;
			this.pdatype = typeof(Obj_Item_Device_Pda_Captain);
			this.department = "Command";
			this.head_position = true;
		}

		// Function from file: captain.dm
		public override ByTable get_access(  ) {
			return GlobalFuncs.get_all_accesses();
		}

		// Function from file: captain.dm
		public override bool equip( dynamic H = null ) {
			Obj_Item_Clothing_Under_Rank_Captain U = null;
			Obj_Item_Clothing_Accessory_Medal_Gold_Captain medal = null;
			Obj_Item_Weapon_Implant_Loyalty L = null;
			Organ_External affected = null;

			
			if ( !Lang13.Bool( H ) ) {
				return false;
			}
			((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_Device_Radio_Headset_Heads_Captain(  ), 8 );

			dynamic _a = H.backbag; // Was a switch-case, sorry for the mess.
			if ( _a==2 ) {
				((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_Weapon_Storage_Backpack_Captain( H ), 1 );
			} else if ( _a==3 ) {
				((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_Weapon_Storage_Backpack_SatchelCap( H ), 1 );
			} else if ( _a==4 ) {
				((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_Weapon_Storage_Backpack_Satchel( H ), 1 );
			}
			((Mob_Living_Carbon_Human)H).equip_or_collect( Lang13.Call( H.species.survival_gear, H.back ), 18 );
			U = new Obj_Item_Clothing_Under_Rank_Captain( H );
			medal = new Obj_Item_Clothing_Accessory_Medal_Gold_Captain();
			U.accessories.Add( medal );
			medal.on_attached( null, U );
			((Mob_Living_Carbon_Human)H).equip_or_collect( U, 14 );
			((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_Clothing_Shoes_Brown( H ), 12 );
			((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_Clothing_Head_Caphat( H ), 11 );
			((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_Clothing_Glasses_Sunglasses( H ), 9 );

			if ( Lang13.Bool( H.backbag ) == true ) {
				((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_Weapon_Storage_Box_Ids( H ), 5 );
				((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_Weapon_Gun_Energy_Gun( H ), 4 );
			} else {
				((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_Weapon_Storage_Box_Ids( H.back ), 18 );
				((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_Weapon_Gun_Energy_Gun( H ), 18 );
			}
			L = new Obj_Item_Weapon_Implant_Loyalty( H );
			L.imp_in = H;
			L.implanted = true;
			GlobalFuncs.to_chat( typeof(Game13), "<b>" + H.real_name + " is the captain!</b>" );
			affected = ((Mob_Living_Carbon_Human)H).get_organ( "head" );
			affected.implants.Add( L );
			L.part = affected;
			return true;
		}

	}

}