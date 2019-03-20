using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public static class ConsoleIO
    {

        public static void DisplayTitle()
        {

            Console.WriteLine("*******************************************");
            Console.WriteLine("   Welcome to The World of BattleShip!");
            Console.WriteLine("        Press any key to start");
            Console.WriteLine("*******************************************");
            Console.ReadKey();
            Console.Clear();




        }

        public static string GetNameFromUser(string prompt)
        {
            while (true)
            {
                
                Console.WriteLine(prompt);
                string result = Console.ReadLine();
                if (result == "" || result == string.Empty)
                {
                    Console.WriteLine("You entered a blank, please try again");
                    continue;
                }

                return result;


            }

        }

        public static void PlayerBoard()
        {
            Board playerBoard = new Board();          

            string xLetter = "ABCDEFGHIJ";
            char row = 'A';

            ShotHistory shotDisplay = new ShotHistory();
            Console.Write("   [1  2  3  4  5  6  7  8  9 10]");
            for (int x = 0; x < 10; x++)
            {
                row = xLetter[x];
                Console.Write($"\n[{row}]");

                for (int y = 0; y < 10; y++)
                {
                    Coordinate coordinate = new Coordinate(x, y);
                    shotDisplay = playerBoard.CheckCoordinate(coordinate);
                    Console.Write($"[{shotDisplay}]");

                    

                }


            }
            Console.ReadLine();
            Console.Clear();
        }

        public static void PlaceShip(string name, Board board)
        {
            Console.WriteLine($"{name} Place your ship: ");

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Place your {Enum.GetName(typeof(ShipType), (ShipType)i)}.");

                PlaceShipRequest request = new PlaceShipRequest();
                {
                    request.Coordinate = ConsoleIO.GetCoord();
                    request.Direction = ConsoleIO.GetDirection();
                    request.ShipType = (ShipType)i;
                };

                ShipPlacement spacevalidity = board.PlaceShip(request);
                switch (spacevalidity)
                {
                    case ShipPlacement.NotEnoughSpace:
                        i--;
                        Console.WriteLine("Not enough space, place somewhere else.");
                        continue;
                    case ShipPlacement.Overlap:
                        i--;
                        Console.WriteLine("Overlap another ship, place somewhere else.");
                        continue;
                    case ShipPlacement.Ok:
                        Console.WriteLine("Good spot!");
                        break;
                    default:
                        break;
                }
            }
        }

        //Need help to GetDirection
        public static ShipDirection GetDirection()
        {                         
            do
            {
                Console.WriteLine("Ship direction, U(up), D(down), L(left), R(right): ");
                string direction = Console.ReadLine();
                direction = direction.ToUpper();
                switch (direction)
                {
                    case "U":
                        return ShipDirection.Up;

                    case "D":
                        return ShipDirection.Down;

                    case "L":
                        return ShipDirection.Left;

                    case "R":
                        return ShipDirection.Right;

                    default:
                        {
                            Console.WriteLine("Invalid, try again!");
                            continue;
                        }                      
                        
                }

            } while (true);
        }

        
        public static Coordinate GetCoord()
        {
            
            string xstring = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int y = 0;
            int x = 0;

            while (true)
            {
                Console.WriteLine("Enter coordinate: ");
                string coord = Console.ReadLine();
                coord = coord.ToUpper();
                Char xChar = coord[0];
                y = int.Parse(coord.Substring(1));

                if (char.IsLetter(xChar) == true)
                {
                    for (int i = 0; i < xstring.Length; i++)
                    {
                        
                        if (xChar == xstring[i])
                        {
                            x = i + 1;                            
                        }
                        

                    }

                    if (x > 10 || x < 1)
                    {
                        Console.WriteLine("Invalid!");
                        continue;
                    }

                }
                if (y > 10 || y < 1)
                {
                    Console.WriteLine("Invalid!");
                    continue;
                }

                Coordinate xy = new Coordinate(x, y);
                return xy;
            }
            

        }

        public static void FirstToGo()
        {
            Random rng = new Random();
            int player = rng.Next(1, 3);

            
            if (player == 1)
            {
                Console.WriteLine($"Player {player} goes first");
            }
            else
            {
                Console.WriteLine($"Player {player} goes first");
            }

        }

        

        public static void DisplayShot()
        {
            ShotStatus result = new ShotStatus();

            FireShotResponse response = new FireShotResponse();


            while (true)
            {

                Console.WriteLine("Place your fireshot. ");
                ConsoleIO.GetCoord();

                switch (result)
                {
                    case ShotStatus.Invalid:
                        DisplayInvalid();
                        break;
                    case ShotStatus.Duplicate:
                        DisplayDuplicate();
                        break;
                    case ShotStatus.Miss:
                        DisplayMiss();
                        break;
                    case ShotStatus.Hit:
                        DisplayHit();
                        break;
                    case ShotStatus.HitAndSunk:
                        DisplayHitAndSunk();
                        break;
                    case ShotStatus.Victory:
                        DisplayVictory();
                        break;
                    default:
                        break;
                }
                Console.ReadKey();

            }
        }

        private static void DisplayInvalid()
        {
            Console.WriteLine("It is an invalid entry, try again!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static void DisplayDuplicate()
        {
            Console.WriteLine("It's a duplicate, try again.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static void DisplayMiss()
        {
            Console.WriteLine("It's a miss.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static void DisplayHit()
        {
            Console.WriteLine("It's a hit.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static void DisplayHitAndSunk()
        {
            Console.WriteLine("It's a hit and sunk");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static void DisplayVictory()
        {
            Console.WriteLine("Congrats, you have won the game!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

    }



}
