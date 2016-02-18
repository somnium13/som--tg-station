// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Slaughter : Mob_Living_SimpleAnimal {

		public int boost = 0;
		public ByTable consumed_mobs = new ByTable();
		public string playstyle_string = "<B><font size=3 color='red'>You are a slaughter demon,</font> a terrible creature from another realm. You have a single desire: To kill.  You may use the \"Blood Crawl\" ability near blood pools to travel through them, appearing and dissaapearing from the station at will. Pulling a dead or unconscious mob while you enter a pool will pull them in with you, allowing you to feast and regain your health. You move quickly upon leaving a pool of blood, but the material world will soon sap your strength and leave you sluggish. </B>";

		protected override void __FieldInit() {
			base.__FieldInit();

			this.real_name = "slaughter demon";
			this.speak_emote = new ByTable(new object [] { "gurgles" });
			this.emote_hear = new ByTable(new object [] { "wails", "screeches" });
			this.response_help = "thinks better of touching";
			this.response_disarm = "flails at";
			this.response_harm = "punches";
			this.icon_living = "daemon";
			this.a_intent = "harm";
			this.stop_automated_movement = true;
			this.attack_sound = "sound/magic/demon_attack1.ogg";
			this.atmos_requirements = new ByTable().Set( "min_oxy", 0 ).Set( "max_oxy", 0 ).Set( "min_tox", 0 ).Set( "max_tox", 0 ).Set( "min_co2", 0 ).Set( "max_co2", 0 ).Set( "min_n2", 0 ).Set( "max_n2", 0 );
			this.minbodytemp = 0;
			this.maxbodytemp = Double.PositiveInfinity;
			this.faction = new ByTable(new object [] { "slaughter" });
			this.attacktext = "wildly tears into";
			this.maxHealth = 200;
			this.health = 200;
			this.healable = false;
			this.environment_smash = 1;
			this.melee_damage_lower = 30;
			this.melee_damage_upper = 30;
			this.bloodcrawl = 2;
			this.icon = "icons/mob/mob.dmi";
			this.icon_state = "daemon";
			this.see_in_dark = 8;
			this.see_invisible = 5;
		}

		// Function from file: slaughter.dm
		public Mob_Living_SimpleAnimal_Slaughter ( dynamic loc = null ) : base( (object)(loc) ) {
			Obj_Effect_ProcHolder_Spell_Bloodcrawl bloodspell = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			bloodspell = new Obj_Effect_ProcHolder_Spell_Bloodcrawl();
			this.AddSpell( bloodspell );

			if ( this.loc is Obj_Effect_Dummy_Slaughter ) {
				bloodspell.phased = true;
			}
			return;
		}

		// Function from file: slaughter.dm
		public override bool phasein( dynamic B = null ) {
			bool _default = false;

			_default = base.phasein( (object)(B) );
			this.speed = 0;
			this.boost = Game13.time + 60;
			return _default;
		}

		// Function from file: slaughter.dm
		public override bool death( bool? gibbed = null, bool? toast = null ) {
			Obj_Effect_Decal_Cleanable_Blood innards = null;
			Mob_Living M = null;

			base.death( true, toast );
			new Obj_Effect_Decal_Cleanable_Blood( GlobalFuncs.get_turf( this ) );
			innards = new Obj_Effect_Decal_Cleanable_Blood( GlobalFuncs.get_turf( this ) );
			innards.icon = "icons/obj/surgery.dmi";
			innards.icon_state = "innards";
			innards.name = "pile of viscera";
			innards.desc = "A repulsive pile of guts and gore.";
			new Obj_Item_Organ_Internal_Heart_Demon( this.loc );
			GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/magic/demon_dies.ogg", 200, 1 );
			this.visible_message( "<span class='danger'>" + this + " screams in anger as it collapses into a puddle of viscera, its most recent meals spilling out of it.</span>" );

			foreach (dynamic _a in Lang13.Enumerate( this.consumed_mobs, typeof(Mob_Living) )) {
				M = _a;
				
				M.loc = GlobalFuncs.get_turf( this );
			}
			this.ghostize();
			GlobalFuncs.qdel( this );
			return false;
		}

		// Function from file: slaughter.dm
		public override bool Life(  ) {
			base.Life();

			if ( this.boost < Game13.time ) {
				this.speed = 1;
			} else {
				this.speed = 0;
			}
			return false;
		}

	}

}