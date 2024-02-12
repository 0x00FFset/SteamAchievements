using System.Runtime.InteropServices;
using SteamAchievements.API.Interfaces;

namespace SteamAchievements.API.Wrappers;

public class SteamApps008 : NativeWrapper<ISteamApps008>
{
    #region IsSubscribed
    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: MarshalAs(UnmanagedType.I1)]
    private delegate bool NativeIsSubscribedApp(IntPtr self, uint gameId);

    public bool IsSubscribedApp(uint gameId)
    {
        return this.Call<bool, NativeIsSubscribedApp>(this.Functions.IsSubscribedApp, this.ObjectAddress, gameId);
    }
    #endregion

    #region GetCurrentGameLanguage
    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    private delegate IntPtr NativeGetCurrentGameLanguage(IntPtr self);

    public string GetCurrentGameLanguage()
    {
        var languagePointer = this.Call<IntPtr, NativeGetCurrentGameLanguage>(
            this.Functions.GetCurrentGameLanguage,
            this.ObjectAddress);
        return NativeStrings.PointerToString(languagePointer);
    }
    #endregion
}