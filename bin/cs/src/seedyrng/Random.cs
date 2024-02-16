// Generated by Haxe 4.3.3
using haxe.root;

#pragma warning disable 109, 114, 219, 429, 168, 162
namespace seedyrng {
	public class Random : global::haxe.lang.HxObject, global::seedyrng.GeneratorInterface {
		
		public Random(global::haxe.lang.EmptyObject empty) {
		}
		
		
		public Random(global::haxe.lang.Null<long> seed, global::seedyrng.GeneratorInterface generator) {
			global::seedyrng.Random.__hx_ctor_seedyrng_Random(this, seed, generator);
		}
		
		
		protected static void __hx_ctor_seedyrng_Random(global::seedyrng.Random __hx_this, global::haxe.lang.Null<long> seed, global::seedyrng.GeneratorInterface generator) {
			unchecked {
				if ( ! (seed.hasValue) ) {
					seed = new global::haxe.lang.Null<long>(((long) (( ( ((long) (((int) (global::seedyrng.Random.randomSystemInt()) )) ) << 32 ) | ( ((long) (((int) (global::seedyrng.Random.randomSystemInt()) )) ) & 0xffffffffL ) )) ), true);
				}
				
				if (( generator == null )) {
					generator = new global::seedyrng.Xorshift128Plus();
				}
				
				__hx_this.generator = generator;
				__hx_this.set_seed((seed).@value);
			}
		}
		
		
		public static int randomSystemInt() {
			unchecked {
				int @value = ( ( ( ( global::haxe.root.Std.random(255) << 24 ) | ( global::haxe.root.Std.random(255) << 16 ) ) | ( global::haxe.root.Std.random(255) << 8 ) ) | global::haxe.root.Std.random(255) );
				return @value;
			}
		}
		
		
		
		
		
		
		
		
		public global::seedyrng.GeneratorInterface generator;
		
