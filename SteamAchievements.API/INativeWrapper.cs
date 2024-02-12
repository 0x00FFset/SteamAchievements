namespace SteamAchievements.API;

public interface INativeWrapper
{
    void SetupFunctions(IntPtr objectAddress);
}