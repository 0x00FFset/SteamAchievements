using System.Runtime.InteropServices;
using SteamAchievements.API.Interfaces;

namespace SteamAchievements.API.Wrappers;

public class SteamUser012 : NativeWrapper<ISteamUser012>
{
    #region IsLoggedIn
    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: MarshalAs(UnmanagedType.I1)]
    private delegate bool NativeLoggedOn(IntPtr self);

    public bool IsLoggedIn()
    {
        return this.Call<bool, NativeLoggedOn>(this.Functions.LoggedOn, this.ObjectAddress);
    }
    #endregion

    #region GetSteamID
    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    private delegate void NativeGetSteamId(IntPtr self, out ulong steamId);

    public ulong GetSteamId()
    {
        var call = this.GetFunction<NativeGetSteamId>(this.Functions.GetSteamID);
        ulong steamId;
        call(this.ObjectAddress, out steamId);
        return steamId;
    }
    #endregion
}