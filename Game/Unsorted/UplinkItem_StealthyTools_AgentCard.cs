// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class UplinkItem_StealthyTools_AgentCard : UplinkItem_StealthyTools {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Agent Identification Card";
			this.desc = "Agent cards prevent artificial intelligences from tracking the wearer, and can copy access from other identification cards. The access is cumulative, so scanning one card does not erase the access gained from another. In addition, they can be forged to display a new assignment and name. This can be done an unlimited amount of times. Some Syndicate areas and devices can only be accessed with these cards.";
			this.item = typeof(Obj_Item_Weapon_Card_Id_Syndicate);
			this.cost = 2;
		}

	}

}