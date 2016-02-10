// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Construction_Reversible_Mecha : Construction_Reversible {

		public string base_icon = "ripley";
		public Type mainboard = typeof(Obj_Item_Weapon_Circuitboard_Mecha_Ripley_Main);
		public Type peripherals = typeof(Obj_Item_Weapon_Circuitboard_Mecha_Ripley_Peripherals);

		protected override void __FieldInit() {
			base.__FieldInit();

			this.steps = new ByTable(new object [] { 
				new ByTable()
					.Set( "desc", "External armor is wrenched." )
					.Set( "nextstep", new ByTable().Set( "key", typeof(Obj_Item_Weapon_Weldingtool) ).Set( "amount", 3 ).Set( "vis_msg", "{USER} weld{s} external armor layer to {HOLDER}." ) )
					.Set( "backstep", new ByTable().Set( "key", typeof(Obj_Item_Weapon_Wrench) ).Set( "vis_msg", "{USER} unfasten{s} the external armor layer." ) )
				, 
				new ByTable()
					.Set( "desc", "External armor is installed." )
					.Set( "nextstep", new ByTable().Set( "key", typeof(Obj_Item_Weapon_Wrench) ).Set( "vis_msg", "{USER} secure{s} external armor layer." ) )
					.Set( "backstep", new ByTable()
						.Set( "key", typeof(Obj_Item_Weapon_Crowbar) )
						.Set( "vis_msg", "{USER} prie{s} external armor layer from {HOLDER}." )
						.Set( "start_msg", "{USER} begin{s} removing the external reinforced armor..." )
						.Set( "delay", 30 )
					 )
				, 
				new ByTable()
					.Set( "desc", "Internal armor is welded." )
					.Set( "nextstep", new ByTable()
						.Set( "key", typeof(Obj_Item_Stack_Sheet_Plasteel) )
						.Set( "amount", 5 )
						.Set( "vis_msg", "{USER} install{s} external reinforced armor layer to {HOLDER}." )
						.Set( "start_msg", "{USER} begin{s} installing the external reinforced armor..." )
						.Set( "delay", 30 )
					 )
					.Set( "backstep", new ByTable().Set( "key", typeof(Obj_Item_Weapon_Weldingtool) ).Set( "amount", 3 ).Set( "vis_msg", "{USER} cut{s} internal armor layer from {HOLDER}." ) )
				, 
				new ByTable()
					.Set( "desc", "Internal armor is wrenched" )
					.Set( "nextstep", new ByTable().Set( "key", typeof(Obj_Item_Weapon_Weldingtool) ).Set( "amount", 3 ).Set( "vis_msg", "{USER} weld{s} internal armor layer to {HOLDER}." ) )
					.Set( "backstep", new ByTable().Set( "key", typeof(Obj_Item_Weapon_Wrench) ).Set( "vis_msg", "{USER} unfastens the internal armor layer." ) )
				, 
				new ByTable()
					.Set( "desc", "Internal armor is installed" )
					.Set( "nextstep", new ByTable().Set( "key", typeof(Obj_Item_Weapon_Wrench) ).Set( "vis_msg", "{USER} secure{s} internal armor layer." ) )
					.Set( "backstep", new ByTable().Set( "key", typeof(Obj_Item_Weapon_Crowbar) ).Set( "vis_msg", "{USER} prie{s} internal armor layer from {HOLDER}." ) )
				, 
				new ByTable()
					.Set( "desc", "Peripherals control module is secured" )
					.Set( "nextstep", new ByTable().Set( "key", typeof(Obj_Item_Stack_Sheet_Metal) ).Set( "amount", 5 ).Set( "vis_msg", "{USER} install{s} internal armor layer to {HOLDER}." ) )
					.Set( "backstep", new ByTable().Set( "key", typeof(Obj_Item_Weapon_Screwdriver) ).Set( "vis_msg", "{USER} unfasten{s} the peripherals control module." ) )
				, 
				new ByTable()
					.Set( "desc", "Peripherals control module is installed" )
					.Set( "nextstep", new ByTable().Set( "key", typeof(Obj_Item_Weapon_Screwdriver) ).Set( "vis_msg", "{USER} secure{s} the peripherals control module." ) )
					.Set( "backstep", new ByTable().Set( "key", typeof(Obj_Item_Weapon_Crowbar) ).Set( "vis_msg", "{USER} remove{s} the peripherals control module from {HOLDER}." ) )
				, 
				new ByTable()
					.Set( "desc", "Central control module is secured" )
					.Set( "nextstep", new ByTable().Set( "key", null ).Set( "amount", 1 ).Set( "vis_msg", "{USER} install{s} the peripherals control module into {HOLDER}." ) )
					.Set( "backstep", new ByTable().Set( "key", typeof(Obj_Item_Weapon_Screwdriver) ).Set( "vis_msg", "{USER} unfasten{s} the mainboard." ) )
				, 
				new ByTable()
					.Set( "desc", "Central control module is installed" )
					.Set( "nextstep", new ByTable().Set( "key", typeof(Obj_Item_Weapon_Screwdriver) ).Set( "vis_msg", "{USER} secure{s} the mainboard." ) )
					.Set( "backstep", new ByTable().Set( "key", typeof(Obj_Item_Weapon_Crowbar) ).Set( "vis_msg", "{USER} remove{s} the central control module from {HOLDER}." ) )
				, 
				new ByTable()
					.Set( "desc", "The wiring is adjusted" )
					.Set( "nextstep", new ByTable().Set( "key", null ).Set( "amount", 1 ).Set( "vis_msg", "{USER} install{s} the central control module into {HOLDER}." ) )
					.Set( "backstep", new ByTable().Set( "key", typeof(Obj_Item_Weapon_Screwdriver) ).Set( "vis_msg", "{USER} disconnect{s} the wiring of {HOLDER}." ) )
				, 
				new ByTable()
					.Set( "desc", "The wiring is added" )
					.Set( "nextstep", new ByTable().Set( "key", typeof(Obj_Item_Weapon_Wirecutters) ).Set( "vis_msg", "{USER} adjust{s} the wiring of {HOLDER}." ) )
					.Set( "backstep", new ByTable().Set( "key", typeof(Obj_Item_Weapon_Screwdriver) ).Set( "vis_msg", "{USER} remove{s} the wiring of {HOLDER}." ) )
				, 
				new ByTable()
					.Set( "desc", "The hydraulic systems are active." )
					.Set( "nextstep", new ByTable().Set( "key", typeof(Obj_Item_Stack_CableCoil) ).Set( "amount", 10 ).Set( "vis_msg", "{USER} add{s} the wiring to {HOLDER}." ) )
					.Set( "backstep", new ByTable().Set( "key", typeof(Obj_Item_Weapon_Screwdriver) ).Set( "vis_msg", "{USER} deactivate{s} {HOLDER} hydraulic systems." ) )
				, 
				new ByTable()
					.Set( "desc", "The hydraulic systems are connected." )
					.Set( "nextstep", new ByTable().Set( "key", typeof(Obj_Item_Weapon_Screwdriver) ).Set( "vis_msg", "{USER} activate{s} {HOLDER} hydraulic systems." ) )
					.Set( "backstep", new ByTable().Set( "key", typeof(Obj_Item_Weapon_Wrench) ).Set( "vis_msg", "{USER} disconnect{s} {HOLDER} hydraulic systems." ) )
				, 
				new ByTable()
					.Set( "desc", "The hydraulic systems are disconnected." )
					.Set( "nextstep", new ByTable().Set( "key", typeof(Obj_Item_Weapon_Wrench) ).Set( "vis_msg", "{USER} connect{s} {HOLDER} hydraulic systems." ) )
				
			 });
		}

		// Function from file: mecha_construction_paths.dm
		public Construction_Reversible_Mecha ( Ent_Static atom = null ) : base( atom ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( this != null ) {
				this.add_board_keys();
			}
			return;
		}

		// Function from file: mecha_construction_paths.dm
		public override void spawn_result( dynamic user = null ) {
			base.spawn_result( (object)(user) );
			GlobalFuncs.feedback_inc( "mecha_" + this.base_icon + "_created", 1 );
			return;
		}

		// Function from file: mecha_construction_paths.dm
		public virtual void add_board_keys(  ) {
			dynamic board_step = null;

			board_step = this.get_forward_step( this.steps.len - 4 );
			board_step["key"] = this.mainboard;
			board_step = this.get_forward_step( this.steps.len - 6 );
			board_step["key"] = this.peripherals;
			return;
		}

		// Function from file: mecha_construction_paths.dm
		public override bool action( dynamic used_atom = null, dynamic user = null ) {
			return this.check_step( used_atom, user );
		}

		// Function from file: mecha_construction_paths.dm
		public override bool custom_action( dynamic index = null, dynamic diff = null, dynamic used_atom = null, dynamic user = null ) {
			
			if ( !base.custom_action( (object)(index), (object)(diff), (object)(used_atom), (object)(user) ) ) {
				return false;
			}
			this.holder.icon_state = "" + this.base_icon + ( this.steps.len - Convert.ToDouble( index ) - Convert.ToDouble( diff ) );
			return true;
		}

	}

}