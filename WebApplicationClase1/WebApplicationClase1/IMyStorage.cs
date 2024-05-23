
using WebApplicationClase1.Models;

namespace WebApplicationClase1
{
    public interface IMyStorage
    {
        List<ToDoList> _ToDoList { get; set; }
    }

    public class MyInMemoryStorage : IMyStorage
    {
        public List<ToDoList> _ToDoList { get; set; } = new List<ToDoList>();
    }
}
