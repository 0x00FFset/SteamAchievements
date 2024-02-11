using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Quic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SteamKit2;
using WebServer;

namespace SteamAchievements;

internal static class Program
{

    private static void Main(string[] args)
    {
        WebServer.Program.Main(args);
    }

}