using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dars2_1.Models;

public class School
{
    // SchoolID maktab identifikatori
    public Guid SchoolId { get; set; }

    // Created maktab qo'shilgan sana
    public DateTime Created { get; set; }

    // Updated maktab ma'lumotlari yangilangan sana
    public DateTime? Updated { get; set; }

    // Name maktab nomi
    public string Name { get; set; }

    // Address maktab manzili
    public string Address { get; set; }

    // EstablishedYear maktab tashkil etilgan yil
    public int EstablishedYear { get; set; }

    // maktab o'quvchilar sig'imi
    public int StudentCapacity { get; set; }
}
