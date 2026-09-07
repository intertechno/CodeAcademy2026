Console.WriteLine("Welcome to the number guessing game!");

int correct = Random.Shared.Next(1, 21);
// Console.WriteLine(correct);

for (int attempt = 0; attempt < 3; attempt++)
{
    Console.WriteLine("Please enter your guess (1-20):");
    string input = Console.ReadLine() ?? "0";
    int guess = int.Parse(input);

    if (guess == correct)
    {
        Console.WriteLine("Correct guess! You win the game.");
        break;
    }
    else if (guess < correct)
    {
        Console.WriteLine("Not quite! The correct number is larger.");
    }
    else if (guess > correct)
    {
        Console.WriteLine("Not quite! The correct number is smaller.");
    }
}

Console.WriteLine("The game ends.");
