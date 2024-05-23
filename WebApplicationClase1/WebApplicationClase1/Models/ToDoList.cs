
namespace WebApplicationClase1.Models
{
    public class ToDoList: EntityBase
    {
        public List<ListItem> ListItems { get; set; }
        public ToDoList()
        {
            ListItems = new List<ListItem>();
        }
    }
}
