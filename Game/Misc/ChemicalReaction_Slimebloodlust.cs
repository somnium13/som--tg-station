// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Slimebloodlust : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Bloodlust";
			this.id = "m_bloodlust";
			this.required_reagents = new ByTable().Set( "blood", 5 );
			this.result_amount = 1;
			this.required_container = typeof(Obj_Item_SlimeExtract_Red);
			this.required_other = true;
		}

		// Function from file: Chemistry-Recipes.dm
		public override void on_reaction( Reagents holder = null, int? created_volume = null ) {
			Mob_Living_Carbon_Slime slime = null;
			Mob_Living_SimpleAnimal_Slime slime2 = null;
			Mob_Living_SimpleAnimal_Adultslime slime3 = null;

			GlobalFuncs.feedback_add_details( "slime_cores_used", "" + GlobalFuncs.replacetext( this.name, " ", "_" ) );

			if ( !( holder.my_atom.loc is Obj_Item_Weapon_Grenade_ChemGrenade ) ) {
				this.send_admin_alert( holder, "red slime + blood (Slime Frenzy)" );
			} else {
				this.send_admin_alert( holder, "red slime + blood (Slime Frenzy) in a grenade" );
			}

			foreach (dynamic _a in Lang13.Enumerate( Map13.FetchViewers( null, GlobalFuncs.get_turf( holder.my_atom ) ), typeof(Mob_Living_Carbon_Slime) )) {
				slime = _a;
				
				slime.rabid();
				holder.my_atom.visible_message( "<span class='warning'>The " + slime + " is driven into a frenzy !</span>" );
			}

			foreach (dynamic _b in Lang13.Enumerate( Map13.FetchViewers( null, GlobalFuncs.get_turf( holder.my_atom ) ), typeof(Mob_Living_SimpleAnimal_Slime) )) {
				slime2 = _b;
				
				slime2.rabid();
				holder.my_atom.visible_message( "<span class='warning'>The " + slime2 + " is driven into a frenzy !</span>" );
			}

			foreach (dynamic _c in Lang13.Enumerate( Map13.FetchViewers( null, GlobalFuncs.get_turf( holder.my_atom ) ), typeof(Mob_Living_SimpleAnimal_Adultslime) )) {
				slime3 = _c;
				
				slime3.rabid();
				holder.my_atom.visible_message( "<span class='warning'>The " + slime3 + " is driven into a frenzy !</span>" );
			}
			return;
		}

	}

}