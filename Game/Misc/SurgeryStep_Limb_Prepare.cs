// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SurgeryStep_Limb_Prepare : SurgeryStep_Limb {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.allowed_tools = new ByTable()
				.Set( typeof(Obj_Item_Weapon_Cautery), 100 )
				.Set( typeof(Obj_Item_Weapon_Scalpel_Laser), 100 )
				.Set( typeof(Obj_Item_Clothing_Mask_Cigarette), 75 )
				.Set( typeof(Obj_Item_Weapon_Lighter), 50 )
				.Set( typeof(Obj_Item_Weapon_Weldingtool), 25 )
			;
			this.min_duration = 60;
			this.max_duration = 70;
		}

		// Function from file: robolimbs.dm
		public override bool? fail_step( dynamic user = null, dynamic target = null, string target_zone = null, Obj_Item tool = null, dynamic surgery = null ) {
			string affected = null;

			affected = ((Mob_Living_Carbon_Human)target).get_organ( target_zone );

			if ( Lang13.Bool( ((dynamic)affected).parent ) ) {
				affected = ((dynamic)affected).parent;
				((Ent_Static)user).visible_message( "<span class='warning'>" + user + "'s hand slips, searing " + target + "'s " + ((dynamic)affected).display_name + "!</span>", "<span class='warning'>Your hand slips, searing " + target + "'s " + ((dynamic)affected).display_name + "!</span>" );
				((Mob_Living)target).apply_damage( 10, "fire", affected );
			}
			return null;
		}

		// Function from file: robolimbs.dm
		public override bool end_step( dynamic user = null, dynamic target = null, string target_zone = null, Obj_Item tool = null, dynamic surgery = null ) {
			dynamic affected = null;

			affected = ((Mob_Living_Carbon_Human)target).get_organ( target_zone );
			((Ent_Static)user).visible_message( new Txt( "<span class='notice'>" ).item( user ).str( " has finished adjusting the area around " ).item( target ).str( "'s " ).item( affected.display_name ).str( " with " ).the( tool ).item().str( ".</span>" ).ToString(), new Txt( "<span class='notice'>You have finished adjusting the area around " ).item( target ).str( "'s " ).item( affected.display_name ).str( " with " ).the( tool ).item().str( ".</span>" ).ToString() );
			affected.status |= 4;
			affected.amputated = true;
			((Organ_External)affected).setAmputatedTree();
			affected.open = 0;
			return false;
		}

		// Function from file: robolimbs.dm
		public override bool begin_step( dynamic user = null, dynamic target = null, string target_zone = null, Obj_Item tool = null, dynamic surgery = null ) {
			dynamic affected = null;

			affected = ((Mob_Living_Carbon_Human)target).get_organ( target_zone );
			((Ent_Static)user).visible_message( new Txt().item( user ).str( " starts adjusting area around " ).item( target ).str( "'s " ).item( affected.display_name ).str( " with " ).the( tool ).item().str( "." ).ToString(), new Txt( "You start adjusting area around " ).item( target ).str( "'s " ).item( affected.display_name ).str( " with " ).the( tool ).item().str( ".." ).ToString() );
			base.begin_step( (object)(user), (object)(target), target_zone, tool, (object)(surgery) );
			return false;
		}

		// Function from file: robolimbs.dm
		public override int can_use( dynamic user = null, dynamic target = null, string target_zone = null, Obj_Item tool = null ) {
			dynamic affected = null;

			affected = ((Mob_Living_Carbon_Human)target).get_organ( target_zone );
			return base.can_use( (object)(user), (object)(target), target_zone, tool ) != 0 && Convert.ToInt32( affected.open ) == 3 ?1:0;
		}

		// Function from file: robolimbs.dm
		public override bool tool_quality( Obj_Item tool = null ) {
			dynamic T = null;

			
			if ( Lang13.Bool( tool.is_hot() ) ) {
				
				foreach (dynamic _a in Lang13.Enumerate( this.allowed_tools )) {
					T = _a;
					

					if ( Lang13.Bool( T.IsInstanceOfType( tool ) ) ) {
						return Lang13.Bool( this.allowed_tools[T] );
					}
				}
			}
			return false;
		}

	}

}