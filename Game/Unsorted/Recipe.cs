// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Recipe : Game_Data {

		public ByTable reagents = null;
		public dynamic items = null;
		public dynamic result = null;
		public int time = 100;

		// Function from file: recipe.dm
		public dynamic make_food( Ent_Static container = null ) {
			dynamic result_obj = null;
			Obj O = null;

			result_obj = Lang13.Call( this.result, container );

			foreach (dynamic _a in Lang13.Enumerate( container.contents - result_obj, typeof(Obj) )) {
				O = _a;
				

				if ( O.reagents != null ) {
					O.reagents.del_reagent( "nutriment" );
					O.reagents.update_total();
					O.reagents.trans_to( result_obj, O.reagents.total_volume );
				}
				GlobalFuncs.qdel( O );
			}
			container.reagents.clear_reagents();
			return result_obj;
		}

		// Function from file: recipe.dm
		public dynamic make( Ent_Static container = null ) {
			dynamic result_obj = null;
			Obj O = null;

			result_obj = Lang13.Call( this.result, container );

			foreach (dynamic _a in Lang13.Enumerate( container.contents - result_obj, typeof(Obj) )) {
				O = _a;
				
				O.reagents.trans_to( result_obj, O.reagents.total_volume );
				GlobalFuncs.qdel( O );
			}
			container.reagents.clear_reagents();
			return result_obj;
		}

		// Function from file: recipe.dm
		public int check_items( dynamic container = null ) {
			int _default = 0;

			dynamic checklist = null;
			Obj O = null;
			bool found = false;
			dynamic type = null;

			
			if ( !Lang13.Bool( this.items ) ) {
				
				if ( Lang13.Bool( Lang13.FindIn( typeof(Obj), container ) ) ) {
					return -1;
				} else {
					return 1;
				}
			}
			_default = 1;
			checklist = this.items.Copy();

			foreach (dynamic _b in Lang13.Enumerate( container, typeof(Obj) )) {
				O = _b;
				
				found = false;

				foreach (dynamic _a in Lang13.Enumerate( checklist )) {
					type = _a;
					

					if ( Lang13.Bool( type.IsInstanceOfType( O ) ) ) {
						checklist -= type;
						found = true;
						break;
					}
				}

				if ( !found ) {
					_default = -1;
				}
			}

			if ( checklist.len != 0 ) {
				return 0;
			}
			return _default;
		}

		// Function from file: recipe.dm
		public int check_reagents( Reagents avail_reagents = null ) {
			int _default = 0;

			dynamic r_r = null;
			bool aval_r_amnt = false;

			_default = 1;

			foreach (dynamic _a in Lang13.Enumerate( this.reagents )) {
				r_r = _a;
				
				aval_r_amnt = avail_reagents.get_reagent_amount( r_r );

				if ( !( Math.Abs( ( aval_r_amnt ?1:0) - Convert.ToDouble( this.reagents[r_r] ) ) < 0.5 ) ) {
					
					if ( ( aval_r_amnt ?1:0) > Convert.ToDouble( this.reagents[r_r] ) ) {
						_default = -1;
					} else {
						return 0;
					}
				}
			}

			if ( ( this.reagents != null ? this.reagents.len : 0 ) < avail_reagents.reagent_list.len ) {
				return -1;
			}
			return _default;
		}

	}

}