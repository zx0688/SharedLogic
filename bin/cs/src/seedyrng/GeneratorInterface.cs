// Generated by Haxe 4.3.3
using haxe.root;

#pragma warning disable 109, 114, 219, 429, 168, 162
namespace seedyrng {
	public interface GeneratorInterface : global::haxe.lang.IHxObject {
		
		[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
		long get_seed();
		
		[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
		long set_seed(long @value);
		
		[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
		global::haxe.io.Bytes get_state();
		
		[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
		global::haxe.io.Bytes set_state(global::haxe.io.Bytes @value);
		
		[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
		bool get_usesAllBits();
		
		int nextInt();
		
	}
}


