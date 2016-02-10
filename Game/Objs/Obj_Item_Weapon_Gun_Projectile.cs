// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Gun_Projectile : Obj_Item_Weapon_Gun {

		public string ammo_type = "/obj/item/ammo_casing/a357";
		public ByTable loaded = new ByTable();
		public double? max_shells = 7;
		public int load_method = 0;
		public dynamic stored_magazine = null;
		public dynamic chambered = null;
		public string mag_type = "";
		public int gun_flags = 4;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.caliber = new ByTable().Set( "357", 1 );
			this.origin_tech = "combat=2;materials=2";
			this.starting_materials = new ByTable().Set( "$iron", 1000 );
			this.recoil = 1;
			this.icon_state = "revolver";
		}

		// Function from file: projectile.dm
		public Obj_Item_Weapon_Gun_Projectile ( dynamic loc = null ) : base( (object)(loc) ) {
			double? i = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( Lang13.Bool( this.mag_type ) && this.load_method == 2 ) {
				this.stored_magazine = Lang13.Call( this.mag_type, this );
				this.chamber_round();
			} else {
				i = null;
				i = 1;

				while (( i ??0) <= ( this.max_shells ??0)) {
					this.loaded.Add( Lang13.Call( this.ammo_type, this ) );
					i++;
				}
			}
			this.update_icon();
			return;
		}

		// Function from file: projectile.dm
		public override dynamic examine( dynamic user = null, string size = null ) {
			base.examine( (object)(user), size );
			GlobalFuncs.to_chat( user, new Txt( "<span class='info'>Has " ).item( this.getAmmo() ).str( " round" ).s().str( " remaining.</span>" ).ToString() );

			if ( this.silenced is Obj_Item_GunPart_Silencer ) {
				GlobalFuncs.to_chat( user, "<span class='warning'>It has a supressor attached to the barrel.</span>" );
			}
			return null;
		}

		// Function from file: projectile.dm
		public override bool afterattack( dynamic A = null, dynamic user = null, bool? flag = null, dynamic _params = null, bool? struggle = null ) {
			_params = _params ?? 0;

			base.afterattack( (object)(A), (object)(user), flag, (object)(_params), struggle );

			if ( !Lang13.Bool( this.chambered ) && Lang13.Bool( this.stored_magazine ) && !( ((Obj_Item_AmmoStorage)this.stored_magazine).ammo_count() != 0 ) && ( this.gun_flags & 2 ) != 0 ) {
				this.RemoveMag();
				GlobalFuncs.playsound( user, "sound/weapons/smg_empty_alarm.ogg", 40, 1 );
			}
			return false;
		}

		// Function from file: projectile.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			Ent_Static AC = null;
			dynamic AC2 = null;

			
			if ( this.target != null ) {
				return base.attack_self( (object)(user), (object)(flag), emp );
			}

			if ( this.loaded.len != 0 || Lang13.Bool( this.stored_magazine ) ) {
				
				if ( this.load_method == 0 ) {
					AC = this.loaded[1];
					this.loaded.Remove( AC );
					AC.loc = GlobalFuncs.get_turf( this );
					GlobalFuncs.to_chat( user, new Txt( "<span class='notice'>You unload " ).the( AC ).item().str( " from " ).the( this ).item().str( "!</span>" ).ToString() );
					this.update_icon();
					return null;
				}

				if ( this.load_method == 2 && Lang13.Bool( this.stored_magazine ) ) {
					this.RemoveMag( user );
				}
			} else if ( this.loc == user ) {
				
				if ( Lang13.Bool( this.chambered ) ) {
					AC2 = this.chambered;
					AC2.loc = GlobalFuncs.get_turf( this );
					this.chambered = null;
					GlobalFuncs.to_chat( user, new Txt( "<span class='notice'>You unload " ).the( AC2 ).item().str( " from " ).the( this ).item().str( "!</span>" ).ToString() );
					this.update_icon();
					return null;
				}

				if ( Lang13.Bool( this.silenced ) ) {
					
					if ( user.l_hand != this && user.r_hand != this ) {
						base.attack_self( (object)(user), (object)(flag), emp );
						return null;
					}
					GlobalFuncs.to_chat( user, "<span class='notice'>You unscrew " + this.silenced + " from " + this + ".</span>" );
					((Mob)user).put_in_hands( this.silenced );
					this.silenced = 0;
					this.w_class = 2;
					this.update_icon();
					return null;
				}
			} else {
				GlobalFuncs.to_chat( user, new Txt( "<span class='warning'>Nothing loaded in " ).the( this ).item().str( "!</span>" ).ToString() );
			}
			return null;
		}

		// Function from file: projectile.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			int num_loaded = 0;
			dynamic AM = null;
			dynamic AS = null;
			int success_load = 0;
			dynamic AC = null;

			
			if ( a is Obj_Item_GunPart_Silencer && ( this.gun_flags & 1 ) != 0 ) {
				
				if ( b.l_hand != this && b.r_hand != this ) {
					GlobalFuncs.to_chat( b, "<span class='notice'>You'll need " + this + " in your hands to do that.</span>" );
					return null;
				}

				if ( Lang13.Bool( b.drop_item( a, this ) ) ) {
					GlobalFuncs.to_chat( b, "<span class='notice'>You screw " + a + " onto " + this + ".</span>" );
					this.silenced = a;
					this.w_class = 3;
					this.update_icon();
					return 1;
				}
			}
			num_loaded = 0;

			if ( a is Obj_Item_AmmoStorage_Magazine ) {
				AM = a;

				if ( this.load_method == 2 ) {
					
					if ( !Lang13.Bool( this.stored_magazine ) ) {
						this.LoadMag( AM, b );
					} else {
						GlobalFuncs.to_chat( b, new Txt( "<span class='rose'>There is already a magazine loaded in " ).the( this ).item().str( "!</span>" ).ToString() );
					}
				} else {
					GlobalFuncs.to_chat( b, new Txt( "<span class='rose'>You can't load " ).the( this ).item().str( " with a magazine, dummy!</span>" ).ToString() );
				}
			}

			if ( a is Obj_Item_AmmoStorage && this.load_method != 2 ) {
				AS = a;
				success_load = ((Obj_Item_AmmoStorage)AS).LoadInto( AS, this );

				if ( success_load != 0 ) {
					GlobalFuncs.to_chat( b, new Txt( "<span class='notice'>You successfully fill the " ).item( this ).str( " with " ).item( success_load ).str( " shell" ).s().str( " from the " ).item( AS ).str( ".</span>" ).ToString() );
				}
			}

			if ( a is Obj_Item_AmmoCasing ) {
				AC = a;

				if ( Lang13.Bool( AC.BB ) && Lang13.Bool( this.caliber[AC.caliber] ) ) {
					
					if ( this.load_method == 2 && !Lang13.Bool( this.chambered ) ) {
						
						if ( Lang13.Bool( b.drop_item( AC, this ) ) ) {
							this.chambered = AC;
							num_loaded++;
							GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/items/Deconstruct.ogg", 25, 1 );
						}
					} else if ( this.getAmmo() < ( this.max_shells ??0) ) {
						
						if ( Lang13.Bool( b.drop_item( AC, this ) ) ) {
							this.loaded.Add( AC );
							num_loaded++;
							GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/items/Deconstruct.ogg", 25, 1 );
						}
					}
				}
			}

			if ( num_loaded != 0 ) {
				GlobalFuncs.to_chat( b, new Txt( "<span class='notice'>You load " ).item( num_loaded ).str( " shell" ).s().str( " into " ).the( this ).item().str( "!</span>" ).ToString() );
			}
			a.update_icon();
			this.update_icon();
			return null;
		}

		// Function from file: projectile.dm
		public override bool process_chambered(  ) {
			dynamic AC = null;

			AC = this.getAC();

			if ( Lang13.Bool( this.in_chamber ) ) {
				return true;
			}

			if ( AC == null || !( AC is Obj_Item_AmmoCasing ) ) {
				return false;
			}

			if ( Lang13.Bool( this.mag_type ) && this.load_method == 2 ) {
				this.chambered = null;
				this.chamber_round();
			} else {
				this.loaded.Remove( AC );
			}

			if ( ( this.gun_flags & 4 ) != 0 ) {
				AC.loc = GlobalFuncs.get_turf( this );
			}

			if ( Lang13.Bool( AC.BB ) ) {
				this.in_chamber = AC.BB;
				AC.BB.loc = this;
				AC.BB = null;
				AC.update_icon();
				return true;
			}
			return false;
		}

		// Function from file: projectile.dm
		public double getAmmo(  ) {
			double bullets = 0;
			Obj_Item_AmmoCasing AC = null;

			bullets = 0;

			if ( Lang13.Bool( this.mag_type ) && this.load_method == 2 ) {
				
				if ( Lang13.Bool( this.stored_magazine ) ) {
					bullets += ((Obj_Item_AmmoStorage)this.stored_magazine).ammo_count();
				}

				if ( Lang13.Bool( this.chambered ) ) {
					bullets++;
				}
			} else {
				
				foreach (dynamic _a in Lang13.Enumerate( this.loaded, typeof(Obj_Item_AmmoCasing) )) {
					AC = _a;
					

					if ( AC is Obj_Item_AmmoCasing ) {
						bullets += 1;
					}
				}
			}
			return bullets;
		}

		// Function from file: projectile.dm
		public dynamic getAC(  ) {
			dynamic AC = null;

			AC = null;

			if ( Lang13.Bool( this.mag_type ) && this.load_method == 2 ) {
				AC = this.chambered;
			} else if ( this.getAmmo() != 0 ) {
				AC = this.loaded[1];
			}
			return AC;
		}

		// Function from file: projectile.dm
		public bool chamber_round(  ) {
			dynamic round = null;

			
			if ( Lang13.Bool( this.chambered ) || !Lang13.Bool( this.stored_magazine ) ) {
				return false;
			} else {
				round = ((Obj_Item_AmmoStorage)this.stored_magazine).get_round();

				if ( round is Obj_Item_AmmoCasing ) {
					this.chambered = round;
					this.chambered.loc = this;
					return true;
				}
			}
			return false;
		}

		// Function from file: projectile.dm
		public bool RemoveMag( dynamic user = null ) {
			
			if ( Lang13.Bool( this.stored_magazine ) ) {
				this.stored_magazine.loc = GlobalFuncs.get_turf( this.loc );

				if ( Lang13.Bool( user ) ) {
					((Mob)user).put_in_hands( this.stored_magazine );
					GlobalFuncs.to_chat( Task13.User, new Txt( "<span class='notice'>You pull the magazine out of " ).the( this ).item().str( "!</span>" ).ToString() );
				}
				this.stored_magazine.update_icon();
				this.stored_magazine = null;
				this.update_icon();
				((Mob)user).update_inv_r_hand();
				((Mob)user).update_inv_l_hand();
				return true;
			}
			return false;
		}

		// Function from file: projectile.dm
		public bool LoadMag( dynamic AM = null, dynamic user = null ) {
			
			if ( Lang13.Bool( ((dynamic)Lang13.FindClass( this.mag_type )).IsInstanceOfType( AM ) ) && !Lang13.Bool( this.stored_magazine ) ) {
				
				if ( Lang13.Bool( user ) ) {
					
					if ( Lang13.Bool( user.drop_item( AM, this ) ) ) {
						GlobalFuncs.to_chat( Task13.User, new Txt( "<span class='notice'>You load the magazine into " ).the( this ).item().str( ".</span>" ).ToString() );
					} else {
						return false;
					}
				}
				this.stored_magazine = AM;
				this.chamber_round();
				AM.update_icon();
				this.update_icon();

				if ( Lang13.Bool( user ) ) {
					((Mob)user).update_inv_r_hand();
					((Mob)user).update_inv_l_hand();
				}
				return true;
			}
			return false;
		}

		// Function from file: projectile.dm
		[Verb]
		[VerbInfo( name: "Remove Magazine", group: "Object", access: VerbAccess.InRange, range: 0 )]
		public virtual void force_removeMag(  ) {
			
			if ( Lang13.Bool( this.stored_magazine ) ) {
				this.RemoveMag();
			} else {
				GlobalFuncs.to_chat( Task13.User, "<span class='rose'>There is no magazine to remove!</span>" );
			}
			return;
		}

	}

}