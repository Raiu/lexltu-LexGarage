using System.Runtime.CompilerServices;

namespace LexGarage;

public class App
{
    private IUserInterface _ui;
    private Headquarter _headQuarter;
    private StateMachine _stateMachine;

    public enum AppState {
        None,
        MainMenu,
        Headquarter,
        LoadSession,
        SaveSession,
        Exit
    }

    public AppState State { get; private set; } = AppState.None;

    ////////////////////////////////////////////////////////////////////////////////

    public App(IUserInterface ui, StateMachine stateMachine) {
        _ui = ui;
        _stateMachine = stateMachine;
        _headQuarter = new Headquarter(_stateMachine);
    }

    ////////////////////////////////////////////////////////////////////////////////

    public void Run() {
        while (true) {
            switch (State) {
                case AppState.None:
                case AppState.MainMenu:
                    MainMenuController();
                    break;
                case AppState.Headquarter:
                    HeadquarterController();
                    break;
                case AppState.LoadSession:
                    break;
                case AppState.SaveSession:
                    break;
                case AppState.Exit:
                    Environment.Exit(0);
                    return;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    private void MainMenuController() {
        _ui.DisplayMainMenuView();
        while (true) {
            var input = _ui.GetUserInput("Enter your choice: ");
            
            State = input switch {
                "1" => AppState.Headquarter,
                "2" => AppState.LoadSession,
                "3" => AppState.SaveSession,
                "4" => AppState.Exit,
                _ => AppState.None
            };

            if (State != AppState.None) {
                break;
            }

            _ui.DisplayWarning("Invalid input");
        }
    }

    private void HeadquarterController() {
        

    }

    private void LoadSessionController() {
        throw new NotImplementedException();
    }

    private void SaveSessionController() {
        throw new NotImplementedException();
    }
}
