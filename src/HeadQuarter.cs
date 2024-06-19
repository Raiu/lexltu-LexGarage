using System.Dynamic;

namespace LexGarage;

public enum StorageType {
    None,
    Garage,
    Hangar,
    Harbour
}

public enum VehicleType {
    Car,
    Truck,
    Motorcycle,
    Bicycle,
    Boat,
    Plane,
    Helicopter,
    Spaceship,
    Train,
    Ship,
    Aircraft,
    None,
}

public class Headquarter {

    private StateMachine _stateMachine;

    private IUserInterface _ui;

    private IVehicleStorage<IVehicle> _storage = null!;

    private List<IVehicle> _unParkedVehicles = null!;

    private List<Vuid> _vins;

    public enum HqAction {
        None,
        Exit,
        CreateNewGarage,
        CreateVehicle,
        Park,
        Withdraw,
        ListParked,
        ListUnParked,
        Search,
    }

    public HqAction CurrentAction { get; private set; } = HqAction.None;

    ////////////////////////////////////////////////////////////////////////////////

    public Headquarter(IUserInterface ui, StateMachine stateMachine) {
        _ui = ui;
        _stateMachine = stateMachine;
        _vins = stateMachine.UsedVins;

        if(_storage == null) {
            CurrentAction = HqAction.CreateNewGarage;
        }
    }

    ////////////////////////////////////////////////////////////////////////////////

    public void Run() {
        while(true) {
            if(CurrentAction == HqAction.Exit) {
                break;
            }

            if(CurrentAction == HqAction.None) {
                _ui.DisplayHeadquarterView();
                GetUserAction();
            }

            switch(CurrentAction) {
                case HqAction.CreateNewGarage: CreateGarageController(); break;
                case HqAction.CreateVehicle: CreateVehicleController(); break;
                case HqAction.Park: ParkController(); break;
                case HqAction.Withdraw: WithdrawController(); break;
                case HqAction.ListParked: ListParkedController(); break;
                case HqAction.ListUnParked: ListUnParkedController(); break;
                case HqAction.Search: SearchController(); break;
                default: break;
            }
        }
    }

    public void SetStorage(IVehicleStorage<IVehicle> storage) {
        _storage = storage;
        CurrentAction = CurrentAction == HqAction.CreateNewGarage ? HqAction.None : CurrentAction;
    }

    private void GetUserAction() {
        while(true) {
            var input = _ui.GetUserInput("Enter your choice: ");

            CurrentAction = input switch {
                //"1" => HqAction.CreateNewGarage,
                "2" => HqAction.CreateVehicle,
                "3" => HqAction.Park,
                "4" => HqAction.Withdraw,
                "5" => HqAction.ListParked,
                "6" => HqAction.ListUnParked,
                "7" => HqAction.Search,
                "0" => HqAction.Exit,
                _ => HqAction.None
            };

            if(CurrentAction != HqAction.None) {
                break;
            }

            _ui.DisplayWarning("Invalid input");
        }
    }

    private void CreateGarageController() {
        _ui.DisplayMessage("Creating a new garage");
        int storageCapacity;
        while(true) {
            var input = _ui.GetUserInput("Garage capacity: ");
            if(int.TryParse(input, out storageCapacity)) {
                break;
            }
            _ui.DisplayWarning("Invalid input");
        }

        _storage = new Garage<IVehicle>(storageCapacity);

        var carDirector = new CarDirector();
        foreach(var vehicle in carDirector.CreateRandomCars(storageCapacity - 2)) {
            if(_stateMachine.AddVin(vehicle.Vin)) {
                _storage.Add(vehicle);
            }
        }

        CurrentAction = HqAction.None;
    }

    private void CreateVehicleController() {
        _ui.Clear();
        _ui.DisplayMessage("Creating a new vehicle");

        var userAttempts = 0;
        var maxAttempts = 3;

        var inputType = VehicleType.None;
        while (inputType == VehicleType.None && userAttempts < maxAttempts) {
            var input = _ui.GetUserInput("Vehicle type: ");
            inputType = ParseVehicleType(input);

            if (inputType == VehicleType.None) {
                _ui.DisplayWarning($"{inputType} is invalid vehicle type");
                userAttempts++;
            }
        }

        if (userAttempts >= maxAttempts) {
            _ui.DisplayWarning("You have exceeded the maximum number of attempts");
            return;
        }

        switch (inputType) {
            case VehicleType.Car:
                CreateCar();
                break;
            default:
                _ui.DisplayWarning("Invalid vehicle type");
                break;
        }

        _ui.GetUserKey("\nPress any key to return to Headquarter");
        CurrentAction = HqAction.None;
    }

