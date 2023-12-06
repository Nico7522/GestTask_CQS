using Arch_GestTask.MVC.Models.Tache;

namespace Arch_GestTask.MVC.Models.Personne
{
	public class PersonneEtTacheDisplayForm
	{
		private int _personId;
		private string _name;
		private string _surname;
		private List<TaskDisplayDetailsForm>? _tasks;

		public PersonneEtTacheDisplayForm(int personId, string name, string surname)
		{
			_personId = personId;
			_name = name;
			_surname = surname;
			_tasks = new List<TaskDisplayDetailsForm>();
		}
		
		public int PersonId { get => _personId; set => _personId = value; }
		public string Name { get => _name; set => _name = value; }
		public string Surname { get => _surname; set => _surname = value; }
		public List<TaskDisplayDetailsForm>? Tasks { get => _tasks; set => _tasks = value; }
	}
}
