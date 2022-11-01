namespace NetCoreCourse.FirstExample.WebApp.Entities
{
    public abstract class EntidadBase
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public EntidadBase(int id, string descripcion)
        {
            Id = id;
            Descripcion = descripcion;
        }
    }
}
