// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Subsystem_Minimap : Subsystem {

		public int MINIMAP_SIZE = 2048;
		public int TILE_SIZE = 8;
		public ByTable z_levels = new ByTable(new object [] { 1 });

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Minimap";
			this.priority = -2;
		}

		// Function from file: minimap.dm
		public Subsystem_Minimap (  ) {
			
			if ( GlobalVars.SSminimap != this ) {
				
				if ( GlobalVars.SSminimap is Subsystem_Minimap ) {
					this.Recover();
					GlobalFuncs.qdel( GlobalVars.SSminimap );
				}
				GlobalVars.SSminimap = this;
			}
			return;
		}

		// Function from file: minimap.dm
		public void generate( dynamic z = null, int? x1 = null, int? y1 = null, int? x2 = null, int? y2 = null ) {
			z = z ?? 1;
			x1 = x1 ?? 1;
			y1 = y1 ?? 1;
			x2 = x2 ?? Game13.map_size_x;
			y2 = y2 ?? Game13.map_size_y;

			Icon minimap = null;
			ByTable obj_icons = null;
			int counter = 0;
			dynamic T = null;
			dynamic tile = null;
			Icon tile_icon = null;
			dynamic obj = null;
			dynamic I = null;
			dynamic obj_icon = null;
			Icon flatten = null;
			Icon final = null;

			minimap = new Icon( "icons/minimap.dmi" );
			minimap.Scale( GlobalVars.MINIMAP_SIZE, GlobalVars.MINIMAP_SIZE );
			obj_icons = new ByTable();
			counter = 128;

			foreach (dynamic _b in Lang13.Enumerate( Map13.FetchInBlock( Map13.GetTile( x1 ??0, y1 ??0, Convert.ToInt32( z ) ), Map13.GetTile( x2 ??0, y2 ??0, Convert.ToInt32( z ) ) ) )) {
				T = _b;
				
				tile = T;
				tile_icon = null;
				obj = null;

				if ( tile is Tile_Space ) {
					obj = Lang13.FindIn( typeof(Obj_Structure_Lattice_Catwalk), tile );

					if ( Lang13.Bool( obj ) ) {
						tile_icon = new Icon( "icons/obj/smooth_structures/catwalk.dmi", "catwalk", GlobalVars.SOUTH );
					}
					obj = Lang13.FindIn( typeof(Obj_Structure_Lattice), tile );

					if ( Lang13.Bool( obj ) ) {
						tile_icon = new Icon( "icons/obj/smooth_structures/lattice.dmi", "lattice", GlobalVars.SOUTH );
					}
					obj = Lang13.FindIn( typeof(Obj_Structure_Grille), tile );

					if ( Lang13.Bool( obj ) ) {
						tile_icon = new Icon( "icons/obj/structures.dmi", "grille", GlobalVars.SOUTH );
					}
					obj = Lang13.FindIn( typeof(Obj_Structure_TransitTube), tile );

					if ( Lang13.Bool( obj ) ) {
						tile_icon = new Icon( "icons/obj/atmospherics/pipes/transit_tube.dmi", obj.icon_state, Lang13.DoubleNullable( obj.dir ) );
					}
				} else {
					tile_icon = new Icon( tile.icon, tile.icon_state, Lang13.DoubleNullable( tile.dir ) );
					obj_icons.Cut();
					obj = Lang13.FindIn( typeof(Obj_Structure), tile );

					if ( Lang13.Bool( obj ) ) {
						obj_icons.Add( GlobalFuncs.getFlatIcon( obj ) );
					}
					obj = Lang13.FindIn( typeof(Obj_Machinery), tile );

					if ( Lang13.Bool( obj ) ) {
						obj_icons.Add( new Icon( obj.icon, obj.icon_state, Lang13.DoubleNullable( obj.dir ), 1, false ) );
					}
					obj = Lang13.FindIn( typeof(Obj_Structure_Window), tile );

					if ( Lang13.Bool( obj ) ) {
						obj_icons.Add( new Icon( "icons/obj/smooth_structures/window.dmi", "window", GlobalVars.SOUTH ) );
					}

					foreach (dynamic _a in Lang13.Enumerate( obj_icons )) {
						I = _a;
						
						obj_icon = I;
						tile_icon.Blend( obj_icon, 3 );
					}
				}

				if ( tile_icon != null ) {
					tile_icon.Scale( GlobalVars.TILE_SIZE, GlobalVars.TILE_SIZE );
					minimap.Blend( tile_icon, 3, Lang13.DoubleNullable( ( tile.x - 1 ) * 8 ), Lang13.DoubleNullable( ( tile.y - 1 ) * 8 ) );
					Lang13.Delete( tile_icon );
					tile_icon = null;
				}
				counter--;

				if ( counter <= 0 ) {
					counter = 128;
					flatten = new Icon();
					flatten.Insert( minimap, "", GlobalVars.SOUTH, 1, false );
					Lang13.Delete( minimap );
					minimap = null;
					minimap = flatten;
					Task13.Sleep( -1 );
				}
			}
			final = new Icon();
			final.Insert( minimap, "", GlobalVars.SOUTH, 1, false );
			File13.Copy( final, this.map_path( z ) );
			return;
		}

		// Function from file: minimap.dm
		public void send( Client client = null ) {
			dynamic z = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.z_levels )) {
				z = _a;
				
				GlobalFuncs.send_asset( client, "minimap_" + z + ".png" );
			}
			return;
		}

		// Function from file: minimap.dm
		public string map_path( dynamic z = null ) {
			return "data/minimaps/" + "Box Station" + "_" + z + ".png";
		}

		// Function from file: minimap.dm
		public string hash_path(  ) {
			return "data/minimaps/" + "Box Station" + ".md5";
		}

		// Function from file: minimap.dm
		public override double Initialize( int start_timeofday = 0, double? zlevel = null ) {
			Engine.NewLib.Logger.Warning("Skipping minimap generation.", "...");

			return 0;
			/*
			string hash = null;
			dynamic z = null;

			
			if ( Lang13.Bool( zlevel ) ) {
				return base.Initialize( start_timeofday, zlevel );
			}
			hash = Num13.Md5( File13.Read( "_maps/" + "map_files/TgStation" + "/" + "tgstation.2.1.3.dmm" ) );

			if ( hash == GlobalFuncs.trim( File13.Read( this.hash_path() ) ) ) {
				return base.Initialize( start_timeofday, zlevel );
			}

			foreach (dynamic _a in Lang13.Enumerate( this.z_levels )) {
				z = _a;

				this.generate( z );
				GlobalFuncs.register_asset( "minimap_" + z + ".png", File13.Cache( this.map_path( z ) ) );
			}
			File13.Delete( this.hash_path() );
			File13.Write( this.hash_path(), hash );
			base.Initialize( start_timeofday, zlevel );
			return 0;*/

		}

	}

}