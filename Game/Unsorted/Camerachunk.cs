// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Camerachunk : Game_Data {

		public ByTable obscuredTurfs = new ByTable();
		public ByTable visibleTurfs = new ByTable();
		public ByTable obscured = new ByTable();
		public ByTable cameras = new ByTable();
		public ByTable turfs = new ByTable();
		public ByTable seenby = new ByTable();
		public int visible = 0;
		public bool changed = false;
		public bool updating = false;
		public int? x = 0;
		public int? y = 0;
		public int z = 0;

		// Function from file: chunk.dm
		public Camerachunk ( dynamic loc = null, int? x = null, int? y = null, int z = 0 ) {
			Obj_Machinery_Camera c = null;
			dynamic t = null;
			dynamic camera = null;
			dynamic c2 = null;
			dynamic t2 = null;
			dynamic turf = null;
			dynamic t3 = null;

			x &= 65520;
			y &= 65520;
			this.x = x;
			this.y = y;
			this.z = z;

			foreach (dynamic _a in Lang13.Enumerate( GlobalFuncs.ultra_range( GlobalVars.CHUNK_SIZE, Map13.GetTile( ( x ??0) + 8, ( y ??0) + 8, z ) ), typeof(Obj_Machinery_Camera) )) {
				c = _a;
				

				if ( c.can_use() ) {
					this.cameras.Add( c );
				}
			}

			foreach (dynamic _b in Lang13.Enumerate( Map13.FetchInBlock( Map13.GetTile( x ??0, y ??0, z ), Map13.GetTile( Num13.MinInt( ( x ??0) + 16 - 1, Game13.map_size_x ), Num13.MinInt( ( y ??0) + 16 - 1, Game13.map_size_y ), z ) ) )) {
				t = _b;
				
				this.turfs[t] = t;
			}

			foreach (dynamic _d in Lang13.Enumerate( this.cameras )) {
				camera = _d;
				
				c2 = camera;

				if ( !Lang13.Bool( c2 ) ) {
					continue;
				}

				if ( !((Obj_Machinery_Camera)c2).can_use() ) {
					continue;
				}

				foreach (dynamic _c in Lang13.Enumerate( ((Obj_Machinery_Camera)c2).can_see() )) {
					t2 = _c;
					
					this.visibleTurfs[t2] = t2;
				}
			}
			this.visibleTurfs.And( this.turfs );
			this.obscuredTurfs = this.turfs - this.visibleTurfs;

			foreach (dynamic _e in Lang13.Enumerate( this.obscuredTurfs )) {
				turf = _e;
				
				t3 = turf;

				if ( !Lang13.Bool( t3.obscured ) ) {
					t3.obscured = new Image( "icons/effects/cameravis.dmi", t3, "black", 16 );
				}
				this.obscured.Add( t3.obscured );
			}
			return;
		}

		// Function from file: chunk.dm
		public void update(  ) {
			ByTable newVisibleTurfs = null;
			dynamic camera = null;
			dynamic c = null;
			Tile point = null;
			dynamic t = null;
			ByTable visAdded = null;
			ByTable visRemoved = null;
			dynamic turf = null;
			dynamic t2 = null;
			dynamic eye = null;
			dynamic m = null;
			Client client = null;
			dynamic turf2 = null;
			dynamic t3 = null;
			dynamic eye2 = null;
			dynamic m2 = null;
			Client client2 = null;

			newVisibleTurfs = new ByTable();

			foreach (dynamic _b in Lang13.Enumerate( this.cameras )) {
				camera = _b;
				
				c = camera;

				if ( !Lang13.Bool( c ) ) {
					continue;
				}

				if ( !((Obj_Machinery_Camera)c).can_use() ) {
					continue;
				}
				point = Map13.GetTile( ( this.x ??0) + 8, ( this.y ??0) + 8, this.z );

				if ( Map13.GetDistance( point, c ) > 24 ) {
					continue;
				}

				foreach (dynamic _a in Lang13.Enumerate( ((Obj_Machinery_Camera)c).can_see() )) {
					t = _a;
					
					newVisibleTurfs[t] = t;
				}
			}
			newVisibleTurfs.And( this.turfs );
			visAdded = newVisibleTurfs - this.visibleTurfs;
			visRemoved = this.visibleTurfs - newVisibleTurfs;
			this.visibleTurfs = newVisibleTurfs;
			this.obscuredTurfs = this.turfs - newVisibleTurfs;

			foreach (dynamic _d in Lang13.Enumerate( visAdded )) {
				turf = _d;
				
				t2 = turf;

				if ( Lang13.Bool( t2.obscured ) ) {
					this.obscured.Remove( t2.obscured );

					foreach (dynamic _c in Lang13.Enumerate( this.seenby )) {
						eye = _c;
						
						m = eye;

						if ( !Lang13.Bool( m ) ) {
							continue;
						}
						client = ((Mob_Camera_AiEye)m).GetViewerClient();

						if ( client != null ) {
							client.images.Remove( t2.obscured );
						}
					}
				}
			}

			foreach (dynamic _f in Lang13.Enumerate( visRemoved )) {
				turf2 = _f;
				
				t3 = turf2;

				if ( Lang13.Bool( this.obscuredTurfs[t3] ) ) {
					
					if ( !Lang13.Bool( t3.obscured ) ) {
						t3.obscured = new Image( "icons/effects/cameravis.dmi", t3, "black", 16 );
					}
					this.obscured.Add( t3.obscured );

					foreach (dynamic _e in Lang13.Enumerate( this.seenby )) {
						eye2 = _e;
						
						m2 = eye2;

						if ( !Lang13.Bool( m2 ) ) {
							this.seenby.Remove( m2 );
							continue;
						}
						client2 = ((Mob_Camera_AiEye)m2).GetViewerClient();

						if ( client2 != null ) {
							client2.images.Add( t3.obscured );
						}
					}
				}
			}
			this.changed = false;
			return;
		}

		// Function from file: chunk.dm
		public void hasChanged( bool? update_now = null ) {
			update_now = update_now ?? false;

			
			if ( this.visible != 0 || update_now == true ) {
				
				if ( !this.updating ) {
					this.updating = true;
					Task13.Schedule( 25, (Task13.Closure)(() => {
						this.update();
						this.updating = false;
						return;
					}));
				}
			} else {
				this.changed = true;
			}
			return;
		}

		// Function from file: chunk.dm
		public void visibilityChanged( dynamic loc = null ) {
			
			if ( !Lang13.Bool( this.visibleTurfs[loc] ) ) {
				return;
			}
			this.hasChanged();
			return;
		}

		// Function from file: chunk.dm
		public void remove( Mob_Camera_AiEye eye = null ) {
			Client client = null;

			client = eye.GetViewerClient();

			if ( client != null ) {
				client.images.Remove( this.obscured );
			}
			eye.visibleCameraChunks.Remove( this );
			this.seenby.Remove( eye );

			if ( this.visible > 0 ) {
				this.visible--;
			}
			return;
		}

		// Function from file: chunk.dm
		public void add( Mob_Camera_AiEye eye = null ) {
			Client client = null;

			client = eye.GetViewerClient();

			if ( client != null ) {
				client.images.Add( this.obscured );
			}
			eye.visibleCameraChunks.Add( this );
			this.visible++;
			this.seenby.Add( eye );

			if ( this.changed && !this.updating ) {
				this.update();
			}
			return;
		}

	}

}