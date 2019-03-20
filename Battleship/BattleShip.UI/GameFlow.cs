using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class GameFlow
    {

        public void GameStart()
        {
            string again = "y";
            bool playAgain = true;

            while (playAgain == true)
            {
                ConsoleIO.DisplayTitle();

                Players player1 = new Players();
                setUpPlayer(player1);


                Players player2 = new Players();
                setUpPlayer(player2);

                Random number = new Random();
                ShotStatus shot = new ShotStatus();


                int whoseTurn = number.Next(1, 2);

                while (shot != ShotStatus.Victory)
                {
                    if (whoseTurn == 1)
                    {
                        ConsoleIO.PlayerBoard(player1, player2);
                        shot = ConsoleIO.DisplayShot(player1);
                        whoseTurn = 2;
                    }
                    else if (whoseTurn == 2)
                    {
                        ConsoleIO.PlayerBoard(player2, player1);
                        shot = ConsoleIO.DisplayShot(player2);
                        whoseTurn = 1;
                    }

                }


                    Console.Write("Wanna to play again? (y/n): ");
                    again = Console.ReadLine();

                    if (again == "y")
                    {
                        playAgain = true;
                        Console.Clear();
                    }
                    else if (again == "n")
                    {
                        Console.Write("Thank you for playing!");
                        playAgain = false;
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.Write("error message");
                    }
                
            }
        }
        public void setUpPlayer(Players currentPlayer)
        {
            currentPlayer.Name = ConsoleIO.GetNameFromUser("Please Enter Your Name:");
            Console.Clear();
            ConsoleIO.PlaceShip(currentPlayer.Name, currentPlayer.Board);
            Console.Clear();
                       
        }        
    }
}
