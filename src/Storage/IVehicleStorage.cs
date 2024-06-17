namespace LexGarage;

public interface IVehicleStorage<T> where T : IVehicle {

    string GetLocation();

    void Park(T vehicle);

    void Withdraw(T vehicle);
}
