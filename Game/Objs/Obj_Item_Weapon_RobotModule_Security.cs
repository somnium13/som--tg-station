// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_RobotModule_Security : Obj_Item_Weapon_RobotModule {

		// Function from file: robot_modules.dm
		public Obj_Item_Weapon_RobotModule_Security ( dynamic R = null ) : base( (object)(R) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.modules.Add( new Obj_Item_Weapon_Melee_Baton_Loaded( this ) );
			this.modules.Add( new Obj_Item_Weapon_Gun_Energy_Taser_Cyborg( this ) );
			this.modules.Add( new Obj_Item_Weapon_Handcuffs_Cyborg( this ) );
			this.modules.Add( new Obj_Item_Weapon_ReagentContainers_Spray_Pepper( this ) );
			this.modules.Add( new Obj_Item_Taperoll_Police( this ) );
			this.modules.Add( new Obj_Item_Weapon_Crowbar( this ) );
			this.emag = new Obj_Item_Weapon_Gun_Energy_Laser_Cyborg( this );
			this.sensor_augs = new ByTable(new object [] { "Security", "Medical", "Disable" });
			return;
		}

		// Function from file: robot_modules.dm
		public override void respawn_consumable( Ent_Static R = null ) {
			Obj_Item M = null;
			Obj_Item B = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.modules, typeof(Obj_Item) )) {
				M = _a;
				

				if ( M is Obj_Item_Weapon_Melee_Baton ) {
					B = M;

					if ( B != null && Lang13.Bool( ((dynamic)B).bcell ) ) {
						((Obj_Item_Weapon_Cell)((dynamic)B).bcell).give( 175 );
					}
				}
			}
			return;
		}

	}

}