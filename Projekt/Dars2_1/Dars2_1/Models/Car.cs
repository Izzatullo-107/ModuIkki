using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dars2_1.Models;

public class Car
{
    // CarID mashina identifikatori
    public Guid CarId { get; set; }

    // Created mashina qo'shilgan sana
    public DateTime Created { get; set; }

    // Updated mashina ma'lumotlari yangilangan sana
    public DateTime? Updated { get; set; }

    // Make mashina ishlab chiqaruvchisi
    public string Make { get; set; }

    // Model mashina modeli
    public string Model { get; set; }

    // Year mashina ishlab chiqarilgan yili
    public int Year { get; set; }

    // Price mashina narxi
    public decimal Price { get; set; }

    // Color mashina rangi
    public string Color { get; set; }

    // KM mashina yurgan masofasi
    public int KilometersDriven { get; set; }

    // Mashina yoqilg'i turi
    public string FuelType { get; set; }

}
