// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Power_Solar_Panel : Obj_Machinery_Power_Solar {

		public bool id_tag = false;
		public dynamic health = 15;
		public dynamic maxhealth = 15;
		public bool obscured = false;
		public double sunfrac = 0;
		public double? adir = 2;
		public double? ndir = 2;
		public bool turn_angle = false;
		public dynamic glass_quality_factor = 1;
		public bool tracker = false;
		public Obj_Machinery_Power_Solar_Control control = null;
		public Obj_Machinery_Power_SolarAssembly solar_assembly = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "sp_base";
		}

		// Function from file: panel.dm
		public Obj_Machinery_Power_Solar_Panel ( dynamic loc = null, Obj_Machinery_Power_SolarAssembly S = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.make( S );
			return;
		}

		// Function from file: panel.dm
		public override bool disconnect_from_network(  ) {
			bool _default = false;

			_default = base.disconnect_from_network();

			if ( _default ) {
				this.control = null;
			}
			return _default;
		}

		// Function from file: panel.dm
		public override bool ex_act( double? severity = null, dynamic child = null ) {
			
			switch ((double?)( severity )) {
				case 1:
					this.solar_assembly.glass_type = null;

					if ( Rand13.PercentChance( 15 ) ) {
						GlobalFuncs.getFromPool( typeof(Obj_Item_Weapon_Shard), this.loc );
					}
					this.kill();
					break;
				case 2:
					
					if ( Rand13.PercentChance( 25 ) ) {
						this.solar_assembly.glass_type = null;
						GlobalFuncs.getFromPool( typeof(Obj_Item_Weapon_Shard), this.loc );
						this.kill();
					} else {
						this.broken();
					}
					break;
				case 3:
					
					if ( Rand13.PercentChance( 35 ) ) {
						this.broken();
					} else {
						this.health--;
					}
					break;
			}
			return false;
		}

		// Function from file: panel.dm
		public override dynamic process(  ) {
			double sgen = 0;

			
			if ( ( this.stat & 1 ) != 0 ) {
				return null;
			}

			if ( !( this.control != null ) ) {
				return null;
			}

			if ( this.adir != this.ndir ) {
				this.adir = ( ( this.adir ??0) + ( ( this.ndir ??0) - ( this.adir ??0) <= -10 ? -10 : ( ( this.ndir ??0) - ( this.adir ??0) >= 10 ? 10 : ( this.ndir ??0) - ( this.adir ??0) ) ) + 360 ) % 360;
				this.update_icon();
				this.update_solar_exposure();
			}

			if ( this.obscured ) {
				return null;
			}
			sgen = this.sunfrac * Convert.ToDouble( this.glass_quality_factor ) * Convert.ToDouble( this.health / this.maxhealth ) * 1500;
			this.add_avail( sgen );

			if ( Lang13.Bool( this.powernet ) && this.control != null ) {
				
				if ( this.powernet.nodes.Find( this.control ) != 0 ) {
					this.control.gen += sgen;
				}
			}
			return null;
		}

		// Function from file: panel.dm
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			Type G = null;
			string icon = null;

			base.update_icon( (object)(location), (object)(target) );

			if ( !this.tracker ) {
				this.overlays.len = 0;
				G = this.solar_assembly.glass_type;
				icon = "solar_panel_" + Lang13.Initial( G, "sname" );

				if ( ( this.stat & 1 ) != 0 ) {
					icon += "-b";
				}
				this.overlays.Add( new Image( "icons/obj/power.dmi", null, icon, GlobalVars.FLY_LAYER ) );
				this.dir = ((int)( GlobalFuncs.angle2dir( this.adir ) ??0 ));
			}
			return null;
		}

		// Function from file: panel.dm
		public override bool blob_act( dynamic severity = null ) {
			
			if ( Rand13.PercentChance( 30 ) ) {
				this.broken();
			} else {
				this.health--;
			}
			this.healthcheck();
			return false;
		}

		// Function from file: panel.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic T = null;
			Type G = null;

			
			if ( a is Obj_Item_Weapon_Crowbar ) {
				T = GlobalFuncs.get_turf( this );
				G = this.solar_assembly.glass_type;
				GlobalFuncs.to_chat( b, "<span class='notice'>You begin taking the " + Lang13.Initial( G, "name" ) + " off the " + this + ".</span>" );
				GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/machines/click.ogg", 50, 1 );

				if ( GlobalFuncs.do_after( b, this, 50 ) ) {
					
					if ( this.solar_assembly != null ) {
						this.solar_assembly.loc = T;
						this.solar_assembly.give_glass();
					}
					GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/items/Deconstruct.ogg", 50, 1 );
					((Ent_Static)b).visible_message( "<span class='notice'>" + b + " takes the " + Lang13.Initial( G, "name" ) + " off the " + this + ".</span>", "<span class='notice'>You takes the " + Lang13.Initial( G, "name" ) + " off the " + this + ".</span>" );
					GlobalFuncs.qdel( this );
				}
			} else if ( Lang13.Bool( a ) ) {
				this.add_fingerprint( b );
				this.health -= a.force;
				this.healthcheck();
			}
			base.attackby( (object)(a), (object)(b), (object)(c) );
			return null;
		}

		// Function from file: panel.dm
		public void kill(  ) {
			Obj_Machinery_Power_SolarAssembly assembly = null;

			
			if ( this.solar_assembly != null ) {
				assembly = this.solar_assembly;
				this.solar_assembly = null;
				GlobalFuncs.qdel( assembly );
			}
			GlobalFuncs.qdel( this );
			return;
		}

		// Function from file: panel.dm
		public void broken(  ) {
			this.stat |= 1;
			this.update_icon();

			if ( Convert.ToDouble( this.health ) > 1 ) {
				this.health = 1;
			}
			return;
		}

		// Function from file: panel.dm
		public void update_solar_exposure(  ) {
			double p_angle = 0;

			
			if ( !( GlobalVars.sun != null ) ) {
				return;
			}

			if ( this.obscured ) {
				this.sunfrac = 0;
				return;
			}
			p_angle = Math.Abs( ( ( this.adir ??0) + 360 ) % 360 - ( ( GlobalVars.sun.angle ??0) + 360 ) % 360 );

			if ( p_angle > 90 ) {
				this.sunfrac = 0;
				return;
			}
			this.sunfrac = Math.Pow( Math.Cos( p_angle ), 2 );
			return;
		}

		// Function from file: panel.dm
		public void healthcheck(  ) {
			Type G = null;
			dynamic shard = null;

			
			if ( Convert.ToDouble( this.health ) <= 0 ) {
				
				if ( !( ( this.stat & 1 ) != 0 ) ) {
					this.broken();
				} else {
					G = this.solar_assembly.glass_type;
					shard = Lang13.Initial( G, "shard_type" );
					this.solar_assembly.glass_type = null;
					this.solar_assembly.loc = GlobalFuncs.get_turf( this );
					GlobalFuncs.getFromPool( shard, this.loc );
					GlobalFuncs.getFromPool( shard, this.loc );
					GlobalFuncs.qdel( this );
				}
			}
			return;
		}

		// Function from file: panel.dm
		public void make( Obj_Machinery_Power_SolarAssembly S = null ) {
			Type G = null;

			
			if ( !( S != null ) ) {
				this.solar_assembly = new Obj_Machinery_Power_SolarAssembly();
				this.solar_assembly.glass_type = typeof(Obj_Item_Stack_Sheet_Glass_Rglass);
				this.solar_assembly.anchored = 1;
				this.solar_assembly.density = true;
				this.solar_assembly.tracker = this.tracker;
			} else {
				this.solar_assembly = S;
				G = this.solar_assembly.glass_type;
				this.glass_quality_factor = Lang13.Initial( G, "glass_quality" );
				this.maxhealth = Lang13.Initial( G, "shealth" );
				this.health = Lang13.Initial( G, "shealth" );
			}
			this.solar_assembly.loc = this;
			this.update_icon();
			return;
		}

	}

}