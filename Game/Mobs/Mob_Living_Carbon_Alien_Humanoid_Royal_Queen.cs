// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_Carbon_Alien_Humanoid_Royal_Queen : Mob_Living_Carbon_Alien_Humanoid_Royal {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.caste = "q";
			this.maxHealth = 400;
			this.health = 400;
			this.icon_state = "alienq";
		}

		// Function from file: queen.dm
		public Mob_Living_Carbon_Alien_Humanoid_Royal_Queen ( dynamic loc = null ) : base( (object)(loc) ) {
			Mob_Living_Carbon_Alien_Humanoid_Royal_Queen Q = null;

			
			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.living_mob_list, typeof(Mob_Living_Carbon_Alien_Humanoid_Royal_Queen) )) {
				Q = _a;
				

				if ( Q == this ) {
					continue;
				}

				if ( Q.stat == 2 ) {
					continue;
				}

				if ( Q.client != null ) {
					this.name = "alien princess (" + Rand13.Int( 1, 999 ) + ")";
					break;
				}
			}
			this.real_name = this.name;
			this.internal_organs.Add( new Obj_Item_Organ_Internal_Alien_Plasmavessel_Large_Queen() );
			this.internal_organs.Add( new Obj_Item_Organ_Internal_Alien_Resinspinner() );
			this.internal_organs.Add( new Obj_Item_Organ_Internal_Alien_Acid() );
			this.internal_organs.Add( new Obj_Item_Organ_Internal_Alien_Neurotoxin() );
			this.internal_organs.Add( new Obj_Item_Organ_Internal_Alien_Eggsac() );
			this.AddSpell( new Obj_Effect_ProcHolder_Spell_AoeTurf_Repulse_Xeno( this ) );
			this.AddAbility( new Obj_Effect_ProcHolder_Alien_Royal_Queen_Promote() );
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

		// Function from file: queen.dm
		public override dynamic movement_delay(  ) {
			dynamic _default = null;

			_default = base.movement_delay();
			_default += 5;
			return _default;
		}

		// Function from file: say.dm
		public override void alien_talk( dynamic message = null, string shown_name = null ) {
			shown_name = shown_name ?? this.name;

			shown_name = "<FONT size = 3>" + shown_name + "</FONT>";
			base.alien_talk( (object)(message), shown_name );
			return;
		}

		// Function from file: mind.dm
		public override void mind_initialize(  ) {
			base.mind_initialize();
			this.mind.special_role = "Queen";
			return;
		}

	}

}