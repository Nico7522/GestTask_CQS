using Arch_GestTask.MVC.Models.Mappers;
using Arch_GestTask.MVC.Models.Personne;
using Arch_GestTask.MVC.Models.Tache;
using ArchNet_GestTask.Domains.Commands;
using TaskModel = ArchNet_GestTask.Domains.Entities.Task;
using ArchNet_GestTask.Domains.Queries;
using ArchNet_GestTask.Domains.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Arch_GestTask.MVC.Controllers
{
    public class PersonneController : Controller
    {
        private readonly IPersonneRepository _personRepository;
        private readonly ITaskRepository _taskRepository;

        public PersonneController(IPersonneRepository personRepository, ITaskRepository taskRepository)
        {
            _personRepository = personRepository;
            _taskRepository = taskRepository;
        }

        public IActionResult Index()
        {

            var response = _personRepository.Execute(new GetAllPersonneQuery());

            if (response.IsSuccess && response.Result!.Count() > 0)
            {
                List<PersonDisplayForm> people = response.Result.Select(p => p.ToPersonDisplay()).ToList();    
            return View(people);
                
            }

            return View();

        }

       public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreatePersonForm form) {

            if (ModelState.IsValid)
            {
                var response = _personRepository.Execute(new ArchNet_GestTask.Domains.Commands.CreatePersonneCommand(form.Name, form.Surname));
                if (response.IsSuccess) 
                    return RedirectToAction("Index");
            }

            return View();
        }


        // TODO
        public IActionResult Edit(int id)
        {
            var response = _personRepository.Execute(new GetOnePersonQuery(id));

            UpdatePersonForm person = response.Result.ToUpdatePerson();
            if (response.IsSuccess)
                return View(person);

            return View();
        }

        [HttpPost]
        public IActionResult Edit(UpdatePersonForm form, int id)
        {
            var response = _personRepository.Execute(new UpdatePersonneCommand(id, form.Name, form.Surname));
            if (response.IsSuccess)
                return RedirectToAction("Index");

            return View();
        }

        public IActionResult PersonneEtTache()
        {
			var response = _personRepository.Execute(new GetAllPersonneQuery());
			if (response.IsSuccess && response.Result!.Count() > 0)
			{
				List<PersonneEtTacheDisplayForm> people = response.Result.Select(p => p.ToPersonEtTaskDisplay()).ToList();

                foreach (var item in people)
                {
					var taskResponse = _taskRepository.Execute(new GetTaskByPersonQuery(item.PersonId));
                    foreach (var task in taskResponse.Result)
                    {
                    item.Tasks.Add(task.ToTaskDisplayDetail());
                        
                    }
                };
                return View(people);

			}

			return View();
		}
    }
}
