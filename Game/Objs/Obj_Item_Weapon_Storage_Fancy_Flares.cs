// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Storage_Fancy_Flares : Obj_Item_Weapon_Storage_Fancy {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_type = "flare";
			this.storage_slots = 6;
			this.can_hold = new ByTable(new object [] { "/obj/item/device/flashlight/flare" });
			this.foldable = typeof(Obj_Item_Stack_Sheet_Cardboard);
			this.starting_materials = new ByTable().Set( "$cardboard", 3750 );
			this.w_type = 1;
			this.icon = "icons/obj/lighting.dmi";
			this.icon_state = "flarebox6";
		}

		// Function from file: fancy.dm
		public Obj_Item_Weapon_Storage_Fancy_Flares ( dynamic loc = null ) : base( (object)(loc) ) {
			int? i = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( this.empty ) {
				this.update_icon();
				return;
			}
			i = null;
			i = 1;

			while (( i ??0) <= ( this.storage_slots ??0)) {
				new Obj_Item_Device_Flashlight_Flare( this );
				i++;
			}
			return;
		}

		// Function from file: fancy.dm
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			base.update_icon( (object)(location), (object)(target) );
			return null;
		}

		// Function from file: fancy.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic _default = null;

			
			if ( !( a is Obj_Item_Device_Flashlight_Flare ) ) {
				return _default;
			}

			if ( Lang13.Bool( a.on ) ) {
				GlobalFuncs.to_chat( b, "You can't put a lit flare in the box!" );
				return _default;
			}

			if ( !Lang13.Bool( a.fuel ) ) {
				GlobalFuncs.to_chat( b, "This flare is empty!" );
				return _default;
			}
			_default = base.attackby( (object)(a), (object)(b), (object)(c) );
			return _default;
		}

	}

}