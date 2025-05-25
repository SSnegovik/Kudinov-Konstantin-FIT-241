using System;
using System.Collections.Generic;

//Лабораторная работа 6_2 21.03.2025

public delegate void CleanVehicleDelegate(Vehicle vehicle);

public class Vehicle
{
    public int ReleaseYear { get; set; }
    public string Brand { get; set; }
    public string Paint { get; set; }
    public bool NeedsWashing { get; set; }

    public Vehicle(int year, string brand, string paint, bool dirty)
    {
        ReleaseYear = year;
        Brand = brand;
        Paint = paint;
        NeedsWashing = dirty;
    }

    public override string ToString()
    {
        return $"{ReleaseYear} {Brand} ({Paint}) - Грязная: {NeedsWashing}";
    }
}

class ParkingLot
{
    private List<Vehicle> vehicles;

    public ParkingLot()
    {
        vehicles = new List<Vehicle>();
    }

    public void StoreVehicle(Vehicle vehicle)
    {
        vehicles.Add(vehicle);
    }

    public List<Vehicle> RetrieveAll()
    {
        return vehicles;
    }
}

class Cleaner
{
    public void Clean(Vehicle vehicle)
    {
        if (vehicle.NeedsWashing)
        {
            vehicle.NeedsWashing = false;
            Console.WriteLine($"Автомобиль {vehicle.Brand} вымыт.");
        }
        else
        {
            Console.WriteLine($"Автомобиль {vehicle.Brand} уже чист.");
        }
    }
}

class EntryPoint
{
    static void Main()
    {
        ParkingLot lot = new ParkingLot();

        lot.StoreVehicle(new Vehicle(2020, "Porsche 911", "Красный", false));
        lot.StoreVehicle(new Vehicle(2012, "Renault Logan", "Синий", false));
        lot.StoreVehicle(new Vehicle(2021, "Renault Duster", "Серебрянный", true));
        lot.StoreVehicle(new Vehicle(2020, "Toyota RAV4", "Белый", true));

        Cleaner autoCleaner = new Cleaner();
        CleanVehicleDelegate cleanerDelegate = new CleanVehicleDelegate(autoCleaner.Clean);

        foreach (var v in lot.RetrieveAll())
        {
            Console.WriteLine(v);
            cleanerDelegate(v);
            Console.WriteLine();
        }
    }
}
          
