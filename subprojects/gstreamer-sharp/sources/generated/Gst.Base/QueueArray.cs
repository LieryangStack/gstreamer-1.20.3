// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Gst.Base {

	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Runtime.InteropServices;

#region Autogenerated code
	public partial class QueueArray : GLib.Opaque {

		[DllImport("gstbase-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern void gst_queue_array_push_tail_struct(IntPtr raw, IntPtr p_struct);

		public void PushTailStruct(IntPtr p_struct) {
			gst_queue_array_push_tail_struct(Handle, p_struct);
		}

		public void PushTailStruct() {
			PushTailStruct (IntPtr.Zero);
		}

		public QueueArray(IntPtr raw) : base(raw) {}


		// Internal representation of the wrapped structure ABI.
		static GLib.AbiStruct _abi_info = null;
		static public GLib.AbiStruct abi_info {
			get {
				if (_abi_info == null)
					_abi_info = new GLib.AbiStruct (new List<GLib.AbiField>{ 
					});

				return _abi_info;
			}
		}


		// End of the ABI representation.

#endregion
	}
}
