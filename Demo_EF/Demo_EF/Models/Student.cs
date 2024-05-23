using Demo_EF.Interfaces;
using System.Data;
using System.Text.Json.Serialization;

namespace Demo_EF.Models
{
    public class Student
    {
        public Student()
        {
            
        }
        public Student(int studentId, string firstName, string lastName, Grade grade)
        {
            StudentId = studentId;
            FirstName = firstName;
            LastName = lastName;
            Grade = grade;
        }

        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }
        public byte[]? Photo { get; set; }
        public decimal Height { get; set; }
        public float Weight { get; set; }
        public int GradeId { get; set; }

        [JsonIgnore]
        public Grade? Grade { get; set; }
    }
}
