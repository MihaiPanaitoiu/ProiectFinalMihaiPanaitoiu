using Data.Exceptions;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public partial class DataAccessLayerSingleton
    {
        #region singleton
        private DataAccessLayerSingleton()
        {
            
        }
        private static DataAccessLayerSingleton instance;
        public static DataAccessLayerSingleton Instance {
            get 
            {
                if (instance == null)
                {
                    instance = new DataAccessLayerSingleton();
                }
                return instance;
            } 
        }
        #endregion

        public IEnumerable<Student> GetStudents()
        {
            using var ctx = new SchoolDbContext();
            return ctx.Students.ToList();
        }

        public Student GetStudentById(int id)
        {
            using var ctx = new SchoolDbContext();
            return ctx.Students.FirstOrDefault(s => s.Id == id);
        }

        public Student CreateStudent(Student student)
        {
            using var ctx = new SchoolDbContext();
            if (ctx.Students.Any(x => x.Id == student.Id))
            {
                //throw exception
            }
            ctx.Add(student);
            ctx.SaveChanges();
            return student;
        }

        public Student UpdateStudent(Student studentToUpdate)
        {
            using var ctx = new SchoolDbContext();


            var student = ctx.Students.FirstOrDefault(s => s.Id == studentToUpdate.Id);

            if (student == null)
            {
                //throw exception
            }

            student.FirstName = studentToUpdate.FirstName;
            student.LastName = studentToUpdate.LastName;
            student.Age = studentToUpdate.Age;

            ctx.SaveChanges();

            return student;
        }

        public void UpdateStudentAddress(int studentId, Address addressToUpdate)
        {
            using var ctx = new SchoolDbContext();

            var student = ctx.Students.Include(s => s.Address).FirstOrDefault(s => s.Id == studentId);

            if (student == null)
            {
                //throw exception
            }

            if (student.Address == null)
            {
                student.Address = new Address();
            }

            student.Address.Street = addressToUpdate.Street;
            student.Address.City = addressToUpdate.City;
            student.Address.Number = addressToUpdate.Number;

            ctx.SaveChanges();
        }

        public void DeleteStudent(int studentId)
        {
            using var ctx = new SchoolDbContext();
            var student = ctx.Students.FirstOrDefault(s => s.Id == studentId);

            if (student == null)
            {
                throw new InvalidIdException($"Student not found with Id {studentId}");
            }

            ctx.Students.Remove(student);
            ctx.SaveChanges();

        }
    }
}
