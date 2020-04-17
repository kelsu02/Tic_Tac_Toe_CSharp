using System;
using System.Linq;

namespace TicTacToe
{
    class Game
    {
        private Square[,] _board = new Square[3, 3];

        public void PlayGame()
        {
            Player player = Player.X;

            bool keepPlaying = true;

            while (keepPlaying)
            {
                DisplayBoard();
                keepPlaying = PlayerMove(player);
                if (!keepPlaying)
                    return;
                keepPlaying = CheckForWin(player);
                if (!keepPlaying)
                    return;
                player = 3 - player;  //swaps players
                Console.Clear();
            }
        }

        private void DisplayBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int k = 0; k < 3; k++)
                {
                    Console.Write(" " + _board[i, k]);
                }
                Console.WriteLine();
            }
        }

        private bool PlayerMove(Player player)
        {
            int row;
            int column;
            bool goodEntry = false;
            while(goodEntry == false)
            {
                row = Methods.IsNumber($"{player}: Enter row for placement: ", 1, 3);
                column = Methods.IsNumber($"{player}: Enter column for placement: ", 1, 3);
                if (_board[row - 1, column - 1].Owner != Player.Empty)
                {
                    Console.WriteLine("Square is already occupied");
                    goodEntry = false;
                }
                else
                {
                    _board[row - 1, column - 1] = new Square(player);
                    goodEntry = true;
                }
            }
            return true;

        }

        private bool CheckForWin(Player player)
        {
            if ((_board[0, 0].Owner == player && _board[0, 1].Owner == player && _board[0,2].Owner == player) ||
                (_board[1, 0].Owner == player && _board[1, 1].Owner == player && _board[1, 2].Owner == player) ||
                (_board[2, 0].Owner == player && _board[2, 1].Owner == player && _board[2, 2].Owner == player) ||
                (_board[0, 0].Owner == player && _board[1, 0].Owner == player && _board[2, 0].Owner == player) ||
                (_board[0, 1].Owner == player && _board[1, 1].Owner == player && _board[2, 1].Owner == player) ||
                (_board[0, 2].Owner == player && _board[1, 2].Owner == player && _board[2, 2].Owner == player) ||
                (_board[0, 0].Owner == player && _board[1, 1].Owner == player && _board[2, 2].Owner == player) ||
                (_board[0, 2].Owner == player && _board[1, 1].Owner == player && _board[2, 0].Owner == player))
            {
                DisplayBoard();
                Console.WriteLine($"{player} is the winner!");
                return false;
            }
            if (_board[0, 0].Owner != Player.Empty && _board[0, 1].Owner != Player.Empty && _board[0, 2].Owner != Player.Empty &&
                _board[1, 0].Owner != Player.Empty && _board[1, 1].Owner != Player.Empty && _board[1, 2].Owner != Player.Empty &&
                _board[2, 0].Owner != Player.Empty && _board[2, 1].Owner != Player.Empty && _board[2, 2].Owner != Player.Empty)
            {
                DisplayBoard();
                Console.WriteLine("Game is a draw");
                return false;
            }

            return true;
        }

        //LINQ check where empty is default check and see if check the board where owner is empty if nothing empty no winner game over

    }
}
