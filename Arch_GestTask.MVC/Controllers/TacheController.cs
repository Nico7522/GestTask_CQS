using Arch_GestTask.MVC.Models.Mappers;
using Arch_GestTask.MVC.Models.Tache;
using ArchNet_GestTask.Domains.Commands;
using ArchNet_GestTask.Domains.Entities;
using ArchNet_GestTask.Domains.Queries;
using ArchNet_GestTask.Domains.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Arch_GestTask.MVC.Controllers
{
    public class TacheController : Controller
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IPersonneRepository _personRepository;
        public TacheController(ITaskRepository taskRepository, IPersonneRepository personRepository)
        {
            _taskRepository = taskRepository;
            _personRepository = personRepository;
        }

        public IActionResult Index()
        {
            var response = _taskRepository.Execute(new ArchNet_GestTask.Domains.Queries.GetAllTaskQuery());
            if (response.IsSuccess && response.Result!.Count() > 0)
            {
                List<TaskDisplayForm> tasks = response.Result!.Select(t => t.ToTaskDisplay()).ToList();
                return View(tasks);
            }
            return View();
        }

        public IActionResult TacheEtPersonne()
        {
            var response = _taskRepository.Execute(new GetAllTaskWithPersonQuery());
            if (response.IsSuccess && response.Result!.Count() > 0)
            {
                List<TaskWithPersonForm> tasks = response.Result.Select(t => t.ToTaskWithPerson()).ToList();
                return View(tasks);
            }
            return View();
        }

        public IActionResult PartialPersonne()
        {
            return new PartialViewResult()
            {
                ViewName = "PartialPersonne"
            };
        }

        public IActionResult Details(int id)
        {
            var response = _taskRepository.Execute(new GetOneTaskQuery(id));
            if (response.IsSuccess && response.Result != null)
            {
                TaskDisplayDetailsForm task = response.Result.ToTaskDisplayDetail();
                return View(task);
            }

            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateTaskForm form)
        {
            var response = _taskRepository.Execute(new CreateTaskCommand(form.Title, form.Description));
            if (response.IsSuccess)
                return RedirectToAction("Index");
            
            return View();
        }

        public IActionResult Edit(int id)
        {
            var response = _taskRepository.Execute(new GetOneTaskQuery(id));
          
                TaskUpdateForm task = response.Result.ToTaskUpdate();
            if (response.IsSuccess)
                return View(task);

            return View();
        }

        [HttpPost]
        public IActionResult Edit(TaskUpdateForm form, int id)
        {
            var response = _taskRepository.Execute(new UpdateTaskCommand(id, form.Title, form.Description));
            if (response.IsSuccess)
                return RedirectToAction("Details", new { id });

            return View();
        }

        
        public IActionResult Complete(int id)
        {
            Console.WriteLine(id);
            var response = _taskRepository.Execute(new FinishTaskCommand(id));
            if (response.IsSuccess)
                return RedirectToAction("Details", new { id });

            return View();
        }

        public IActionResult Assign(int id)
        {
            AssignTaskForm form = new AssignTaskForm();
            var response = _personRepository.Execute(new GetAllPersonneQuery());
            if (response.IsSuccess)
            {
                form.People = response.Result.Select(p => p.ToPersonDisplay()).ToList();
                return View(form);
            } else
            {
                return View();
            }
        }
        [HttpPost]
        public IActionResult Assign(AssignTaskForm form, int id)
        {
            Console.WriteLine(form.PersonId);
            var response = _taskRepository.Execute(new AssignTaskCommand(id, form.PersonId));
            if (response.IsSuccess)
                return RedirectToAction("Details", new { id });

        return View(form);
        }

        public IActionResult Partial() 
        {
			if (ViewData.ContainsKey("TaskId") && ViewData["TaskId"] is int taskId)
			{

				var response = _taskRepository.Execute(new GetOneTaskQuery(taskId));
				if (response.IsSuccess && response.Result != null)
				{
					TaskDisplayDetailsForm task = response.Result.ToTaskDisplayDetail();
					return PartialView(task);
				}

			}
			return new PartialViewResult
			{
				ViewName = "Partial",
			};
		}
	}
}
