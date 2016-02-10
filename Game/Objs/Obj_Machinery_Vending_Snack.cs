// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Vending_Snack : Obj_Machinery_Vending {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.product_slogans = "Try our new nougat bar!;Half the calories for double the price!;It's better then Dan's!";
			this.product_ads = "The healthiest!;Award-winning chocolate bars!;Mmm! So good!;Oh my god it's so juicy!;Have a snack.;Snacks are good for you!;Have some more Getmore!;Best quality snacks straight from mars.;We love chocolate!;Try our new jerky!";
			this.products = new ByTable()
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Candy), 6 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Drinks_DryRamen), 6 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Chips), 6 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Sosjerky), 6 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_NoRaisin), 6 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Spacetwinkie), 6 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Cheesiehonkers), 6 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Chococoin_Wrapped), 2 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Bustanuts), 10 )
			;
			this.contraband = new ByTable().Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Syndicake), 6 );
			this.prices = new ByTable()
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Candy), 13 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Drinks_DryRamen), 15 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Chips), 30 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Sosjerky), 40 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_NoRaisin), 60 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Spacetwinkie), 12 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Cheesiehonkers), 40 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Chococoin_Wrapped), 75 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Bustanuts), 0 )
			;
			this.pack = typeof(Obj_Structure_Vendomatpack_Snack);
			this.icon_state = "snack";
		}

		public Obj_Machinery_Vending_Snack ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}