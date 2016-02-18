// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Tile_Simulated_Wall : Tile_Simulated {

		public string mineral = "metal";
		public string walltype = "metal";
		public int hardness = 40;
		public int slicing_duration = 100;
		public Type sheet_type = typeof(Obj_Item_Stack_Sheet_Metal);
		public dynamic builtin_sheet = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.blocks_air = true;
			this.explosion_block = 1;
			this.thermal_conductivity = 0;
			this.heat_capacity = 312500;
			this.canSmoothWith = new ByTable(new object [] { 
				typeof(Tile_Simulated_Wall), 
				typeof(Tile_Simulated_Wall_RWall), 
				typeof(Obj_Structure_Falsewall), 
				typeof(Obj_Structure_Falsewall_Reinforced), 
				typeof(Tile_Simulated_Wall_Rust), 
				typeof(Tile_Simulated_Wall_RWall_Rust)
			 });
			this.smooth = 1;
			this.icon = "icons/turf/walls/wall.dmi";
			this.icon_state = "wall";
			this.layer = 2.05;
		}

		// Function from file: walls.dm
		public Tile_Simulated_Wall ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.builtin_sheet = Lang13.Call( this.sheet_type );
			return;
		}

		// Function from file: mine_turfs.dm
		public override void updateMineralOverlays(  ) {
			return;
		}

		// Function from file: walls.dm
		public override bool storage_contents_dump_act( Obj_Item_Weapon_Storage src_object = null, Mob user = null ) {
			return false;
		}

		// Function from file: walls.dm
		public override void narsie_act(  ) {
			
			if ( Rand13.PercentChance( 20 ) ) {
				this.ChangeTurf( typeof(Tile_Simulated_Wall_Cult) );
			}
			return;
		}

		// Function from file: walls.dm
		public override void singularity_pull( Obj_Singularity S = null, int? current_size = null ) {
			
			if ( ( current_size ??0) >= 9 ) {
				
				if ( Rand13.PercentChance( 50 ) ) {
					this.dismantle_wall();
				}
				return;
			}

			if ( current_size == 7 ) {
				
				if ( Rand13.PercentChance( 30 ) ) {
					this.dismantle_wall();
				}
			}
			return;
		}

		// Function from file: walls.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			Ent_Static T = null;

			((Mob)user).changeNext_move( 8 );

			if ( !((Mob)user).IsAdvancedToolUser() ) {
				user.WriteMsg( "<span class='warning'>You don't have the dexterity to do this!</span>" );
				return null;
			}

			if ( !( user.loc is Tile ) ) {
				return null;
			}
			this.add_fingerprint( user );

			if ( this.thermite != 0 ) {
				
				if ( ((Obj_Item)A).is_hot() != 0 ) {
					this.thermitemelt( user );
				}
				return null;
			}
			T = user.loc;

			if ( this.try_wallmount( A, user, T ) || this.try_decon( A, user, T ) || this.try_destroy( A, user, T ) ) {
				return null;
			}
			return null;
		}

		// Function from file: walls.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			((Mob)a).changeNext_move( 8 );
			a.WriteMsg( "<span class='notice'>You push the wall but nothing happens!</span>" );
			GlobalFuncs.playsound( this, "sound/weapons/genhit.ogg", 25, 1 );
			this.add_fingerprint( a );
			base.attack_hand( (object)(a), b, c );
			return null;
		}

		// Function from file: walls.dm
		public override bool attack_hulk( Mob_Living_Carbon_Human hulk = null, bool? do_attack_animation = null ) {
			base.attack_hulk( hulk, true );

			if ( Rand13.PercentChance( this.hardness ) ) {
				GlobalFuncs.playsound( this, "sound/effects/meteorimpact.ogg", 100, 1 );
				hulk.WriteMsg( "<span class='notice'>You smash through the wall.</span>" );
				hulk.say( Rand13.Pick(new object [] { ";RAAAAAAAARGH!", ";HNNNNNNNNNGGGGGGH!", ";GWAAAAAAAARRRHHH!", "NNNNNNNNGGGGGGGGHH!", ";AAAAAAARRRGH!" }) );
				this.dismantle_wall( true );
			} else {
				GlobalFuncs.playsound( this, "sound/effects/bang.ogg", 50, 1 );
				hulk.WriteMsg( "<span class='notice'>You punch the wall.</span>" );
			}
			return true;
		}

		// Function from file: walls.dm
		public override bool attack_animal( Mob_Living user = null ) {
			user.changeNext_move( 8 );
			user.do_attack_animation( this );

			if ( Convert.ToDouble( ((dynamic)user).environment_smash ) >= 2 ) {
				GlobalFuncs.playsound( this, "sound/effects/meteorimpact.ogg", 100, 1 );
				user.WriteMsg( "<span class='notice'>You smash through the wall.</span>" );
				this.dismantle_wall( true );
				return false;
			}
			return false;
		}

		// Function from file: walls.dm
		public override dynamic attack_paw( dynamic a = null, dynamic b = null, dynamic c = null ) {
			((Mob)a).changeNext_move( 8 );
			return this.attack_hand( a );
		}

		// Function from file: walls.dm
		public override bool mech_melee_attack( Obj_Mecha M = null ) {
			
			if ( M.damtype == "brute" ) {
				GlobalFuncs.playsound( this, "sound/weapons/punch4.ogg", 50, 1 );
				this.visible_message( "<span class='danger'>" + M.name + " has hit " + this + "!</span>" );

				if ( Rand13.PercentChance( this.hardness ) && Convert.ToDouble( M.force ) > 20 ) {
					this.dismantle_wall( true );
					this.visible_message( "<span class='warning'>" + this.name + " smashes through the wall!</span>" );
					GlobalFuncs.playsound( this, "sound/effects/meteorimpact.ogg", 100, 1 );
				}
			}
			return false;
		}

		// Function from file: walls.dm
		public override bool blob_act( dynamic severity = null ) {
			
			if ( Rand13.PercentChance( 50 ) ) {
				this.dismantle_wall();
			}
			return false;
		}

		// Function from file: walls.dm
		public override bool ex_act( double? severity = null, dynamic target = null ) {
			
			if ( target == this ) {
				this.dismantle_wall( true, true );
				return false;
			}

			switch ((int?)( severity )) {
				case 1:
					this.ChangeTurf( this.baseturf );
					return false;
					break;
				case 2:
					
					if ( Rand13.PercentChance( 50 ) ) {
						this.dismantle_wall( false, true );
					} else {
						this.dismantle_wall( true, true );
					}
					break;
				case 3:
					
					if ( Rand13.PercentChance( this.hardness ) ) {
						this.dismantle_wall( false, true );
					}
					break;
			}

			if ( !this.density ) {
				base.ex_act( severity, (object)(target) );
			}
			return false;
		}

		// Function from file: walls.dm
		public override void attack_tk( Mob_Living_Carbon_Human user = null ) {
			return;
		}

		// Function from file: walls.dm
		public virtual void thermitemelt( dynamic user = null ) {
			Obj_Effect_Overlay O = null;
			dynamic F = null;

			this.overlays = new ByTable();
			O = new Obj_Effect_Overlay( this );
			O.name = "thermite";
			O.desc = "Looks hot.";
			O.icon = "icons/effects/fire.dmi";
			O.icon_state = "2";
			O.anchored = 1;
			O.opacity = true;
			O.density = true;
			O.layer = 5;
			GlobalFuncs.playsound( this, "sound/items/welder.ogg", 100, 1 );

			if ( this.thermite >= 50 ) {
				F = this.ChangeTurf( typeof(Tile_Simulated_Floor_Plating) );
				((Tile_Simulated)F).burn_tile();
				F.icon_state = "wall_thermite";
				((Ent_Static)F).add_hiddenprint( user );
				Task13.Schedule( Num13.MaxInt( 100, ((int)( 300 - this.thermite )) ), (Task13.Closure)(() => {
					
					if ( O != null ) {
						GlobalFuncs.qdel( O );
					}
					return;
				}));
			} else {
				this.thermite = 0;
				Task13.Schedule( 50, (Task13.Closure)(() => {
					
					if ( O != null ) {
						GlobalFuncs.qdel( O );
					}
					return;
				}));
			}
			return;
		}

		// Function from file: walls.dm
		public virtual bool try_destroy( dynamic W = null, dynamic user = null, Ent_Static T = null ) {
			dynamic D = null;

			
			if ( W is Obj_Item_Weapon_Pickaxe_Drill_Jackhammer ) {
				D = W;

				if ( !( this is Tile_Simulated_Wall ) || !Lang13.Bool( user ) || !Lang13.Bool( W ) || !( T != null ) ) {
					return true;
				}

				if ( user.loc == T && ((Mob)user).get_active_hand() == W ) {
					((Obj_Item_Weapon_Pickaxe)D).playDigSound();
					this.dismantle_wall();
					this.visible_message( "<span class='warning'>" + user + " smashes through the " + this.name + " with the " + W.name + "!</span>", "<span class='italics'>You hear the grinding of metal.</span>" );
					return true;
				}
			}
			return false;
		}

		// Function from file: walls.dm
		public virtual bool try_decon( dynamic W = null, dynamic user = null, Ent_Static T = null ) {
			dynamic WT = null;

			
			if ( W is Obj_Item_Weapon_Weldingtool ) {
				WT = W;

				if ( ((Obj_Item_Weapon_Weldingtool)WT).remove_fuel( 0, user ) ) {
					user.WriteMsg( "<span class='notice'>You begin slicing through the outer plating...</span>" );
					GlobalFuncs.playsound( this, "sound/items/welder.ogg", 100, 1 );

					if ( GlobalFuncs.do_after( user, this.slicing_duration / W.toolspeed, null, this ) ) {
						
						if ( !( this is Tile_Simulated_Wall ) || !Lang13.Bool( user ) || !Lang13.Bool( WT ) || !((Obj_Item_Weapon_Weldingtool)WT).isOn() || !( T != null ) ) {
							return true;
						}

						if ( user.loc == T && ((Mob)user).get_active_hand() == WT ) {
							user.WriteMsg( "<span class='notice'>You remove the outer plating.</span>" );
							this.dismantle_wall();
							return true;
						}
					}
				}
			} else if ( W is Obj_Item_Weapon_Gun_Energy_Plasmacutter ) {
				user.WriteMsg( "<span class='notice'>You begin slicing through the outer plating...</span>" );
				GlobalFuncs.playsound( this, "sound/items/welder.ogg", 100, 1 );

				if ( GlobalFuncs.do_after( user, this.slicing_duration * 0.6, null, this ) ) {
					
					if ( !( this is Tile_Simulated_Wall ) || !Lang13.Bool( user ) || !Lang13.Bool( W ) || !( T != null ) ) {
						return true;
					}

					if ( user.loc == T && ((Mob)user).get_active_hand() == W ) {
						user.WriteMsg( "<span class='notice'>You remove the outer plating.</span>" );
						this.dismantle_wall();
						this.visible_message( "The wall was sliced apart by " + user + "!", "<span class='italics'>You hear metal being sliced apart.</span>" );
						return true;
					}
				}
			}
			return false;
		}

		// Function from file: walls.dm
		public bool try_wallmount( dynamic W = null, dynamic user = null, Ent_Static T = null ) {
			dynamic F = null;

			
			if ( W is Obj_Item_Wallframe ) {
				F = W;

				if ( ((Obj_Item_Wallframe)F).try_build( this ) ) {
					((Obj_Item_Wallframe)F).attach( this );
				}
				return true;
			} else if ( W is Obj_Item_Weapon_Poster ) {
				this.place_poster( W, user );
				return true;
			}
			return false;
		}

		// Function from file: walls.dm
		public virtual void devastate_wall(  ) {
			this.builtin_sheet.amount = 2;
			this.builtin_sheet.loc = this;
			new Obj_Item_Stack_Sheet_Metal( this );
			return;
		}

		// Function from file: walls.dm
		public virtual Obj_Structure break_wall(  ) {
			this.builtin_sheet.amount = 2;
			this.builtin_sheet.loc = this;
			return new Obj_Structure_Girder( this );
		}

		// Function from file: walls.dm
		public void dismantle_wall( bool? devastated = null, bool? explode = null ) {
			devastated = devastated ?? false;
			explode = explode ?? false;

			Obj_Structure newgirder = null;
			Obj O = null;
			Obj P = null;

			
			if ( devastated == true ) {
				this.devastate_wall();
			} else {
				GlobalFuncs.playsound( this, "sound/items/welder.ogg", 100, 1 );
				newgirder = this.break_wall();
				this.transfer_fingerprints_to( newgirder );
			}

			foreach (dynamic _a in Lang13.Enumerate( this.contents, typeof(Obj) )) {
				O = _a;
				

				if ( O is Obj_Structure_Sign_Poster ) {
					P = O;
					((Obj_Structure_Sign_Poster)P).roll_and_drop( this );
				} else {
					O.loc = this;
				}
			}
			this.ChangeTurf( typeof(Tile_Simulated_Floor_Plating) );
			return;
		}

		// Function from file: tgstation.dme
		public void place_poster( dynamic P = null, dynamic user = null ) {
			int stuff_on_wall = 0;
			Obj O = null;
			Obj_Structure_Sign_Poster D = null;
			Ent_Static temp_loc = null;

			
			if ( !( P.resulting_poster != null ) ) {
				return;
			}
			stuff_on_wall = 0;

			foreach (dynamic _a in Lang13.Enumerate( this.contents, typeof(Obj) )) {
				O = _a;
				

				if ( O is Obj_Structure_Sign_Poster ) {
					user.WriteMsg( "<span class='warning'>The wall is far too cluttered to place a poster!</span>" );
					return;
				}
				stuff_on_wall++;

				if ( stuff_on_wall == 3 ) {
					user.WriteMsg( "<span class='warning'>The wall is far too cluttered to place a poster!</span>" );
					return;
				}
			}
			user.WriteMsg( "<span class='notice'>You start placing the poster on the wall...</span>" );
			D = P.resulting_poster;
			temp_loc = user.loc;
			Icon13.Flick( "poster_being_set", D );
			D.loc = this;
			D.official = Lang13.BoolNullable( P.official );
			GlobalFuncs.qdel( P );
			GlobalFuncs.playsound( D.loc, "sound/items/poster_being_created.ogg", 100, 1 );

			if ( GlobalFuncs.do_after( user, D.placespeed, null, this ) ) {
				
				if ( !( D != null ) ) {
					return;
				}

				if ( this is Tile_Simulated_Wall && Lang13.Bool( user ) && user.loc == temp_loc ) {
					user.WriteMsg( "<span class='notice'>You place the poster!</span>" );
				} else {
					D.roll_and_drop( temp_loc, D.official );
				}
				return;
			}
			return;
		}

		// Function from file: checkForMultipleDoors.dm
		public bool checkForMultipleDoors(  ) {
			Obj_Machinery_Door D = null;

			
			if ( !( this.loc != null ) ) {
				return false;
			}

			foreach (dynamic _a in Lang13.Enumerate( Map13.GetTile( this.x, this.y, this.z ), typeof(Obj_Machinery_Door) )) {
				D = _a;
				

				if ( !( D is Obj_Machinery_Door_Window ) && D.density ) {
					return false;
				}
			}
			return true;
		}

		// Function from file: swarmer.dm
		public override void swarmer_act( Mob_Living_SimpleAnimal_Hostile_Swarmer S = null ) {
			dynamic T = null;

			
			foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInRange( this, 1 ) )) {
				T = _a;
				

				if ( T is Tile_Space || T.loc is Zone_Space ) {
					S.WriteMsg( "<span class='warning'>Destroying this object has the potential to cause a hull breach. Aborting.</span>" );
					return;
				}
			}
			base.swarmer_act( S );
			return;
		}

	}

}