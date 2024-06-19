namespace LexGarage;

public interface IVehicleStorage<T> where T : IVehicle {

    string GetLocation();

    bool IsFull();

    void Add(T vehicle);

    void Remove(T vehicle);

    void Park(T vehicle);

    void Withdraw(T vehicle);

    void Clear();

    void IncreaseSize(int newSize);

    IEnumerable<T> GetVehicles();

    T GetVehicleByVin(Vuid vin);

    T GetVehicleByLicensePlate(Ruid license);
}
