namespace LexGarage;

public interface IUserInterface {

    void Clear();

    void DisplayMessage(string message);

    void DisplayError(string message);

    void DisplayWarning(string message);

    void DisplaySuccess(string message);

    void DisplayList<T>(string message, List<T> list);

    void DisplayMainMenuView();

    void DisplayHeadquarterView();

    string GetUserInput(string message);

    bool GetUserKey(string message);

    bool GetUserKey(string message, out string key);
}
