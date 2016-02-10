// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Teleport : Game_Data {

		public Ent_Dynamic teleatom = null;
		public Ent_Static destination = null;
		public int? precision = 0;
		public bool effectin = false;
		public bool effectout = false;
		public string soundin = null;
		public string soundout = null;
		public bool force_teleport = true;

		// Function from file: teleport.dm
		public Teleport ( dynamic ateleatom = null, dynamic adestination = null, bool? aprecision = null, bool? afteleport = null, dynamic aeffectin = null, dynamic aeffectout = null, dynamic asoundin = null, dynamic asoundout = null, params object[] _ ) {
			ByTable _args = new ByTable( new object[] { ateleatom, adestination, aprecision, afteleport, aeffectin, aeffectout, asoundin, asoundout } ).Extend(_);

			
			if ( _args[3] == null ) {
				_args[3] = 0;
			}

			if ( _args[4] == null ) {
				_args[4] = 1;
			}

			if ( _args[5] == null ) {
				_args[5] = null;
			}

			if ( _args[6] == null ) {
				_args[6] = null;
			}

			if ( _args[7] == null ) {
				_args[7] = null;
			}

			if ( _args[8] == null ) {
				_args[8] = null;
			}
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( !Lang13.Bool( _args.Apply( Lang13.BindFunc( this, "Init" ) ) ) ) {
				return; // Warning! Attempt to return some other value!
			}
			return; // Warning! Attempt to return some other value!
		}

		// Function from file: teleport.dm
		public bool teleport(  ) {
			
			if ( this.teleportChecks() ) {
				return this.doTeleport();
			}
			return false;
		}

		// Function from file: teleport.dm
		public bool doTeleport(  ) {
			dynamic destturf = null;
			dynamic curturf = null;
			dynamic destarea = null;
			ByTable posturfs = null;
			dynamic Xchange = null;
			dynamic Ychange = null;
			Ent_Dynamic P = null;

			curturf = GlobalFuncs.get_turf( this.teleatom );
			destarea = GlobalFuncs.get_area( this.destination );

			if ( Lang13.Bool( this.precision ) ) {
				posturfs = GlobalFuncs.circlerangeturfs( this.destination, this.precision );
				destturf = GlobalFuncs.safepick( posturfs );
			} else {
				destturf = GlobalFuncs.get_turf( this.destination );
			}

			if ( !Lang13.Bool( destturf ) || !Lang13.Bool( curturf ) ) {
				return false;
			}
			this.playSpecials( curturf, this.effectin, this.soundin );

			if ( this.teleatom is Obj_Item_Projectile ) {
				Xchange = destturf.x - curturf.x;
				Ychange = destturf.y - curturf.y;
				P = this.teleatom;
				((dynamic)P).override_starting_X += Xchange;
				((dynamic)P).override_starting_Y += Ychange;
				((dynamic)P).override_target_X += Xchange;
				((dynamic)P).override_target_Y += Ychange;
				((dynamic)P).reflected = 1;
			}

			if ( this.force_teleport ) {
				this.teleatom.forceMove( destturf, 1 );
				this.playSpecials( destturf, this.effectout, this.soundout );
			} else if ( this.teleatom.Move( destturf ) ) {
				this.playSpecials( destturf, this.effectout, this.soundout );
			}
			((Base_Static)destarea).Entered( this.teleatom );
			return true;
		}

		// Function from file: teleport.dm
		public void playSpecials( dynamic location = null, dynamic effect = null, string sound = null ) {
			
			if ( Lang13.Bool( location ) ) {
				
				if ( Lang13.Bool( effect ) ) {
					Task13.Schedule( -1, (Task13.Closure)(() => {
						Task13.Source = null;
						((Effect_Effect_System)effect).attach( location );
						effect.start();
						return;
					}));
				}

				if ( Lang13.Bool( sound ) ) {
					Task13.Schedule( -1, (Task13.Closure)(() => {
						Task13.Source = null;
						GlobalFuncs.playsound( location, sound, 60, 1 );
						return;
					}));
				}
			}
			return;
		}

		// Function from file: teleport.dm
		public virtual bool teleportChecks(  ) {
			return true;
		}

		// Function from file: teleport.dm
		public bool setSounds( dynamic asoundin = null, dynamic asoundout = null ) {
			this.soundin = ( asoundin is File ? asoundin : null );
			this.soundout = ( asoundout is File ? asoundout : null );
			return true;
		}

		// Function from file: teleport.dm
		public bool setForceTeleport( dynamic afteleport = null ) {
			this.force_teleport = Lang13.Bool( afteleport );
			return true;
		}

		// Function from file: teleport.dm
		public virtual bool setEffects( dynamic aeffectin = null, dynamic aeffectout = null ) {
			this.effectin = Lang13.Bool( ( aeffectin is Effect_Effect_System ? aeffectin : null ) );
			this.effectout = Lang13.Bool( ( aeffectout is Effect_Effect_System ? aeffectout : null ) );
			return true;
		}

		// Function from file: teleport.dm
		public bool setTeleatom( dynamic ateleatom = null ) {
			
			if ( ateleatom is Obj_Effect && !( ateleatom is Obj_Effect_Dummy_Chameleon ) ) {
				GlobalFuncs.qdel( ateleatom );
				return false;
			}

			if ( ateleatom is Ent_Dynamic ) {
				this.teleatom = ateleatom;
				return true;
			}
			return false;
		}

		// Function from file: teleport.dm
		public bool setDestination( dynamic adestination = null ) {
			
			if ( adestination is Ent_Static ) {
				this.destination = adestination;
				return true;
			}
			return false;
		}

		// Function from file: teleport.dm
		public virtual bool setPrecision( dynamic aprecision = null ) {
			
			if ( Lang13.Bool( Lang13.IsNumber( aprecision ) ) ) {
				this.precision = Lang13.IntNullable( aprecision );
				return true;
			}
			return false;
		}

		// Function from file: teleport.dm
		public bool Init( dynamic ateleatom = null, dynamic adestination = null, dynamic aprecision = null, dynamic afteleport = null, dynamic aeffectin = null, dynamic aeffectout = null, dynamic asoundin = null, dynamic asoundout = null ) {
			
			if ( !this.setTeleatom( ateleatom ) ) {
				return false;
			}

			if ( !this.setDestination( adestination ) ) {
				return false;
			}

			if ( !this.setPrecision( aprecision ) ) {
				return false;
			}
			this.setEffects( aeffectin, aeffectout );
			this.setForceTeleport( afteleport );
			this.setSounds( asoundin, asoundout );
			return true;
		}

	}

}