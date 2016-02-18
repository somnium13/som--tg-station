// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Objective_Build : Objective {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.dangerrating = 15;
			this.martyr_compatible = true;
		}

		public Objective_Build ( string text = null ) : base( text ) {
			
		}

		// Function from file: objectives.dm
		public override int check_completion(  ) {
			bool shrines = false;
			dynamic G = null;
			dynamic S = null;

			
			if ( !Lang13.Bool( this.owner ) || !Lang13.Bool( this.owner.current ) ) {
				return 0;
			}
			shrines = false;

			if ( GlobalFuncs.is_handofgod_god( this.owner.current ) ) {
				G = this.owner.current;

				foreach (dynamic _a in Lang13.Enumerate( G.structures, typeof(Obj_Structure_Divine_Shrine) )) {
					S = _a;
					
					S++;
				}
			}
			return ( shrines ?1:0) >= Convert.ToDouble( this.target_amount ) ?1:0;
		}

		// Function from file: objectives.dm
		public dynamic gen_amount_goal( int lower = 0, int upper = 0 ) {
			this.target_amount = Rand13.Int( lower, upper );
			this.explanation_text = "Build " + this.target_amount + " shrines.";
			return this.target_amount;
		}

	}

}