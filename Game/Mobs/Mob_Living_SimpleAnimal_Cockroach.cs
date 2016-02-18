// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Cockroach : Mob_Living_SimpleAnimal {

		public int squish_chance = 50;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_dead = "cockroach";
			this.health = 1;
			this.maxHealth = 1;
			this.turns_per_move = 5;
			this.atmos_requirements = new ByTable().Set( "min_oxy", 0 ).Set( "max_oxy", 0 ).Set( "min_tox", 0 ).Set( "max_tox", 0 ).Set( "min_co2", 0 ).Set( "max_co2", 0 ).Set( "min_n2", 0 ).Set( "max_n2", 0 );
			this.minbodytemp = 270;
			this.maxbodytemp = Double.PositiveInfinity;
			this.pass_flags = 21;
			this.mob_size = 0;
			this.response_disarm = "shoos";
			this.response_harm = "splats";
			this.ventcrawler = 2;
			this.gold_core_spawnable = 2;
			this.loot = new ByTable(new object [] { typeof(Obj_Effect_Decal_Cleanable_Deadcockroach) });
			this.del_on_death = true;
			this.icon_state = "cockroach";
		}

		public Mob_Living_SimpleAnimal_Cockroach ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: cockroach.dm
		public override bool ex_act( double? severity = null, dynamic target = null ) {
			return false;
		}

		// Function from file: cockroach.dm
		public override dynamic Crossed( Ent_Dynamic O = null, dynamic X = null ) {
			Ent_Dynamic A = null;

			
			if ( O is Mob ) {
				
				if ( O is Mob_Living ) {
					A = O;

					if ( Convert.ToDouble( ((dynamic)A).mob_size ) > 0 ) {
						
						if ( Rand13.PercentChance( this.squish_chance ) ) {
							A.visible_message( new Txt( "<span class='notice'>" ).The( A ).item().str( " squashed " ).the( this.name ).item().str( ".</span>" ).ToString(), new Txt( "<span class='notice'>You squashed " ).the( this.name ).item().str( ".</span>" ).ToString() );
							this.death();
						} else {
							this.visible_message( new Txt( "<span class='notice'>" ).The( this.name ).item().str( " avoids getting crushed.</span>" ).ToString() );
						}
					}
				}
			} else if ( O is Obj ) {
				
				if ( O is Obj_Structure ) {
					this.visible_message( new Txt( "<span class='notice'>As " ).the( O ).item().str( " moved over " ).the( this.name ).item().str( ", it was crushed.</span>" ).ToString() );
					this.death();
				}
			}
			return null;
		}

		// Function from file: cockroach.dm
		public override bool death( bool? gibbed = null, bool? toast = null ) {
			
			if ( GlobalVars.ticker.cinematic != null ) {
				return false;
			}
			base.death( gibbed, toast );
			return false;
		}

	}

}