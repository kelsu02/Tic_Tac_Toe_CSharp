using System;

namespace TicTacToe
{
    public enum Player { Empty = 0, X, O}

    public struct Square
    {
        public Player Owner { get; }

        public Square(Player owner)
        {
            Owner = owner;
        }

        public override string ToString()
        {
            return Owner switch
            {
                Player.Empty => ".",
                Player.X => "X",
                Player.O => "O",
                _ => throw new Exception("Invalid state"),
            };
        }
    }
}
