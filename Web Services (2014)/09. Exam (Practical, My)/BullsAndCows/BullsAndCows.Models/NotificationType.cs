namespace BullsAndCows.Models
{
    using System;
    using System.Linq;

    public enum NotificationType
    {
        GameJoined = 0,
        YourTurn = 1,
        OpponentTurn = 2,
        GameWon = 3,
        GameLost = 4
    }
}
