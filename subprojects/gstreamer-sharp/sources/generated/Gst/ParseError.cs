// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Gst {

	using System;
	using System.Runtime.InteropServices;

#region Autogenerated code
	[GLib.GType (typeof (Gst.ParseErrorGType))]
	public enum ParseError {

		Syntax = 0,
		NoSuchElement = 1,
		NoSuchProperty = 2,
		Link = 3,
		CouldNotSetProperty = 4,
		EmptyBin = 5,
		Empty = 6,
		DelayedLink = 7,
	}

	internal class ParseErrorGType {
		[DllImport ("gstreamer-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr gst_parse_error_get_type ();

		public static GLib.GType GType {
			get {
				return new GLib.GType (gst_parse_error_get_type ());
			}
		}
	}
#endregion
}
