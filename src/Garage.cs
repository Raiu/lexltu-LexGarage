namespace LexGarage;

public class Garage<T> : IVehicleStorage<T> where T : IVehicle {

    private Catalogue<T> _vehicles;

    ////////////////////////////////////////////////////////////////////////////////

    public Garage() : this(8) {
    }

    public Garage(int size) {
        _vehicles = new Catalogue<T>(size);
    }

    ////////////////////////////////////////////////////////////////////////////////

    public void Park(T vehicle) => throw new NotImplementedException();

    public void Withdraw(T vehicle) => throw new NotImplementedException();

    public void Clear() => throw new NotImplementedException();

    public void IncreaseSize(int newSize) => throw new NotImplementedException();

    public IEnumerable<T> GetVehicles() => throw new NotImplementedException();

    public T GetVehicleByVin(Vuid vin) => throw new NotImplementedException();

    public string GetLocation() {
        throw new NotImplementedException();
    }
}