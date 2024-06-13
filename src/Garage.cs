namespace LexGarage;

public class Garage : IVehicleStorage {

    private Catalogue<IVehicle> _vehicles;

    ////////////////////////////////////////////////////////////////////////////////

    public Garage() : this(8) {
    }

    public Garage(int size) {
        _vehicles = new Catalogue<IVehicle>(size);
    }

    ////////////////////////////////////////////////////////////////////////////////

    public void Add(IVehicle vehicle) => throw new NotImplementedException();

    public void Remove(IVehicle vehicle) => throw new NotImplementedException();

    public void Clear() => throw new NotImplementedException();

    public void IncreaseSize(int newSize) => throw new NotImplementedException();

    public IVehicle GetVehicleByVin(Vuid vin) => throw new NotImplementedException();
}