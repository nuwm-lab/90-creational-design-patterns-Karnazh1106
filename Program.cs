using System;

// Продукт - клас House, який представляє будинок
public class House
{
    public string Type { get; set; }
    public int Floors { get; set; }
    public bool HasGarage { get; set; }
    public bool HasGarden { get; set; }
    public int Apartments { get; set; }

    public override string ToString()
    {
        return $"Тип: {Type}, Поверхи: {Floors}, Гараж: {HasGarage}, Сад: {HasGarden}, Кількість квартир: {Apartments}";
    }
}

// Інтерфейс IHouseBuilder, який визначає методи для будівельника
public interface IHouseBuilder
{
    void BuildType();
    void BuildFloors();
    void BuildGarage();
    void BuildGarden();
    void BuildApartments();
    House GetHouse();
}

// Конкретний будівельник для офісної будівлі
public class OfficeBuildingBuilder : IHouseBuilder
{
    private House _house;

    public OfficeBuildingBuilder()
    {
        _house = new House();
    }

    public void BuildType() => _house.Type = "Офісна будівля";
    public void BuildFloors() => _house.Floors = 10;
    public void BuildGarage() => _house.HasGarage = true;
    public void BuildGarden() => _house.HasGarden = false;
    public void BuildApartments() => _house.Apartments = 0;

    public House GetHouse() => _house;
}

// Конкретний будівельник для приватної забудови
public class PrivateHouseBuilder : IHouseBuilder
{
    private House _house;

    public PrivateHouseBuilder()
    {
        _house = new House();
    }

    public void BuildType() => _house.Type = "Приватний будинок";
    public void BuildFloors() => _house.Floors = 2;
    public void BuildGarage() => _house.HasGarage = true;
    public void BuildGarden() => _house.HasGarden = true;
    public void BuildApartments() => _house.Apartments = 0;

    public House GetHouse() => _house;
}

// Конкретний будівельник для багатоквартирного будинку
public class ApartmentBuildingBuilder : IHouseBuilder
{
    private House _house;

    public ApartmentBuildingBuilder()
    {
        _house = new House();
    }

    public void BuildType() => _house.Type = "Багатоквартирний будинок";
    public void BuildFloors() => _house.Floors = 5;
    public void BuildGarage() => _house.HasGarage = true;
    public void BuildGarden() => _house.HasGarden = false;
    public void BuildApartments() => _house.Apartments = 50;

    public House GetHouse() => _house;
}

// Директор - клас, що керує будівельним процесом
public class HouseDirector
{
    private IHouseBuilder _builder;

    public HouseDirector(IHouseBuilder builder)
    {
        _builder = builder;
    }

    public void ConstructHouse()
    {
        _builder.BuildType();
        _builder.BuildFloors();
        _builder.BuildGarage();
        _builder.BuildGarden();
        _builder.BuildApartments();
    }

    public House GetHouse()
    {
        return _builder.GetHouse();
    }
}

// Тестова програма для демонстрації
public class Program
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        // Створення будівельників
        IHouseBuilder officeBuilder = new OfficeBuildingBuilder();
        IHouseBuilder privateHouseBuilder = new PrivateHouseBuilder();
        IHouseBuilder apartmentBuilder = new ApartmentBuildingBuilder();

        // Директор для кожного типу будинку
        HouseDirector director = new HouseDirector(officeBuilder);
        director.ConstructHouse();
        House officeBuilding = director.GetHouse();
        Console.WriteLine(officeBuilding);

        director = new HouseDirector(privateHouseBuilder);
        director.ConstructHouse();
        House privateHouse = director.GetHouse();
        Console.WriteLine(privateHouse);

        director = new HouseDirector(apartmentBuilder);
        director.ConstructHouse();
        House apartmentBuilding = director.GetHouse();
        Console.WriteLine(apartmentBuilding);
    }
}
