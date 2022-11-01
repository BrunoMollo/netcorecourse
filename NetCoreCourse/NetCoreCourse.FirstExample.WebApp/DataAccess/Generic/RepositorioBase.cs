using NetCoreCourse.FirstExample.WebApp.Entities;

namespace NetCoreCourse.FirstExample.WebApp.DataAccess.Generic
{
    public class RepositorioBase<T> : IRepositorioBase<T>
        where T : EntidadBase
    {
        public string Add(T entity) => $"El {entity.GetType().Name} con Id {entity.Id} fue agregado";

        public T ModifyDescription(T entity, string newDescription)
        {
            entity.Descripcion = newDescription;
            return entity;
        }

    }
}
