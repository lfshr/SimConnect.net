using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace SimConnectNet.Interop
{
    
    public static class SimConnectNetInterop
    {
        [SuppressUnmanagedCodeSecurity]
        [DllImport("SimConnect.dll")]
        [MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
        public static extern uint SimConnect_Open(
            [In] ref object phSimConnect,
            [In] string szName,
            [In] IntPtr hWnd,
            [In] uint UserEventWin32,
            [In] IntPtr hEventHandle,
            [In] uint ConfigIndex);
    }
}
