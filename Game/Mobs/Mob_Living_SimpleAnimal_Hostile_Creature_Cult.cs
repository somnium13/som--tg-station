// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Hostile_Creature_Cult : Mob_Living_SimpleAnimal_Hostile_Creature {

		public dynamic shuttletarget = null;
		public bool enroute = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.faction = "cult";
			this.min_oxy = 0;
			this.max_tox = false;
			this.max_co2 = 0;
			this.minbodytemp = 0;
			this.supernatural = true;
		}

		public Mob_Living_SimpleAnimal_Hostile_Creature_Cult ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: creature.dm
		public void horde(  ) {
			Tile T = null;
			Ent_Static A = null;
			Ent_Static D = null;
			Ent_Static D2 = null;
			dynamic new_target = null;

			T = Map13.GetStepTowards( this, this.shuttletarget, 0 );

			foreach (dynamic _a in Lang13.Enumerate( T, typeof(Ent_Static) )) {
				A = _a;
				

				if ( A is Obj_Machinery_Door_Airlock ) {
					D = A;

					if ( D.density && !Lang13.Bool( ((dynamic)D).locked ) && !Lang13.Bool( ((dynamic)D).welded ) ) {
						((Obj_Machinery_Door)D).open();
					}
				} else if ( A is Obj_Machinery_Door_Mineral ) {
					D2 = A;

					if ( D2.density ) {
						((Obj_Machinery_Door)D2).open();
					}
				} else if ( A is Obj_Structure_Cult_Pylon ) {
					A.attack_animal( this );
				} else if ( A is Obj_Structure_Window || A is Obj_Structure_Closet || A is Obj_Structure_Table || A is Obj_Structure_Grille || A is Obj_Structure_Rack ) {
					A.attack_animal( this );
				}
			}
			this.Move( T );
			new_target = this.FindTarget();
			this.GiveTarget( new_target );

			if ( !Lang13.Bool( this.target ) || this.enroute ) {
				Task13.Schedule( 10, (Task13.Closure)(() => {
					
					if ( !Lang13.Bool( this.stat ) ) {
						this.horde();
					}
					return;
				}));
			}
			return;
		}

		// Function from file: creature.dm
		public override bool Life(  ) {
			
			if ( this.timestopped ) {
				return false;
			}
			base.Life();

			if ( GlobalVars.emergency_shuttle.location == 1 ) {
				
				if ( !this.enroute && !Lang13.Bool( this.target ) ) {
					
					if ( !Lang13.Bool( this.shuttletarget ) && GlobalVars.escape_list.len != 0 ) {
						this.shuttletarget = Rand13.PickFromTable( GlobalVars.escape_list );
					}
					this.enroute = true;
					this.stop_automated_movement = true;
				}

				if ( Map13.GetDistance( this, this.shuttletarget ) <= 2 ) {
					this.enroute = false;
					this.stop_automated_movement = false;
				}
			}
			return false;
		}

		// Function from file: creature.dm
		public override dynamic cultify(  ) {
			return null;
		}

		// Function from file: creature.dm
		public override bool CanAttack( dynamic target = null ) {
			
			if ( GlobalFuncs.iscultist( target ) ) {
				return false;
			}
			return base.CanAttack( (object)(target) );
		}

	}

}