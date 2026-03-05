using Car.Server.Car.Dtos;

namespace Car.Server.Car.Services;

public interface IService
{
    List<GetDto> GetAll();
    GetDto? GetById(int id);
    void Create(CreateDto createDto);
    bool Update(int id, UpdateDto updateDto);
    bool Delete(int id);
}