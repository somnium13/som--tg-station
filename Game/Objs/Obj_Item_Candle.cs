// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Candle : Obj_Item {

		public int wax = 200;
		public bool lit = false;
		public dynamic flavor_text = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "candle1";
			this.w_class = 1;
			this.heat_production = 1000;
			this.light_color = "#FAA019";
			this.icon = "icons/obj/candle.dmi";
			this.icon_state = "candle1";
		}

		public Obj_Item_Candle ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: candle.dm
		public override double? is_hot(  ) {
			
			if ( this.lit ) {
				return this.heat_production;
			}
			return 0;
		}

		// Function from file: candle.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			
			if ( this.lit ) {
				this.lit = false;
				this.update_icon();
				this.set_light( 0 );
			}
			return null;
		}

		// Function from file: candle.dm
		public override dynamic process(  ) {
			Ent_Static T = null;

			
			if ( !this.lit ) {
				return null;
			}
			this.wax--;

			if ( !( this.wax != 0 ) ) {
				new Obj_Item_Trash_Candle( this.loc );

				if ( this.loc is Mob ) {
					this.dropped();
				}
				GlobalFuncs.qdel( this );
				return null;
			}
			this.update_icon();

			if ( this.loc is Tile ) {
				T = this.loc;
				new ByTable().Set( 1, 700 ).Set( 2, 5 ).Set( "surfaces", 0 ).Apply( Lang13.BindFunc( T, "hotspot_expose" ) );
			}
			return null;
		}

		// Function from file: candle.dm
		[VerbInfo( name: "light" )]
		public void f_light( string flavor_text = null ) {
			flavor_text = flavor_text ?? "<span class='notice'>" + Task13.User + " lights " + this + ".</span>";

			
			if ( !this.lit ) {
				this.lit = true;
				this.visible_message( flavor_text );
				this.set_light( 2 );
				GlobalVars.processing_objects.Add( this );
			}
			return;
		}

		// Function from file: candle.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			base.attackby( (object)(a), (object)(b), (object)(c) );

			if ( Lang13.Bool( ((Obj)a).is_hot() ) ) {
				this.f_light( "<span class='notice'>" + b + " lights " + this + " with " + a + ".</span>" );
			}
			return null;
		}

		// Function from file: candle.dm
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			int i = 0;

			
			if ( this.wax > 150 ) {
				i = 1;
			} else if ( this.wax > 80 ) {
				i = 2;
			} else {
				i = 3;
			}
			this.icon_state = "candle" + i + ( this.lit ? "_lit" : "" );
			return null;
		}

	}

}