using System.Runtime.InteropServices;

namespace SteamAchievements.API.Types;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct UserStatsReceived
{
    public ulong GameId;
    public int Result;
}