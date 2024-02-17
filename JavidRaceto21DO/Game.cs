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


            for (int i = 0;  i < numberOfplayers; i++)
            {
                
                players.Add(new Player());
            }
            
            Console.WriteLine("There is still " + players.Count + "playing Javid");
        
        
        
        }





    }

}
