using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavidRaceto21DO
{
   class Player
    {

        List<Card> cardsInHand = new List<Card>();
        public string name;
        int bettingMoney = 100;

        bool isBetting = false;
        bool isActive = true;
        bool isBust = false;
        bool isStaying = false;
        

    }
}
