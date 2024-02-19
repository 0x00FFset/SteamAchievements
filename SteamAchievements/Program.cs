
namespace SteamAchievements;

internal static class Program
{

    [STAThread]
    private static void Main()
    {
        // current directory
        if (API.Steam.GetInstallPath() == Directory.GetCurrentDirectory())
        {
            Console.WriteLine("SteamAchievements is running from the Steam directory. This is not supported.");
        }

        using (var client = new API.Client())
        {
            try
            {
                client.Initialize(0);
            }
            catch (API.ClientInitializeException e)
            {
                if (string.IsNullOrEmpty(e.Message) == false)
                {
                    Console.WriteLine(e.Message);
                }
                else
                {
                    Console.WriteLine("An error occurred while initializing the Steam client.");
                }
                return;
            }
            catch (DllNotFoundException)
            {
                Console.WriteLine("Failed to load SteamClient.");
                return;
            }

            Console.WriteLine("SteamAchievements is running.");
        }
    }
}