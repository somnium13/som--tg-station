// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Lamarr : Obj_Structure {

		public double health = 30;
		public bool occupied = true;
		public bool destroyed = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.unacidable = true;
			this.icon = "icons/obj/stationobjs.dmi";
			this.icon_state = "labcage1";
		}

		public Obj_Structure_Lamarr ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: lamarr_cage.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic O = null;

			
			if ( this.destroyed ) {
				return null;
			} else {
				GlobalFuncs.to_chat( Task13.User, "<span class='notice'>You kick the lab cage.</span>" );

				foreach (dynamic _a in Lang13.Enumerate( Map13.FetchViewersExcludeThis( null, null ) )) {
					O = _a;
					

					if ( Lang13.Bool( O.client ) && !Lang13.Bool( O.blinded ) ) {
						GlobalFuncs.to_chat( O, "<span class='warning'>" + Task13.User + " kicks the lab cage.</span>" );
					}
				}
				this.health -= 2;
				this.healthcheck();
				return null;
			}
		}

		// Function from file: lamarr_cage.dm
		public override dynamic attack_paw( Mob a = null, dynamic b = null, dynamic c = null ) {
			return this.attack_hand( a );
		}

		// Function from file: lamarr_cage.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			this.health -= Convert.ToDouble( a.force );
			this.healthcheck();
			base.attackby( (object)(a), (object)(b), (object)(c) );
			return null;
		}

		// Function from file: lamarr_cage.dm
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			
			if ( this.destroyed ) {
				this.icon_state = "labcageb" + this.occupied;
			} else {
				this.icon_state = "labcage" + this.occupied;
			}
			return null;
		}

		// Function from file: lamarr_cage.dm
		public void Break(  ) {
			
			if ( this.occupied ) {
				new Obj_Item_Clothing_Mask_Facehugger_Lamarr( this.loc );
				this.occupied = false;
			}
			this.update_icon();
			return;
		}

		// Function from file: lamarr_cage.dm
		public void healthcheck(  ) {
			
			if ( this.health <= 0 ) {
				
				if ( !this.destroyed ) {
					this.density = false;
					this.destroyed = true;
					GlobalFuncs.getFromPool( typeof(Obj_Item_Weapon_Shard), this.loc );
					GlobalFuncs.playsound( this, "shatter", 70, 1 );
					this.Break();
				}
			} else {
				GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/effects/Glasshit.ogg", 75, 1 );
			}
			return;
		}

		// Function from file: lamarr_cage.dm
		public override bool blob_act( dynamic severity = null ) {
			
			if ( Rand13.PercentChance( 75 ) ) {
				GlobalFuncs.getFromPool( typeof(Obj_Item_Weapon_Shard), this.loc );
				this.Break();
				GlobalFuncs.qdel( this );
			}
			return false;
		}

		// Function from file: lamarr_cage.dm
		public override int? bullet_act( dynamic Proj = null, dynamic def_zone = null ) {
			this.health -= Convert.ToDouble( Proj.damage );
			base.bullet_act( (object)(Proj), (object)(def_zone) );
			this.healthcheck();
			return null;
		}

		// Function from file: lamarr_cage.dm
		public override bool ex_act( double? severity = null, dynamic child = null ) {
			
			switch ((double?)( severity )) {
				case 1:
					GlobalFuncs.getFromPool( typeof(Obj_Item_Weapon_Shard), this.loc );
					this.Break();
					GlobalFuncs.qdel( this );
					break;
				case 2:
					
					if ( Rand13.PercentChance( 50 ) ) {
						this.health -= 15;
						this.healthcheck();
					}
					break;
				case 3:
					
					if ( Rand13.PercentChance( 50 ) ) {
						this.health -= 5;
						this.healthcheck();
					}
					break;
			}
			return false;
		}

	}

}