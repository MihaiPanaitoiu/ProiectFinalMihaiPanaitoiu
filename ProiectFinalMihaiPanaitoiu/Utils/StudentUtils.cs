using Data.Models;
using ProiectFinalMihaiPanaitoiu.DTOS;

namespace ProiectFinalMihaiPanaitoiu.Utils
{
    public static class StudentUtils
    {
        public static StudentToGetDto ToDto(this Student student)
        {
            if(student == null)
            {
                return null;
            }

          return new StudentToGetDto
            {
                Id = student.Id,
                LastName = student.LastName,
                FirstName = student.FirstName,
                Age = student.Age,
            };
        }

        public static StudentToAritmeticMeanDto ToDto(this (Student, double) studentToAritmeticMean)
        {

            return new StudentToAritmeticMeanDto
            {
                Id = studentToAritmeticMean.Item1.Id,
                LastName = studentToAritmeticMean.Item1.LastName,
                FirstName = studentToAritmeticMean.Item1.FirstName,
                Age = studentToAritmeticMean.Item1.Age,
                AritmeticMean = studentToAritmeticMean.Item2,
            };
        }

        public static IEnumerable<StudentToAritmeticMeanDto> ToDto(this IEnumerable<(Student, double)> studentToAritmeticMean) 
            => studentToAritmeticMean.Select(x => ToDto(x));

        public static Student ToEntity(this StudentToCreateDto student)
        {
            if (student == null)
            {
                return null;
            }
            return new Student
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                Age = student.Age,
            };
        }

        public static Student ToEntity(this StudentToUpdateDto student)
        {
            if (student == null)
            {
                return null;
            }
            return new Student
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Age = student.Age,
            };
        }

        public static Address ToEntity(this AddressToUpdateDto address)
        {
            if (address == null)
            {
                return null;
            }

            return new Address
            {
                Street = address.Street,
                City = address.City,
                Number = address.Number,
            };

        }
    }
}
