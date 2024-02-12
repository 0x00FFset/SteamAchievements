namespace SteamAchievements.API.Callbacks;

public class AppDataChanged : Callback<Types.AppDataChanged>
{
    public override int Id
    {
        get { return 1001; }
    }

    public override bool IsServer
    {
        get { return false; }
    }
}