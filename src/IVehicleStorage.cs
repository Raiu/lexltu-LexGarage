namespace LexGarage;

public interface IVehicleStorage<T> where T : IVehicle {

    bool IsFull();

    void Add(T vehicle);

    void Remove(T vehicle);

    void IncreaseSize(int newSize);

    IEnumerable<T> GetVehicles();

    T? GetVehicleByVin(Vuid vin);

    T GetVehicleByLicensePlate(Ruid license);
}