		public virtual long get_seed() {
			return this.generator.get_seed();
		}
		
		
		public virtual long set_seed(long @value) {
			return this.generator.set_seed(@value);
		}
		
		
		public virtual global::haxe.io.Bytes get_state() {
			return this.generator.get_state();
		}
		
		
		public virtual global::haxe.io.Bytes set_state(global::haxe.io.Bytes @value) {
			return this.generator.set_state(@value);
		}
		
		
		public virtual bool get_usesAllBits() {
			return this.generator.get_usesAllBits();
		}
		
		
		public virtual int nextInt() {
			return this.generator.nextInt();
		}
		
		
		public virtual int nextFullInt() {
			unchecked {
				if (this.generator.get_usesAllBits()) {
					return this.generator.nextInt();
				}
				else {
					int num1 = this.generator.nextInt();
					int num2 = this.generator.nextInt();
					num2 = ( ((int) (( ((uint) (num2) ) >> 16 )) ) | ( num2 << 16 ) );
					return ( num1 ^ num2 );
				}
				
			}
		}
		
		
		public virtual void setStringSeed(string seed) {
			this.setBytesSeed(global::haxe.io.Bytes.ofString(seed, null));
		}
		
		
		public virtual void setBytesSeed(global::haxe.io.Bytes seed) {
			unchecked {
				global::haxe.io.Bytes hash = global::haxe.crypto.Sha1.make(seed);
				int pos = 4;
				this.set_seed(((long) (( ( ((long) (((int) (( ( ( ((int) (hash.b[pos]) ) | ( ((int) (hash.b[( pos + 1 )]) ) << 8 ) ) | ( ((int) (hash.b[( pos + 2 )]) ) << 16 ) ) | ( ((int) (hash.b[( pos + 3 )]) ) << 24 ) )) )) ) << 32 ) | ( ((long) (((int) (( ( ( ((int) (hash.b[0]) ) | ( ((int) (hash.b[1]) ) << 8 ) ) | ( ((int) (hash.b[2]) ) << 16 ) ) | ( ((int) (hash.b[3]) ) << 24 ) )) )) ) & 0xffffffffL ) )) ));
			}
		}
		
		
		public virtual double random() {
			unchecked {
				int upper = ( this.nextFullInt() & 2097151 );
				uint lower = ((uint) (this.nextFullInt()) );
				double floatNum = ( lower + ( upper * global::System.Math.Pow(((double) (2) ), ((double) (32) )) ) );
				double result = ( floatNum * global::System.Math.Pow(((double) (2) ), ((double) (-53) )) );
				return result;
			}
		}
		
		
		public virtual int randomInt(int lower, int upper) {
			unchecked {
				return ( ((int) (global::System.Math.Floor(((double) (( this.random() * (( ( upper - lower ) + 1 )) )) ))) ) + lower );
			}
		}
		
		
		public virtual double uniform(double lower, double upper) {
			return ( ( this.random() * (( upper - lower )) ) + lower );
		}
		
		
		public virtual T choice<T>(global::haxe.root.Array<T> array) {
			unchecked {
				return array[this.randomInt(0, ( array.length - 1 ))];
			}
		}
		
		
		public virtual void shuffle<T>(global::haxe.root.Array<T> array) {
			unchecked {
				int _g = 0;
				int _g1 = ( array.length - 1 );
				while (( _g < _g1 )) {
					int index = _g++;
					int randIndex = this.randomInt(index, ( array.length - 1 ));
					T tempA = array[index];
					T tempB = array[randIndex];
					array[index] = tempB;
					array[randIndex] = tempA;
				}
				
			}
		}
		
		
		public override object __hx_setField(string field, int hash, object @value, bool handleProperties) {
			unchecked {
				switch (hash) {
					case 342947923:
					{
						this.generator = ((global::seedyrng.GeneratorInterface) (@value) );
						return @value;
					}
					
					
					case 67859985:
					{
						this.set_state(((global::haxe.io.Bytes) (@value) ));
						return @value;
					}
					
					
					case 1280345457:
					{
						this.set_seed(((long) (@value) ));
						return @value;
					}
					
					
					default:
					{
						return base.__hx_setField(field, hash, @value, handleProperties);
					}
					
				}
				
			}
		}
		
		
		public override object __hx_getField(string field, int hash, bool throwErrors, bool isCheck, bool handleProperties) {
			unchecked {
				switch (hash) {
					case 1692222969:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "shuffle", 1692222969)) );
					}
					
					
					case 1085259617:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "choice", 1085259617)) );
					}
					
					
					case 895762740:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "uniform", 895762740)) );
					}
					
					
					case 658867884:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "randomInt", 658867884)) );
					}
					
					
					case 932127235:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "random", 932127235)) );
					}
					
					
					case 362122106:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "setBytesSeed", 362122106)) );
					}
					
					
					case 533026084:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "setStringSeed", 533026084)) );
					}
					
					
					case 645494253:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "nextFullInt", 645494253)) );
					}
					
					
					case 624859580:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "nextInt", 624859580)) );
					}
					
					
					case 194589554:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "get_usesAllBits", 194589554)) );
					}
					
					
					case 721796724:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "set_state", 721796724)) );
					}
					
					
					case 1203032680:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "get_state", 1203032680)) );
					}
					
					
					case 2053675630:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "set_seed", 2053675630)) );
					}
					
					
					case 1275805946:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "get_seed", 1275805946)) );
					}
					
					
					case 342947923:
					{
						return this.generator;
					}
					
					
					case 1253538779:
					{
						return this.get_usesAllBits();
					}
					
					
					case 67859985:
					{
						return this.get_state();
					}
					
					
					case 1280345457:
					{
						return this.get_seed();
					}
					
					
					default:
					{
						return base.__hx_getField(field, hash, throwErrors, isCheck, handleProperties);
					}
					
				}
				
			}
		}
		
		
		public override object __hx_invokeField(string field, int hash, object[] dynargs) {
			unchecked {
				switch (hash) {
					case 1692222969:
					{
						this.shuffle<object>(((global::haxe.root.Array<object>) (global::haxe.root.Array<object>.__hx_cast<object>(((global::haxe.root.Array) (dynargs[0]) ))) ));
						break;
					}
					
					
					case 1085259617:
					{
						return this.choice<object>(((global::haxe.root.Array<object>) (global::haxe.root.Array<object>.__hx_cast<object>(((global::haxe.root.Array) (dynargs[0]) ))) ));
					}
					
					
					case 895762740:
					{
						return this.uniform(((double) (global::haxe.lang.Runtime.toDouble(dynargs[0])) ), ((double) (global::haxe.lang.Runtime.toDouble(dynargs[1])) ));
					}
					
					
					case 658867884:
					{
						return this.randomInt(((int) (global::haxe.lang.Runtime.toInt(dynargs[0])) ), ((int) (global::haxe.lang.Runtime.toInt(dynargs[1])) ));
					}
					
					
					case 932127235:
					{
						return this.random();
					}
					
					
					case 362122106:
					{
						this.setBytesSeed(((global::haxe.io.Bytes) (dynargs[0]) ));
						break;
					}
					
					
					case 533026084:
					{
						this.setStringSeed(global::haxe.lang.Runtime.toString(dynargs[0]));
						break;
					}
					
					
					case 645494253:
					{
						return this.nextFullInt();
					}
					
					
					case 624859580:
					{
						return this.nextInt();
					}
					
					
					case 194589554:
					{
						return this.get_usesAllBits();
					}
					
					
					case 721796724:
					{
						return this.set_state(((global::haxe.io.Bytes) (dynargs[0]) ));
					}
					
					
					case 1203032680:
					{
						return this.get_state();
					}
					
					
					case 2053675630:
					{
						return this.set_seed(((long) (dynargs[0]) ));
					}
					
					
					case 1275805946:
					{
						return this.get_seed();
					}
					
					
					default:
					{
						return base.__hx_invokeField(field, hash, dynargs);
					}
					
				}
				
				return null;
			}
		}
		
		
		public override void __hx_getFields(global::haxe.root.Array<string> baseArr) {
			baseArr.push("generator");
			baseArr.push("usesAllBits");
			baseArr.push("state");
			baseArr.push("seed");
			base.__hx_getFields(baseArr);
		}
		
		
	}
}

