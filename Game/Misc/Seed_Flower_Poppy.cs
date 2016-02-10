// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Seed_Flower_Poppy : Seed_Flower {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "poppies";
			this.seed_name = "poppy";
			this.display_name = "poppies";
			this.packet_icon = "seed-poppy";
			this.products = new ByTable(new object [] { typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Poppy) });
			this.plant_icon = "poppy";
			this.chems = new ByTable().Set( "nutriment", new ByTable(new object [] { 1, 20 }) ).Set( "bicaridine", new ByTable(new object [] { 1, 10 }) );
			this.lifespan = 25;
			this.potency = 20;
			this.maturation = 8;
			this.production = 6;
			this.yield = 6;
			this.growth_stages = 3;
			this.ideal_light = 8;
			this.water_consumption = 0.5;
			this.large = false;
		}

	}

}