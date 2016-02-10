// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Mine : Obj_Effect {

		public string triggerproc = "explode";
		public bool triggered = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.icon = "icons/obj/weapons.dmi";
			this.icon_state = "uglymine";
		}

		// Function from file: mines.dm
		public Obj_Effect_Mine ( dynamic loc = null ) : base( (object)(loc) ) {
			this.icon_state = "uglyminearmed";
			return;
		}

		// Function from file: mines.dm
		public void explode( dynamic obj = null ) {
			GlobalFuncs.explosion( this.loc, 0, 1, 2, 3 );
			Task13.Schedule( 0, (Task13.Closure)(() => {
				GlobalFuncs.qdel( this );
				return;
			}));
			return;
		}

		// Function from file: mines.dm
		public void triggerkick( dynamic obj = null ) {
			Effect_Effect_System_SparkSpread s = null;

			s = new Effect_Effect_System_SparkSpread();
			s.set_up( 3, 1, this );
			s.start();
			GlobalFuncs.qdel( obj.client );
			Task13.Schedule( 0, (Task13.Closure)(() => {
				GlobalFuncs.qdel( this );
				return;
			}));
			return;
		}

		// Function from file: mines.dm
		public void triggerplasma( dynamic obj = null ) {
			Tile_Simulated_Floor target = null;
			GasMixture payload = null;

			
			foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInRange( this, 1 ), typeof(Tile_Simulated_Floor) )) {
				target = _a;
				

				if ( !target.blocks_air ) {
					payload = new GasMixture();
					payload.toxins = 30;
					target.zone.air.merge( payload );
					target.hotspot_expose( 1000, 2500 );
				}
			}
			Task13.Schedule( 0, (Task13.Closure)(() => {
				GlobalFuncs.qdel( this );
				return;
			}));
			return;
		}

		// Function from file: mines.dm
		public void triggern2o( dynamic obj = null ) {
			Tile_Simulated_Floor target = null;
			GasMixture payload = null;
			Gas_SleepingAgent trace_gas = null;

			
			foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInRange( this, 1 ), typeof(Tile_Simulated_Floor) )) {
				target = _a;
				

				if ( !target.blocks_air ) {
					payload = new GasMixture();
					trace_gas = new Gas_SleepingAgent();
					trace_gas.moles = 30;
					payload += trace_gas;
					target.zone.air.merge( payload );
				}
			}
			Task13.Schedule( 0, (Task13.Closure)(() => {
				GlobalFuncs.qdel( this );
				return;
			}));
			return;
		}

		// Function from file: mines.dm
		public void triggerstun( dynamic obj = null ) {
			Mob M = null;
			Effect_Effect_System_SparkSpread s = null;

			
			if ( obj is Mob ) {
				M = obj;
				M.Stun( 30 );
			}
			s = new Effect_Effect_System_SparkSpread();
			s.set_up( 3, 1, this );
			s.start();
			Task13.Schedule( 0, (Task13.Closure)(() => {
				GlobalFuncs.qdel( this );
				return;
			}));
			return;
		}

		// Function from file: mines.dm
		public void triggerrad( Ent_Static obj = null ) {
			Effect_Effect_System_SparkSpread s = null;

			s = new Effect_Effect_System_SparkSpread();
			s.set_up( 3, 1, this );
			s.start();
			((dynamic)obj).radiation += 50;
			GlobalFuncs.randmutb( obj );
			GlobalFuncs.domutcheck( obj, null );
			Task13.Schedule( 0, (Task13.Closure)(() => {
				GlobalFuncs.qdel( this );
				return;
			}));
			return;
		}

		// Function from file: mines.dm
		public override bool Bumped( Ent_Static AM = null, dynamic yes = null ) {
			dynamic O = null;

			
			if ( this.triggered ) {
				return false;
			}

			if ( AM is Mob_Living_Carbon_Human || AM is Mob_Living_Carbon_Monkey ) {
				
				foreach (dynamic _a in Lang13.Enumerate( Map13.FetchViewers( this.loc, Game13.view ) )) {
					O = _a;
					
					GlobalFuncs.to_chat( O, new Txt( "<font color='red'>" ).item( AM ).str( " triggered the " ).icon( this ).str( " " ).item( this ).str( "</font>" ).ToString() );
				}
				this.triggered = true;
				Lang13.Call( Lang13.BindFunc( this, this.triggerproc ), AM );
			}
			return false;
		}

		// Function from file: mines.dm
		public override dynamic Crossed( Ent_Dynamic O = null, dynamic X = null ) {
			this.Bumped( O );
			return null;
		}

	}

}