// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SurgeryStep_Limb_Cut : SurgeryStep_Limb {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.allowed_tools = new ByTable().Set( typeof(Obj_Item_Weapon_Scalpel), 100 ).Set( typeof(Obj_Item_Weapon_Kitchen_Utensil_Knife_Large), 75 ).Set( typeof(Obj_Item_Weapon_Shard), 50 );
			this.min_duration = 80;
			this.max_duration = 100;
		}

		// Function from file: robolimbs.dm
		public override bool? fail_step( dynamic user = null, dynamic target = null, string target_zone = null, Obj_Item tool = null, dynamic surgery = null ) {
			Organ_External affected = null;

			affected = ((Mob_Living_Carbon_Human)target).get_organ( target_zone );

			if ( affected.parent != null ) {
				affected = affected.parent;
				((Ent_Static)user).visible_message( "<span class='warning'>" + user + "'s hand slips, cutting " + target + "'s " + affected.display_name + " open!</span>", "<span class='warning'>Your hand slips,  cutting " + target + "'s " + affected.display_name + " open!</span>" );
				affected.createwound( "cut", 10 );
			}
			return null;
		}

		// Function from file: robolimbs.dm
		public override bool end_step( dynamic user = null, dynamic target = null, string target_zone = null, Obj_Item tool = null, dynamic surgery = null ) {
			dynamic affected = null;

			affected = ((Mob_Living_Carbon_Human)target).get_organ( target_zone );
			((Ent_Static)user).visible_message( new Txt( "<span class='notice'>" ).item( user ).str( " cuts away flesh where " ).item( target ).str( "'s " ).item( affected.display_name ).str( " used to be with " ).the( tool ).item().str( ".</span>" ).ToString(), new Txt( "<span class='notice'>You cut away flesh where " ).item( target ).str( "'s " ).item( affected.display_name ).str( " used to be with " ).the( tool ).item().str( ".</span>" ).ToString() );
			affected.status |= 1;
			return false;
		}

		// Function from file: robolimbs.dm
		public override bool begin_step( dynamic user = null, dynamic target = null, string target_zone = null, Obj_Item tool = null, dynamic surgery = null ) {
			dynamic affected = null;

			affected = ((Mob_Living_Carbon_Human)target).get_organ( target_zone );
			((Ent_Static)user).visible_message( new Txt().item( user ).str( " starts cutting away flesh where " ).item( target ).str( "'s " ).item( affected.display_name ).str( " used to be with " ).the( tool ).item().str( "." ).ToString(), new Txt( "You start cutting away flesh where " ).item( target ).str( "'s " ).item( affected.display_name ).str( " used to be with " ).the( tool ).item().str( "." ).ToString() );
			base.begin_step( (object)(user), (object)(target), target_zone, tool, (object)(surgery) );
			return false;
		}

		// Function from file: robolimbs.dm
		public override bool tool_quality( Obj_Item tool = null ) {
			bool _default = false;

			_default = base.tool_quality( tool );

			if ( !Lang13.Bool( tool.is_sharp() ) ) {
				return false;
			}
			return _default;
		}

	}

}