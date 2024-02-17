using System;

namespace JavidRaceto21DO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Race to 21!");
            Console.WriteLine();
            Console.WriteLine("                               _____\r\n   _____                _____ |6    |\r\n  |2    | _____        |5    || o o | \r\n  |  o  ||3    | _____ | o o || o o | _____\r\n  |     || o o ||4    ||  o  || o o ||7    |\r\n  |  o  ||     || o o || o o ||____6|| o o | _____\r\n  |____2||  o  ||     ||____5|       |o o o||8    | _____\r\n         |____3|| o o |              | o o ||o o o||9    |\r\n                |____4|              |____7|| o o ||o o o|\r\n                                            |o o o||o o o|\r\n                                            |____8||o o o|\r\n                                                   |____9|\r\n");
            Console.WriteLine();


            Game game = new Game();
           
            game.Setup();
            game.CoreGame();     
        
        }
    }
}
