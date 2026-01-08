using Dars2_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dars2_1.Services;

public class CarService
{
    // Carlarni saqlash uchun ro'yxat
    public List<Car> Cars = new List<Car>();


    //{C} Yangi car qo'shish metodi
    public Guid CreatCar(Car car)
    {
        // car id va yaratilgan vaqtini belgilash 
        car.CarId = Guid.NewGuid();
        car.Created = DateTime.Now;
        Cars.Add(car);

        // Qo'shilgan car ning Guid(id) sini qaytarish
        return car.CarId;
    }


    //{R} Barcha carlarni ko'rish metodi
    public List<Car> ReadCar()
    {
        return Cars;
    }


    //{U} Car dagi malumotni yangilash metodi
    public void UpdateCar(Guid carId, Car updatedCar)
    {
        // Car ni topish
        var existingCar = Cars.FirstOrDefault(c => c.CarId == carId);

        // Agar car topilsa, malumotlarini yangilash
        if (existingCar != null)
        {
            existingCar.Updated = DateTime.Now;
            existingCar.Make = updatedCar.Make;
            existingCar.Model = updatedCar.Model;
            existingCar.Year = updatedCar.Year;
            existingCar.Price = updatedCar.Price;

        }
    }


    //{D} Car ni o'chirish metodi
    public Guid DeleteCar(Guid carId)
    {
        // Car ni topish
        var carToDelete = Cars.FirstOrDefault(c => c.CarId == carId);

        // Agar car topilsa, uni ro'yxatdan o'chirish
        if (carToDelete != null)
        {
            Cars.Remove(carToDelete);
        }
        return Guid.Empty;
    }









}
