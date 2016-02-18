// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Action_Innate_SwapBody : Action_Innate {

		public dynamic body = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Swap Body";
			this.check_flags = 8;
			this.button_icon_state = "slimeswap";
			this.background_icon_state = "bg_alien";
		}

		public Action_Innate_SwapBody ( Obj_Item_Weapon_Tank Target = null ) : base( Target ) {
			
		}

		// Function from file: species_types.dm
		public override void Activate( int? forced_state = null ) {
			
			if ( !Lang13.Bool( this.body ) || !( this.body is Mob_Living_Carbon_Human ) || !Lang13.Bool( this.body.dna ) || !Lang13.Bool( this.body.dna.species ) || this.body.dna.species.id != "slime" || Convert.ToInt32( this.body.stat ) == 2 || Lang13.Bool( GlobalFuncs.qdeleted( this.body ) ) ) {
				this.owner.WriteMsg( "<span class='warning'>Something is wrong, you cannot sense your other body!</span>" );
				this.Remove( this.owner );
				return;
			}

			if ( Lang13.Bool( this.body.stat ) == true ) {
				this.owner.WriteMsg( "<span class='warning'>You sense this body has passed out for some reason. Best to stay away.</span>" );
				return;
			}
			((Mind)this.owner.mind).transfer_to( this.body );
			return;
		}

		// Function from file: species_types.dm
		public override bool CheckRemoval( dynamic user = null ) {
			dynamic H = null;

			H = this.owner;

			if ( !( H is Mob_Living_Carbon_Human ) || !Lang13.Bool( H.dna ) || !Lang13.Bool( H.dna.species ) || H.dna.species.id != "slime" ) {
				return true;
			}
			return false;
		}

	}

}