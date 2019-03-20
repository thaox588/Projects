using BattleShip.BLL.GameLogic;
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
            ConsoleIO.DisplayTitle();                              

            Players player1 = new Players();
            setUpPlayer(player1);
            ConsoleIO.PlayerBoard();

            Players player2 = new Players();
            setUpPlayer(player2);
            ConsoleIO.PlayerBoard();

            ConsoleIO.FirstToGo();
            ConsoleIO.DisplayShot();




        }

        

        public void setUpPlayer(Players currentPlayer)
        {
            currentPlayer.Name = ConsoleIO.GetNameFromUser("Please Enter Your Name:");
            Console.Clear();
            ConsoleIO.PlaceShip(currentPlayer.Name, currentPlayer.Board);
            Console.Clear();
                       
        }

        //public void Fire()
        //{
        //    ConsoleIO.DisplayShot();
        //    Console.Clear();


        //}

        
    }
}
