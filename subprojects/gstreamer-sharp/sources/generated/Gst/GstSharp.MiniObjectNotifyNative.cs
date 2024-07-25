// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace GstSharp {

	using System;
	using System.Runtime.InteropServices;

#region Autogenerated code
	[UnmanagedFunctionPointer (CallingConvention.Cdecl)]
	internal delegate void MiniObjectNotifyNative(IntPtr user_data, IntPtr obj);

	internal class MiniObjectNotifyInvoker {

		MiniObjectNotifyNative native_cb;
		IntPtr __data;
		GLib.DestroyNotify __notify;

		~MiniObjectNotifyInvoker ()
		{
			if (__notify == null)
				return;
			__notify (__data);
		}

		internal MiniObjectNotifyInvoker (MiniObjectNotifyNative native_cb) : this (native_cb, IntPtr.Zero, null) {}

		internal MiniObjectNotifyInvoker (MiniObjectNotifyNative native_cb, IntPtr data) : this (native_cb, data, null) {}

		internal MiniObjectNotifyInvoker (MiniObjectNotifyNative native_cb, IntPtr data, GLib.DestroyNotify notify)
		{
			this.native_cb = native_cb;
			__data = data;
			__notify = notify;
		}

		internal Gst.MiniObjectNotify Handler {
			get {
				return new Gst.MiniObjectNotify(InvokeNative);
			}
		}

		void InvokeNative (Gst.MiniObject obj)
		{
			native_cb (__data, obj == null ? IntPtr.Zero : obj.Handle);
		}
	}

	internal class MiniObjectNotifyWrapper {

		public void NativeCallback (IntPtr user_data, IntPtr obj)
		{
			try {
				managed (obj == IntPtr.Zero ? null : (Gst.MiniObject) GLib.Opaque.GetOpaque (obj, typeof (Gst.MiniObject), false));
				if (release_on_call)
					gch.Free ();
			} catch (Exception e) {
				GLib.ExceptionManager.RaiseUnhandledException (e, false);
			}
		}

		bool release_on_call = false;
		GCHandle gch;

		public void PersistUntilCalled ()
		{
			release_on_call = true;
			gch = GCHandle.Alloc (this);
		}

		internal MiniObjectNotifyNative NativeDelegate;
		Gst.MiniObjectNotify managed;

		public MiniObjectNotifyWrapper (Gst.MiniObjectNotify managed)
		{
			this.managed = managed;
			if (managed != null)
				NativeDelegate = new MiniObjectNotifyNative (NativeCallback);
		}

		public static Gst.MiniObjectNotify GetManagedDelegate (MiniObjectNotifyNative native)
		{
			if (native == null)
				return null;
			MiniObjectNotifyWrapper wrapper = (MiniObjectNotifyWrapper) native.Target;
			if (wrapper == null)
				return null;
			return wrapper.managed;
		}
	}
#endregion
}
