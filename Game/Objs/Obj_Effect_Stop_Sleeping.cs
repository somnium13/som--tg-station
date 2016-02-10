// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Stop_Sleeping : Obj_Effect_Stop {

		public int sleeptime = 0;
		public dynamic owner = null;
		public Spell_AoeTurf_Fall ourspell = null;
		public bool theworld = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.invisibility = 100;
			this.ignoreinvert = 1;
		}

		// Function from file: obj.dm
		public Obj_Effect_Stop_Sleeping ( dynamic loc = null, dynamic ourtime = null, dynamic mind = null, dynamic F = null, dynamic theworld = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.sleeptime = Convert.ToInt32( ourtime );
			this.owner = mind;
			this.ourspell = F;
			this.theworld = Lang13.Bool( theworld );
			return;
		}

		// Function from file: obj.dm
		public override dynamic Crossed( Ent_Dynamic O = null, dynamic X = null ) {
			Ent_Dynamic L = null;

			
			if ( this.sleeptime > Game13.time ) {
				
				if ( O is Mob ) {
					L = O;

					if ( ((dynamic)L).mind != this.owner ) {
						
						if ( !Lang13.Bool( ((dynamic)L).stat ) ) {
							((dynamic)L).playsound_local( this, ( this.theworld ? "sound/effects/theworld2.ogg" : "sound/effects/fall2.ogg" ), 100, 0, 0, 0, 0 );
						}
						Interface13.Stat( null, this.ourspell.affected.Contains( L ) );

						if ( !( !Lang13.Bool( ((dynamic)L).stat ) ) ) {
							GlobalFuncs.invertcolor( L );
							this.ourspell.affected.Add( L );
							this.ourspell.recursive_timestop( L );
						}
					}
				} else {
					Interface13.Stat( null, this.ourspell.affected.Contains( O ) );

					if ( !( O is Mob ) ) {
						GlobalFuncs.invertcolor( O );
						this.ourspell.affected.Add( O );
						this.ourspell.recursive_timestop( O );
					}
				}
			}
			return null;
		}

	}

}