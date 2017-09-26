using System;
using ObjCRuntime;

namespace JPushiOSLibrary
{
    


public enum JPAuthorizationOptions : int
{
    None = 0,
    Badge = (1 << 0),
    Sound = (1 << 1),
    Alert = (1 << 2)
}
}
