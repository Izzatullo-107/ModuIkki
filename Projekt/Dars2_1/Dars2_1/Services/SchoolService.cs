using Dars2_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dars2_1.Services;

public class SchoolService
{
    // School larni saqlash uchun ro'yxat
    public List<School> Schools = new List<School>();


    //{C} Yangi school qo'shish metodi
    public Guid CreateSchool(School school)
    {
        // school id va yaratilgan vaqtini belgilash 
        school.SchoolId = Guid.NewGuid();
        school.Created = DateTime.Now;
        Schools.Add(school);
        // Qo'shilgan school ning Guid(id) sini qaytarish
        return school.SchoolId;
    }
    
    
    //{R} Barcha school larni ko'rish metodi
    public List<School> ReadSchool()
    {
        return Schools;
    }
    
    
    //{U} School dagi malumotni yangilash metodi
    public void UpdateSchool(Guid schoolId, School updatedSchool)
    {
        // School ni topish
        var existingSchool = Schools.FirstOrDefault(s => s.SchoolId == schoolId);
        // Agar school topilsa, malumotlarini yangilash
        if (existingSchool != null)
        {
            existingSchool.Updated = DateTime.Now;
            existingSchool.Name = updatedSchool.Name;
            existingSchool.Address = updatedSchool.Address;
            existingSchool.EstablishedYear = updatedSchool.EstablishedYear;
            existingSchool.StudentCapacity = updatedSchool.StudentCapacity; 
        }
    }


    //{D} School ni o'chirish metodi
    public Guid DeleteSchool(Guid schoolId)
    {
        // School ni topish
        var schoolToDelete = Schools.FirstOrDefault(s => s.SchoolId == schoolId);
        // Agar school topilsa, uni ro'yxatdan o'chirish
        if (schoolToDelete != null)
        {
            Schools.Remove(schoolToDelete);
        }
        return schoolId;
    }
}
