using static System.Net.Mime.MediaTypeNames;

//We can use the CarBuilder to create different representations of Car objects:

class Program
{
    static void Main(string[] args)
    {
        ICarBuilder carBuilder = new CarBuilder();

        carBuilder.SetBrand("Toyota")
                  .SetModel("Camry")
                  .SetColor("Red")
                  .SetEngineCapacity(2.5)
                  .SetNumberOfDoors(4);

        Car car1 = carBuilder.Build();
        Console.WriteLine("Car 1: " + car1);

        // Let's create another representation of a car
        carBuilder.SetBrand("Honda")
                  .SetModel("Civic")
                  .SetColor("Blue")
                  .SetEngineCapacity(1.8)
                  .SetNumberOfDoors(2);

        Car car2 = carBuilder.Build();
        Console.WriteLine("Car 2: " + car2);
    }
}

public class Car
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public string Color { get; set; }
    public double EngineCapacity { get; set; }
    public int NumberOfDoors { get; set; }

    public override string ToString()
    {
        return $"Brand: {Brand}, Model: {Model}, Color: {Color}, Engine: {EngineCapacity}L, Doors: {NumberOfDoors}";
    }
}
//Next, we'll create an interface called ICarBuilder to define the steps to build a car:

public interface ICarBuilder
{
    ICarBuilder SetBrand(string brand);
    ICarBuilder SetModel(string model);
    ICarBuilder SetColor(string color);
    ICarBuilder SetEngineCapacity(double engineCapacity);
    ICarBuilder SetNumberOfDoors(int numberOfDoors);
    Car Build();
}


//Now, we'll implement the CarBuilder class that implements the ICarBuilder interface:

public class CarBuilder : ICarBuilder
{
    private Car car;

    public CarBuilder()
    {
        car = new Car();
    }

    public ICarBuilder SetBrand(string brand)
    {
        car.Brand = brand;
        return this;
    }

    public ICarBuilder SetModel(string model)
    {
        car.Model = model;
        return this;
    }

    public ICarBuilder SetColor(string color)
    {
        car.Color = color;
        return this;
    }

    public ICarBuilder SetEngineCapacity(double engineCapacity)
    {
        car.EngineCapacity = engineCapacity;
        return this;
    }

    public ICarBuilder SetNumberOfDoors(int numberOfDoors)
    {
        car.NumberOfDoors = numberOfDoors;
        return this;
    }

    public Car Build()
    {
        return car;
    }
}

