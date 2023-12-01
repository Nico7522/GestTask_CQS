using Arch_GestTask.MVC.Models.Personne;

namespace Arch_GestTask.MVC.Models.Tache
{
    public class AssignTaskForm
    {
        private int _personId;
        private List<PersonDisplayForm> people = new List<PersonDisplayForm>();

        public int PersonId { get => _personId; set => _personId = value; }
        public List<PersonDisplayForm> People { get => people; set => people = value; }
    }
}
