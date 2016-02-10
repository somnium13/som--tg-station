// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Vending_Mining : Obj_Machinery_Vending {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.product_slogans = "This asteroid isn't going to dig itself!;Stay safe in the tunnels, bring two Kinetic Accelerators!;Jetpacks, anyone?";
			this.product_ads = "Hungry, thirsty or unequipped? We have your fix!";
			this.vend_reply = "What a glorious time to mine!";
			this.products = new ByTable()
				.Set( typeof(Obj_Item_Toy_Canary), 10 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Hotchili), 10 )
				.Set( typeof(Obj_Item_Clothing_Mask_Cigarette_Cigar_Havana), 5 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Drinks_Bottle_Whiskey), 10 )
				.Set( typeof(Obj_Item_Weapon_Soap_Nanotrasen), 10 )
				.Set( typeof(Obj_Item_Clothing_Mask_Facehugger_Toy), 10 )
				.Set( typeof(Obj_Item_Weapon_Storage_Belt_Lazarus), 3 )
				.Set( typeof(Obj_Item_Device_Mobcapsule), 10 )
				.Set( typeof(Obj_Item_Weapon_LazarusInjector), 10 )
				.Set( typeof(Obj_Item_Weapon_Pickaxe_Jackhammer), 5 )
				.Set( typeof(Obj_Item_Weapon_MiningDroneCube), 5 )
				.Set( typeof(Obj_Item_Device_WormholeJaunter), 10 )
				.Set( typeof(Obj_Item_Weapon_Resonator), 5 )
				.Set( typeof(Obj_Item_Weapon_Gun_Energy_KineticAccelerator), 10 )
				.Set( typeof(Obj_Item_Weapon_Tank_Jetpack_Carbondioxide), 3 )
				.Set( typeof(Obj_Item_Weapon_Gun_Hookshot), 3 )
			;
			this.prices = new ByTable()
				.Set( typeof(Obj_Item_Toy_Canary), 100 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Hotchili), 100 )
				.Set( typeof(Obj_Item_Clothing_Mask_Cigarette_Cigar_Havana), 100 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Drinks_Bottle_Whiskey), 150 )
				.Set( typeof(Obj_Item_Weapon_Soap_Nanotrasen), 150 )
				.Set( typeof(Obj_Item_Clothing_Mask_Facehugger_Toy), 250 )
				.Set( typeof(Obj_Item_Weapon_Storage_Belt_Lazarus), 500 )
				.Set( typeof(Obj_Item_Device_Mobcapsule), 250 )
				.Set( typeof(Obj_Item_Weapon_LazarusInjector), 1000 )
				.Set( typeof(Obj_Item_Weapon_Pickaxe_Jackhammer), 500 )
				.Set( typeof(Obj_Item_Weapon_MiningDroneCube), 500 )
				.Set( typeof(Obj_Item_Device_WormholeJaunter), 250 )
				.Set( typeof(Obj_Item_Weapon_Resonator), 750 )
				.Set( typeof(Obj_Item_Weapon_Gun_Energy_KineticAccelerator), 1000 )
				.Set( typeof(Obj_Item_Weapon_Tank_Jetpack_Carbondioxide), 2000 )
				.Set( typeof(Obj_Item_Weapon_Gun_Hookshot), 3000 )
			;
			this.pack = typeof(Obj_Structure_Vendomatpack_Mining);
			this.icon_state = "mining";
		}

		// Function from file: mine_vending.dm
		public Obj_Machinery_Vending_Mining ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( GlobalVars.ticker != null ) {
				this.initialize();
			}
			return;
		}

		// Function from file: mine_vending.dm
		public override bool initialize( bool? suppress_icon_check = null ) {
			base.initialize( suppress_icon_check );
			this.linked_account = GlobalVars.department_accounts["Cargo"];
			return false;
		}

	}

}