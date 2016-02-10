// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Vending_Nuka : Obj_Machinery_Vending {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.product_slogans = "A refreshing burst of atomic energy!;Drink like there's no tomorrow!;Take the leap... enjoy a Quantum!";
			this.product_ads = "Wouldn't you enjoy an ice cold Nuka Cola right about now?";
			this.vend_reply = "Enjoy a Nuka break!";
			this.products = new ByTable().Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Drinks_SodaCans_Nuka), 15 );
			this.prices = new ByTable().Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Drinks_SodaCans_Nuka), 20 ).Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Drinks_SodaCans_Quantum), 50 );
			this.contraband = new ByTable().Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Drinks_SodaCans_Quantum), 5 );
			this.pack = typeof(Obj_Structure_Vendomatpack_Nuka);
			this.icon_state = "nuka";
		}

		public Obj_Machinery_Vending_Nuka ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}