    private static VehicleType ParseVehicleType(string input) => input switch {
            "Car" or "car" => VehicleType.Car,
            //"Truck" => VehicleType.Truck,
            //"Motorcycle" => VehicleType.Motorcycle,
            //"Bicycle" => VehicleType.Bicycle,
            //"Boat" => VehicleType.Boat,
            //"Plane" => VehicleType.Plane,
            //"Helicopter" => VehicleType.Helicopter,
            //"Spaceship" => VehicleType.Spaceship,
            //"Train" => VehicleType.Train,
            //"Ship" => VehicleType.Ship,
            //"Aircraft" => VehicleType.Aircraft,
            _ => VehicleType.None
        };

    private static VehicleColor ParseVehicleColor(string input) => input switch {
            "Red" or "red" => VehicleColor.Red,
            "Blue" or "blue" => VehicleColor.Blue,
            "Green" or "green" => VehicleColor.Green,
            "Yellow" or "yellow" => VehicleColor.Yellow,
            "Purple" or "purple" => VehicleColor.Purple,
            "Orange" or "orange" => VehicleColor.Orange,
            "Black" or "black" => VehicleColor.Black,
            "White" or "white" => VehicleColor.White,
            _ => VehicleColor.None
        };

    private void CreateCar() {
        if (_storage.IsFull()) {
            _ui.DisplayWarning("The garage is full");
            return;
        }

        var builder = new CarBuilder();

        Vuid vin;
        while(true) {
            var input = _ui.GetUserInput("Enter your vin or leave blank to generate a new one");
            if(!string.IsNullOrWhiteSpace(input)) {
                if (Vuid.TryParse(input, out var result)) {
                    if (_stateMachine.IsUniueVin(result)) {
                        vin = result;
                        break;
                    }
                    else {
                        _ui.DisplayWarning($"{input} is not a unique vin");
                    }
                }
                else {
                    _ui.DisplayWarning($"{input} is an invalid vehicle id");
                }
            }
            else {
                do {
                    vin = Vuid.NewVuid();
                } while(!_stateMachine.IsUniueVin(vin));
                break;
            }
        }
        builder.SetVin(vin);

        VehicleColor color;
        while(true) {
            var input = _ui.GetUserInput("Enter your color or leave blank to generate a new one");
            if(string.IsNullOrWhiteSpace(input)) {
                color = default;
                break;
            }
            if (ParseVehicleColor(input) != VehicleColor.None) {
                color = ParseVehicleColor(input);
                break;
            }
            else {
                _ui.DisplayWarning($"{input} is an invalid vehicle color");
            }
        }
        builder.SetColor(color);

        int nrWheels;
        while(true) {
            var input = _ui.GetUserInput("Enter the number of wheels or leave blank to generate a new one");
            if(!string.IsNullOrWhiteSpace(input)) {
                if (int.TryParse(input, out var result)) {
                    nrWheels = result;
                    break;
                }
                else {
                    _ui.DisplayWarning($"{input} is an invalid number of wheels");
                }
            }
            else {
                nrWheels = default;
                break;
            }
        }
        builder.SetNumberOfWheels(nrWheels);

        var car = builder.Build();

        if(!_stateMachine.AddVin(car.Vin)) {
            _ui.DisplayWarning($"Vehicle {car.Vin} is already in use");
            return;
        }

        _storage.Add(car);
        _ui.DisplaySuccess($"\nVehicle {car.Vin} has been created");
    }

    private void SearchController() {
        CurrentAction = HqAction.None;
        throw new NotImplementedException();
    }

    private void ListUnParkedController() {
        if(_unParkedVehicles == null) {
            _ui.DisplayMessage("All vehicles are currently parked");
            return;
        }
        _ui.DisplayList("", _unParkedVehicles.Select(v => v.Vin.ToString()).ToList());

        _ui.GetUserKey("\nPress any key to return to Headquarter");
        CurrentAction = HqAction.None;
    }

    private void ListParkedController() {
        var vehicles = _storage.GetVehicles().ToList();

        if(vehicles.Count < 1) {
            _ui.DisplayMessage("No vehicles are currently parked");
            return;
        }
        _ui.DisplayList("Currently parked vehicles", vehicles);

        _ui.GetUserKey("\nPress any key to return to Headquarter");
        CurrentAction = HqAction.None;
    }

    private void WithdrawController() {

        _ui.GetUserKey("\nPress any key to return to Headquarter");
        CurrentAction = HqAction.None;
        throw new NotImplementedException();
    }

    private void ParkController() {

        _ui.GetUserKey("\nPress any key to return to Headquarter");
        CurrentAction = HqAction.None;
        throw new NotImplementedException();
    }

    public void AddStorage(int capacity) {
        _storage = new Garage<IVehicle>(capacity);
    }

    private bool ValidateInt(int input) {

        return true;
    }
}
