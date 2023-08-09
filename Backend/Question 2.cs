public interface IService<T>
{
    T Build(IEnumerable<Part> parts);
}

public interface IPartsProvider
{
    IEnumerable<Part> GetParts(Enum type);
}

public class Factory
{
    private readonly IService<Robot> _robotService;
    private readonly IService<Car> _carService;
    private readonly IPartsProvider _partsProvider;

    public Factory(IService<Robot> robotService, IService<Car> carService, IPartsProvider partsProvider)
    {
        _robotService = robotService;
        _carService = carService;
        _partsProvider = partsProvider;
    }

    public Robot BuildRobot(Enum robotType)
    {
        var parts = GetPartsFor(robotType);
        return _robotService.Build(parts);
    }

    public Car BuildCar(Enum carType)
    {
        var parts = GetPartsFor(carType);
        return _carService.Build(parts);
    }

    private IEnumerable<Part> GetPartsFor(Enum type)
    {
        return _partsProvider.GetParts(type);
    }
}
