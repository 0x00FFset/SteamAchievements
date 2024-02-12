﻿using System.Runtime.InteropServices;

namespace SteamAchievements.API;

[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
internal struct NativeClass
{
    public IntPtr VirtualTable;
}