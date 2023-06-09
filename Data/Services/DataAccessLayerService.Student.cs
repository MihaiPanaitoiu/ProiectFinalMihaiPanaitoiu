﻿using Data.Exceptions;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Services
{
    public partial class DataAccessLayerService : IDataAccessLayerService
    {
        public IEnumerable<Student> GetStudents() => ctx.Students.ToList();
 

        public Student GetStudentById(int id)
        {
            var student = ctx.Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                throw new InvalidIdException($"Student not found with id {id}");
            }
            return student;
        }

        public Student CreateStudent(Student student)
        {
            if (ctx.Students.Any(x => x.Id == student.Id))
            {
                throw new DuplicatedIdException($"Duplicated student id {student.Id}");
            }
            ctx.Add(student);
            ctx.SaveChanges();
            return student;
        }

        public Student UpdateStudent(Student studentToUpdate)
        {
            var student = ctx.Students.FirstOrDefault(s => s.Id == studentToUpdate.Id);

            if (student == null)
            {
                throw new InvalidIdException($"Student not found with id {studentToUpdate.Id}");
            }

            student.FirstName = studentToUpdate.FirstName;
            student.LastName = studentToUpdate.LastName;
            student.Age = studentToUpdate.Age;

            ctx.SaveChanges();

            return student;
        }

        public Address UpdateStudentAddress(int studentId, Address addressToUpdate)
        {
            var student = ctx.Students.Include(s => s.Address).FirstOrDefault(s => s.Id == studentId);

            if (student == null)
            {
                throw new InvalidIdException($"Student not found with id {studentId}");
            }

            if (student.Address == null)
            {
                student.Address = new Address();
            }

            student.Address.Street = addressToUpdate.Street;
            student.Address.City = addressToUpdate.City;
            student.Address.Number = addressToUpdate.Number;

            ctx.SaveChanges();

            return student.Address;
        }

        public void DeleteStudent(int studentId)
        {
            var student = ctx.Students.FirstOrDefault(s => s.Id == studentId) 
                ?? throw new InvalidIdException($"Student not found with Id {studentId}");
            ctx.Students.Remove(student);
            ctx.SaveChanges();
        }

        public IEnumerable<(Student, double)> GetAritmeticMean(SortDirectionEnum sortDir)
        {
            var studentsWithGrades = ctx.Students.Where(s => s.Marks.Any())
                .Select(s => new { Student = s, AritmeticMean = s.Marks.Average(m => m.Value) });
           
            if (sortDir == SortDirectionEnum.Asc)
            {
                studentsWithGrades = studentsWithGrades.OrderBy(s => s.AritmeticMean);
            } else
            {
                studentsWithGrades = studentsWithGrades.OrderByDescending(s => s.AritmeticMean);
            }
            return studentsWithGrades.ToList().Select(s =>
                         (s.Student, s.AritmeticMean)
                 );
        }
    }
}
