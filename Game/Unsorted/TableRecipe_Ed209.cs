// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class TableRecipe_Ed209 : TableRecipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "ED209";
			this.result = typeof(Mob_Living_SimpleAnimal_Bot_Ed209);
			this.reqs = new ByTable()
				.Set( typeof(Obj_Item_RobotParts_RobotSuit), 1 )
				.Set( typeof(Obj_Item_Clothing_Head_Helmet), 1 )
				.Set( typeof(Obj_Item_Clothing_Suit_Armor_Vest), 1 )
				.Set( typeof(Obj_Item_RobotParts_LLeg), 1 )
				.Set( typeof(Obj_Item_RobotParts_RLeg), 1 )
				.Set( typeof(Obj_Item_Stack_Sheet_Metal), 5 )
				.Set( typeof(Obj_Item_Stack_CableCoil), 5 )
				.Set( typeof(Obj_Item_Weapon_Gun_Energy_Gun_Advtaser), 1 )
				.Set( typeof(Obj_Item_Weapon_StockParts_Cell), 1 )
				.Set( typeof(Obj_Item_Device_Assembly_ProxSensor), 1 )
				.Set( typeof(Obj_Item_RobotParts_RArm), 1 )
			;
			this.tools = new ByTable(new object [] { typeof(Obj_Item_Weapon_Weldingtool), typeof(Obj_Item_Weapon_Screwdriver) });
			this.time = 60;
			this.category = "Robots";
		}

	}

}