// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Hud_Monkey : Hud {

		// Function from file: monkey.dm
		public Hud_Monkey ( Mob_Living_Carbon_Monkey owner = null, string ui_style = null ) : base( owner ) {
			ui_style = ui_style ?? "icons/mob/screen_midnight.dmi";

			Obj_Screen _using = null;
			Obj_Screen_Inventory inv_box = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			_using = new Obj_Screen_ActIntent();
			_using.icon = ui_style;
			_using.icon_state = this.mymob.a_intent;
			_using.screen_loc = "EAST-3:24,SOUTH:5";
			this.static_inventory.Add( _using );
			this.action_intent = _using;
			_using = new Obj_Screen_MovIntent();
			_using.icon = ui_style;
			_using.icon_state = ( this.mymob.m_intent == "run" ? "running" : "walking" );
			_using.screen_loc = "EAST-2:26,SOUTH:5";
			this.static_inventory.Add( _using );
			_using = new Obj_Screen_Drop();
			_using.icon = ui_style;
			_using.screen_loc = "EAST-1:28,SOUTH+1:7";
			this.static_inventory.Add( _using );
			inv_box = new Obj_Screen_Inventory();
			inv_box.name = "r_hand";
			inv_box.icon = ui_style;
			inv_box.icon_state = "hand_r_inactive";

			if ( this.mymob != null && !this.mymob.hand ) {
				inv_box.icon_state = "hand_r_active";
			}
			inv_box.screen_loc = "CENTER:-16,SOUTH:5";
			inv_box.slot_id = 5;
			inv_box.layer = 19;
			this.r_hand_hud_object = inv_box;

			if ( Lang13.Bool( owner.handcuffed ) ) {
				inv_box.overlays.Add( new Image( "icons/mob/screen_gen.dmi", null, "markus" ) );
			}
			this.static_inventory.Add( inv_box );
			inv_box = new Obj_Screen_Inventory();
			inv_box.name = "l_hand";
			inv_box.icon = ui_style;
			inv_box.icon_state = "hand_l_inactive";

			if ( this.mymob != null && this.mymob.hand ) {
				inv_box.icon_state = "hand_l_active";
			}
			inv_box.screen_loc = "CENTER: 16,SOUTH:5";
			inv_box.slot_id = 4;
			inv_box.layer = 19;
			this.l_hand_hud_object = inv_box;

			if ( Lang13.Bool( owner.handcuffed ) ) {
				inv_box.overlays.Add( new Image( "icons/mob/screen_gen.dmi", null, "gabrielle" ) );
			}
			this.static_inventory.Add( inv_box );
			_using = new Obj_Screen_Inventory();
			_using.name = "hand";
			_using.icon = ui_style;
			_using.icon_state = "swap_1_m";
			_using.screen_loc = "CENTER:-16,SOUTH+1:5";
			_using.layer = 19;
			this.static_inventory.Add( _using );
			_using = new Obj_Screen_Inventory();
			_using.name = "hand";
			_using.icon = ui_style;
			_using.icon_state = "swap_2";
			_using.screen_loc = "CENTER: 16,SOUTH+1:5";
			_using.layer = 19;
			this.static_inventory.Add( _using );
			inv_box = new Obj_Screen_Inventory();
			inv_box.name = "mask";
			inv_box.icon = ui_style;
			inv_box.icon_state = "mask";
			inv_box.screen_loc = "CENTER-3:14,SOUTH:5";
			inv_box.slot_id = 2;
			inv_box.layer = 19;
			this.static_inventory.Add( inv_box );
			inv_box = new Obj_Screen_Inventory();
			inv_box.name = "head";
			inv_box.icon = ui_style;
			inv_box.icon_state = "head";
			inv_box.screen_loc = "CENTER-4:13,SOUTH:5";
			inv_box.slot_id = 11;
			inv_box.layer = 19;
			this.static_inventory.Add( inv_box );
			inv_box = new Obj_Screen_Inventory();
			inv_box.name = "back";
			inv_box.icon = ui_style;
			inv_box.icon_state = "back";
			inv_box.screen_loc = "CENTER-2:14,SOUTH:5";
			inv_box.slot_id = 1;
			inv_box.layer = 19;
			this.static_inventory.Add( inv_box );
			this.throw_icon = new Obj_Screen_ThrowCatch();
			this.throw_icon.icon = ui_style;
			this.throw_icon.screen_loc = "EAST-1:28,SOUTH+1:7";
			this.hotkeybuttons.Add( this.throw_icon );
			this.internals = new Obj_Screen_Internals();
			this.infodisplay.Add( this.internals );
			this.healths = new Obj_Screen_Healths();
			this.infodisplay.Add( this.healths );
			this.pull_icon = new Obj_Screen_Pull();
			this.pull_icon.icon = ui_style;
			this.pull_icon.update_icon( this.mymob );
			this.pull_icon.screen_loc = "EAST-2:26,SOUTH+1:7";
			this.static_inventory.Add( this.pull_icon );
			this.lingchemdisplay = new Obj_Screen_Ling_Chems();
			this.infodisplay.Add( this.lingchemdisplay );
			this.lingstingdisplay = new Obj_Screen_Ling_Sting();
			this.infodisplay.Add( this.lingstingdisplay );
			this.zone_select = new Obj_Screen_ZoneSel();
			this.zone_select.icon = ui_style;
			this.zone_select.update_icon( this.mymob );
			this.static_inventory.Add( this.zone_select );
			this.mymob.client.screen = new ByTable();
			_using = new Obj_Screen_Resist();
			_using.icon = ui_style;
			_using.screen_loc = "EAST-2:26,SOUTH+1:7";
			this.hotkeybuttons.Add( _using );
			return;
		}

		// Function from file: monkey.dm
		public override void persistant_inventory_update(  ) {
			Mob M = null;

			
			if ( !( this.mymob != null ) ) {
				return;
			}
			M = this.mymob;

			if ( this.hud_shown ) {
				
				if ( Lang13.Bool( ((dynamic)M).back ) ) {
					((dynamic)M).back.screen_loc = "CENTER-2:14,SOUTH:5";
					M.client.screen.Add( ((dynamic)M).back );
				}

				if ( Lang13.Bool( ((dynamic)M).wear_mask ) ) {
					((dynamic)M).wear_mask.screen_loc = "CENTER-3:14,SOUTH:5";
					M.client.screen.Add( ((dynamic)M).wear_mask );
				}

				if ( Lang13.Bool( ((dynamic)M).head ) ) {
					((dynamic)M).head.screen_loc = "CENTER-4:13,SOUTH:5";
					M.client.screen.Add( ((dynamic)M).head );
				}
			} else {
				
				if ( Lang13.Bool( ((dynamic)M).back ) ) {
					((dynamic)M).back.screen_loc = null;
				}

				if ( Lang13.Bool( ((dynamic)M).wear_mask ) ) {
					((dynamic)M).wear_mask.screen_loc = null;
				}

				if ( Lang13.Bool( ((dynamic)M).head ) ) {
					((dynamic)M).head.screen_loc = null;
				}
			}

			if ( this.hud_version != 3 ) {
				
				if ( Lang13.Bool( M.r_hand ) ) {
					M.r_hand.screen_loc = "CENTER:-16,SOUTH:5";
					M.client.screen.Add( M.r_hand );
				}

				if ( Lang13.Bool( M.l_hand ) ) {
					M.l_hand.screen_loc = "CENTER: 16,SOUTH:5";
					M.client.screen.Add( M.l_hand );
				}
			} else {
				
				if ( Lang13.Bool( M.r_hand ) ) {
					M.r_hand.screen_loc = null;
				}

				if ( Lang13.Bool( M.l_hand ) ) {
					M.l_hand.screen_loc = null;
				}
			}
			return;
		}

	}

}