namespace SteamAchievements.API;

public interface ICallback
{
    int Id { get; }
    bool IsServer { get; }
    void Run(IntPtr param);
}