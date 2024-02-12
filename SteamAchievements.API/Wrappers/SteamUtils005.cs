using System.Runtime.InteropServices;
using SteamAchievements.API.Interfaces;

namespace SteamAchievements.API.Wrappers;

public class SteamUtils005 : NativeWrapper<ISteamUtils005>
{
    #region GetConnectedUniverse
    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    private delegate int NativeGetConnectedUniverse(IntPtr self);

    public int GetConnectedUniverse()
    {
        return this.Call<int, NativeGetConnectedUniverse>(this.Functions.GetConnectedUniverse, this.ObjectAddress);
    }
    #endregion

    #region GetIPCountry
    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    private delegate IntPtr NativeGetIPCountry(IntPtr self);

    public string GetIPCountry()
    {
        var result = this.Call<IntPtr, NativeGetIPCountry>(this.Functions.GetIPCountry, this.ObjectAddress);
        return NativeStrings.PointerToString(result);
    }
    #endregion

    #region GetImageSize
    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: MarshalAs(UnmanagedType.I1)]
    private delegate bool NativeGetImageSize(IntPtr self, int index, out int width, out int height);

    public bool GetImageSize(int index, out int width, out int height)
    {
        var call = this.GetFunction<NativeGetImageSize>(this.Functions.GetImageSize);
        return call(this.ObjectAddress, index, out width, out height);
    }
    #endregion

    #region GetImageRGBA
    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: MarshalAs(UnmanagedType.I1)]
    private delegate bool NativeGetImageRGBA(IntPtr self, int index, byte[] buffer, int length);

    public bool GetImageRGBA(int index, byte[] data)
    {
        if (data == null)
        {
            throw new ArgumentNullException("data");
        }
        var call = this.GetFunction<NativeGetImageRGBA>(this.Functions.GetImageRGBA);
        return call(this.ObjectAddress, index, data, data.Length);
    }
    #endregion

    #region GetAppID
    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    private delegate uint NativeGetAppId(IntPtr self);

    public uint GetAppId()
    {
        return this.Call<uint, NativeGetAppId>(this.Functions.GetAppID, this.ObjectAddress);
    }
    #endregion
}