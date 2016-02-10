// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Screen_Movable : Obj_Screen {

		public bool snap2grid = false;

		public Obj_Screen_Movable ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: movable_screen_objects.dm
		public dynamic decode_screen_Y( string Y = null ) {
			dynamic _default = null;

			dynamic view = null;
			double? num = null;
			double? num2 = null;

			view = this.get_view_size();

			if ( String13.FindIgnoreCase( Y, "NORTH-", 1, 0 ) != 0 ) {
				num = String13.ParseNumber( String13.SubStr( Y, 7, 0 ) );

				if ( !Lang13.Bool( num ) ) {
					num = 0;
				}
				_default = view * 2 + 1 - num;
			} else if ( String13.FindIgnoreCase( Y, "SOUTH+", 1, 0 ) != 0 ) {
				num2 = String13.ParseNumber( String13.SubStr( Y, 7, 0 ) );

				if ( !Lang13.Bool( num2 ) ) {
					num2 = 0;
				}
				_default = ( num2 ??0) + 1;
			} else if ( String13.FindIgnoreCase( Y, "CENTER", 1, 0 ) != 0 ) {
				_default = view + 1;
			}
			return _default;
		}

		// Function from file: movable_screen_objects.dm
		public string encode_screen_Y( dynamic Y = null ) {
			string _default = null;

			dynamic view = null;

			view = this.get_view_size();

			if ( Convert.ToDouble( Y ) > Convert.ToDouble( view + 1 ) ) {
				_default = "NORTH-" + ( view * 2 + 1 - Y );
			} else if ( Convert.ToDouble( Y ) < Convert.ToDouble( view + 1 ) ) {
				_default = "SOUTH+" + ( Y - 1 );
			} else {
				_default = "CENTER";
			}
			return _default;
		}

		// Function from file: movable_screen_objects.dm
		public dynamic decode_screen_X( string X = null ) {
			dynamic _default = null;

			dynamic view = null;
			double? num = null;
			double? num2 = null;

			view = this.get_view_size();

			if ( String13.FindIgnoreCase( X, "EAST-", 1, 0 ) != 0 ) {
				num = String13.ParseNumber( String13.SubStr( X, 6, 0 ) );

				if ( !Lang13.Bool( num ) ) {
					num = 0;
				}
				_default = view * 2 + 1 - num;
			} else if ( String13.FindIgnoreCase( X, "WEST+", 1, 0 ) != 0 ) {
				num2 = String13.ParseNumber( String13.SubStr( X, 6, 0 ) );

				if ( !Lang13.Bool( num2 ) ) {
					num2 = 0;
				}
				_default = ( num2 ??0) + 1;
			} else if ( String13.FindIgnoreCase( X, "CENTER", 1, 0 ) != 0 ) {
				_default = view + 1;
			}
			return _default;
		}

		// Function from file: movable_screen_objects.dm
		public string encode_screen_X( dynamic X = null ) {
			string _default = null;

			dynamic view = null;

			view = this.get_view_size();

			if ( Convert.ToDouble( X ) > Convert.ToDouble( view + 1 ) ) {
				_default = "EAST-" + ( view * 2 + 1 - X );
			} else if ( Convert.ToDouble( X ) < Convert.ToDouble( view + 1 ) ) {
				_default = "WEST+" + ( X - 1 );
			} else {
				_default = "CENTER";
			}
			return _default;
		}

		// Function from file: movable_screen_objects.dm
		public virtual dynamic get_view_size(  ) {
			dynamic _default = null;

			
			if ( Task13.User != null && Task13.User.client != null ) {
				_default = Task13.User.client.view;
			} else {
				_default = Game13.view;
			}
			return _default;
		}

		// Function from file: movable_screen_objects.dm
		public override dynamic MouseDrop( Mob over_object = null, dynamic src_location = null, Ent_Static over_location = null, dynamic src_control = null, dynamic over_control = null, string _params = null ) {
			ByTable PM = null;
			ByTable screen_loc_params = null;
			ByTable screen_loc_X = null;
			ByTable screen_loc_Y = null;
			double pix_X = 0;
			double pix_Y = 0;

			PM = String13.ParseUrlParams( _params );

			if ( !( PM != null ) || !Lang13.Bool( PM["screen-loc"] ) ) {
				return null;
			}
			screen_loc_params = GlobalFuncs.text2list( PM["screen-loc"], "," );
			screen_loc_X = GlobalFuncs.text2list( screen_loc_params[1], ":" );
			screen_loc_X[1] = this.encode_screen_X( String13.ParseNumber( screen_loc_X[1] ) );
			screen_loc_Y = GlobalFuncs.text2list( screen_loc_params[2], ":" );
			screen_loc_Y[1] = this.encode_screen_Y( String13.ParseNumber( screen_loc_Y[1] ) );

			if ( this.snap2grid ) {
				this.screen_loc = "" + screen_loc_X[1] + "," + screen_loc_Y[1];
			} else {
				pix_X = ( String13.ParseNumber( screen_loc_X[2] ) ??0) - 16;
				pix_Y = ( String13.ParseNumber( screen_loc_Y[2] ) ??0) - 16;
				this.screen_loc = "" + screen_loc_X[1] + ":" + pix_X + "," + screen_loc_Y[1] + ":" + pix_Y;
			}
			return null;
		}

	}

}