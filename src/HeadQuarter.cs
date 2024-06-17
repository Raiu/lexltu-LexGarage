namespace LexGarage;

public enum StorageType {
    None,
    Garage,
    Hangar,
    Harbour
}

public class HeadQuarter {

    private AppStateManager _stateManager;

    private IVehicleStorage<IVehicle> _storage;

    private List<IVehicle> _unParkedVehicles = null!;

    public HeadQuarter(AppStateManager stateManager) {
        _stateManager = stateManager;
        _storage = new Garage<IVehicle>();        
    }

    public void AddStorage(StorageType type, int size) {
        _storage = type switch {
            StorageType.Garage => new Garage<IVehicle>(size),
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, "Invalid storage type"),
        };
    }

    public void CreateNew(string name, int size) {

    }

    private bool ValidateInt(int input) {

        return true;
    }
}