// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Decal_Cleanable_LiquidFuel_FlamethrowerFuel : Obj_Effect_Decal_Cleanable_LiquidFuel {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.volatility = 0.01;
			this.icon_state = "mustard";
		}

		// Function from file: fuel.dm
		public Obj_Effect_Decal_Cleanable_LiquidFuel_FlamethrowerFuel ( dynamic newLoc = null, bool? amt = null, bool? d = null ) : base( (object)(newLoc), amt ) {
			amt = amt ?? true;
			d = d ?? false;

			dynamic T = null;

			this.dir = d == true ?1:0;
			T = newLoc;

			if ( T is Tile ) {
				((Tile)T).hotspot_expose( 70000, 50000, true, true );
			}
			return;
		}

		// Function from file: fuel.dm
		public override void Spread(  ) {
			Ent_Static S = null;
			double transferred_amount = 0;
			dynamic d = null;
			Tile O = null;
			Game_Data FF = null;
			double balanced = 0;

			
			if ( ( this.amount ??0) < 0.1 ) {
				return;
			}
			S = this.loc;

			if ( !( S is Tile_Simulated ) ) {
				return;
			}
			transferred_amount = 0;

			foreach (dynamic _a in Lang13.Enumerate( new ByTable(new object [] { Num13.Rotate( this.dir, 90 ), Num13.Rotate( this.dir, -90 ), this.dir }) )) {
				d = _a;
				
				O = Map13.GetStep( S, Convert.ToInt32( d ) );

				if ( Lang13.Bool( Lang13.FindIn( typeof(Obj_Effect_Decal_Cleanable_LiquidFuel_FlamethrowerFuel), O ) ) ) {
					continue;
				}

				if ( O.CanPass( null, S, 0, false ) && S.CanPass( null, O, 0, false ) ) {
					FF = GlobalFuncs.getFromPool( typeof(Obj_Effect_Decal_Cleanable_LiquidFuel_FlamethrowerFuel), O, ( this.amount ??0) * 0.25, d );

					if ( ( this.amount ??0) + Convert.ToDouble( ((dynamic)FF).amount ) > 0.4 ) {
						
						if ( ( this.amount ??0) < 0.2 || Convert.ToDouble( ((dynamic)FF).amount ) < 0.2 ) {
							balanced = ( ( this.amount ??0) + Convert.ToDouble( ((dynamic)FF).amount ) ) / 2;
							this.amount = balanced;
							((dynamic)FF).amount = balanced;
						}
					} else {
						GlobalFuncs.returnToPool( FF );
						return;
					}
					Task13.Schedule( 1, (Task13.Closure)(() => {
						O.hotspot_expose( 7000, 500, true, true );
						return;
					}));

					if ( FF != null ) {
						transferred_amount += Convert.ToDouble( ((dynamic)FF).amount );
					}
				}
			}
			this.amount = Num13.MaxInt( ((int)( ( this.amount ??0) - transferred_amount )), 0 );

			if ( this.amount == 0 ) {
				GlobalFuncs.returnToPool( this );
			}
			return;
		}

	}

}