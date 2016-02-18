// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class RobotEnergyStorage : Game_Data {

		public string name = "Generic energy storage";
		public int max_energy = 30000;
		public int recharge_rate = 1000;
		public double energy = 0;

		// Function from file: robot_modules.dm
		public RobotEnergyStorage ( Obj_Item_Weapon_RobotModule R = null ) {
			this.energy = this.max_energy;

			if ( R != null ) {
				R.storages.Or( this );
			}
			return;
		}

		// Function from file: robot_modules.dm
		public void add_charge( double amount = 0 ) {
			this.energy = Num13.MinInt( ((int)( this.energy + amount )), this.max_energy );
			return;
		}

		// Function from file: robot_modules.dm
		public int use_charge( double amount = 0 ) {
			
			if ( this.energy >= amount ) {
				this.energy -= amount;

				if ( this.energy == 0 ) {
					return 1;
				}
				return 2;
			} else {
				return 0;
			}
		}

	}

}