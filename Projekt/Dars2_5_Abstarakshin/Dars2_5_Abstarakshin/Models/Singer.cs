using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dars2_5_Abstarakshin.Models;

public  class Singer
{
    public Guid SingerId { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Genre { get; set; }
    public decimal Price { get; set; }

    }
