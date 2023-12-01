using Arch_GestTask.MVC.Models.Mappers;
using Arch_GestTask.MVC.Models.Personne;
using Arch_GestTask.MVC.Models.Tache;
using ArchNet_GestTask.Domains.Commands;
using ArchNet_GestTask.Domains.Queries;
using ArchNet_GestTask.Domains.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Arch_GestTask.MVC.Controllers
{
    public class PersonneController : Controller
    {
        private readonly IPersonneRepository _personRepository;

        public PersonneController(IPersonneRepository taskRepository)
        {
            _personRepository = taskRepository;
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
        //public IActionResult Edit(int id)
        //{
  
        //}

        //public IActionResult Edit()
        //{
        //    return View();
        //}
    }
}
