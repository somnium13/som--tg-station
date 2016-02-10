// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_ReagentDispensers_WaterCooler : Obj_Structure_ReagentDispensers {

		public int addedliquid = 500;
		public int paper_cups = 10;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.amount_per_transfer_from_this = 5;
			this.possible_transfer_amounts = null;
			this.anchored = 1;
			this.icon = "icons/obj/vending.dmi";
			this.icon_state = "water_cooler";
		}

		// Function from file: reagent_dispenser.dm
		public Obj_Structure_ReagentDispensers_WaterCooler ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			((Reagents)this.reagents).add_reagent( "water", this.addedliquid );
			this.desc = "" + Lang13.Initial( this, "desc" ) + " There's " + this.paper_cups + " paper cups stored inside.";
			return;
		}

		// Function from file: reagent_dispenser.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic WT = null;

			
			if ( a is Obj_Item_Weapon_Weldingtool ) {
				WT = a;

				if ( Lang13.Bool( WT.remove_fuel( 0, b ) ) ) {
					new Obj_Item_Stack_Sheet_Mineral_Plastic( this.loc, 4 );
					GlobalFuncs.qdel( this );
					return null;
				}
			} else {
				base.attackby( (object)(a), (object)(b), (object)(c) );
			}
			return null;
		}

		// Function from file: reagent_dispenser.dm
		public override dynamic attack_paw( Mob a = null, dynamic b = null, dynamic c = null ) {
			return this.attack_hand( a );
		}

		// Function from file: reagent_dispenser.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( this.paper_cups > 0 ) {
				((Mob)a).put_in_hands( new Obj_Item_Weapon_ReagentContainers_Food_Drinks_Sillycup() );
				GlobalFuncs.to_chat( a, new Txt( "You pick up an empty paper cup from " ).the( this ).item().ToString() );
				this.paper_cups--;
				this.desc = "" + Lang13.Initial( this, "desc" ) + " There's " + this.paper_cups + " paper cups stored inside.";
			}
			return null;
		}

	}

}