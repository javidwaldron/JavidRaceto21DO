using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace JavidRaceto21DO
{
    public class Game
    {

       public bool gameEnd = false;
       public bool roundEnd = false;

        List<Player> players = new List<Player>();

        //Begin from here, move welcome to 21 to beginning of program later
        public void Setup()
        {
            gameEnd = false;
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
            // Using turn ints to tell when everyone has gone
            int turn = 0;
            //Creating a list within a list for round by round play
            List<Player> currentPlayers = new List<Player>();

            //While the game isnt over
            while (roundEnd ==  false)
            {
                // For every player playing in game
                foreach (Player player in players)
                {
                    //Adding a smaller list of players for individual rounds
                    
                    //Ask would you like to play
                    Console.Write("" + player.name + ", would you like to be dealt in? Enter (Y) for yes or (N) for no : ");
                    string response = Console.ReadLine();

                    //If player says yes and wants a card
                    if (response.ToUpper().StartsWith("Y"))
                    {
                        //Adding a smaller list of players for individual rounds
                        currentPlayers.Add(player);


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
                                    
                                   //If player takes card is under 21 score and active all the code happens and will repeat until....
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
                                        turn++;
                                    }
                                 else
                                    {
                                        Console.WriteLine("Please Enter either (Y) for yes or (N) for no : ");
                                    }
                                
                                }
                                // When player score is equal to 21 they win automatically and the game ends ***Revist has won***
                                if (player.score == 21)
                                {
                                    player.hasWon = true;
                                    roundEnd = true;
                                    turn++;
                                }
                                //If a player busts they lose automatically and turn ends
                                if (player.score > 21)
                                {
                                    player.isActive = false;
                                    player.isBust = true;
                                    turn++;
                                }
                            }
                            // Sets game for player to be based on three cards
                            else if (cardamountresponse == "3")
                            {
                                Console.WriteLine("Add Card x3 Placeholder");
                                Console.WriteLine("Showcard placeholder");
                                Console.WriteLine("Update Player Score");
                                player.askedAboutThreeCard = true;

                                if (player.score == 21)
                                {
                                    player.hasWon = true;
                                    roundEnd = true;
                                    turn++;
                                }
                                //If a player busts they lose automatically and turn ends
                                if (player.score > 21)
                                {
                                    player.isActive = false;
                                    player.isBust = true;
                                    turn++;
                                }
                                else
                                {
                                    player.isActive = false;
                                    turn++;
                                }

                            }
                            //Reprimands to Enter one of the two acceptable options
                            else
                            {
                                Console.WriteLine("Please Enter either 1 or 3");
                            }
                        }
                   
                    //Player says no and sits out Round
                    }
                    else if (response.ToUpper().StartsWith("N")) 
                    {

                        Console.WriteLine("" + player.name + " , is staying out this round.");
                        currentPlayers.Remove(player);
                    
                    }
                    // If every outcome has happened, adds an int. if it equals the total items in current player list, round ends
                    if (turn == currentPlayers.Count)
                    {
                        roundEnd = true;

                    }

                }
                
                


            }
            //Round is up due to everyone having gone
            if (roundEnd == true)
            {
                foreach (Player player in currentPlayers)
                {
                    // Calculate score mechanic
                    //Declare Winner
                   
                    currentPlayers.Clear();
                    turn = 0;
                    Console.Write("Would you like to play another round (Y) for yes and (N) for no. : ");
                    string playagain = Console.ReadLine();


                    //Do you want to play again, if yes adds back to the current players
                    if (playagain.ToUpper().StartsWith("Y"))
                    {

                        currentPlayers.Add(player);
                        player.isActive = true;
                        player.score = 0;


                    }
                    //If you dont want to play again removes from current players/
                    else if (playagain.ToUpper().StartsWith("N"))
                    {
                        currentPlayers.Remove(player);
                        player.isActive = false;
                    }
                    //Reprimanding bad input
                    else
                    {
                        Console.Write("Please Enter (Y) for yes or (N) for no. : ");
                    }
                }
                // If there are no current players, ask if they want to start a new game
                if (currentPlayers.Count == 0)
                {
                    Console.WriteLine("There is no one who wants to continue this round. Start a new game? Enter (Y) for yes or (N) for no : ");
                    string playAgainResponse = Console.ReadLine();

                    if(playAgainResponse.ToUpper().StartsWith("Y"))
                    {
                        Console.WriteLine("Start game over again code here");
                        players.Clear();
                        gameEnd = true;

                    }
                   else if(playAgainResponse.ToUpper().StartsWith("N"))
                    {
                        Console.WriteLine("Enter code to end game");
                        
                    }
                    else
                    {
                        Console.WriteLine("Please Enter a (Y) for yes or (N) for no : ");
                    }
                }

            }

        }


       






    }

}



            


        





    