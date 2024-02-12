using System.Runtime.InteropServices;

namespace SteamAchievements.API.Types;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct AppDataChanged
{
    public uint Id;
    public bool Result;
}