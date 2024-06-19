namespace LexGarage;

public class CarBuilder : IVehicleBuilder<Car> {

    private Vuid _vin;

    private VehicleColor _color;

    private int _nrOfWheels;

    ////////////////////////////////////////////////////////////////////////////////

    ////////////////////////////////////////////////////////////////////////////////

    public void SetVin(Vuid vin) => _vin = vin;


    public void CreateVin() => _vin = new Vuid();


    public void SetColor(VehicleColor color) => _color = color;


    public void SetNumberOfWheels(int numberOfWheels) => _nrOfWheels = numberOfWheels;

    public void Clear() {
        _vin = default;
        _color = default;
        _nrOfWheels = default;
    }

    public Car Build() {

        if(_vin == default) {
            _vin = new Vuid();
        }

        if(_color == default) {
            _color = VehicleColor.Black;
        }

        if(_nrOfWheels == default) {
            _nrOfWheels = 4;
        }

        return new Car(_vin, _color, _nrOfWheels);
    }
}
