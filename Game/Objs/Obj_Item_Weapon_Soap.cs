// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Soap : Obj_Item_Weapon {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.w_class = 1;
			this.throwforce = 0;
			this.throw_speed = 4;
			this.throw_range = 20;
			this.icon_state = "soap";
		}

		public Obj_Item_Weapon_Soap ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: clown_items.dm
		public override bool? attack( dynamic M = null, dynamic user = null, string def_zone = null, bool? eat_override = null ) {
			
			if ( Lang13.Bool( M ) && Lang13.Bool( user ) && M is Mob_Living_Carbon_Human && !Lang13.Bool( M.stat ) && !Lang13.Bool( user.stat ) && user.zone_sel != null && ((dynamic)user.zone_sel).selecting == "mouth" ) {
				((Ent_Static)user).visible_message( new Txt( "<span class='warning'>" ).the( user ).item().str( " washes " ).the( M ).item().str( "'s mouth out with soap!</span>" ).ToString() );
				return null;
			}
			base.attack( (object)(M), (object)(user), def_zone, eat_override );
			return null;
		}

		// Function from file: clown_items.dm
		public override bool afterattack( dynamic A = null, dynamic user = null, bool? flag = null, dynamic _params = null, bool? struggle = null ) {
			dynamic T = null;
			dynamic cleanables = null;
			Obj_Effect_Decal_Cleanable CC = null;
			Obj_Effect_Decal_Cleanable CC2 = null;
			Obj_Effect_Decal_Cleanable C = null;
			Obj_Effect_Decal_Cleanable d = null;

			
			if ( !((Ent_Static)user).Adjacent( A ) ) {
				return false;
			}

			if ( Lang13.Bool( user.client ) && false && !( user.l_hand == A || user.r_hand == A ) ) {
				((Mob)user).simple_message( "<span class='notice'>You need to take that " + A.name + " off before cleaning it.</span>", "<span class='notice'>You need to take that " + A.name + " off before destroying it.</span>" );
			} else if ( A is Obj_Effect_Decal_Cleanable ) {
				((Mob)user).simple_message( new Txt( "<span class='notice'>You scrub " ).the( A.name ).item().str( " out.</span>" ).ToString(), "<span class='warning'>You destroy " + Rand13.Pick(new object [] { "an artwork", "a valuable artwork", "a rare piece of art", "a rare piece of modern art" }) + ".</span>" );
				GlobalFuncs.returnToPool( A );
			} else if ( A is Tile_Simulated ) {
				T = A;
				cleanables = new ByTable();

				foreach (dynamic _a in Lang13.Enumerate( T, typeof(Obj_Effect_Decal_Cleanable) )) {
					CC = _a;
					

					if ( !( CC is Obj_Effect_Decal_Cleanable ) || !( CC != null ) ) {
						continue;
					}
					cleanables += CC;
				}

				foreach (dynamic _b in Lang13.Enumerate( GlobalFuncs.get_turf( user ), typeof(Obj_Effect_Decal_Cleanable) )) {
					CC2 = _b;
					

					if ( CC2.on_wall == A ) {
						cleanables += CC2;
					}
				}

				if ( !( cleanables.len != 0 ) ) {
					((Mob)user).simple_message( "<span class='notice'>You fail to clean anything.</span>", "<span class='notice'>There is nothing for you to vandalize.</span>" );
					return false;
				}
				cleanables = GlobalFuncs.shuffle( cleanables );
				C = null;

				foreach (dynamic _c in Lang13.Enumerate( cleanables, typeof(Obj_Effect_Decal_Cleanable) )) {
					d = _c;
					

					if ( d != null && d is Obj_Effect_Decal_Cleanable ) {
						C = d;
						break;
					}
				}
				((Mob)user).simple_message( new Txt( "<span class='notice'>You scrub " ).the( C.name ).item().str( " out.</span>" ).ToString(), "<span class='warning'>You destroy " + Rand13.Pick(new object [] { "an artwork", "a valuable artwork", "a rare piece of art", "a rare piece of modern art" }) + ".</span>" );
				GlobalFuncs.returnToPool( C );
			} else {
				((Mob)user).simple_message( new Txt( "<span class='notice'>You clean " ).the( A.name ).item().str( ".</span>" ).ToString(), new Txt( "<span class='warning'>You " ).item( Rand13.Pick(new object [] { "deface", "ruin", "stain" }) ).str( " " ).the( A.name ).item().str( ".</span>" ).ToString() );
				((Ent_Static)A).clean_blood();
			}
			return false;
		}

		// Function from file: clown_items.dm
		public override dynamic Crossed( Ent_Dynamic O = null, dynamic X = null ) {
			Ent_Dynamic M = null;

			
			if ( O is Mob_Living_Carbon ) {
				M = O;

				if ( ((Mob_Living_Carbon)M).Slip( 3, 2, true ) ) {
					((Mob)M).simple_message( "<span class='notice'>You slipped on the " + this.name + "!</span>", "<span class='userdanger'>Something is scratching at your feet! Oh god!</span>" );
				}
			}
			return null;
		}

	}

}