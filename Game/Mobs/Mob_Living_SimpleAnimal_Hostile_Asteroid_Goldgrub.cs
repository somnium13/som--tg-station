// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Hostile_Asteroid_Goldgrub : Mob_Living_SimpleAnimal_Hostile_Asteroid {

		public int chase_time = 100;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_living = "Goldgrub";
			this.icon_aggro = "Goldgrub_alert";
			this.icon_dead = "Goldgrub_dead";
			this.icon_gib = "syndicate_gib";
			this.idle_vision_range = 2;
			this.move_to_delay = 5;
			this.friendly = "harmlessly rolls into";
			this.maxHealth = 45;
			this.health = 45;
			this.harm_intent_damage = 5;
			this.attacktext = "barrels into";
			this.attack_sound = "sound/weapons/punch1.ogg";
			this.speak_emote = new ByTable(new object [] { "screeches" });
			this.throw_message = "sinks in slowly, before being pushed out of ";
			this.search_objects = 1;
			this.wanted_objects = new ByTable(new object [] { typeof(Obj_Item_Weapon_Ore_Diamond), typeof(Obj_Item_Weapon_Ore_Gold), typeof(Obj_Item_Weapon_Ore_Silver), typeof(Obj_Item_Weapon_Ore_Uranium) });
			this.icon_state = "Goldgrub";
		}

		// Function from file: mining_mobs.dm
		public Mob_Living_SimpleAnimal_Hostile_Asteroid_Goldgrub ( dynamic loc = null ) : base( (object)(loc) ) {
			int i = 0;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.deathmessage = "" + this + " spits up the contents of its stomach before dying!";
			i = Rand13.Int( 1, 3 );

			while (i != 0) {
				this.loot.Add( Rand13.Pick(new object [] { typeof(Obj_Item_Weapon_Ore_Silver), typeof(Obj_Item_Weapon_Ore_Gold), typeof(Obj_Item_Weapon_Ore_Uranium), typeof(Obj_Item_Weapon_Ore_Diamond) }) );
				i--;
			}
			return;
		}

		// Function from file: mining_mobs.dm
		public override dynamic adjustHealth( dynamic amount = null ) {
			dynamic _default = null;

			this.idle_vision_range = 9;
			_default = base.adjustHealth( (object)(amount) );
			return _default;
		}

		// Function from file: mining_mobs.dm
		public override dynamic bullet_act( dynamic P = null, dynamic def_zone = null ) {
			this.visible_message( "<span class='danger'>The " + P.name + " was repelled by " + this.name + "'s girth!</span>" );
			return null;
		}

		// Function from file: mining_mobs.dm
		public void Burrow(  ) {
			
			if ( !( this.stat != 0 ) ) {
				this.visible_message( "<span class='danger'>The " + this.name + " buries into the ground, vanishing from sight!</span>" );
				GlobalFuncs.qdel( this );
			}
			return;
		}

		// Function from file: mining_mobs.dm
		public void EatOre( dynamic targeted_ore = null ) {
			Obj_Item_Weapon_Ore O = null;

			
			foreach (dynamic _a in Lang13.Enumerate( targeted_ore.loc, typeof(Obj_Item_Weapon_Ore) )) {
				O = _a;
				

				if ( this.loot.len < 10 ) {
					this.loot.Add( O.type );
					GlobalFuncs.qdel( O );
				}
			}
			this.visible_message( "<span class='notice'>The ore was swallowed whole!</span>" );
			return;
		}

		// Function from file: mining_mobs.dm
		public override bool AttackingTarget(  ) {
			
			if ( this.target is Obj_Item_Weapon_Ore ) {
				this.EatOre( this.target );
				return false;
			}
			base.AttackingTarget();
			return false;
		}

		// Function from file: mining_mobs.dm
		public override bool GiveTarget( dynamic new_target = null ) {
			this.target = new_target;

			if ( this.target != null ) {
				
				if ( this.target is Obj_Item_Weapon_Ore && this.loot.len < 10 ) {
					this.visible_message( "<span class='notice'>The " + this.name + " looks at " + this.target.name + " with hungry eyes.</span>" );
				} else if ( this.target is Mob_Living ) {
					this.Aggro();
					this.visible_message( "<span class='danger'>The " + this.name + " tries to flee from " + this.target.name + "!</span>" );
					this.retreat_distance = 10;
					this.minimum_distance = 10;
					Task13.Schedule( this.chase_time, (Task13.Closure)(() => {
						this.Burrow();
						return;
					}));
				}
			}
			return false;
		}

	}

}