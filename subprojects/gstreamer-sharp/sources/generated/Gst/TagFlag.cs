// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Gst {

	using System;
	using System.Runtime.InteropServices;

#region Autogenerated code
	[GLib.GType (typeof (Gst.TagFlagGType))]
	public enum TagFlag {

		Undefined = 0,
		Meta = 1,
		Encoded = 2,
		Decoded = 3,
		Count = 4,
	}

	internal class TagFlagGType {
		[DllImport ("gstreamer-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr gst_tag_flag_get_type ();

		public static GLib.GType GType {
			get {
				return new GLib.GType (gst_tag_flag_get_type ());
			}
		}
	}
#endregion
}
