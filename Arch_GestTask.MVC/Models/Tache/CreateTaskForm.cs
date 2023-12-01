using System.ComponentModel.DataAnnotations;

namespace Arch_GestTask.MVC.Models.Tache
{
    #nullable disable
    public class CreateTaskForm
    {
        [Required]
        private string _title;
        [Required]
        private string _description;

        public string Title { get => _title; set => _title = value; }
        public string Description { get => _description; set => _description = value; }
    }
}
