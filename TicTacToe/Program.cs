using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            string playagain = "Y";

            while(playagain == "Y")
            {
                Game game = new Game();
                game.PlayGame();
                Console.WriteLine("Game Over");
                playagain = Methods.StringInput("Would you like to play again? ( Y / N ): ", "Y", "N");
                Console.Clear();
            }

            Console.WriteLine("Thanks for playing");

        }
    }
}
