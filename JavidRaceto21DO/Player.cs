using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavidRaceto21DO
{
   class Player
    {

        public List<Card> cardsInHand = new List<Card>();
        public string name;
        public int bettingMoney = 100;

        public bool isBetting = false;
        public bool isActive = true;
        public bool isBust = false;
        public bool isStaying = false;
        public bool askedAboutBetting = false;

    }
}
