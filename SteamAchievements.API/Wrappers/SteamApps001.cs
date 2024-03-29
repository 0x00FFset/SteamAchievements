﻿using System.Runtime.InteropServices;
using SteamAchievements.API.Interfaces;

namespace SteamAchievements.API.Wrappers;

public class SteamApps001 : NativeWrapper<ISteamApps001>
{
    #region GetAppData
    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    private delegate int NativeGetAppData(
        IntPtr self,
        uint appId,
        IntPtr key,
        IntPtr value,
        int valueLength);

    public string GetAppData(uint appId, string key)
    {
        using (var nativeHandle = NativeStrings.StringToStringHandle(key))
        {
            const int valueLength = 1024;
            var valuePointer = Marshal.AllocHGlobal(valueLength);
            int result = this.Call<int, NativeGetAppData>(
                this.Functions.GetAppData,
                this.ObjectAddress,
                appId,
                nativeHandle.Handle,
                valuePointer,
                valueLength);
            var value = result == 0 ? null : NativeStrings.PointerToString(valuePointer, valueLength);
            Marshal.FreeHGlobal(valuePointer);
            return value;
        }
    }
    #endregion
}