// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SurgeryStep_Drill : SurgeryStep {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "drill bone";
			this.implements = new ByTable()
				.Set( typeof(Obj_Item_Weapon_Surgicaldrill), 100 )
				.Set( typeof(Obj_Item_Weapon_Pickaxe_Drill), 60 )
				.Set( typeof(Obj_Item_MechaParts_MechaEquipment_Drill), 60 )
				.Set( typeof(Obj_Item_Weapon_Screwdriver), 20 )
			;
			this.time = 30;
		}

		// Function from file: generic_steps.dm
		public override bool success( dynamic user = null, Mob target = null, string target_zone = null, dynamic tool = null, Surgery surgery = null ) {
			((Ent_Static)user).visible_message( "" + user + " drills into " + target + "'s " + GlobalFuncs.parse_zone( target_zone ) + "!", "<span class='notice'>You drill into " + target + "'s " + GlobalFuncs.parse_zone( target_zone ) + ".</span>" );
			return true;
		}

		// Function from file: generic_steps.dm
		public override int preop( dynamic user = null, Mob target = null, string target_zone = null, dynamic tool = null, Surgery surgery = null ) {
			((Ent_Static)user).visible_message( "" + user + " begins to drill into the bone in " + target + "'s " + GlobalFuncs.parse_zone( target_zone ) + ".", "<span class='notice'>You begin to drill into the bone in " + target + "'s " + GlobalFuncs.parse_zone( target_zone ) + "...</span>" );
			return 0;
		}

	}

}