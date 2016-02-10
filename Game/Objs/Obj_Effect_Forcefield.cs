// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Forcefield : Obj_Effect {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.unacidable = true;
			this.icon = "icons/effects/effects.dmi";
			this.icon_state = "m_shield";
		}

		public Obj_Effect_Forcefield ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: forcewall.dm
		public override dynamic cultify(  ) {
			new Obj_Effect_Forcefield_Cult( GlobalFuncs.get_turf( this ) );
			GlobalFuncs.qdel( this );
			return null;
		}

		// Function from file: forcewall.dm
		public override int? bullet_act( dynamic Proj = null, dynamic def_zone = null ) {
			dynamic T = null;
			dynamic M = null;

			T = GlobalFuncs.get_turf( this.loc );

			if ( Lang13.Bool( T ) ) {
				
				foreach (dynamic _a in Lang13.Enumerate( T )) {
					M = _a;
					
					((Obj_Item_Projectile)Proj).on_hit( M, ((Ent_Static)M).bullet_act( Proj, def_zone ) );
				}
			}
			return null;
		}

	}

}