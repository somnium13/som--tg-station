// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_Silicon_Decoy : Mob_Living_Silicon {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.canmove = false;
			this.icon = "icons/mob/AI.dmi";
			this.icon_state = "ai";
		}

		// Function from file: decoy.dm
		public Mob_Living_Silicon_Decoy ( dynamic loc = null ) : base( (object)(loc) ) {
			this.icon = "icons/mob/AI.dmi";
			this.icon_state = "ai";
			this.anchored = 1;
			this.canmove = false;
			return;
		}

		// Function from file: life.dm
		public override void updatehealth(  ) {
			
			if ( ( this.status_flags & 4096 ) != 0 ) {
				this.health = this.maxHealth;
				this.stat = 0;
			} else {
				this.health = this.maxHealth - this.getOxyLoss() - this.getToxLoss() - this.getFireLoss() - this.getBruteLoss();
			}
			return;
		}

		// Function from file: life.dm
		public override bool Life(  ) {
			
			if ( this.timestopped ) {
				return false;
			}

			if ( this.stat == 2 ) {
				return false;
			} else if ( Convert.ToDouble( this.health ) <= Convert.ToDouble( GlobalVars.config.health_threshold_dead ) && this.stat != 2 ) {
				this.death();
				return false;
			}
			return false;
		}

		// Function from file: decoy.dm
		public override string say_quote( dynamic text = null ) {
			string ending = null;

			ending = String13.SubStr( text, Lang13.Length( text ), 0 );

			if ( ending == "?" ) {
				return "queries, " + text;
			} else if ( ending == "!" ) {
				return "declares, " + String13.SubStr( text, 1, Lang13.Length( text ) );
			}
			return "states, " + text;
		}

		// Function from file: death.dm
		public override dynamic death( bool? gibbed = null ) {
			Obj_Machinery_AiStatusDisplay O = null;

			
			if ( this.stat == 2 ) {
				return null;
			}
			this.stat = 2;
			this.icon_state = "ai-crash";
			Task13.Schedule( 10, (Task13.Closure)(() => {
				GlobalFuncs.explosion( this.loc, 3, 6, 12, 15 );
				return;
			}));

			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.machines, typeof(Obj_Machinery_AiStatusDisplay) )) {
				O = _a;
				
				O.mode = 2;
			}
			return base.death( gibbed );
		}

	}

}