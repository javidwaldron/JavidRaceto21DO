using System;
using System.Collections.Generic;
using System.Linq; // currently only needed if we use alternate shuffle method

namespace JavidRaceto21DO
{
   
    public class Deck
    {
        List<Card> cards = new List<Card>();

     
        public Deck()
        {
            //Lifted from template, creates an array of card suits, creating an item for every 13 in each four suit

            Console.WriteLine("...............Please wait, building new deck Deck..........");
            string[] suits = { "S", "H", "C", "D" };

            for (int cardVal = 1; cardVal <= 13; cardVal++)
            {
                foreach (string cardSuit in suits)
                {
                    string cardName;
                    string cardLongName;

                    switch (cardVal)
                    {
                        case 1:
                            cardName = "A";
                            cardLongName = "Ace of ";
                            break;
                        case 11:
                            cardName = "J";
                            cardLongName = "Jack of ";
                            break;
                        case 12:
                            cardName = "Q";
                            cardLongName = "Queen of ";
                            break;
                        case 13:
                            cardName = "K";
                            cardLongName = "King of ";
                            break;
                        default:
                            cardName = cardVal.ToString();
                            cardLongName = cardVal.ToString() + " of ";
                            break;
                    }

                    switch (cardSuit)
                    {
                        case "S":
                            cardLongName += "Spades";
                            break;
                        case "H":
                            cardLongName += "Hearts";
                            break;
                        case "C":
                            cardLongName += "Clubs";
                            break;
                        case "D":
                            cardLongName += "Diamonds";
                            break;
                    }
                    cards.Add(new Card { ID = cardName + cardSuit, name = cardLongName });
                }
            }
        }

        
        public void Shuffle()
        {
            Console.WriteLine();
            Console.WriteLine("Shuffling Cards.....");
            Console.WriteLine();

            Random rng = new Random(); // rng is short for "Random Number Generator"

            // one-line method that uses Linq
            // (only uncomment this and comment out the multi-line approach
            // after you understand this approach!):
            // cards = cards.OrderBy(a => rng.Next()).ToList();

            // multi-line approach that uses Array notation on a list!
            // (this should be easier to understand):
            for (int i = 0; i < cards.Count; i++)
            {
                Card tmp = cards[i];
                int swapindex = rng.Next(cards.Count);
                cards[i] = cards[swapindex];
                cards[swapindex] = tmp;
            }
        }


        public void ShowAllCards()
        {
            for (int i = 0; i < cards.Count; i++)
            {
                Console.Write(i + ":" + cards[i].ID); // NOTE: a list property can be accessed by an index just like an Array!
                if (i < cards.Count - 1)
                {
                    Console.Write(" ");
                }
                else
                {
                    Console.WriteLine("");
                }
            }
        }

        //After Index has been jumbled takes card and removes from index and returns value to be plugged into player
        public void  DealTopCard()
        {
            Card card = cards[cards.Count - 1];
            cards.RemoveAt(cards.Count - 1);
            // Console.WriteLine("I'm giving you " + card);
          
        }
    }
}

