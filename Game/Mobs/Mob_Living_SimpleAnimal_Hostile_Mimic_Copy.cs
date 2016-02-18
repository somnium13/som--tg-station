// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Hostile_Mimic_Copy : Mob_Living_SimpleAnimal_Hostile_Mimic {

		public dynamic creator = null;
		public bool destroy_objects = false;
		public bool knockdown_people = false;
		public Image googly_eyes = null;

		// Function from file: mimic.dm
		public Mob_Living_SimpleAnimal_Hostile_Mimic_Copy ( dynamic loc = null, Ent_Static copy = null, dynamic creator = null, bool? destroy_original = null ) : base( (object)(loc) ) {
			destroy_original = destroy_original ?? false;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.CopyObject( copy, creator, destroy_original );
			return;
		}

		// Function from file: mimic.dm
		public override void Aggro(  ) {
			base.Aggro();
			((dynamic)this.googly_eyes).dir = Map13.GetDistance( this, this.target );
			return;
		}

		// Function from file: mimic.dm
		public override bool AttackingTarget(  ) {
			dynamic C = null;

			base.AttackingTarget();

			if ( this.knockdown_people ) {
				
				if ( this.target is Mob_Living_Carbon ) {
					C = this.target;

					if ( Rand13.PercentChance( 15 ) ) {
						((Mob)C).Weaken( 2 );
						((Ent_Static)C).visible_message( new Txt( "<span class='danger'>" ).The( this ).item().str( " knocks down " ).the( C ).item().str( "!</span>" ).ToString(), new Txt( "<span class='userdanger'>" ).The( this ).item().str( " knocks you down!</span>" ).ToString() );
					}
				}
			}
			return false;
		}

		// Function from file: mimic.dm
		public override void DestroySurroundings(  ) {
			
			if ( this.destroy_objects ) {
				base.DestroySurroundings();
			}
			return;
		}

		// Function from file: mimic.dm
		public virtual bool CopyObject( Ent_Static O = null, dynamic user = null, bool? destroy_original = null ) {
			destroy_original = destroy_original ?? false;

			Ent_Static I = null;

			
			if ( destroy_original == true || this.CheckObject( O ) ) {
				O.loc = this;
				this.name = O.name;
				this.desc = O.desc;
				this.icon = O.icon;
				this.icon_state = O.icon_state;
				this.icon_living = this.icon_state;
				this.overlays = O.overlays;
				this.googly_eyes = new Image( "icons/mob/mob.dmi", "googly_eyes" );
				this.overlays.Add( this.googly_eyes );

				if ( O is Obj_Structure || O is Obj_Machinery ) {
					this.health = this.anchored * 50 + 50;
					this.destroy_objects = true;

					if ( O.density && Lang13.Bool( ((dynamic)O).anchored ) ) {
						this.knockdown_people = true;
						this.melee_damage_lower *= 2;
						this.melee_damage_upper *= 2;
					}
				} else if ( O is Obj_Item ) {
					I = O;
					this.health = ((dynamic)I).w_class * 15;
					this.melee_damage_lower = ((dynamic)I).force + 2;
					this.melee_damage_upper = ((dynamic)I).force + 2;
					this.move_to_delay = Convert.ToInt32( ((dynamic)I).w_class * 2 + 1 );
				}
				this.maxHealth = this.health;

				if ( Lang13.Bool( user ) ) {
					this.creator = user;
					this.faction += new Txt().Ref( this.creator ).ToString();
				}

				if ( destroy_original == true ) {
					GlobalFuncs.qdel( O );
				}
				return true;
			}
			return false;
		}

		// Function from file: mimic.dm
		public bool CheckObject( Ent_Static O = null ) {
			
			if ( ( O is Obj_Item || O is Obj_Structure ) && !GlobalFuncs.is_type_in_list( O, GlobalVars.protected_objects ) ) {
				return true;
			}
			return false;
		}

		// Function from file: mimic.dm
		public void ChangeOwner( Ent_Static owner = null ) {
			
			if ( owner != this.creator ) {
				this.LoseTarget();
				this.creator = owner;
				this.faction |= new Txt().Ref( owner ).ToString();
			}
			return;
		}

		// Function from file: mimic.dm
		public override ByTable ListTargets(  ) {
			ByTable _default = null;

			_default = base.ListTargets();
			return _default - this.creator;
		}

		// Function from file: mimic.dm
		public override bool death( bool? gibbed = null, bool? toast = null ) {
			Ent_Dynamic M = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this, typeof(Ent_Dynamic) )) {
				M = _a;
				
				M.loc = GlobalFuncs.get_turf( this );
			}
			base.death( gibbed, toast );
			return false;
		}

		// Function from file: mimic.dm
		public override bool Life(  ) {
			Mob_Living M = null;

			base.Life();

			if ( !Lang13.Bool( this.target ) && !Lang13.Bool( this.ckey ) ) {
				this.adjustBruteLoss( 1 );
			}

			foreach (dynamic _a in Lang13.Enumerate( this.contents, typeof(Mob_Living) )) {
				M = _a;
				
				this.death();
			}
			return false;
		}

	}

}