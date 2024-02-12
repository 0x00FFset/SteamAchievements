using System.Runtime.InteropServices;

namespace SteamAchievements.API.Types;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct UserItemsReceived
{
    public ulong GameId;
    public int Unknown;
    public int ItemCount;
}