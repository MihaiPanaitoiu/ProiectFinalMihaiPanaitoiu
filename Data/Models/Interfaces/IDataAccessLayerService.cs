using Data.Models;

namespace Data.Models.Interfaces
{
    public interface IDataAccessLayerService
    {
        Student CreateStudent(Student student);
        void DeleteStudent(int studentId);
        Student GetStudentById(int id);
        IEnumerable<Student> GetStudents();
        void Seed();
        Student UpdateStudent(Student studentToUpdate);
        Address UpdateStudentAddress(int studentId, Address addressToUpdate);
    }
}