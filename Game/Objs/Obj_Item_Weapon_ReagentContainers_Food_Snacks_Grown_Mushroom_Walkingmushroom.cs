// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Mushroom_Walkingmushroom : Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Mushroom {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.filling_color = "#FFBFEF";
			this.potency = 30;
			this.plantname = "walkingmushroom";
			this.icon_state = "walkingmushroom";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Mushroom_Walkingmushroom ( dynamic newloc = null, dynamic newpotency = null ) : base( (object)(newloc), (object)(newpotency) ) {
			
		}

		// Function from file: grown.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			
			if ( user.loc is Tile_Space ) {
				return null;
			}
			new Mob_Living_SimpleAnimal_Hostile_Mushroom( user.loc );
			GlobalFuncs.qdel( this );
			GlobalFuncs.to_chat( user, "<span class='notice'>You plant the walking mushroom.</span>" );
			return null;
		}

	}

}