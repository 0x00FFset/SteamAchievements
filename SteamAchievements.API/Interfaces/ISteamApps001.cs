﻿using System.Runtime.InteropServices;

namespace SteamAchievements.API.Interfaces;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct ISteamApps001
{
    public IntPtr GetAppData;
}