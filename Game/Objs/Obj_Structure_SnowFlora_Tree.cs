// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_SnowFlora_Tree : Obj_Structure_SnowFlora {

		public int axe_hits = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.pixel_y = 21;
			this.anchored = 1;
			this.icon = "icons/obj/flora/deadtrees.dmi";
			this.icon_state = "tree_1";
			this.layer = 5;
		}

		// Function from file: snow.dm
		public Obj_Structure_SnowFlora_Tree ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.icon_state = Rand13.Pick(new object [] { "tree_1", "tree_2", "tree_3", "tree_4", "tree_5", "tree_6" });
			Task13.Schedule( 0, (Task13.Closure)(() => {
				this.idle();
				return;
			}));
			return;
		}

		// Function from file: snow.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			ByTable cutting = null;

			cutting = new ByTable(new object [] { typeof(Obj_Item_Weapon_Hatchet), typeof(Obj_Item_Weapon_Fireaxe) });

			if ( GlobalFuncs.is_type_in_list( a, cutting ) ) {
				this.axe_hits++;
				((Ent_Static)b).visible_message( new Txt( "<span class='warning'>" ).item( b ).str( " hits " ).the( this ).item().str( " with " ).the( a ).item().str( ".</span>" ).ToString() );

				if ( this.axe_hits >= 3 ) {
					new Obj_Item_Weapon_Grown_Log( GlobalFuncs.get_turf( this ) );
					GlobalFuncs.qdel( this );
				}
			}
			return null;
		}

		// Function from file: snow.dm
		public virtual void idle(  ) {
			return;
		}

	}

}