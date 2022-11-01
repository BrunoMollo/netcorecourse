namespace NetCoreCourse.FirstExample.WebApp.Entities
{
    public class TaskToDo : EntidadBase
    {
        public List<Item> items { get; }

        public TaskToDo(int id, string descripcion) : base(id, descripcion)
        {
            items = new List<Item>();
        }

        public TaskToDo Add(Item item)
        {
            items.Add(item);
            return this;
        }
    }
}
