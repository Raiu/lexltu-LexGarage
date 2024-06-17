namespace LexGarage;

public class Application
{
    private IInputHandler _inputHandler;
    
    private IOutputHandler _outputHandler;

    private AppStateManager _stateManager;

    private HeadQuarter _headQuarter;

    public Application(IInputHandler inputHandler, IOutputHandler outputHandler) {
        _inputHandler = inputHandler;
        _outputHandler = outputHandler;
        _stateManager = new AppStateManager();
        _headQuarter = new HeadQuarter(_stateManager);
    }

    public void Run()
    {


        Console.ReadKey();
    }

}
