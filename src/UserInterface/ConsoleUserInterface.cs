using System.Text;

namespace LexGarage;

public class ConsoleUserInterface : IUserInterface {

    public void Clear() => Console.Clear();

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

    public void DisplayList<T>(string message, List<T> list) {
        Console.WriteLine(message);
        var iter = 1;
        foreach (var item in list) {
            Console.WriteLine($"{iter}. {item}");
            iter++;
        }
    }

    public void DisplayMainMenuView() {
        var sb = new StringBuilder();
        sb.AppendLine("Main Menu: ");
        sb.AppendLine("  1. Headquarter");
        sb.AppendLine("  2. Load previous session");
        sb.AppendLine("  3. Save current session");
        sb.AppendLine("  0. Exit");

        Console.Clear();
        Console.WriteLine(sb.ToString());
    }

    public void DisplayHeadquarterView() {
        var sb = new StringBuilder();
        sb.AppendLine("Headquarter: ");
        //sb.AppendLine("  1. Create Garage");
        sb.AppendLine("  2. Create Car");
        sb.AppendLine("  3. Park vehicle");
        sb.AppendLine("  4. Withdraw vehicle");
        sb.AppendLine("  5. List Parked vehicles");
        sb.AppendLine("  6. List Unparked vehicles");
        sb.AppendLine("  7. Search for vehicle");
        sb.AppendLine("  0. Return to Main Menu");

        Console.Clear();
        Console.WriteLine(sb.ToString());
    }

    public string GetUserInput(string message) {
        Console.WriteLine(message);
        string? input;
        while (true) {
            input = Console.ReadLine();
            if (input == null) {
                DisplayWarning($"{input} is not a valid input");
                continue;
            }
            return input;
        }
    }

    public bool GetUserKey(string message) {
        Console.WriteLine(message);
        return Console.ReadKey(true).Key == ConsoleKey.Enter;
    }

    public bool GetUserKey(string message, out string key) {
        Console.WriteLine(message);
        key = Console.ReadKey(true).Key.ToString();
        return true;
    }
}
