namespace LexGarage;

public class CarDirector {
    public IEnumerable<Car> CreateRandomCars(int count) {
        for (int i = 0; i < count; i++) {
            var builder = new CarBuilder();
            builder.CreateVin();
            builder.SetColor(GetRandomColor());
            builder.SetNumberOfWheels(new Random().Next(4, 8));
            yield return builder.Build();
        }
    }

    private static VehicleColor GetRandomColor() {
        var colors = new List<VehicleColor> {
            VehicleColor.Red,
            VehicleColor.Blue,
            VehicleColor.Green,
            VehicleColor.Yellow,
            VehicleColor.Purple,
            VehicleColor.Orange,
            VehicleColor.Black,
            VehicleColor.White,
        };
        return colors[new Random().Next(colors.Count)];
    }

    public Car CreateRandomCar() {
        var builder = new CarBuilder();
        builder.CreateVin();
        builder.SetColor(GetRandomColor());
        builder.SetNumberOfWheels(new Random().Next(4, 8));
        return builder.Build();
    }

    public Car CreateCar(VehicleColor color, int numberOfWheels) {
        var builder = new CarBuilder();
        builder.CreateVin();
        builder.SetColor(color);
        builder.SetNumberOfWheels(numberOfWheels);
        return builder.Build();
    }
}