namespace Arch_GestTask.MVC.Models.Tache
{
    public class TaskWithPersonForm
    {
        public TaskWithPersonForm(int taskId, string title, string description, bool isCompleted, int? personId, string name, string surname)
        {
            TaskId = taskId;
            Title = title;
            Description = description;
            IsCompleted = isCompleted;
            PersonId = personId;
            Name = name;
            Surname = surname;
        }

        public int TaskId { get; init; }
        public string Title { get; init; }
        public string Description { get; init; }
        public bool IsCompleted { get; init; }
        public int? PersonId { get; init; }
        public string Name { get; init; }
        public string Surname { get; init; }


    }
}
