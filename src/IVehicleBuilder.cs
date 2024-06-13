namespace LexGarage;

public interface IVehicleBuilder<T> where T : IVehicle
{
    IVehicleBuilder<T> SetVin();

    IVehicleBuilder<T> CreateVin();
}
