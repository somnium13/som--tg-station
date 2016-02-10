// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Mushroom_Glowshroom : Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Mushroom {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.filling_color = "#DAFF91";
			this.potency = 30;
			this.plantname = "glowshroom";
			this.icon_state = "glowshroom";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Mushroom_Glowshroom ( dynamic newloc = null, dynamic newpotency = null ) : base( (object)(newloc), (object)(newpotency) ) {
			
		}

		// Function from file: grown.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			Obj_Effect_Glowshroom planted = null;

			
			if ( user.loc is Tile_Space ) {
				return null;
			}
			planted = new Obj_Effect_Glowshroom( user.loc );
			planted.delay = 50;
			planted.endurance = 100;
			planted.potency = this.potency;
			GlobalFuncs.qdel( this );
			GlobalFuncs.to_chat( user, "<span class='notice'>You plant the glowshroom.</span>" );
			return null;
		}

	}

}