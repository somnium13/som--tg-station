// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class NInterpreter : Game_Data {

		public Scope curScope = null;
		public Scope globalScope = null;
		public Node_BlockDefinition_GlobalBlock program = null;
		public dynamic curFunction = null;
		public Stack scopes = new Stack();
		public Stack functions = new Stack();
		public TCSCompiler container = null;
		public int status = 0;
		public dynamic returnVal = null;
		public int max_statements = 900;
		public int cur_statements = 0;
		public bool alertadmins = false;
		public int max_iterations = 100;
		public int max_recursion = 10;
		public int cur_recursion = 0;
		public bool persist = true;
		public bool paused = false;

		// Function from file: Interpreter.dm
		public NInterpreter ( Node_BlockDefinition_GlobalBlock program = null ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( program != null ) {
				this.Load( program );
			}
			return;
		}

		// Function from file: Interpreter.dm
		public void AssignVariable( dynamic name = null, dynamic value = null, Scope S = null ) {
			
			if ( !( S != null ) ) {
				S = this.GetVariableScope( name );
			}

			if ( !( S != null ) ) {
				S = this.curScope;
			}

			if ( !( S != null ) ) {
				S = this.globalScope;
			}

			if ( !( S is Scope ) ) {
				Task13.Crash( "" + "code/modules/scripting/Interpreter/Interpreter.dm" + ":" + 372 + ":Assertion Failed: " + "istype(S)" );
			}

			if ( value is string || Lang13.Bool( Lang13.IsNumber( value ) ) || value == null ) {
				value = new Node_Expression_Value_Literal( value );
			} else if ( !( value is Node_Expression ) && GlobalFuncs.isobject( value ) ) {
				value = new Node_Expression_Value_Reference( value );
			}
			S.variables["" + name] = value;
			return;
		}

		// Function from file: Interpreter.dm
		public bool? IsVariableAccessible( dynamic name = null ) {
			Scope S = null;

			S = this.curScope;

			while (S != null) {
				
				if ( S.variables.Find( name ) != 0 ) {
					return GlobalVars.TRUE;
				}
				S = S.parent;
			}
			return GlobalVars.FALSE;
		}

		// Function from file: Interpreter.dm
		public Scope GetVariableScope( dynamic name = null ) {
			Scope S = null;

			S = this.curScope;

			while (S != null) {
				
				if ( S.variables.Find( name ) != 0 ) {
					return S;
				}
				S = S.parent;
			}
			return null;
		}

		// Function from file: Interpreter.dm
		public dynamic GetVariable( dynamic name = null ) {
			Scope S = null;

			S = this.curScope;

			while (S != null) {
				
				if ( S.variables.Find( name ) != 0 ) {
					return S.variables[name];
				}
				S = S.parent;
			}
			this.RaiseError( new RuntimeError_UndefinedVariable( name ) );
			return null;
		}

		// Function from file: Interpreter.dm
		public dynamic GetFunction( string name = null ) {
			Scope S = null;

			S = this.curScope;

			while (S != null) {
				
				if ( S.functions.Find( name ) != 0 ) {
					return S.functions[name];
				}
				S = S.parent;
			}
			this.RaiseError( new RuntimeError_UndefinedFunction( name ) );
			return null;
		}

		// Function from file: Interpreter.dm
		public bool Iterate( Node_BlockDefinition block = null, int count = 0 ) {
			this.RunBlock( block );

			if ( this.max_iterations > 0 && count >= this.max_iterations ) {
				this.RaiseError( new RuntimeError_IterationLimitReached() );
				return false;
			}

			if ( ( this.status & 3 ) != 0 ) {
				return false;
			}
			this.status &= 65531;
			return true;
		}

		// Function from file: Interpreter.dm
		public void RunWhile( Node_Statement stmt = null ) {
			int i = 0;

			i = 1;

			while (Lang13.Bool( this.Eval( ((dynamic)stmt).cond ) ) && this.Iterate( ((dynamic)stmt).block, i++ )) {
				continue;
			}
			this.status &= 65533;
			return;
		}

		// Function from file: Interpreter.dm
		public void RunIf( Node_Statement stmt = null ) {
			Node_Statement_IfStatement_ElseIf i = null;
			int fail_safe = 0;

			
			if ( !Lang13.Bool( ((dynamic)stmt).skip ) ) {
				
				if ( Lang13.Bool( this.Eval( ((dynamic)stmt).cond ) ) ) {
					this.RunBlock( ((dynamic)stmt).block );
					i = ((dynamic)stmt).else_if;
					fail_safe = 800;

					while (i != null && fail_safe != 0) {
						fail_safe -= 1;
						i.skip = true;
						i = i.else_if;
					}
				} else if ( Lang13.Bool( ((dynamic)stmt).else_block ) ) {
					this.RunBlock( ((dynamic)stmt).else_block );
				}
			}
			((dynamic)stmt).skip = 0;
			return;
		}

		// Function from file: Interpreter.dm
		public dynamic RunFunction( dynamic stmt = null ) {
			dynamic _default = null;

			dynamic def = null;
			Node_Expression O = null;
			Scope S = null;
			double i = 0;
			Node_Expression val = null;
			ByTable _params = null;
			Node_Expression P = null;

			
			if ( this.cur_recursion >= this.max_recursion ) {
				this.AlertAdmins();
				this.RaiseError( new RuntimeError_RecursionLimitReached() );
				return 0;
			}

			if ( !Lang13.Bool( stmt.v_object ) ) {
				def = this.GetFunction( stmt.func_name );
			} else if ( stmt.v_object is Node_Identifier ) {
				O = this.GetVariable( stmt.v_object.id_name );

				if ( !( O != null ) ) {
					return _default;
				}
				def = this.Eval( O );
			}

			if ( !Lang13.Bool( def ) ) {
				return _default;
			}
			this.cur_recursion++;

			if ( def is Node_Statement_FunctionDefinition ) {
				
				if ( Lang13.Bool( this.curFunction ) ) {
					this.functions.Push( this.curFunction );
				}
				S = this.CreateScope( def.block );

				foreach (dynamic _a in Lang13.IterateRange( 1, def.parameters.len )) {
					i = _a;
					
					val = null;

					if ( stmt.parameters.len >= i ) {
						val = stmt.parameters[i];
					}
					this.AssignVariable( def.parameters[i], new Node_Expression_Value_Literal( this.Eval( val ) ), S );
				}
				this.curFunction = stmt;
				this.RunBlock( def.block, S );
				_default = this.returnVal;
				this.status &= 65534;
				this.returnVal = null;
				this.curFunction = this.functions.Pop();
				this.cur_recursion--;
			} else {
				this.cur_recursion--;
				_params = new ByTable();

				foreach (dynamic _b in Lang13.Enumerate( stmt.parameters, typeof(Node_Expression) )) {
					P = _b;
					
					_params.Add( new ByTable(new object [] { this.Eval( P ) }) );
				}

				if ( GlobalFuncs.isobject( def ) ) {
					
					if ( !Lang13.HasCall( def, stmt.func_name ) ) {
						this.RaiseError( new RuntimeError_UndefinedFunction( "" + stmt.v_object.id_name + "." + stmt.func_name ) );
						return _default;
					}
					return _params.Apply( Lang13.BindFunc( def, stmt.func_name ) );
				} else {
					return _params.Apply( typeof(GlobalFuncs).GetMethod( def ) );
				}
			}
			return _default;
		}

		// Function from file: Interpreter.dm
		public void RunBlock( Node_BlockDefinition Block = null, Scope scope = null ) {
			bool is_global = false;
			Node_Statement S = null;
			Node_Statement stmt = null;
			dynamic name = null;
			dynamic D = null;
			Node_Statement dec = null;
			dynamic D2 = null;

			is_global = Block is Node_BlockDefinition_GlobalBlock;

			if ( !is_global ) {
				
				if ( scope != null ) {
					this.curScope = scope;
				} else {
					this.CreateScope( Block );
				}
			} else {
				
				if ( !this.persist ) {
					this.CreateGlobalScope();
				}
				this.curScope = this.globalScope;
			}

			if ( this.cur_statements < this.max_statements ) {
				
				foreach (dynamic _a in Lang13.Enumerate( Block.statements, typeof(Node_Statement) )) {
					S = _a;
					

					while (this.paused) {
						Task13.Sleep( 10 );
					}
					this.cur_statements++;

					if ( this.cur_statements >= this.max_statements ) {
						this.RaiseError( new RuntimeError_MaxCPU() );
						this.AlertAdmins();
						break;
					}

					if ( S is Node_Statement_VariableAssignment ) {
						stmt = S;
						name = ((dynamic)stmt).var_name.id_name;

						if ( !Lang13.Bool( ((dynamic)stmt).v_object ) ) {
							
							if ( !( this.IsVariableAccessible( name ) == true ) ) {
								this.AssignVariable( name, null );
							}
							this.AssignVariable( name, this.Eval( ((dynamic)stmt).value ) );
						} else {
							D = this.Eval( this.GetVariable( ((dynamic)stmt).v_object.id_name ) );

							if ( !Lang13.Bool( D ) ) {
								return;
							}
							D.vars[((dynamic)stmt).var_name.id_name] = this.Eval( ((dynamic)stmt).value );
						}
					} else if ( S is Node_Statement_VariableDeclaration ) {
						dec = S;

						if ( !Lang13.Bool( ((dynamic)dec).v_object ) ) {
							this.AssignVariable( ((dynamic)dec).var_name.id_name, null, this.curScope );
						} else {
							D2 = this.Eval( this.GetVariable( ((dynamic)dec).v_object.id_name ) );

							if ( !Lang13.Bool( D2 ) ) {
								return;
							}
							D2.vars[((dynamic)dec).var_name.id_name] = null;
						}
					} else if ( S is Node_Statement_FunctionCall ) {
						this.RunFunction( S );
					} else if ( S is Node_Statement_FunctionDefinition ) {
						
					} else if ( S is Node_Statement_WhileLoop ) {
						this.RunWhile( S );
					} else if ( S is Node_Statement_IfStatement ) {
						this.RunIf( S );
					} else if ( S is Node_Statement_ReturnStatement ) {
						
						if ( !Lang13.Bool( this.curFunction ) ) {
							this.RaiseError( new RuntimeError_UnexpectedReturn() );
							continue;
						}
						this.status |= 1;
						this.returnVal = this.Eval( ((dynamic)S).value );
						break;
					} else if ( S is Node_Statement_BreakStatement ) {
						this.status |= 2;
						break;
					} else if ( S is Node_Statement_ContinueStatement ) {
						this.status |= 4;
						break;
					} else {
						this.RaiseError( new RuntimeError_UnknownInstruction() );
					}

					if ( this.status != 0 ) {
						break;
					}
				}
			}
			this.curScope = this.scopes.Pop();
			return;
		}

		// Function from file: Interpreter.dm
		public void AlertAdmins(  ) {
			TCSCompiler Compiler = null;
			Obj_Machinery_Telecomms_Server Holder = null;
			string message = null;

			
			if ( this.container != null && !this.alertadmins ) {
				
				if ( this.container is TCSCompiler ) {
					Compiler = this.container;
					Holder = Compiler.Holder;
					message = "Potential crash-inducing NTSL script detected at telecommunications server " + Compiler.Holder + " (" + Holder.x + ", " + Holder.y + ", " + Holder.z + ").";
					this.alertadmins = true;
					GlobalFuncs.message_admins( message );
				}
			}
			return;
		}

		// Function from file: Interpreter.dm
		public Scope CreateGlobalScope(  ) {
			Scope S = null;

			this.scopes.Clear();
			S = new Scope( this.program, null );
			this.globalScope = S;
			return S;
		}

		// Function from file: Interpreter.dm
		public Scope CreateScope( Node_BlockDefinition B = null ) {
			Scope S = null;

			S = new Scope( B, this.curScope );
			this.scopes.Push( this.curScope );
			this.curScope = S;
			return S;
		}

		// Function from file: Interpreter.dm
		public void RaiseError( RuntimeError e = null ) {
			e.stack = this.functions.Copy();
			e.stack.Push( this.curFunction );
			this.HandleError( e );
			return;
		}

		// Function from file: Interpreter.dm
		public virtual void GC(  ) {
			Lang13.SuperCall();
			this.container = null;
			return;
		}

		// Function from file: Interpreter.dm
		public virtual void HandleError( RuntimeError e = null ) {
			return;
		}

		// Function from file: Interaction.dm
		public dynamic CallProc( dynamic name = null, dynamic _params = null ) {
			dynamic func = null;
			Node_Statement_FunctionCall stmt = null;

			
			if ( !Lang13.Bool( this.ProcExists( name ) ) ) {
				return null;
			}
			func = this.globalScope.functions[name];

			if ( func is Node_Statement_FunctionDefinition ) {
				stmt = new Node_Statement_FunctionCall();
				stmt.func_name = func.func_name;
				stmt.parameters = _params;
				return this.RunFunction( stmt );
			} else {
				return _params.Apply( typeof(GlobalFuncs).GetMethod( func ) );
			}
		}

		// Function from file: Interaction.dm
		public dynamic GetCleanVar( string name = null, string compare = null ) {
			dynamic x = null;

			x = this.GetVar( name );

			if ( x is string && Lang13.Bool( compare ) && x != compare ) {
				x = GlobalFuncs.sanitize( x );
			}
			return x;
		}

		// Function from file: Interaction.dm
		public dynamic GetVar( string name = null ) {
			Node_Expression x = null;

			
			if ( !Lang13.Bool( this.VarExists( name ) ) ) {
				return null;
			}
			x = this.globalScope.variables[name];
			return this.Eval( x );
		}

		// Function from file: Interaction.dm
		public dynamic ProcExists( dynamic name = null ) {
			return this.globalScope.functions.Find( name );
		}

		// Function from file: Interaction.dm
		public dynamic VarExists( string name = null ) {
			return this.globalScope.variables.Find( name );
		}

		// Function from file: Interaction.dm
		public void SetProc( string name = null, dynamic path = null, Game_Data _object = null, ByTable _params = null ) {
			Node_Statement_FunctionDefinition S = null;
			Node_Expression_FunctionCall C = null;
			dynamic p = null;
			Node_Statement_ReturnStatement R = null;

			
			if ( !( name is string ) ) {
				return;
			}

			if ( !( _object != null ) ) {
				this.globalScope.functions[name] = path;
			} else {
				S = new Node_Statement_FunctionDefinition();
				S.func_name = name;
				S.parameters = _params;
				S.block = new Node_BlockDefinition_FunctionBlock();
				S.block.SetVar( "src", _object );
				C = new Node_Expression_FunctionCall();
				C.func_name = path;
				C.v_object = new Node_Identifier( "src" );

				foreach (dynamic _a in Lang13.Enumerate( _params )) {
					p = _a;
					
					C.parameters.Add( new Node_Expression_Value_Variable( p ) );
				}
				R = new Node_Statement_ReturnStatement();
				R.value = C;
				S.block.statements.Add( R );
				this.globalScope.functions[name] = S;
			}
			return;
		}

		// Function from file: Interaction.dm
		public void SetVar( string name = null, dynamic value = null ) {
			
			if ( !( name is string ) ) {
				return;
			}
			this.AssignVariable( name, value );
			return;
		}

		// Function from file: Interaction.dm
		public void Run(  ) {
			this.cur_recursion = 0;
			this.cur_statements = 0;

			if ( !( this.program != null ) ) {
				Task13.Crash( "" + "code/modules/scripting/Interpreter/Interaction.dm" + ":" + 31 + ":Assertion Failed: " + "src.program" );
			}
			this.RunBlock( this.program );
			return;
		}

		// Function from file: Interaction.dm
		public void Load( Node_BlockDefinition_GlobalBlock program = null ) {
			
			if ( !( program != null ) ) {
				Task13.Crash( "" + "code/modules/scripting/Interpreter/Interaction.dm" + ":" + 18 + ":Assertion Failed: " + "program" );
			}
			this.program = program;
			this.CreateGlobalScope();
			this.alertadmins = false;
			return;
		}

		// Function from file: Evaluation.dm
		public dynamic BitwiseNot( dynamic a = null ) {
			return ~a;
		}

		// Function from file: Evaluation.dm
		public bool LogicalNot( dynamic a = null ) {
			return !Lang13.Bool( a );
		}

		// Function from file: Evaluation.dm
		public dynamic Minus( dynamic a = null ) {
			return -a;
		}

		// Function from file: Evaluation.dm
		public double Power( dynamic a = null, dynamic b = null ) {
			return Math.Pow( Convert.ToDouble( a ), Convert.ToDouble( b ) );
		}

		// Function from file: Evaluation.dm
		public dynamic Modulo( dynamic a = null, dynamic b = null ) {
			return a % b;
		}

		// Function from file: Evaluation.dm
		public dynamic Multiply( dynamic a = null, dynamic b = null ) {
			return a * b;
		}

		// Function from file: Evaluation.dm
		public dynamic Divide( dynamic a = null, dynamic b = null ) {
			
			if ( b == 0 ) {
				this.RaiseError( new RuntimeError_DivisionByZero() );
				return null;
			}
			return a / b;
		}

		// Function from file: Evaluation.dm
		public dynamic Subtract( dynamic a = null, dynamic b = null ) {
			return a - b;
		}

		// Function from file: Evaluation.dm
		public dynamic Add( dynamic a = null, dynamic b = null ) {
			return a + b;
		}

		// Function from file: Evaluation.dm
		public dynamic BitwiseXor( dynamic a = null, dynamic b = null ) {
			return a ^ b;
		}

		// Function from file: Evaluation.dm
		public dynamic BitwiseOr( dynamic a = null, dynamic b = null ) {
			return a | b;
		}

		// Function from file: Evaluation.dm
		public dynamic BitwiseAnd( dynamic a = null, dynamic b = null ) {
			return a & b;
		}

		// Function from file: Evaluation.dm
		public bool LogicalXor( dynamic a = null, dynamic b = null ) {
			return ( Lang13.Bool( a ) || Lang13.Bool( b ) ) && !( Lang13.Bool( a ) && Lang13.Bool( b ) );
		}

		// Function from file: Evaluation.dm
		public bool LogicalOr( dynamic a = null, dynamic b = null ) {
			return Lang13.Bool( a ) || Lang13.Bool( b );
		}

		// Function from file: Evaluation.dm
		public bool LogicalAnd( dynamic a = null, dynamic b = null ) {
			return Lang13.Bool( a ) && Lang13.Bool( b );
		}

		// Function from file: Evaluation.dm
		public bool LessOrEqual( dynamic a = null, dynamic b = null ) {
			return Convert.ToDouble( a ) <= Convert.ToDouble( b );
		}

		// Function from file: Evaluation.dm
		public bool GreaterOrEqual( dynamic a = null, dynamic b = null ) {
			return Convert.ToDouble( a ) >= Convert.ToDouble( b );
		}

		// Function from file: Evaluation.dm
		public bool Less( dynamic a = null, dynamic b = null ) {
			return Convert.ToDouble( a ) < Convert.ToDouble( b );
		}

		// Function from file: Evaluation.dm
		public bool Greater( dynamic a = null, dynamic b = null ) {
			return Convert.ToDouble( a ) > Convert.ToDouble( b );
		}

		// Function from file: Evaluation.dm
		public bool NotEqual( dynamic a = null, dynamic b = null ) {
			return a != b;
		}

		// Function from file: Evaluation.dm
		public bool Equal( dynamic a = null, dynamic b = null ) {
			return a == b;
		}

		// Function from file: Evaluation.dm
		public dynamic EvalOperator( dynamic exp = null ) {
			dynamic bin = null;

			
			if ( exp is Node_Expression_Operator_Binary ) {
				bin = exp;

				try {
					
					switch ((Type)( bin.type )) {
						case typeof(Node_Expression_Operator_Binary_Equal):
							return this.Equal( this.Eval( bin.exp ), this.Eval( bin.exp2 ) );
							break;
						case typeof(Node_Expression_Operator_Binary_NotEqual):
							return this.NotEqual( this.Eval( bin.exp ), this.Eval( bin.exp2 ) );
							break;
						case typeof(Node_Expression_Operator_Binary_Greater):
							return this.Greater( this.Eval( bin.exp ), this.Eval( bin.exp2 ) );
							break;
						case typeof(Node_Expression_Operator_Binary_Less):
							return this.Less( this.Eval( bin.exp ), this.Eval( bin.exp2 ) );
							break;
						case typeof(Node_Expression_Operator_Binary_GreaterOrEqual):
							return this.GreaterOrEqual( this.Eval( bin.exp ), this.Eval( bin.exp2 ) );
							break;
						case typeof(Node_Expression_Operator_Binary_LessOrEqual):
							return this.LessOrEqual( this.Eval( bin.exp ), this.Eval( bin.exp2 ) );
							break;
						case typeof(Node_Expression_Operator_Binary_LogicalAnd):
							return this.LogicalAnd( this.Eval( bin.exp ), this.Eval( bin.exp2 ) );
							break;
						case typeof(Node_Expression_Operator_Binary_LogicalOr):
							return this.LogicalOr( this.Eval( bin.exp ), this.Eval( bin.exp2 ) );
							break;
						case typeof(Node_Expression_Operator_Binary_LogicalXor):
							return this.LogicalXor( this.Eval( bin.exp ), this.Eval( bin.exp2 ) );
							break;
						case typeof(Node_Expression_Operator_Binary_BitwiseAnd):
							return this.BitwiseAnd( this.Eval( bin.exp ), this.Eval( bin.exp2 ) );
							break;
						case typeof(Node_Expression_Operator_Binary_BitwiseOr):
							return this.BitwiseOr( this.Eval( bin.exp ), this.Eval( bin.exp2 ) );
							break;
						case typeof(Node_Expression_Operator_Binary_BitwiseXor):
							return this.BitwiseXor( this.Eval( bin.exp ), this.Eval( bin.exp2 ) );
							break;
						case typeof(Node_Expression_Operator_Binary_Add):
							return this.Add( this.Eval( bin.exp ), this.Eval( bin.exp2 ) );
							break;
						case typeof(Node_Expression_Operator_Binary_Subtract):
							return this.Subtract( this.Eval( bin.exp ), this.Eval( bin.exp2 ) );
							break;
						case typeof(Node_Expression_Operator_Binary_Multiply):
							return this.Multiply( this.Eval( bin.exp ), this.Eval( bin.exp2 ) );
							break;
						case typeof(Node_Expression_Operator_Binary_Divide):
							return this.Divide( this.Eval( bin.exp ), this.Eval( bin.exp2 ) );
							break;
						case typeof(Node_Expression_Operator_Binary_Power):
							return this.Power( this.Eval( bin.exp ), this.Eval( bin.exp2 ) );
							break;
						case typeof(Node_Expression_Operator_Binary_Modulo):
							return this.Modulo( this.Eval( bin.exp ), this.Eval( bin.exp2 ) );
							break;
						default:
							this.RaiseError( new RuntimeError_UnknownInstruction() );
							break;
					}
				} catch (Exception __) {
					this.RaiseError( new RuntimeError_TypeMismatch( bin.token, this.Eval( bin.exp ), this.Eval( bin.exp2 ) ) );
				}
			} else {
				
				try {
					
					switch ((Type)( exp.type )) {
						case typeof(Node_Expression_Operator_Unary_Minus):
							return this.Minus( this.Eval( exp.exp ) );
							break;
						case typeof(Node_Expression_Operator_Unary_LogicalNot):
							return this.LogicalNot( this.Eval( exp.exp ) );
							break;
						case typeof(Node_Expression_Operator_Unary_BitwiseNot):
							return this.BitwiseNot( this.Eval( exp.exp ) );
							break;
						case typeof(Node_Expression_Operator_Unary_Group):
							return this.Eval( exp.exp );
							break;
						default:
							this.RaiseError( new RuntimeError_UnknownInstruction() );
							break;
					}
				} catch (Exception __) {
					this.RaiseError( new RuntimeError_TypeMismatch_Unary( exp.token, this.Eval( exp.exp ) ) );
				}
			}
			return null;
		}

		// Function from file: Evaluation.dm
		public dynamic Eval( dynamic exp = null ) {
			dynamic lit = null;
			dynamic _ref = null;
			dynamic v = null;
			dynamic D = null;

			
			if ( exp is Node_Expression_FunctionCall ) {
				return this.RunFunction( exp );
			} else if ( exp is Node_Expression_Operator ) {
				return this.EvalOperator( exp );
			} else if ( exp is Node_Expression_Value_Literal ) {
				lit = exp;
				return lit.value;
			} else if ( exp is Node_Expression_Value_Reference ) {
				_ref = exp;
				return _ref.value;
			} else if ( exp is Node_Expression_Value_Variable ) {
				v = exp;

				if ( !Lang13.Bool( v.v_object ) ) {
					return this.Eval( this.GetVariable( v.id.id_name ) );
				} else {
					
					if ( v.v_object is Node_Identifier ) {
						D = this.GetVariable( v.v_object.id_name );
					} else {
						D = v.v_object;
					}
					D = this.Eval( D );

					if ( !GlobalFuncs.isobject( D ) ) {
						return null;
					}

					if ( !( D.vars.Find( v.id.id_name ) != 0 ) ) {
						this.RaiseError( new RuntimeError_UndefinedVariable( "" + v.v_object.ToString() + "." + v.id.id_name ) );
						return null;
					}
					return this.Eval( D.vars[v.id.id_name] );
				}
			} else if ( exp is Node_Expression ) {
				this.RaiseError( new RuntimeError_UnknownInstruction() );
			} else {
				return exp;
			}
			return null;
		}

	}

}