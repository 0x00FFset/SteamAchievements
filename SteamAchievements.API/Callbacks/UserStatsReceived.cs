namespace SteamAchievements.API.Callbacks;

public class UserStatsReceived : Callback<Types.UserStatsReceived>
{
    public override int Id
    {
        get { return 1101; }
    }

    public override bool IsServer
    {
        get { return false; }
    }
}