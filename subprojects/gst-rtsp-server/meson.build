project('gst-rtsp-server', 'c',
  version : '1.20.3',
  meson_version : '>= 0.59',
  default_options : ['warning_level=1', 'buildtype=debugoptimized'])

gst_version = meson.project_version()
version_arr = gst_version.split('.')
gst_version_major = version_arr[0].to_int()
gst_version_minor = version_arr[1].to_int()
gst_version_micro = version_arr[2].to_int()
 if version_arr.length() == 4
  gst_version_nano = version_arr[3].to_int()
else
  gst_version_nano = 0
endif
gst_version_is_stable = gst_version_minor.is_even()
gst_version_is_dev = gst_version_minor.is_odd() and gst_version_micro < 90

glib_req = '>= 2.56.0'

if gst_version_is_stable
  gst_req = '>= @0@.@1@.0'.format(gst_version_major, gst_version_minor)
else
  gst_req = '>= ' + gst_version
endif

api_version = '1.0'
soversion = 0
# maintaining compatibility with the previous libtool versioning
# current = minor * 100 + micro
curversion = gst_version_minor * 100 + gst_version_micro
libversion = '@0@.@1@.0'.format(soversion, curversion)
osxversion = curversion + 1

plugins_install_dir = '@0@/gstreamer-1.0'.format(get_option('libdir'))

cc = meson.get_compiler('c')

cdata = configuration_data()

if cc.has_link_argument('-Wl,-Bsymbolic-functions')
  add_project_link_arguments('-Wl,-Bsymbolic-functions', language : 'c')
endif

# Symbol visibility
if cc.get_id() == 'msvc'
  export_define = '__declspec(dllexport) extern'
elif cc.has_argument('-fvisibility=hidden')
  add_project_arguments('-fvisibility=hidden', language: 'c')
  export_define = 'extern __attribute__ ((visibility ("default")))'
else
  export_define = 'extern'
endif

# Passing this through the command line would be too messy
cdata.set('GST_API_EXPORT', export_define)

# Disable strict aliasing
if cc.has_argument('-fno-strict-aliasing')
  add_project_arguments('-fno-strict-aliasing', language: 'c')
endif

# Define G_DISABLE_DEPRECATED for development versions
if gst_version_is_dev
  message('Disabling deprecated GLib API')
  add_project_arguments('-DG_DISABLE_DEPRECATED', language: 'c')
endif

cast_checks = get_option('gobject-cast-checks')
if cast_checks.disabled() or (cast_checks.auto() and not gst_version_is_dev)
  message('Disabling GLib cast checks')
  add_project_arguments('-DG_DISABLE_CAST_CHECKS', language: 'c')
endif

glib_asserts = get_option('glib-asserts')
if glib_asserts.disabled() or (glib_asserts.auto() and not gst_version_is_dev)
  message('Disabling GLib asserts')
  add_project_arguments('-DG_DISABLE_ASSERT', language: 'c')
endif

glib_checks = get_option('glib-checks')
if glib_checks.disabled() or (glib_checks.auto() and not gst_version_is_dev)
  message('Disabling GLib checks')
  add_project_arguments('-DG_DISABLE_CHECKS', language: 'c')
endif

cdata.set_quoted('GETTEXT_PACKAGE', 'gst-rtsp-server-1.0')
cdata.set_quoted('PACKAGE', 'gst-rtsp-server')
cdata.set_quoted('VERSION', gst_version)
cdata.set_quoted('PACKAGE_VERSION', gst_version)
cdata.set_quoted('GST_API_VERSION', api_version)
cdata.set_quoted('GST_LICENSE', 'LGPL')

# FIXME: ENABLE_NLS (currently also missing from autotools build)
# cdata.set('ENABLE_NLS', true)
# cdata.set_quoted('LOCALEDIR', join_paths(get_option('prefix'), get_option('localedir')))

# GStreamer package name and origin url
gst_package_name = get_option('package-name')
if gst_package_name == ''
  if gst_version_nano == 0
    gst_package_name = 'GStreamer RTSP Server Library source release'
  elif gst_version_nano == 1
    gst_package_name = 'GStreamer RTSP Server Library git'
  else
    gst_package_name = 'GStreamer RTSP Server Library prerelease'
  endif
endif
cdata.set_quoted('GST_PACKAGE_NAME', gst_package_name)
cdata.set_quoted('GST_PACKAGE_ORIGIN', get_option('package-origin'))

rtspserver_args = ['-DHAVE_CONFIG_H']

