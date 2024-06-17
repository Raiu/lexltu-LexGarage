namespace LexGarage;

public class Harbour<T> : IVehicleStorage<T> where T : IVehicle {
    public void Park(T vehicle) {
        throw new NotImplementedException();
    }

    public string GetLocation() {
        throw new NotImplementedException();
    }

    public void Withdraw(T vehicle) {
        throw new NotImplementedException();
    }
}