// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Storage_Belt_Medical : Obj_Item_Weapon_Storage_Belt {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "medical";
			this.can_hold = new ByTable(new object [] { 
				"/obj/item/device/healthanalyzer", 
				"/obj/item/weapon/dnainjector", 
				"/obj/item/weapon/reagent_containers/dropper", 
				"/obj/item/weapon/reagent_containers/glass/beaker", 
				"/obj/item/weapon/reagent_containers/glass/bottle", 
				"/obj/item/weapon/reagent_containers/pill", 
				"/obj/item/weapon/reagent_containers/syringe", 
				"/obj/item/weapon/reagent_containers/glass/dispenser", 
				"/obj/item/weapon/lighter/zippo", 
				"/obj/item/weapon/storage/fancy/cigarettes", 
				"/obj/item/weapon/storage/pill_bottle", 
				"/obj/item/stack/medical", 
				"/obj/item/device/flashlight/pen", 
				"/obj/item/clothing/mask/surgical", 
				"/obj/item/clothing/gloves/latex", 
				"/obj/item/weapon/reagent_containers/hypospray/autoinjector", 
				"/obj/item/device/mass_spectrometer", 
				"/obj/item/device/gps/paramedic", 
				"/obj/item/device/antibody_scanner"
			 });
			this.icon_state = "medicalbelt";
		}

		public Obj_Item_Weapon_Storage_Belt_Medical ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}