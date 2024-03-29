﻿namespace SteamAchievements.API.Types;

public enum ItemRequestResult
{
    InvalidValue = -1,
    Ok = 0,
    Denied = 1,
    ServerError = 2,
    Timeout = 3,
    Invalid = 4,
    NoMatch = 5,
    UnknownError = 6,
    NotLoggedOn = 7,
}