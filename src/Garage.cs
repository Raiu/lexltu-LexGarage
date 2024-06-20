namespace LexGarage;

public class Garage<T> : IVehicleStorage<T> where T : IVehicle {

    private Catalogue<T> _vehicles;

    private int _capacity;

    public int Capacity => _capacity;

    ////////////////////////////////////////////////////////////////////////////////

    public Garage() : this(8) {
    }

    public Garage(int size) {
        _vehicles = new Catalogue<T>(size);
        _capacity = size;
    }

    ////////////////////////////////////////////////////////////////////////////////

    public bool IsFull() => _vehicles.Count >= _capacity;

    public void Add(T vehicle) => _vehicles.Add(vehicle);

    public void Remove(T vehicle) => _vehicles.Remove(vehicle);

    public void IncreaseSize(int newSize) => _vehicles.IncreaseSize(newSize);

    public IEnumerable<T> GetVehicles() => [.. _vehicles];

    public T? GetVehicleByVin(Vuid vin) => _vehicles.FirstOrDefault(v => v.Vin == vin);

    public T GetVehicleByLicensePlate(Ruid license) {
        throw new NotImplementedException();
    }
}
