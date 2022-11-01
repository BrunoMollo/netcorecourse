using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCoreCourse.FirstExample.WebApp.DataAccess.Generic;
using NetCoreCourse.FirstExample.WebApp.Entities;

namespace NetCoreCourse.FirstExample.WebApp.Controllers
{
    [Route("api/[controller]")] 
    public class RepositorioBaseController : ControllerBase
    {
        private readonly ILogger logger;
        private readonly IRepositorioBase<TaskToDo> taskToDoRepository;
        private readonly IRepositorioBase<Item> itemRepository;

        public RepositorioBaseController
        (
            ILoggerFactory loggerFactory, 
            IRepositorioBase<TaskToDo> repoTask, 
            IRepositorioBase<Item> repoItem
        )
        {
            this.logger = loggerFactory.CreateLogger("NetCoreCourse");
            this.taskToDoRepository = repoTask;
            this.itemRepository=repoItem;
        }


        [HttpGet]
        public IActionResult baseRepository()
        {

            var firstItem = new Item(1, "mi primer item");
            var secondItem = new Item(2, "mi segundo item");

            var myTask = new TaskToDo(1, "mi tarea")
                            .Add(firstItem)
                            .Add(secondItem);

            itemRepository.ModifyDescription(firstItem, "mi primer item !!!!!!");
            taskToDoRepository.ModifyDescription(myTask, "mi tarea :)");

            logger.LogInformation(itemRepository.Add(firstItem));
            logger.LogInformation(itemRepository.Add(secondItem));
            logger.LogInformation(taskToDoRepository.Add(myTask));

            return Ok(myTask);
        }
    }
}
