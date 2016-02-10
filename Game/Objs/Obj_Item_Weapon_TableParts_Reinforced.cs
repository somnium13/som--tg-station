// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_TableParts_Reinforced : Obj_Item_Weapon_TableParts {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.starting_materials = new ByTable().Set( "$iron", 7500 );
			this.icon_state = "reinf_tableparts";
		}

		public Obj_Item_Weapon_TableParts_Reinforced ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: table_rack_parts.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			new Obj_Structure_Table_Reinforced( user.loc );
			user.drop_item( this, null, 1 );
			GlobalFuncs.qdel( this );
			return null;
		}

		// Function from file: table_rack_parts.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			Game_Data M = null;

			
			if ( a is Obj_Item_Weapon_Wrench ) {
				M = GlobalFuncs.getFromPool( typeof(Obj_Item_Stack_Sheet_Metal), GlobalFuncs.get_turf( this ) );
				((dynamic)M).amount = 1;
				new Obj_Item_Stack_Rods( b.loc );
				GlobalFuncs.qdel( this );
			}
			return null;
		}

	}

}