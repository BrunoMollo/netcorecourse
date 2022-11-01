namespace NetCoreCourse.FirstExample.WebApp.DataAccess.Generic
{
    public interface IRepositorioBase<T>
    {
        public string Add(T entity);
        public T ModifyDescription(T entity, string newDescription);
    }
}
