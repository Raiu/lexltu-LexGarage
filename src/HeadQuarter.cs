namespace LexGarage;

public enum StorageType {
    None,
    Garage,
    Hangar,
    Harbour
}

public class Headquarter {

    private StateMachine _stateMachine;

    private IVehicleStorage<IVehicle> _storage;

    private List<IVehicle> _unParkedVehicles = null!;

    public Headquarter(StateMachine stateMachine) {
        _stateMachine = stateMachine;
        _storage = new Garage<IVehicle>();        
    }

    public void AddStorage(int capacity) {
        _storage = new Garage<IVehicle>(capacity);
    }

    /* public void AddStorage(StorageType type, int size) {
        _storage = type switch {
            StorageType.Garage => new Garage<IVehicle>(size),
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, "Invalid storage type"),
        };
    } */

    public void CreateNew(string name, int size) {

    }

    private bool ValidateInt(int input) {

        return true;
    }
}