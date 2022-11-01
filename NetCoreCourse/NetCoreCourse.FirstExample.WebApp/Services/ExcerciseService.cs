namespace NetCoreCourse.FirstExample.WebApp.Services
{
    public class ExcerciseService : IExcerciseService
    {
        public string getExcercise(int id)
        {
            if (id == 2) return "Crear una interfaz “IExcerciseService” y agregar la firma de un metodo (el que ustedes quieran), crear una clase “ExcerciseService” que implemente dicha interfaz. Agregar en el “ServicesController” dicha interfaz como dependencia y utilizarla en cualquier de los metodos existentes.";

            else return "idk";
        
        }
    }
}
