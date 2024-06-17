using System.Drawing;

namespace LexGarage;

public class CarBuilder : IVehicleBuilder<Car> {

    private Vuid _vin;
    private VehicleColor _color;
    private int _numberOfWheels;

    public void SetVin(Vuid vin) => _vin = vin;

    public void CreateVin(IEnumerable<Vuid> vins) {
        Vuid vin;
        do {
            vin = Vuid.NewVuid();
        } while (!vins.Contains(vin));
        _vin = vin;
    }

    public void SetColor(VehicleColor color) => _color = color;

    public void SetNumberOfWheels(int numberOfWheels) => 
            _numberOfWheels = numberOfWheels;

    public Car Build() => new Car(_vin, _color, _numberOfWheels);
}