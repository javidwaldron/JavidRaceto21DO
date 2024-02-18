using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
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
        Deck deck = new Deck();
        public int gamesplayed = 0;

        List<Player> players = new List<Player>();


        public void Setup()
        {
            gameEnd = false;
            Console.WriteLine("How many players?");
            Console.WriteLine();
            int numberOfplayers = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine();
            Console.WriteLine("There are " + numberOfplayers + " playing");
            Console.WriteLine();

            // Getting number of players using int obtained 
            for (int i = 0; i < numberOfplayers; i++)
            {

                players.Add(new Player());
            }

            // Delete this comment when done for testing
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine();

            //Getting player names
            foreach (Player player in players)
            {

                //Added + 1 because indexes start at 0
                Console.Write("Ok player " + (players.IndexOf(player) + 1) + " , what is your name? ");
                player.name = Console.ReadLine();

            }

            Console.WriteLine();
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++");


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
            //Shuffle's cards
            deck.Shuffle();

            // Using turn ints to tell when everyone has gone
            int turn = 0;
            int busted = 0;
            //Creating a list within a list for round by round play
            List<Player> currentPlayers = new List<Player>();
            List<int> playerScore = new List<int>();

            //While the game isnt over
            while (roundEnd == false)
            {
                // For every player playing in game
                foreach (Player player in players)
                {
                    //To stop it asking players who said no to playing another round
                    if (player.isActive == true)
                    {
                        //Adding a smaller list of players for individual rounds
                        Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++");
                        Console.WriteLine();
                        //Ask would you like to play
                        Console.Write("" + player.name + ", would you like to be dealt in? Enter (Y) for yes or (N) for no : ");
                        string response = Console.ReadLine();
                        while (player.askedInRound == false)
                        {
                            //If player says yes and wants a card
                            if (response.ToUpper().StartsWith("Y"))
                            {
                                //Adding a smaller list of players for individual rounds
                                currentPlayers.Add(player);
                                player.askedInRound = true;


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

                                            Console.Write("" + player.name + ", would you like a card? Enter (Y) for yes or (N) for no. : ");
                                            string anotherResponse = Console.ReadLine();

                                            //If player takes card is under 21 score and active all the code happens and will repeat until....
                                            if (anotherResponse.ToUpper().StartsWith("Y"))
                                            {
                                                Console.WriteLine();
                                                Card card = deck.DealTopCard();
                                                player.cardsInHand.Add(card);
                                                player.score = ScoreHand(player);
                                                ShowHand(player);
                                                Console.WriteLine();
                                                Console.WriteLine("" + player.name + "'s, score is now " + player.score + "/21.");
                                                

                                            }
                                            else if (anotherResponse.ToUpper().StartsWith("N"))
                                            {
                                                player.isStaying = true;
                                                player.isActive = false;
                                                Console.WriteLine();
                                                Console.WriteLine("" + player.name + "'is staying with a final score of " + player.score + "/21.");
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
                                            busted++;
                                            Console.WriteLine();
                                            Console.WriteLine("" + player.name + " has busted, sorry!");
                                            turn++;

                                        }
                                    }
                                    // Sets game for player to be based on three cards
                                    else if (cardamountresponse == "3")
                                    {
                                        Console.WriteLine();
                                        for (int i = 0; i < 3; i++)
                                        {
                                            Card card = deck.DealTopCard();

                                            player.cardsInHand.Add(card);
                                        }
                                        
                                        player.score = ScoreHand(player);
                                        ShowHand(player);
                                        Console.WriteLine();
                                        Console.WriteLine("" + player.name + "'s, score is now " + player.score + "/21.");
                                        playerScore.Add(player.score);

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
                                            Console.WriteLine();
                                            Console.WriteLine("" + player.name + " has busted, sorry!");
                                            player.isBust = true;
                                            turn++;
                                            busted++;

                                        }
                                        else
                                        {
                                            player.isActive = false;
                                            Console.WriteLine();
                                            Console.WriteLine("" + player.name + "'is staying with a final score of " + player.score + "/21.");
                                            turn++;
                                            
                                        }

                                    }
                                    //Reprimands to Enter one of the two acceptable options
                                    else
                                    {
                                        player.askedAboutThreeCard = false;
                                        Console.WriteLine("Please Enter either 1 or 3");
                                        cardamountresponse = Console.ReadLine();
                                    }
                                }

                                //Player says no and sits out Round
                            }
                            else if (response.ToUpper().StartsWith("N"))
                            {

                                Console.WriteLine("" + player.name + " , is staying out this round.");
                                currentPlayers.Remove(player);
                                player.askedInRound = true;

                            }
                            else
                            {
                                Console.WriteLine("Please Enter either (Y) for yes or (N) for no");
                                response = Console.ReadLine();

                            }
                        }
                        // If every outcome has happened, adds an int. if it equals the total items in current player list, round ends
                        if (turn == currentPlayers.Count)
                        {
                            roundEnd = true;

                        }

                    }

                }


            }
            //Round is up due to everyone having gone
            while (roundEnd == true)
            {
                var result = playerScore.OrderByDescending(playerScore => playerScore);
                int highscore = playerScore.IndexOf(0);
                Console.WriteLine(highscore);

                foreach (Player player in players)
                {    
                    if (player.hasWon == true)
                    {
                        Console.WriteLine("Congratulations, " + player.name + " has won this round!");
                    }
                    // If all but one has busted
                    else if (!player.isBust && !player.hasWon && busted == currentPlayers.Count - 1)
                    {
                        Console.WriteLine("Congratulations, " + player.name + " , you are the last man standing!");
                    }
                    else if (player.isStaying && !player.isBust && player.score == playerScore.IndexOf(0))
                    {
                        Console.WriteLine("" + player.name+ "scored the highest, therefore, they win!");
                    }
                    else
                    {
                        Console.Write("");
                    }
                    
                



                    turn = 0;
                    Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++");
                    Console.WriteLine();
                    Console.Write("" + player.name + " would you like to play another round (Y) for yes and (N) for no. : ");
                    string playagain = Console.ReadLine();
                    Console.WriteLine();


                    //Do you want to play again, if yes adds back to the current players
                    if (playagain.ToUpper().StartsWith("Y"))
                    {

                        currentPlayers.Add(player);
                        player.isActive = true;
                        player.askedAboutThreeCard = false;
                        player.askedInRound = false;
                        player.isBust = false;
                        player.hasWon = false;

                        player.score = 0;
                        roundEnd = false;
                        player.cardsInHand.Clear();


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

                    if (playAgainResponse.ToUpper().StartsWith("Y"))
                    {
                        gamesplayed++;
                        string deckName = gamesplayed.ToString();
                        Console.WriteLine();
                        players.Clear();
                        roundEnd = false;

                        Setup();
                        CoreGame();


                    }
                    else if (playAgainResponse.ToUpper().StartsWith("N"))
                    {
                        System.Environment.Exit(1);

                    }
                    else
                    {
                        Console.WriteLine("Please Enter a (Y) for yes or (N) for no : ");
                    }
                }

                //Creates a new deck after asking whos still playing, checking if  theres a new game started
                Deck deck = new Deck();
                CoreGame();

            }
            int ScoreHand(Player player)
            {
                int score = 0;

                foreach (Card card in player.cardsInHand)
                {
                    string faceValue = card.ID.Remove(card.ID.Length - 1);
                    switch (faceValue)
                    {
                        case "K":
                        case "Q":
                        case "J":
                            score = score + 10;
                            break;
                        case "A":
                            score = score + 1;
                            break;
                        default:
                            score = score + int.Parse(faceValue);
                            break;
                    }
                }
                return score;
            }
            void ShowHand(Player player)
            {
                if (player.cardsInHand.Count > 0)
                {
                    Console.Write(player.name + " has: ");
                    foreach (Card card in player.cardsInHand)
                    {
                        Console.Write(card.name + " , ");

                    }


                }

            }






        }
    }
}












