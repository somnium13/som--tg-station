// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Borg_Upgrade_Medical_Surgery : Obj_Item_Borg_Upgrade_Medical {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.require_module = true;
		}

		public Obj_Item_Borg_Upgrade_Medical_Surgery ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: robot_upgrades.dm
		public override bool action( Mob_Living_Silicon_Robot R = null ) {
			
			if ( base.action( R ) ) {
				return false;
			}

			if ( !( R.module is Obj_Item_Weapon_RobotModule_Medical ) ) {
				GlobalFuncs.to_chat( R, "Upgrade mounting error!  This module is reserved for medical modules!" );
				GlobalFuncs.to_chat( Task13.User, "There's no mounting point for the module!" );
				return false;
			} else {
				R.module.modules.Add( new Obj_Item_Weapon_Melee_Defibrillator( R.module ) );
				R.module.modules.Add( new Obj_Item_Weapon_ReagentContainers_Borghypo_Upgraded( R.module ) );
				return true;
			}
		}

	}

}