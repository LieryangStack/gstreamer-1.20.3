// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Gst.WebRTC {

	using System;
	using System.Runtime.InteropServices;

#region Autogenerated code
	[GLib.GType (typeof (Gst.WebRTC.WebRTCBundlePolicyGType))]
	public enum WebRTCBundlePolicy {

		None = 0,
		Balanced = 1,
		MaxCompat = 2,
		MaxBundle = 3,
	}

	internal class WebRTCBundlePolicyGType {
		[DllImport ("gstwebrtc-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr gst_webrtc_bundle_policy_get_type ();

		public static GLib.GType GType {
			get {
				return new GLib.GType (gst_webrtc_bundle_policy_get_type ());
			}
		}
	}
#endregion
}
