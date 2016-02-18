// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Hostile_Mimic : Mob_Living_SimpleAnimal_Hostile {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_living = "crate";
			this.response_help = "touches";
			this.response_disarm = "pushes";
			this.speed = 0;
			this.maxHealth = 250;
			this.health = 250;
			this.harm_intent_damage = 5;
			this.melee_damage_lower = 8;
			this.melee_damage_upper = 12;
			this.attack_sound = "sound/weapons/punch1.ogg";
			this.emote_taunt = new ByTable(new object [] { "growls" });
			this.speak_emote = new ByTable(new object [] { "creaks" });
			this.taunt_chance = 30;
			this.atmos_requirements = new ByTable().Set( "min_oxy", 0 ).Set( "max_oxy", 0 ).Set( "min_tox", 0 ).Set( "max_tox", 0 ).Set( "min_co2", 0 ).Set( "max_co2", 0 ).Set( "min_n2", 0 ).Set( "max_n2", 0 );
			this.minbodytemp = 0;
			this.faction = new ByTable(new object [] { "mimic" });
			this.move_to_delay = 9;
			this.gold_core_spawnable = 1;
			this.del_on_death = true;
			this.icon = "icons/obj/crates.dmi";
			this.icon_state = "crate";
		}

		public Mob_Living_SimpleAnimal_Hostile_Mimic ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}