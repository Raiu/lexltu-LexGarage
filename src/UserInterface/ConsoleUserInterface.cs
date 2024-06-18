using System.Text;

namespace LexGarage;

public class ConsoleUserInterface : IUserInterface {

    public void DisplayMessage(string message) {
        Console.WriteLine(message);
    }

    public void DisplaySuccess(string message) {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public void DisplayError(string message) {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public void DisplayWarning(string message) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public void DisplayMainMenuView() {
        var sb = new StringBuilder();
        sb.AppendLine("Main Menu: ");
        sb.AppendLine("  1. Headquarter");
        sb.AppendLine("  2. Load previous session");
        sb.AppendLine("  3. Save current session");
        sb.AppendLine("  4. Exit");
        Console.WriteLine(sb.ToString());
    }

    public void DisplayHeadquarterView() {
        throw new NotImplementedException();
    }

    public string GetUserInput(string message) {
        Console.WriteLine(message);
        string? input;
        while (true) {
            input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) {
                DisplayWarning($"{input} is not a valid input");
                continue;
            }
            return input;
        }
    }

    public bool GetUserKey(string message, out string key) {
        Console.WriteLine(message);
        key = Console.ReadKey(true).Key.ToString();
        return true;
    }
}