using AuthBoilerplateApplication.DTOs;
using AuthBoilerplateApplication.Interfaces;
using AuthBoilerplateDomain.Entities;
using AuthBoilerplateInfrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AuthBoilerplateInfrastructure.Services
{
    public class StudentService : IStudentService
    {
        private readonly StudentDbContext _db;
        public StudentService(StudentDbContext db)
        {
            _db = db;
        }
        public async Task<List<Student>> GetAllHeros(bool? isActive)
        {
            if (isActive != null)
            {
                return await _db.Students.Where(m => m.isActive == isActive).ToListAsync();
            }
            return await _db.Students.ToListAsync();
        }

        public async Task<Student?> GetHerosByID(int id)
        {
            return await _db.Students.FirstOrDefaultAsync(hero => hero.Id == id);
        }

        public async Task<Student?> AddStudent(AddUpdateStudent obj)
        {
            var addHero = new Student()
            {
                FirstName = obj.FirstName,
                LastName = obj.LastName,
                isActive = obj.isActive,
            };

            _db.Students.Add(addHero);
            var result = await _db.SaveChangesAsync();
            return result >= 0 ? addHero : null;
        }

        public async Task<Student?> UpdateStudent(int id, AddUpdateStudent obj)
        {
            var hero = await _db.Students.FirstOrDefaultAsync(index => index.Id == id);
            if (hero != null)
            {
                hero.FirstName = obj.FirstName;
                hero.LastName = obj.LastName;
                hero.isActive = obj.isActive;

                var result = await _db.SaveChangesAsync();
                return result >= 0 ? hero : null;
            }
            return null;
        }

        public async Task<bool> DeleteHerosByID(int id)
        {
            var hero = await _db.Students.FirstOrDefaultAsync(index => index.Id == id);
            if (hero != null)
            {
                _db.Students.Remove(hero);
                var result = await _db.SaveChangesAsync();
                return result >= 0;
            }
            return false;
        }
    }
}
