using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavidRaceto21DO
{
    public class Game
    {




        //Creates list of players after getting number playing and asks their name
        public void Setup()
        {
            List<Player> players = new List<Player>();

            Console.WriteLine("Welcome to Race to 21!");
            Console.WriteLine();
            Console.WriteLine("                               _____\r\n   _____                _____ |6    |\r\n  |2    | _____        |5    || o o | \r\n  |  o  ||3    | _____ | o o || o o | _____\r\n  |     || o o ||4    ||  o  || o o ||7    |\r\n  |  o  ||     || o o || o o ||____6|| o o | _____\r\n  |____2||  o  ||     ||____5|       |o o o||8    | _____\r\n         |____3|| o o |              | o o ||o o o||9    |\r\n                |____4|              |____7|| o o ||o o o|\r\n                                            |o o o||o o o|\r\n                                            |____8||o o o|\r\n                                                   |____9|\r\n");
            Console.WriteLine();
            Console.WriteLine("How many players?");
            Console.WriteLine();
            int numberOfplayers = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("+++++++++++++++++++++++++++++++++");
            Console.WriteLine();
            Console.WriteLine("There are " + numberOfplayers + " playing");
            Console.WriteLine();

            // Getting number of players using int obtained above

            for (int i = 0; i < numberOfplayers; i++)
            {

                players.Add(new Player());
            }

            // Delete this comment when done for testing
            Console.WriteLine("There is still " + players.Count + " playing Javid, relax");


            //Getting player names

            foreach (Player player in players)
            {
                Console.WriteLine();
                //Added + 1 because indexes start at 0
                Console.WriteLine("Ok player " + (players.IndexOf(player) + 1) + " , what is your name? ");
                player.name = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("" + player.name + " is now playing");
                Console.WriteLine("+++++++++++++++++++++++++++++");
            }

            //Setting waging / difficulty

            foreach (Player player in players)
            {
                while (player.askedAboutBetting == false)
                {
                    Console.WriteLine();
                    Console.WriteLine("" + player.name + "Are you interested in placing a wager? Enter (Y) for yes or (N) for no");
                    string response = Console.ReadLine();
                    if (response.ToUpper().StartsWith("Y"))
                    {
                        Console.WriteLine("" + player.name + "is beginning with $100 betting money");
                        Console.WriteLine();
                        player.isBetting = true;
                        player.askedAboutBetting = true;

                    }
                    else if (response.ToUpper().StartsWith("N"))
                    {
                        Console.WriteLine("" + player.name + "is just playing for fun");
                        Console.WriteLine();
                        player.isBetting = false;
                        player.askedAboutBetting = true;
                    }
                    else
                    {
                        Console.WriteLine("Please Enter (Y) for yes or (N) for no");
                    }
                }

                
            }
            Console.WriteLine("Thats as far as you got");
        }
    }
}



            


        





    