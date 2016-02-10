// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Hostile_Asteroid : Mob_Living_SimpleAnimal_Hostile {

		public string throw_message = "bounces off of";
		public string icon_aggro = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.vision_range = 2;
			this.min_oxy = 0;
			this.max_tox = false;
			this.max_co2 = 0;
			this.unsuitable_atoms_damage = 15;
			this.faction = "mining";
			this.environment_smash = 2;
			this.minbodytemp = 0;
			this.heat_damage_per_tick = 20;
			this.response_harm = "strikes";
			this.status_flags = 0;
			this.a_intent = "hurt";
		}

		public Mob_Living_SimpleAnimal_Hostile_Asteroid ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: mining_mobs.dm
		public override void hitby( Ent_Static AM = null, dynamic speed = null, int? dir = null ) {
			Ent_Static T = null;

			
			if ( AM is Obj_Item ) {
				T = AM;

				if ( !Lang13.Bool( this.stat ) ) {
					this.Aggro();
				}

				if ( Convert.ToDouble( ((dynamic)T).throwforce ) <= 15 && Convert.ToDouble( speed ) < 10 ) {
					this.visible_message( "<span class='notice'>The " + T.name + " " + this.throw_message + " " + this.name + "!</span>" );
					return;
				}
			}
			base.hitby( AM, (object)(speed), dir );
			return;
		}

		// Function from file: mining_mobs.dm
		public override int? bullet_act( dynamic Proj = null, dynamic def_zone = null ) {
			
			if ( !Lang13.Bool( this.stat ) ) {
				this.Aggro();
			}

			if ( Convert.ToDouble( Proj.damage ) < 30 ) {
				Proj.damage = Proj.damage / 2;
				this.visible_message( "<span class='danger'>The " + Proj + " has a reduced effect on " + this + "!</span>" );
			}
			base.bullet_act( (object)(Proj), (object)(def_zone) );
			return null;
		}

		// Function from file: mining_mobs.dm
		public override void LoseAggro(  ) {
			base.LoseAggro();
			this.icon_state = this.icon_living;
			return;
		}

		// Function from file: mining_mobs.dm
		public override void Aggro(  ) {
			base.Aggro();
			this.icon_state = this.icon_aggro;
			return;
		}

	}

}