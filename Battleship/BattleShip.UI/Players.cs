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
    public class Players
    {   

        public string Name { get; set; }

        public Board Board { get; set; }
        public Players()
        {
            Board = new Board();

        }

        public string Spot { get; set; }

    }


    
}
