using LexGarage;
using Microsoft.Extensions.DependencyInjection;


var services = new ServiceCollection();

services.AddTransient<IUserInterface, ConsoleUserInterface>();
services.AddSingleton<Headquarter, Headquarter>();
services.AddSingleton<StateMachine, StateMachine>();

var serviceProvider = services.BuildServiceProvider();

var ui = serviceProvider.GetRequiredService<IUserInterface>();
var stateMachine = serviceProvider.GetRequiredService<StateMachine>();

var app = new App(ui: ui, stateMachine: stateMachine);
app.Run();