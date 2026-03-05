using Car.Server.Cars.Dtos;
using Car.Server.Cars.Entiti;

namespace Car.Server.Cars.Repository
{
    public interface IInterfacesRepo
    {
        public List<Car>? GetAllCars();
        public void SaveAllCars(List<Car> cars);
    }
}
