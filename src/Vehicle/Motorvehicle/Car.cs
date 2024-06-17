namespace LexGarage;

public class Car : IMotorvehicle {

    public Vuid Vin { get; }

    public VehicleColor Color { get; }

    public int NumberOfWheels { get; }

    public Ruid RegistrationNumber { get; }

    public Car(Vuid vin, VehicleColor color, int numberOfWheels) {
        Vin = vin;
        Color = color;
        NumberOfWheels = numberOfWheels;
    }

    public void Start() {
        throw new NotImplementedException();
    }

    public void Stop() {
        throw new NotImplementedException();
    }
}
