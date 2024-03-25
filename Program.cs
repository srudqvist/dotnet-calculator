using System.Text.RegularExpressions;

Console.WriteLine("Welcome to the Calculator");
Console.WriteLine("Please enter two numbers and the calculation method");
Console.WriteLine("you wish to use.");
Console.WriteLine("Example: 2+2");
Console.WriteLine("Type exit to quit");

Console.WriteLine("Enter your calculation: ");

string? userInput = Console.ReadLine()?.Trim()?.ToLower();
while (userInput != "exit")
{
    // This pattern captures the first number, operation, and last number
    string pattern = @"^(\d+)\s*([\+\-\*\/])\s*(\d+)$";

    if (userInput != null)
    {
        Match match = Regex.Match(userInput, pattern);

        if (match.Success)
        {
            int firstNumber = int.Parse(match.Groups[1].Value);
            char operation = char.Parse(match.Groups[2].Value);
            int lastNumber = int.Parse(match.Groups[3].Value);

            Console.WriteLine("");
            Console.WriteLine(
                $"Result: {userInput} = {CalculateResult(firstNumber, operation, lastNumber)}"
            );
            Console.WriteLine("Enter another calculation or exit to quit: ");
            userInput = Console.ReadLine()?.Trim()?.ToLower();
        }
        else
        {
            Console.WriteLine("Invalid Input format");
            Console.WriteLine("Try again: ");
            userInput = Console.ReadLine()?.Trim()?.ToLower();
        }
    }
}

static int CalculateResult(int firstNumber, char operation, int lastNumber)
{
    switch (operation)
    {
        case '+':
            return firstNumber + lastNumber;
        case '-':
            return firstNumber - lastNumber;
        case '*':
            return firstNumber * lastNumber;
        case '/':
            if (lastNumber == 0)
            {
                throw new ArgumentException("Division by zero is not allowed.");
            }
            return firstNumber / lastNumber;
        default:
            throw new ArgumentException($"Unsupported operation: {operation}");
    }
}
