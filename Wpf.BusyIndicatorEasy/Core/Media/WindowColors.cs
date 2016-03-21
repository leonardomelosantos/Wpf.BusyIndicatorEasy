using System;
using System.Windows.Media;

namespace Wpf.BusyIndicatorEasy.Core.Media
{
    public static class WindowColors
    {
        private static Color? _colorizationMode;
        private static bool? _colorizationOpaqueBlend;

        public static Color ColorizationColor
        {
            get
            {
                if (_colorizationMode.HasValue)
                    return _colorizationMode.Value;

                try
                {
                    _colorizationMode = WindowColors.GetDWMColorValue("ColorizationColor");
                }
                catch
                {
                    _colorizationMode = Color.FromArgb(255, 175, 175, 175);
                }

                return _colorizationMode.Value;
            }
        }

        public static bool ColorizationOpaqueBlend
        {
            get
            {
                if (_colorizationOpaqueBlend.HasValue)
                    return _colorizationOpaqueBlend.Value;

                try
                {
                    _colorizationOpaqueBlend = WindowColors.GetDWMBoolValue("ColorizationOpaqueBlend");
                }
                catch
                {
                    // If for any reason (for example, a SecurityException for XBAP apps)
                    // we cannot read the value in the registry, fall back on some color.
                    _colorizationOpaqueBlend = false;
                }

                return _colorizationOpaqueBlend.Value;
            }
        }

        private static int GetDWMIntValue(string keyName)
        {
            // This value is not accessible throught the standard WPF API.
            // We must dig into the registry to get the value.
            var curUser = Microsoft.Win32.Registry.CurrentUser;
            var subKey = curUser.CreateSubKey(
                @"Software\Microsoft\Windows\DWM",
                Microsoft.Win32.RegistryKeyPermissionCheck.ReadSubTree
#if VS2008
        );
#else
                , Microsoft.Win32.RegistryOptions.None);
#endif
            return (int) subKey.GetValue(keyName);
        }

        private static Color GetDWMColorValue(string keyName)
        {
            int value = WindowColors.GetDWMIntValue(keyName);
            byte[] bytes = BitConverter.GetBytes(value);
            return new Color()
            {
                B = bytes[0],
                G = bytes[1],
                R = bytes[2],
                A = 255
            };
        }

        private static bool GetDWMBoolValue(string keyName)
        {
            int value = WindowColors.GetDWMIntValue(keyName);
            return (value != 0);
        }
    }
}