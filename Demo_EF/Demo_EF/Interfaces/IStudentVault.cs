using Demo_EF.Models;

namespace Demo_EF.Interfaces
{
    public interface IStudentVault
    {
         IEnumerable<Student> GetStudents();
        
    }
}
