using Roshambo_Lab;
using System.Net.Http.Headers;

Console.WriteLine("Welcome to Rock Paper Scissors!");
Console.WriteLine();

Console.Write("What is your name? : ");
HumanPlayer humanPlayer = new HumanPlayer();

humanPlayer.Name = Console.ReadLine();
Console.WriteLine();

RockPlayer rockPlayer = new RockPlayer();
rockPlayer.Name = "Mountain";
RandomPlayer randomPlayer = new RandomPlayer();
randomPlayer.Name = "Loose Canon";

string playerOpponentChoice = "";
bool playerWantsToQuit = false;

while (true)
{
    Console.Write("Would you like to play against the Mountain or the Loose Canon? (m/l): ");
    playerOpponentChoice = Console.ReadLine();
    if (playerOpponentChoice.ToLower().Trim() == "m")
    {
        while (playerWantsToQuit == false)
        {
            RockPaperScissorsPrompt();
            string userInput = Console.ReadLine();
            ConverHumanInputToPlayerChoice(userInput);

            Roshambo humanChoice = humanPlayer.GenerateRochambo();
            Roshambo computerChoice = rockPlayer.GenerateRochambo();

            Console.WriteLine($"{humanPlayer.Name}: {PlayerThrowSelection(humanChoice)}");
            Console.WriteLine($"{rockPlayer.Name}: {PlayerThrowSelection(computerChoice)}");

            RoundResult roundResult = RoshamboRoundResultCalulator(humanChoice, computerChoice);
            
            Console.WriteLine(WinDetermination(roundResult,humanPlayer.Name,rockPlayer.Name));
            Console.WriteLine();

            Console.Write("Play again? (y/n): ");
            string endRequest = Console.ReadLine();
            playerWantsToQuit = PlayerQuitRequest(endRequest);
        }
        break;
    }
    else if (playerOpponentChoice.ToLower().Trim() == "l")
    {
        while (playerWantsToQuit == false)
        {
            RockPaperScissorsPrompt();
            string userInput = Console.ReadLine();
            ConverHumanInputToPlayerChoice(userInput);

            Roshambo humanChoice = humanPlayer.GenerateRochambo();
            Roshambo computerChoice = randomPlayer.GenerateRochambo();

            Console.WriteLine($"{humanPlayer.Name}: {PlayerThrowSelection(humanChoice)}");
            Console.WriteLine($"{randomPlayer.Name}: {PlayerThrowSelection(computerChoice)}");

            RoundResult roundResult = RoshamboRoundResultCalulator(humanChoice,computerChoice);

            Console.WriteLine(WinDetermination(roundResult, humanPlayer.Name, randomPlayer.Name));
            Console.WriteLine();


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


void RockPaperScissorsPrompt()
{
    Console.Write("Rock, paper, or scissors? (r/p/s): ");
}

void ConverHumanInputToPlayerChoice(string userInput)
{
    if (userInput.ToLower().Trim() == "r")
    {
        humanPlayer.SetPlayerChoice(1);
    }
    else if (userInput == "p")
    {
        humanPlayer.SetPlayerChoice(2);
    }
    else if (userInput == "s")
    {
        humanPlayer.SetPlayerChoice(3);
    }
    else
    {
        Console.WriteLine($"{userInput} is not a valid choice");
        Console.WriteLine();
    }
}




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

string PlayerThrowSelection(Roshambo playerSelection)
{
    switch (playerSelection)
    {
        case Roshambo.rock:
            return "Rock";
        case Roshambo.paper:
            return "Paper";
        case Roshambo.scissors:
            return "Scissors";
        default:
            return "invalid Response";
    }
}

string WinDetermination(RoundResult input, string humanPlayer, string computerPlayer)
{
    switch (input)
    {
        case RoundResult.humanWin:
            return $"{humanPlayer} Wins!";
           

        case RoundResult.computerWin:
            return $"{computerPlayer} Wins!";
            

        case RoundResult.draw:
            return "Draw!";

        default:
            return "Not valid input";
    }
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