﻿namespace LexGarage;

public class App
{
    public App()
    {
    }

    public void Run()
    {

        var cat = new Catalogue<IVehicle>();

        cat.Add(new Car());
        cat.Add(new Car());

        

        

        /* for (int i = 0; i < 30; i++)
        {
            var ruidList = new List<Ruid>()
            {
                Ruid.NewRuid()
            };
            while (true)
            {
                var newRuid = Ruid.NewRuid();
                if (!ruidList.Contains(newRuid))
                {
                    ruidList.Add(newRuid);
                    continue;
                }

                Console.WriteLine($"Duplicate: {newRuid}");
                Console.WriteLine($"Count: {ruidList.Count}");
                break;
            }
        } */


        Console.ReadKey();
    }

}
