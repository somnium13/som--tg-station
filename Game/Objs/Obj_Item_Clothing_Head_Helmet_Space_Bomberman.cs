// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Head_Helmet_Space_Bomberman : Obj_Item_Clothing_Head_Helmet_Space {

		public bool never_removed = true;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "bomberman";
			this.armor = new ByTable().Set( "melee", 0 ).Set( "bullet", 0 ).Set( "laser", 0 ).Set( "energy", 0 ).Set( "bomb", 100 ).Set( "bio", 0 ).Set( "rad", 0 );
			this.species_restricted = new ByTable(new object [] { "exclude" });
			this.icon_state = "bomberman";
		}

		// Function from file: bomberman.dm
		public Obj_Item_Clothing_Head_Helmet_Space_Bomberman ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			GlobalVars.bombermangear.Add( this );
			return;
		}

		// Function from file: bomberman.dm
		public override dynamic dropped( dynamic user = null ) {
			base.dropped( (object)(user) );
			this.never_removed = false;
			return null;
		}

		// Function from file: bomberman.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			base.Destroy( (object)(brokenup) );
			GlobalVars.bombermangear.Remove( this );
			return null;
		}

	}

}