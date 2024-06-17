namespace LexGarage;

public class AppStateManager {

    public List<Vuid> Vins { get; set; } = null!;

    public event EventHandler? VinsChanged;


}