﻿using Data.Exceptions;
using Data.Models;
using Data.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Services
{
    public partial class DataAccessLayerService : IDataAccessLayerService
    {
        public Mark CreateMark(Mark mark)
        {
            if (ctx.Marks.Any(x => x.Id == mark.Id))
            {
                throw new Exception("Mark already exists");
            }
            var student = ctx.Students.FirstOrDefault(s => s.Id == mark.StudentId);

            if (student is null) {
                throw new InvalidIdException($"Invalid student id {mark.StudentId}");
            }
            var course = ctx.Courses.Include(s => s.Students).FirstOrDefault(c => c.Id == mark.CourseId);

            if (course is null)
            {
                throw new InvalidIdException($"Invalid course id {mark.CourseId}");
            }
            if (!course.Students.Any(s => s.Id == student.Id))
            {
                course.Students.Add(student);
            }
            ctx.Marks.Add(mark);
            ctx.SaveChanges();
            return mark;
        }

        public IEnumerable<Mark> GetMarksByStudentId(int studentId) 
            => ctx.Marks.Include(c => c.Course).Where(m => m.StudentId == studentId).ToList();

        public IEnumerable<Mark> GetByStudentAndCourse(int studentId, int courseId)
            => ctx.Marks.Include(c => c.Course).Where(m => m.StudentId == studentId).Where(c => c.Id == courseId).ToList();

        public double GetAvgByStudentAndCourse(int studentId, int courseId)
            => ctx.Marks.Where(m => m.StudentId == studentId).Where(m => m.CourseId == courseId).Average(m => m.Value);
    }
}
