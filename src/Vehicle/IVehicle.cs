namespace LexGarage;

public interface IVehicle
{
    Vuid Vin { get; }

    void Start();

    void Stop();
}
