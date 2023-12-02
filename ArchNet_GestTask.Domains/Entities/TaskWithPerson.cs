using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchNet_GestTask.Domains.Entities
{
    public class TaskWithPerson
    {
        public TaskWithPerson(int taskId, string title, string description, bool isCompleted, int? personneId, string name, string surname)
        {
            TaskId = taskId;
            Title = title;
            Description = description;
            IsCompleted = isCompleted;
            PersonneId = personneId;
            Name = name;
            Surname = surname;
        }

        public int TaskId { get; init; }
        public string Title { get; init; }
        public string Description { get; init; }
        public bool IsCompleted { get; init; }
        public int? PersonneId { get; init; }
        public string Name { get; init; }
        public string Surname { get; init; }

    }
}
