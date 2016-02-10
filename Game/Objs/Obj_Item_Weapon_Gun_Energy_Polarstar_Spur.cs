// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Gun_Energy_Polarstar_Spur : Obj_Item_Weapon_Gun_Energy_Polarstar {

		public int charge_tick = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.origin_tech = "materials=5;powerstorage=4;combat=5";
			this.fire_delay = 0;
			this.projectile_type = "/obj/item/projectile/spur";
			this.icon_state = "spur";
		}

		// Function from file: special.dm
		public Obj_Item_Weapon_Gun_Energy_Polarstar_Spur ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			GlobalVars.processing_objects.Add( this );
			return;
		}

		// Function from file: special.dm
		public override dynamic process(  ) {
			this.charge_tick++;

			if ( this.charge_tick < 2 ) {
				return 0;
			}
			this.charge_tick = 0;

			if ( !Lang13.Bool( this.power_supply ) ) {
				return 0;
			}
			((Obj_Item_Weapon_Cell)this.power_supply).give( 100 );
			this.levelChange();
			return 1;
		}

		// Function from file: special.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			GlobalVars.processing_objects.Remove( this );
			base.Destroy( (object)(brokenup) );
			return null;
		}

	}

}