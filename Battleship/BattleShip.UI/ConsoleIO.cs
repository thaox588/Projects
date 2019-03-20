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

        public static void PlayerBoard(Players player, Players player2)
        {      

            string xLetter = "ABCDEFGHIJ";
            char row = 'A';

            
            Console.Write("   [1  2  3  4  5  6  7  8  9 10]");
            for (int x = 0; x < 10; x++)
            {
                row = xLetter[x];
                Console.Write($"\n[{row}]");

                for (int y = 0; y < 10; y++)
                {
                    ShotHistory shotDisplay = new ShotHistory();
                    Coordinate coordinate = new Coordinate(x+1, y+1);
                    
                    
                    switch (shotDisplay = player.Board.CheckCoordinate(coordinate))
                    {
                        case ShotHistory.Hit:
                            Console.ForegroundColor = ConsoleColor.Red; Console.Write("[h]");
                            break;
                        case ShotHistory.Miss:
                            Console.ForegroundColor = ConsoleColor.Yellow; Console.Write("[m]");
                            break;
                        case ShotHistory.Unknown:
                            Console.Write("");
                            break;
                        default:
                            break;
                    }
                    Console.ForegroundColor = ConsoleColor.White;
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

        public static ShotStatus DisplayShot(Players player)
        {
            while (true)
            {                
                Console.WriteLine("Place your fireshot. ");
                FireShotResponse shot = player.Board.FireShot(GetCoord());
           
                switch (shot.ShotStatus)
                {
                    case ShotStatus.Invalid:
                        DisplayInvalid();
                        continue;
                    case ShotStatus.Duplicate:
                        DisplayDuplicate();
                        continue;
                    case ShotStatus.Miss:
                        DisplayMiss();
                        return shot.ShotStatus;
                    case ShotStatus.Hit:
                        DisplayHit();
                        return shot.ShotStatus;
                    case ShotStatus.HitAndSunk:
                        DisplayHitAndSunk();
                        return shot.ShotStatus;
                    case ShotStatus.Victory:
                        DisplayVictory();
                        return shot.ShotStatus;
                    default:
                        break;
                }

            }
        }

        private static void DisplayInvalid()
        {
            Console.WriteLine("It is an invalid entry, try again!");
        }

        private static void DisplayDuplicate()
        {
            Console.WriteLine("It's a duplicate, try again.");
        }

        private static void DisplayMiss()
        {
            Console.WriteLine("It's a miss.");
        }

        private static void DisplayHit()
        {
            Console.WriteLine("It's a hit.");
        }

        private static void DisplayHitAndSunk()
        {
            Console.WriteLine("It's a hit and sunk");
        }

        private static void DisplayVictory()
        {
            Console.WriteLine("Congrats, you have won the game!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();            
        }

        
    }

    


}
