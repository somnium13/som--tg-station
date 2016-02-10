// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ArtifactEffect : Game_Data {

		public string effecttype = "unknown";
		public int effect = 0;
		public int effectrange = 4;
		public int trigger = 0;
		public Ent_Static holder = null;
		public bool activated = false;
		public int chargelevel = 0;
		public int chargelevelmax = 10;
		public string artifact_id = "";
		public int effect_type = 0;

		// Function from file: effect.dm
		public ArtifactEffect ( dynamic location = null ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.holder = location;
			this.effect = Rand13.Int( 0, 2 );
			this.trigger = Rand13.Int( 0, 12 );
			this.artifact_id = "" + Rand13.Pick(new object [] { "kappa", "sigma", "antaeres", "beta", "omicron", "iota", "epsilon", "omega", "gamma", "delta", "tau", "alpha" }) + "-" + Rand13.Int( 100, 999 );

			dynamic _a = Rand13.PickWeighted(new object [] { 37448, 1, 56172, 2, 65535, 3 }); // Was a switch-case, sorry for the mess.
			if ( _a==1 ) {
				this.chargelevelmax = Rand13.Int( 3, 20 );
				this.effectrange = Rand13.Int( 1, 3 );
			} else if ( _a==2 ) {
				this.chargelevelmax = Rand13.Int( 15, 40 );
				this.effectrange = Rand13.Int( 5, 15 );
			} else if ( _a==3 ) {
				this.chargelevelmax = Rand13.Int( 20, 120 );
				this.effectrange = Rand13.Int( 20, 200 );
			}
			return;
		}

		// Function from file: effect.dm
		public virtual void process(  ) {
			
			if ( this.chargelevel < this.chargelevelmax ) {
				this.chargelevel++;
			}

			if ( this.activated ) {
				
				if ( this.effect == 1 ) {
					this.DoEffectAura();
				} else if ( this.effect == 2 && this.chargelevel >= this.chargelevelmax ) {
					this.chargelevel = 0;
					this.DoEffectPulse();
				}
			}
			return;
		}

		// Function from file: effect.dm
		public virtual void UpdateMove(  ) {
			return;
		}

		// Function from file: effect.dm
		public virtual bool DoEffectPulse( dynamic holder = null ) {
			return false;
		}

		// Function from file: effect.dm
		public virtual bool DoEffectAura( dynamic holder = null ) {
			return false;
		}

		// Function from file: effect.dm
		public virtual bool DoEffectTouch( dynamic user = null ) {
			return false;
		}

		// Function from file: effect.dm
		public virtual bool ToggleActivate( bool? reveal_toggle = null ) {
			reveal_toggle = reveal_toggle ?? true;

			Ent_Static A = null;
			dynamic display_msg = null;
			Ent_Static toplevelholder = null;

			Task13.Schedule( 0, (Task13.Closure)(() => {
				
				if ( this.activated ) {
					this.activated = false;
				} else {
					this.activated = true;
				}

				if ( reveal_toggle == true && this.holder != null ) {
					
					if ( this.holder is Obj_Machinery_Artifact ) {
						A = this.holder;
						A.icon_state = "ano" + ((dynamic)A).icon_num + this.activated;
					}

					if ( this.activated ) {
						display_msg = Rand13.Pick(new object [] { "momentarily glows brightly!", "distorts slightly for a moment!", "flickers slightly!", "vibrates!", "shimmers slightly for a moment!" });
					} else {
						display_msg = Rand13.Pick(new object [] { "grows dull!", "fades in intensity!", "suddenly becomes very still!", "suddenly becomes very quiet!" });
					}
					toplevelholder = this.holder;

					while (!( toplevelholder.loc is Tile )) {
						toplevelholder = toplevelholder.loc;
					}
					toplevelholder.visible_message( new Txt( "<span class='warning'>" ).icon( toplevelholder ).str( " " ).item( toplevelholder ).str( " " ).item( display_msg ).str( "</span>" ).ToString() );
				}
				return;
			}));
			return false;
		}

	}

}