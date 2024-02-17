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

        bool gameEnd = false;
        bool roundEnd = false;

        List<Player> players = new List<Player>();

        //Begin from here, move welcome to 21 to beginning of program later
        public void Setup()
        {
            
            Console.WriteLine("How many players?");
            Console.WriteLine();
            int numberOfplayers = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("+++++++++++++++++++++++++++++++++");
            Console.WriteLine();
            Console.WriteLine("There are " + numberOfplayers + " playing");
            Console.WriteLine();

            // Getting number of players using int obtained 
            for (int i = 0; i < numberOfplayers; i++)
            {

                players.Add(new Player());
            }

            // Delete this comment when done for testing
            Console.WriteLine("++++++++++++++++++++++++++++++++++");
            Console.WriteLine();

            //Getting player names
            foreach (Player player in players)
            {
                
                //Added + 1 because indexes start at 0
                Console.Write("Ok player " + (players.IndexOf(player) + 1) + " , what is your name? ");
                player.name = Console.ReadLine();
                
            }

            Console.WriteLine();
            Console.WriteLine("+++++++++++++++++++++++++++++");
            
            
            //Setting waging, while all players will begin with 100 not revealed or displayed for not betting people
            foreach (Player player in players)
            {
                while (player.askedAboutBetting == false)
                {
                    Console.WriteLine();
                    Console.Write("" + player.name + ", are you interested in placing a wager? Enter (Y) for yes or (N) for no : ");
                    string response = Console.ReadLine();
                    
                    if (response.ToUpper().StartsWith("Y"))
                    {
                        Console.WriteLine("" + player.name + ", is beginning with $100 betting money!");
                        Console.WriteLine();
                        player.isBetting = true;
                        player.askedAboutBetting = true;

                    }
                    else if (response.ToUpper().StartsWith("N"))
                    {
                        Console.WriteLine("" + player.name + ", is just playing for fun!");
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

        }
    // Essentially where offer a card is, asked if they want to be dealt a card or three in a turn
        public void CoreGame()
        {

            //While the game isnt over
            while (roundEnd ==  false)
            {
                // For every player playing
                foreach (Player player in players)
                {
                    //Ask would you like to play
                    Console.Write("" + player.name + ", would you like to be dealt in? Enter (Y) for yes or (N) for no : ");
                    string response = Console.ReadLine();

                    //If player says yes and wants a card
                    if (response.ToUpper().StartsWith("Y"))
                    {
                        // Goes through check to see if they want the one card or three card version
                        while (player.askedAboutThreeCard == false && player.isActive == true)
                        {

                            Console.Write("Would you like one card or three? Enter (1) to be dealt one card at a time, or (3) for three at a time : ");
                            string cardamountresponse = Console.ReadLine();
                            
                            // Sets game for player to be based on individual cards
                            if (cardamountresponse == "1")
                            {
                                player.askedAboutThreeCard = true;
                                
                                //While player score is under 21 will deal card then keep asking if they want another until no
                                while (player.score < 21 && player.isActive == true)
                                {
                                    
                                    Console.WriteLine(""+ player.name + " , would you like a card? Enter (Y) for yes or (N) for no. : ");
                                    string anotherResponse = Console.ReadLine();
                                    
                                   
                                    if (anotherResponse.ToUpper().StartsWith("Y"))
                                    {
                                        Console.WriteLine("Add Card PlaceHolder");
                                        Console.WriteLine("Showcard placeholder");
                                        Console.WriteLine("Update Player Score");
                                    }
                                else if (anotherResponse.ToUpper().StartsWith("N"))
                                    {
                                        player.isStaying = true;
                                        player.isActive = false;
                                    }
                                 else
                                    {
                                        Console.WriteLine("Please Enter either (Y) for yes or (N) for no : ");
                                    }
                                
                                }
                                // When player score is equal to 21 they win automatically and the game ends
                                if (player.score == 21)
                                {
                                    player.hasWon = true;
                                    gameEnd = true;
                                }
                                //If a player busts they lose automatically and the gme ends
                                if (player.score > 21)
                                {
                                    player.isActive = false;
                                    player.isBust = true;
                                    gameEnd = true;
                                }
                            }
                            // Sets game for player to be based on three cards
                            else if (cardamountresponse == "3")
                            {
                                Console.WriteLine("Add Card x3 Placeholder");
                                Console.WriteLine("Showcard placeholder");
                                Console.WriteLine("Update Player Score");
                                player.askedAboutThreeCard = true;
                            }
                            //Reprimands to Enter one of the two acceptable options
                            else
                            {
                                Console.WriteLine("Please Enter either 1 or 3");
                            }
                        }
                   
                    //Player says No and sits out Round
                    }
                    else if (response.ToUpper().StartsWith("N")) 
                    {

                        Console.WriteLine("" + player.name + " , is staying out this round .");
                        player.isActive = false;
                    
                    }

                    if (!players.Contains(player.isActive))
                    {

                    }

                }
                
                


            }
            if (roundEnd == true)
            {
                foreach (Player player in players)
                {
                    // Calculate score mechanic
                    //Declare Winner
                    //Ask to play again
                    Console.Write("Would you like to play again? (Y) for yes and (N) for no. : ");
                    string playagain = Console.ReadLine();

                    if (playagain.ToUpper().StartsWith("Y"))
                    {
                        player.isActive = true;

                    }
                    else if (playagain.ToUpper().StartsWith("N"))
                    {
                        player.isActive = false;
                    }
                    else
                    {
                        Console.Write("Please Enter (Y) for yes or (N) for no. : ");
                    }
                }

            }

        }
    
    
    
    
    
    
    
    
    
    }

}



            


        





    