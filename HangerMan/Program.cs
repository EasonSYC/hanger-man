namespace CodingTest;

class Program
{
    static void Main(string[] args)
    {
        HangmanGame();
    }

    static void HangmanGame()
    {
        bool nameInputValid = false;
        string? movieName;

        do
        {
            Console.WriteLine("Please input the name of the film. Upper case and spaces only.");
            movieName = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(movieName))
            {
                nameInputValid = true;
                foreach (char c in movieName)
                {
                    if (!(char.IsUpper(c) || c == ' '))
                    {
                        nameInputValid = false;
                        break;
                    }
                }
            }
        } while (!nameInputValid);

        int l = movieName!.Length;

        bool[] guess = new bool[l];

        for (int i = 0; i < l; ++i)
        {
            if (movieName[i] == ' ')
            {
                guess[i] = true;
            }
        }

        bool guessedAll = false;

        for (int i = 5; i > 0 && (!guessedAll); --i)
        {
            string currentGuess = string.Empty;

            for (int j = 0; j < l; ++j)
            {
                if (guess[j])
                {
                    currentGuess += movieName[j] == ' ' ? '/' : movieName[j];
                }
                else
                {
                    currentGuess += '_';
                }
            }

            Console.WriteLine(currentGuess);
            Console.WriteLine($"Guesses Remaining: {i}");

            string? input;

            do
            {
                Console.WriteLine("What letter would you like to try: ");
                input = Console.ReadLine();
            } while (!(!string.IsNullOrWhiteSpace(input) && (input.Length == 1) && input.All(char.IsUpper)));

            char inputLetter = input[0];

            bool includesLetter = false;
            for (int j = 0; j < l; ++j)
            {
                if (movieName[j] == inputLetter)
                {
                    guess[j] = true;
                    includesLetter = true;
                }
            }

            if (includesLetter)
            {
                ++i;
            }

            guessedAll = true;
            for (int j = 0; j < l && guessedAll; ++j)
            {
                guessedAll &= guess[j];
            }
        }

        if (guessedAll)
        {
            Console.WriteLine("You guessed correctly.");
        }
        else
        {
            Console.WriteLine($"Sorry you didn't guess it. The film was {movieName}.");
        }
    }
}

