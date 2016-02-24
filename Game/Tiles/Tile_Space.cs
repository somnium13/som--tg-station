// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Tile_Space : Tile {

		public int? destination_z = null;
		public int destination_x = 0;
		public int destination_y = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.intact = false;
			this.temperature = 2.7;
			this.thermal_conductivity = 0.4;
			this.heat_capacity = 700000;
			this.icon = "icons/turf/space.dmi";
			this.icon_state = "0";
		}

		// Function from file: space.dm
		public Tile_Space ( dynamic loc = null ) : base( (object)(loc) ) {
			
			if ( !( this is Tile_Space_Transit ) ) {
				this.icon_state = "" + -( this.x + this.y ^ ~( this.x * this.y ) + this.z ) % 25;
			}
		}

		// Function from file: lighting_system.dm
		public override dynamic init_lighting(  ) {
			dynamic _default = null;

			_default = base.init_lighting();

			if ( GlobalVars.config.starlight ) {
				this.update_starlight();
			}
			return _default;
		}

		// Function from file: lighting_system.dm
		public override void update_lumcount( double amount = 0 ) {
			this.lighting_lumcount += amount;
			return;
		}

		// Function from file: space.dm
		public override bool can_have_cabling(  ) {
			
			if ( Lang13.Bool( Lang13.FindIn( typeof(Obj_Structure_Lattice_Catwalk), this ) ) ) {
				return true;
			}
			return false;
		}

		// Function from file: space.dm
		public override double singularity_act( int? current_size = null, Obj_Singularity S = null ) {
			return 0;
		}

		// Function from file: space.dm
		public override bool handle_slip( Mob_Living_Carbon C = null, int s_amount = 0, int w_amount = 0, dynamic O = null, dynamic lube = null ) {
			return false;
		}

		// Function from file: space.dm
		public override dynamic Entered( Ent_Dynamic Obj = null, Ent_Static oldloc = null ) {
			Ent_Dynamic L = null;
			Tile T = null;

			base.Entered( Obj, oldloc );

			if ( !( Obj != null ) || this != Obj.loc ) {
				return null;
			}

			if ( Lang13.Bool( this.destination_z ) ) {
				Obj.x = this.destination_x;
				Obj.y = this.destination_y;
				Obj.z = this.destination_z ??0;

				if ( Obj is Mob_Living ) {
					L = Obj;

					if ( Lang13.Bool( ((dynamic)L).pulling ) ) {
						T = Map13.GetStep( L.loc, Num13.Rotate( Obj.dir, 180 ) );
						((dynamic)L).pulling.loc = T;
					}
				}
				Task13.Sleep( 0 );
				Obj.newtonian_move( Obj.inertia_dir );
			}
			return null;
		}

		// Function from file: space.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic R = null;
			dynamic L = null;
			dynamic W = null;
			dynamic L2 = null;
			dynamic S = null;

			base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );

			if ( A is Obj_Item_Stack_Rods ) {
				R = A;
				L = Lang13.FindIn( typeof(Obj_Structure_Lattice), this );
				W = Lang13.FindIn( typeof(Obj_Structure_Lattice_Catwalk), this );

				if ( Lang13.Bool( W ) ) {
					user.WriteMsg( "<span class='warning'>There is already a catwalk here!</span>" );
					return null;
				}

				if ( Lang13.Bool( L ) ) {
					
					if ( ((Obj_Item_Stack)R).use( 1 ) != 0 ) {
						user.WriteMsg( "<span class='notice'>You begin constructing catwalk...</span>" );
						GlobalFuncs.playsound( this, "sound/weapons/genhit.ogg", 50, 1 );
						GlobalFuncs.qdel( L );
						this.ReplaceWithCatwalk();
					} else {
						user.WriteMsg( "<span class='warning'>You need two rods to build a catwalk!</span>" );
					}
					return null;
				}

				if ( ((Obj_Item_Stack)R).use( 1 ) != 0 ) {
					user.WriteMsg( "<span class='notice'>Constructing support lattice...</span>" );
					GlobalFuncs.playsound( this, "sound/weapons/genhit.ogg", 50, 1 );
					this.ReplaceWithLattice();
				} else {
					user.WriteMsg( "<span class='warning'>You need one rod to build a lattice.</span>" );
				}
				return null;
			}

			if ( A is Obj_Item_Stack_Tile_Plasteel ) {
				L2 = Lang13.FindIn( typeof(Obj_Structure_Lattice), this );

				if ( Lang13.Bool( L2 ) ) {
					S = A;

					if ( ((Obj_Item_Stack)S).use( 1 ) != 0 ) {
						GlobalFuncs.qdel( L2 );
						GlobalFuncs.playsound( this, "sound/weapons/genhit.ogg", 50, 1 );
						user.WriteMsg( "<span class='notice'>You build a floor.</span>" );
						this.ChangeTurf( typeof(Tile_Simulated_Floor_Plating) );
					} else {
						user.WriteMsg( "<span class='warning'>You need one floor tile to build a floor!</span>" );
					}
				} else {
					user.WriteMsg( "<span class='warning'>The plating is going to need some support! Place metal rods first.</span>" );
				}
			}
			return null;
		}

		// Function from file: space.dm
		public override dynamic attack_paw( dynamic a = null, dynamic b = null, dynamic c = null ) {
			return this.attack_hand( a );
		}

		// Function from file: space.dm
		public void Sandbox_Spacemove( dynamic A = null ) {
			int cur_x = 0;
			int cur_y = 0;
			int next_x = 0;
			int next_y = 0;
			int target_z = 0;
			ByTable y_arr = null;
			dynamic cur_pos = null;
			Tile T = null;

			next_x = this.x;
			next_y = this.y;
			cur_pos = this.get_global_map_pos();

			if ( !Lang13.Bool( cur_pos ) ) {
				return;
			}
			cur_x = Convert.ToInt32( cur_pos["x"] );
			cur_y = Convert.ToInt32( cur_pos["y"] );

			if ( this.x <= 1 ) {
				next_x = --cur_x != 0 || GlobalVars.global_map.len != 0 ?1:0;
				y_arr = GlobalVars.global_map[next_x];
				target_z = Convert.ToInt32( y_arr[cur_y] );
				next_x = Game13.map_size_x - 2;
			} else if ( this.x >= Game13.map_size_x ) {
				next_x = ( ++cur_x > GlobalVars.global_map.len ? 1 : cur_x );
				y_arr = GlobalVars.global_map[next_x];
				target_z = Convert.ToInt32( y_arr[cur_y] );
				next_x = 3;
			} else if ( this.y <= 1 ) {
				y_arr = GlobalVars.global_map[cur_x];
				next_y = --cur_y != 0 || y_arr.len != 0 ?1:0;
				target_z = Convert.ToInt32( y_arr[next_y] );
				next_y = Game13.map_size_y - 2;
			} else if ( this.y >= Game13.map_size_y ) {
				y_arr = GlobalVars.global_map[cur_x];
				next_y = ( ++cur_y > y_arr.len ? 1 : cur_y );
				target_z = Convert.ToInt32( y_arr[next_y] );
				next_y = 3;
			}
			T = Map13.GetTile( next_x, next_y, target_z );
			A.Move( T );
			return;
		}

		// Function from file: space.dm
		public void update_starlight(  ) {
			Tile_Simulated T = null;

			
			if ( GlobalVars.config != null ) {
				
				if ( GlobalVars.config.starlight ) {
					
					foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInBlock( Map13.GetTile( Num13.MaxInt( this.x - 1, 1 ), Num13.MaxInt( this.y - 1, 1 ), this.z ), Map13.GetTile( Num13.MinInt( this.x + 1, Game13.map_size_x ), Num13.MinInt( this.y + 1, Game13.map_size_y ), this.z ) ), typeof(Tile_Simulated) )) {
						T = _a;
						
						this.SetLuminosity( 4, 1 );
						return;
					}
					this.SetLuminosity( 0 );
				}
			}
			return;
		}

		// Function from file: space.dm
		public override dynamic Destroy(  ) {
			return 1;
		}

		// Function from file: turf.dm
		public override void levelupdate(  ) {
			Obj O = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this, typeof(Obj) )) {
				O = _a;
				

				if ( O.level == 1 ) {
					O.hide( false );
				}
			}
			return;
		}

	}

}