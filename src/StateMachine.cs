namespace LexGarage;

public class StateMachine {

    public List<Vuid> UsedVins { get; } = [];

    public bool IsUniueVin(Vuid vin) => !UsedVins.Contains(vin);

    public bool AddVin(Vuid vin) {
        if (UsedVins.Contains(vin)) {
            return false;
        }
        UsedVins.Add(vin);
        return true;
    }
}
