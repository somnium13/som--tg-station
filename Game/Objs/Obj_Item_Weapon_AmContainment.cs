// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_AmContainment : Obj_Item_Weapon {

		public double fuel = 1000;
		public int fuel_max = 1000;
		public int stability = 100;
		public bool exploded = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.force = 8;
			this.throwforce = 10;
			this.throw_speed = 1;
			this.throw_range = 2;
			this.icon = "icons/obj/machines/antimatter.dmi";
			this.icon_state = "jar";
		}

		public Obj_Item_Weapon_AmContainment ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: containment_jar.dm
		public override bool ex_act( double? severity = null, dynamic child = null ) {
			
			switch ((double?)( severity )) {
				case 1:
					this.boom();
					break;
				case 2:
					
					if ( Rand13.PercentChance( ((int)( this.fuel / 10 - this.stability )) ) ) {
						this.boom();
					}
					this.stability -= 40;
					break;
				case 3:
					this.stability -= 20;
					break;
			}
			return false;
		}

		// Function from file: containment_jar.dm
		public dynamic usefuel( dynamic wanted = null ) {
			
			if ( this.fuel < Convert.ToDouble( wanted ) ) {
				wanted = this.fuel;
			}
			this.fuel -= Convert.ToDouble( wanted );
			return wanted;
		}

		// Function from file: containment_jar.dm
		public void boom(  ) {
			double percent = 0;

			percent = 0;

			if ( this.fuel != 0 ) {
				percent = this.fuel / this.fuel_max * 100;
			}

			if ( !this.exploded && percent >= 10 ) {
				GlobalFuncs.explosion( GlobalFuncs.get_turf( this ), 1, 2, 3, 5 );
				this.exploded = true;
			}

			if ( this != null ) {
				GlobalFuncs.qdel( this );
			}
			return;
		}

	}

}