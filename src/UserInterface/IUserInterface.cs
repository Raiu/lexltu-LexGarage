using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexGarage;

public interface IUserInterface {

    void DisplayMessage(string message);

    void DisplayError(string message);

    void DisplayWarning(string message);

    void DisplaySuccess(string message);

    void DisplayMainMenuView();

    void DisplayHeadquarterView();

    string GetUserInput(string message);

    bool GetUserKey(string message, out string key);    
}