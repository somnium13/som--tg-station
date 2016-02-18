// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Hostile_Bear : Mob_Living_SimpleAnimal_Hostile {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_living = "bear";
			this.icon_dead = "bear_dead";
			this.icon_gib = "bear_gib";
			this.speak = new ByTable(new object [] { "RAWR!", "Rawr!", "GRR!", "Growl!" });
			this.speak_emote = new ByTable(new object [] { "growls", "roars" });
			this.emote_hear = new ByTable(new object [] { "rawrs.", "grumbles.", "grawls." });
			this.emote_taunt = new ByTable(new object [] { "stares ferociously", "stomps" });
			this.speak_chance = 1;
			this.taunt_chance = 25;
			this.turns_per_move = 5;
			this.butcher_results = new ByTable().Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Meat_Slab_Bear), 5 ).Set( typeof(Obj_Item_Clothing_Head_Bearpelt), 1 );
			this.response_help = "pets";
			this.response_disarm = "gently pushes aside";
			this.maxHealth = 60;
			this.health = 60;
			this.melee_damage_lower = 20;
			this.melee_damage_upper = 30;
			this.attacktext = "claws";
			this.attack_sound = "sound/weapons/bladeslice.ogg";
			this.friendly = "bear hugs";
			this.atmos_requirements = new ByTable().Set( "min_oxy", 0 ).Set( "max_oxy", 0 ).Set( "min_tox", 0 ).Set( "max_tox", 0 ).Set( "min_co2", 0 ).Set( "max_co2", 0 ).Set( "min_n2", 0 ).Set( "max_n2", 0 );
			this.minbodytemp = 0;
			this.maxbodytemp = 1500;
			this.faction = new ByTable(new object [] { "russian" });
			this.gold_core_spawnable = 1;
			this.icon_state = "bear";
			this.see_in_dark = 6;
		}

		public Mob_Living_SimpleAnimal_Hostile_Bear ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: bear.dm
		public override int Process_Spacemove( dynamic movement_dir = null ) {
			movement_dir = movement_dir ?? 0;

			return 1;
		}

	}

}