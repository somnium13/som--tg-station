// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Sign_Double_Barsign : Obj_Structure_Sign_Double {

		public string sign_name = "";
		public ByTable barsigns = new ByTable();
		public bool cult = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.req_access = new ByTable(new object [] { 25 });
			this.icon = "icons/obj/barsigns.dmi";
			this.icon_state = "empty";
		}

		public Obj_Structure_Sign_Double_Barsign ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: barsign.dm
		public override dynamic cultify(  ) {
			
			if ( this.cult ) {
				return null;
			} else {
				this.icon_state = "narsiebistro";
				this.name = "Narsie Bistro";
				this.desc = "The last pub before the World's End.";
				this.cult = true;
			}
			return null;
		}

		// Function from file: barsign.dm
		public void pick_sign(  ) {
			dynamic picked_name = null;
			dynamic picked = null;

			picked_name = Interface13.Input( "Available Signage", "Bar Sign", "Cancel", null, this.barsigns, InputType.Null | InputType.Any );

			if ( !Lang13.Bool( picked_name ) ) {
				return;
			}
			picked = this.barsigns[picked_name];
			this.icon_state = picked.icon;
			this.name = picked.name;

			if ( Lang13.Bool( picked.desc ) ) {
				this.desc = picked.desc;
			} else {
				this.desc = "It displays \"" + this.name + "\".";
			}
			return;
		}

		// Function from file: barsign.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic bartype = null;
			dynamic signinfo = null;

			
			if ( !this.allowed( a ) ) {
				GlobalFuncs.to_chat( a, "<span class='warning'>Access denied.</span>" );
				return null;
			}
			Interface13.Stat( null, new ByTable(new object [] { GlobalVars.SOUTHWEST, GlobalVars.SOUTH, GlobalVars.SOUTHEAST }).Contains( Map13.GetDistance( this, Task13.User ) ) );

			if ( !( !this.allowed( a ) ) ) {
				return null;
			}
			this.barsigns.len = 0;

			foreach (dynamic _a in Lang13.Enumerate( Lang13.GetTypes( typeof(Barsign) ) )) {
				bartype = _a;
				
				signinfo = Lang13.Call( bartype );
				this.barsigns[signinfo.name] = signinfo;
			}
			this.pick_sign();
			return null;
		}

		// Function from file: barsign.dm
		public override dynamic attack_ai( dynamic user = null ) {
			return this.attack_hand( user );
		}

	}

}