// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Stack_PackageWrap : Obj_Item_Stack {

		public Type smallpath = typeof(Obj_Item_Delivery);
		public Type bigpath = typeof(Obj_Item_Delivery_Large);
		public Type manpath = null;
		public double? human_wrap_speed = 100;
		public ByTable cannot_wrap = new ByTable(new object [] { 
											typeof(Obj_Structure_Table), 
											typeof(Obj_Structure_Rack), 
											typeof(Obj_Item_Delivery), 
											typeof(Obj_Item_Weapon_Gift), 
											typeof(Obj_Item_Weapon_WinterGift), 
											typeof(Obj_Item_Weapon_Evidencebag), 
											typeof(Obj_Item_Weapon_Legcuffs_Bolas), 
											typeof(Obj_Item_Weapon_Storage)
										 });
		public ByTable wrappable_big_stuff = new ByTable(new object [] { typeof(Obj_Structure_Closet), typeof(Obj_Structure_Vendomatpack), typeof(Obj_Structure_Stackopacks) });

		protected override void __FieldInit() {
			base.__FieldInit();

			this.singular_name = "paper sheet";
			this.w_class = 2;
			this.amount = 24;
			this.max_amount = 24;
			this.icon_state = "deliveryPaper";
		}

		public Obj_Item_Stack_PackageWrap ( dynamic loc = null, int? amount = null ) : base( (object)(loc), amount ) {
			
		}

		// Function from file: packagewrap.dm
		public bool try_wrap_human( dynamic H = null, dynamic user = null ) {
			dynamic present = null;

			
			if ( !( this.manpath != null ) ) {
				return false;
			}

			if ( ( this.amount ??0) >= 2 ) {
				((Ent_Static)H).visible_message( "<span class='danger'>" + user + " is trying to wrap up " + H + "!</span>" );

				if ( GlobalFuncs.do_mob( user, H, this.human_wrap_speed ) ) {
					present = Lang13.Call( this.manpath, GlobalFuncs.get_turf( H ), H );

					if ( Lang13.Bool( H.client ) ) {
						H.client.perspective = GlobalVars.EYE_PERSPECTIVE ?1:0;
						H.client.eye = present;
					}
					((Ent_Dynamic)H).forceMove( present );
					H.attack_log.Add( "[" + GlobalFuncs.time_stamp() + "] <font color='orange'>Has been wrapped with " + this.name + "  by " + user.name + " (" + user.ckey + ")</font>" );
					user.attack_log.Add( "[" + GlobalFuncs.time_stamp() + "] <font color='red'>Used the " + this.name + " to wrap " + H.name + " (" + H.ckey + ")</font>" );

					if ( !( user is Mob_Living_Carbon ) ) {
						H.LAssailant = null;
					} else {
						H.LAssailant = user;
					}
					GlobalVars.diaryofmeanpeople.WriteMsg( String13.HtmlDecode( "[" + GlobalFuncs.time_stamp() + "]ATTACK: " + ( "<font color='red'>" + user.name + " (" + user.ckey + ") used the " + this.name + " to wrap " + H.name + " (" + H.ckey + ")</font>" ) ) );
					this.use( 2 );
					return true;
				}
			} else {
				GlobalFuncs.to_chat( user, "<span class='warning'>You need more paper!</span>" );
				return false;
			}
			return false;
		}

		// Function from file: packagewrap.dm
		public override bool afterattack( dynamic A = null, dynamic user = null, bool? flag = null, dynamic _params = null, bool? struggle = null ) {
			dynamic target = null;
			dynamic I = null;
			dynamic P = null;
			dynamic C = null;
			dynamic P2 = null;

			
			if ( A is Mob_Living_Carbon_Human ) {
				return this.try_wrap_human( A, user );
			}

			if ( !( A is Obj ) ) {
				return false;
			}
			target = A;

			if ( GlobalFuncs.is_type_in_list( target, this.cannot_wrap ) ) {
				return false;
			}

			if ( Lang13.Bool( target.anchored ) ) {
				return false;
			}
			Interface13.Stat( null, user.Contains( target ) );

			if ( Lang13.Bool( target.anchored ) ) {
				return false;
			}

			if ( !( flag == true ) ) {
				return false;
			}
			user.attack_log.Add( new Txt( "[" ).item( GlobalFuncs.time_stamp() ).str( "] <font color='blue'>Has used " ).item( this.name ).str( " on " ).Ref( target ).str( "</font>" ).ToString() );
			((Ent_Static)target).add_fingerprint( user );
			this.add_fingerprint( user );

			if ( target is Obj_Item && this.smallpath != null ) {
				
				if ( ( this.amount ??0) >= 1 ) {
					I = target;
					P = Lang13.Call( this.smallpath, GlobalFuncs.get_turf( target.loc ), target, Num13.Floor( Convert.ToDouble( I.w_class ) ) );

					if ( !( target.loc is Tile ) ) {
						
						if ( Lang13.Bool( user.client ) ) {
							user.client.screen -= target;
						}
					}
					((Ent_Dynamic)target).forceMove( P );
					((Ent_Static)P).add_fingerprint( user );
					this.use( 1 );
				} else {
					GlobalFuncs.to_chat( user, "<span class='warning'>You need more paper!</span>" );
				}
			} else if ( GlobalFuncs.is_type_in_list( target, this.wrappable_big_stuff ) && this.bigpath != null ) {
				
				if ( target is Obj_Structure_Closet ) {
					C = target;

					if ( Lang13.Bool( C.opened ) ) {
						return false;
					}
				}

				if ( ( this.amount ??0) >= 3 ) {
					P2 = Lang13.Call( this.bigpath, GlobalFuncs.get_turf( target.loc ), target );
					((Ent_Dynamic)target).forceMove( P2 );
					((Ent_Static)P2).add_fingerprint( user );
					this.use( 3 );
				} else {
					GlobalFuncs.to_chat( user, "<span class='warning'>You need more paper!</span>" );
				}
			} else {
				GlobalFuncs.to_chat( user, "<span class='warning'>" + this + " isn't useful for wrapping " + target + ".</span>" );
			}
			return true;
		}

	}

}