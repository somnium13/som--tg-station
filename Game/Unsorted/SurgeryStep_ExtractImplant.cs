// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SurgeryStep_ExtractImplant : SurgeryStep {

		public dynamic I = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "extract implant";
			this.implements = new ByTable().Set( typeof(Obj_Item_Weapon_Hemostat), 100 ).Set( typeof(Obj_Item_Weapon_Crowbar), 65 );
			this.time = 64;
		}

		// Function from file: implant_removal.dm
		public override bool success( dynamic user = null, Mob target = null, string target_zone = null, dynamic tool = null, Surgery surgery = null ) {
			dynamic _case = null;

			
			if ( Lang13.Bool( this.I ) ) {
				((Ent_Static)user).visible_message( "" + user + " successfully removes " + this.I + " from " + target + "'s " + target_zone + "!", "<span class='notice'>You successfully remove " + this.I + " from " + target + "'s " + target_zone + ".</span>" );
				((Obj_Item_Weapon_Implant)this.I).removed( target );

				if ( ((Mob)user).get_item_by_slot( 4 ) is Obj_Item_Weapon_Implantcase ) {
					_case = ((Mob)user).get_item_by_slot( 4 );
				} else if ( ((Mob)user).get_item_by_slot( 5 ) is Obj_Item_Weapon_Implantcase ) {
					_case = ((Mob)user).get_item_by_slot( 5 );
				} else {
					_case = Lang13.FindIn( typeof(Obj_Item_Weapon_Implantcase), GlobalFuncs.get_turf( target ) );
				}

				if ( Lang13.Bool( _case ) && !Lang13.Bool( _case.imp ) ) {
					_case.imp = this.I;
					this.I.loc = _case;
					_case.update_icon();
					((Ent_Static)user).visible_message( "" + user + " places " + this.I + " into " + _case + "!", "<span class='notice'>You place " + this.I + " into " + _case + ".</span>" );
				} else {
					GlobalFuncs.qdel( this.I );
				}
			} else {
				user.WriteMsg( "<span class='warning'>You can't find anything in " + target + "'s " + target_zone + "!</span>" );
			}
			return true;
		}

		// Function from file: implant_removal.dm
		public override int preop( dynamic user = null, Mob target = null, string target_zone = null, dynamic tool = null, Surgery surgery = null ) {
			this.I = Lang13.FindIn( typeof(Obj_Item_Weapon_Implant), target );

			if ( Lang13.Bool( this.I ) ) {
				((Ent_Static)user).visible_message( "" + user + " begins to extract " + this.I + " from " + target + "'s " + target_zone + ".", "<span class='notice'>You begin to extract " + this.I + " from " + target + "'s " + target_zone + "...</span>" );
			} else {
				((Ent_Static)user).visible_message( "" + user + " looks for an implant in " + target + "'s " + target_zone + ".", "<span class='notice'>You look for an implant in " + target + "'s " + target_zone + "...</span>" );
			}
			return 0;
		}

	}

}