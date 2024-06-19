using System.Drawing;

namespace LexGarage;

public interface IVehicleBuilder<T> where T : IVehicle
{
    void SetVin(Vuid vin);

    void SetColor(VehicleColor color);

    T Build();
}