warning_flags = [
  '-Wmissing-declarations',
  '-Wmissing-prototypes',
  '-Wredundant-decls',
  '-Wundef',
  '-Wwrite-strings',
  '-Wformat',
  '-Wformat-nonliteral',
  '-Wformat-security',
  '-Wold-style-definition',
  '-Waggregate-return',
  '-Winit-self',
  '-Wmissing-include-dirs',
  '-Waddress',
  '-Wno-multichar',
  '-Wdeclaration-after-statement',
  '-Wvla',
  '-Wpointer-arith',
]

foreach extra_arg : warning_flags
  if cc.has_argument (extra_arg)
    add_project_arguments([extra_arg], language: 'c')
  endif
endforeach

rtspserver_incs = include_directories('gst/rtsp-server', '.')

glib_dep = dependency('glib-2.0', version : glib_req,
  fallback: ['glib', 'libglib_dep'])
gst_dep = dependency('gstreamer-1.0', version : gst_req,
  fallback : ['gstreamer', 'gst_dep'])
gstrtsp_dep = dependency('gstreamer-rtsp-1.0', version : gst_req,
  fallback : ['gst-plugins-base', 'rtsp_dep'])
gstrtp_dep = dependency('gstreamer-rtp-1.0', version : gst_req,
  fallback : ['gst-plugins-base', 'rtp_dep'])
gstsdp_dep = dependency('gstreamer-sdp-1.0', version : gst_req,
  fallback : ['gst-plugins-base', 'sdp_dep'])
gstapp_dep = dependency('gstreamer-app-1.0', version : gst_req,
  fallback : ['gst-plugins-base', 'app_dep'])
gstnet_dep = dependency('gstreamer-net-1.0', version : gst_req,
  fallback : ['gstreamer', 'gst_net_dep'])
if host_machine.system() != 'windows'
  gstcheck_dep = dependency('gstreamer-check-1.0', version : gst_req,
    required : get_option('tests'),
    fallback : ['gstreamer', 'gst_check_dep'])
endif

# Disable compiler warnings for unused variables and args if gst debug system is disabled
if gst_dep.type_name() == 'internal'
  gst_debug_disabled = not subproject('gstreamer').get_variable('gst_debug')
else
  # We can't check that in the case of subprojects as we won't
  # be able to build against an internal dependency (which is not built yet)
  gst_debug_disabled = cc.has_header_symbol('gst/gstconfig.h', 'GST_DISABLE_GST_DEBUG', dependencies: gst_dep)
endif

if gst_debug_disabled
  message('GStreamer debug system is disabled')
  add_project_arguments(cc.get_supported_arguments(['-Wno-unused']), language: 'c')
else
  message('GStreamer debug system is enabled')
endif

gir = find_program('g-ir-scanner', required : get_option('introspection'))
gnome = import('gnome')
build_gir = gir.found() and (not meson.is_cross_build() or get_option('introspection').enabled())
gir_init_section = [ '--add-init-section=extern void gst_init(gint*,gchar**);' + \
    'g_setenv("GST_REGISTRY_1.0", "@0@", TRUE);'.format(meson.current_build_dir() + '/gir_empty_registry.reg') + \
    'g_setenv("GST_PLUGIN_PATH_1_0", "", TRUE);' + \
    'g_setenv("GST_PLUGIN_SYSTEM_PATH_1_0", "", TRUE);' + \
    'gst_init(NULL,NULL);', '--quiet']

pkgconfig = import('pkgconfig')
plugins_pkgconfig_install_dir = join_paths(plugins_install_dir, 'pkgconfig')
if get_option('default_library') == 'shared'
  # If we don't build static plugins there is no need to generate pc files
  plugins_pkgconfig_install_dir = disabler()
endif

plugins = []
pkgconfig_subdirs = ['gstreamer-1.0']
static_build = get_option('default_library') == 'static'
libraries = []

subdir('gst')
if not get_option('tests').disabled()
  subdir('tests')
endif
if not get_option('examples').disabled()
  subdir('examples')
endif
subdir('docs')

# Set release date
if gst_version_nano == 0
  extract_release_date = find_program('scripts/extract-release-date-from-doap-file.py')
  run_result = run_command(extract_release_date, gst_version, files('gst-rtsp-server.doap'), check: true)
  release_date = run_result.stdout().strip()
  cdata.set_quoted('GST_PACKAGE_RELEASE_DATETIME', release_date)
  message('Package release date: ' + release_date)
endif

configure_file(output: 'config.h', configuration: cdata)
