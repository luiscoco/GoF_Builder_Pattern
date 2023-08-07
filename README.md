# GoF_Csharp-Builder_Pattern

Separates the construction of a complex object from its representation, allowing the same construction process to create different representations.

The Builder Pattern is a creational design pattern that allows you to separate the construction of a complex object from its representation. This pattern is useful when you want to create an object with multiple parts or configurations, but you don't want to expose the details of the object's construction to the client code. It provides a step-by-step approach to building an object and allows different representations of the object to be created using the same construction process.

Here's a simple example of implementing the Builder Pattern in C#:

We want to create a Car object with the following properties:

Brand

Model

Color

Engine Capacity

Number of Doors

```csharp
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
```



