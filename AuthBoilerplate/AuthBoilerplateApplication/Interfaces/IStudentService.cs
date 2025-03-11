
using AuthBoilerplateApplication.DTOs;
using AuthBoilerplateDomain.Entities;

namespace AuthBoilerplateApplication.Interfaces
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllHeros(bool? isActive);
        Task<Student?> GetHerosByID(int id);
        Task<Student?> AddStudent(AddUpdateStudent obj);
        Task<Student?> UpdateStudent(int id, AddUpdateStudent obj);
        Task<bool> DeleteHerosByID(int id);
    }
}
