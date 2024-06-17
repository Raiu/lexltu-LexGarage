using LexGarage;

var inputHandler = new ConsoleUserInput();
var outputHandler = new ConsoleUserOutput();

var app = new Application(inputHandler, outputHandler);
app.Run();