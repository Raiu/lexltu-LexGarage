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

    public void Park(T vehicle) => throw new NotImplementedException();

    public void Withdraw(T vehicle) => throw new NotImplementedException();

    public void Clear() => throw new NotImplementedException();

    public void IncreaseSize(int newSize) => throw new NotImplementedException();

    public IEnumerable<T> GetVehicles() => [.. _vehicles];

    public T GetVehicleByVin(Vuid vin) => throw new NotImplementedException();

    public string GetLocation() {
        throw new NotImplementedException();
    }

    public T GetVehicleByLicensePlate(Ruid license) {
        throw new NotImplementedException();
    }
}
