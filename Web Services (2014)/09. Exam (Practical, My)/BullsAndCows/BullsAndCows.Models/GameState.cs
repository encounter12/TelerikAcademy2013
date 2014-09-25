namespace BullsAndCows.Models
{
    using System;
    using System.Linq;

    public enum GameState
    {
        WaitingForOpponent = 0,
        RedInTurn = 1, 
        BlueInTurn = 2
    }
}
