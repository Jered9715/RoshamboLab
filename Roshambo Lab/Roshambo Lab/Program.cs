using Roshambo_Lab;

//Welcome to program
Console.WriteLine("Welcome to Rock Paper Scissors!");
Console.WriteLine();

//create humanPlayer
Console.Write("What is your name? : ");
HumanPlayer humanPlayer = new HumanPlayer();

//set humanPlayer name
humanPlayer.Name = Console.ReadLine();
Console.WriteLine();

//set computerPlayers
RockPlayer rockPlayer = new RockPlayer();
rockPlayer.Name = "Mountain";
RandomPlayer randomPlayer = new RandomPlayer();
randomPlayer.Name = "Loose Canon";

//select computerPlayer Mountain / Loose Canon


string playerOpponentChoice = "";
bool playerWantsToQuit = false;
//if else if else that helps validate inside while loop that will handle the validation
//if and else if will hold the main program loop
while (true)
{
    Console.Write("Would you like to play against the Mountain or the Loose Canon? (m/l): ");
    playerOpponentChoice = Console.ReadLine();
    if (playerOpponentChoice.ToLower().Trim() == "m")
    {
        //start main program loop for rockPlayer - ending when user no longer wants to play
        while (playerWantsToQuit == false)
        {
            
            
            
            Console.Write("Play again? (y/n): ");
            string endRequest = Console.ReadLine();
            playerWantsToQuit = PlayerQuitRequest(endRequest);
        }
        break;
    }
    else if (playerOpponentChoice.ToLower().Trim() == "l")
    {
        //start main program loop for randomPlayer - ending when user no longer wants to play
        while (playerWantsToQuit == false)
        {

            Console.Write("Play again? (y/n): ");
            string endRequest = Console.ReadLine();
            playerWantsToQuit = PlayerQuitRequest(endRequest);
        }
        break;
    }
    else 
    {
        Console.WriteLine("That is not a valid selection. Please try again.");
        Console.WriteLine();
    }

}




//start main program loop - ending when user no longer wants to play


//method for end request ending returning bool
bool PlayerQuitRequest(string endRequestAnswer)
{
    if (endRequestAnswer.ToLower().Trim() != "y")
    {
        if (endRequestAnswer.ToLower().Trim() == "n")
        {
            Console.WriteLine("Thank you playing!");
            return true;
        }
        else
        {
            Console.WriteLine("That is not a recognized input. Ending Program.");
            return true;
        }
    }
    return false;
}


RoundResult RoshamboRoundResultCalulator(Roshambo humanPlayer, Roshambo computerPlayer)
{
    int opponentScore = 0;
    int userScore = 0;
    switch (humanPlayer)
    {
        case Roshambo.rock:
            switch (computerPlayer)
            {
                case Roshambo.rock:
                    break;
                case Roshambo.paper:
                    opponentScore++;
                    break;
                case Roshambo.scissors:
                    userScore++;
                    break;
            }
            break;
        case Roshambo.paper:
            switch (computerPlayer)
            {
                case Roshambo.paper:
                    break;
                case Roshambo.scissors:
                    opponentScore++;
                    break;
                case Roshambo.rock:
                    userScore++;
                    break;
            }

            break;
        case Roshambo.scissors:
            switch (computerPlayer)
            {
                case Roshambo.scissors:
                    break;
                case Roshambo.rock:
                    opponentScore++;
                    break;
                case Roshambo.paper:
                    userScore++;
                    break;
            }
            break;

    }
    if (userScore > opponentScore)
    { return RoundResult.humanWin; }
    else if (userScore < opponentScore)
    { return RoundResult.computerWin; }
    else
    { return RoundResult.draw; }
}