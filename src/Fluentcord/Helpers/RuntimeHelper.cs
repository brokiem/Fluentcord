using System;
using System.Runtime.InteropServices;

namespace Fluentcord.Helpers;

public static partial class RuntimeHelper {
    
    [LibraryImport("user32.dll", EntryPoint = "SetPropW", SetLastError = true, StringMarshalling = StringMarshalling.Utf16)]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static partial bool SetPropW(IntPtr hWnd, string lpString, IntPtr hData);
}