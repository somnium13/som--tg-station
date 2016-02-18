// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Action_Innate_Godspeak : Action_Innate {

		public Mob_Camera_God god = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Godspeak";
			this.button_icon_state = "godspeak";
			this.check_flags = 8;
		}

		public Action_Innate_Godspeak ( Obj_Item_Weapon_Tank Target = null ) : base( Target ) {
			
		}

		// Function from file: actions.dm
		public override void Activate( int? forced_state = null ) {
			dynamic msg = null;

			msg = Interface13.Input( this.owner, "Speak to your god", "Godspeak", "", null, InputType.Str | InputType.Null );

			if ( !Lang13.Bool( msg ) ) {
				return;
			}
			this.god.WriteMsg( "<span class='notice'><B>" + this.owner + ":</B> " + msg + "</span>" );
			this.owner.WriteMsg( "You say: " + msg );
			return;
		}

		// Function from file: actions.dm
		public override dynamic IsAvailable(  ) {
			
			if ( Lang13.Bool( base.IsAvailable() ) ) {
				
				if ( this.god != null ) {
					return 1;
				}
				return 0;
			}
			return null;
		}

	}

}