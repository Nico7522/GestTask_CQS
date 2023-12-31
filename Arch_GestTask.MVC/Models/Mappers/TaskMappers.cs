﻿using Arch_GestTask.MVC.Models.Tache;
using ArchNet_GestTask.Domains.Entities;
using TaskDomain = ArchNet_GestTask.Domains.Entities.Task;

namespace Arch_GestTask.MVC.Models.Mappers
{
    internal static class TaskMappers
    {

        internal static TaskDisplayForm ToTaskDisplay(this TaskDomain task)
        {
            return new TaskDisplayForm()
            {
                TaskId = task.Id,
                Title = task.Titre,
                Description = task.Description,
                
            };

        }

        internal static TaskDisplayDetailsForm ToTaskDisplayDetail(this TaskDomain task)
        {

            return new TaskDisplayDetailsForm()
            {
                TaskId = task.Id,
                Title = task.Titre,
                Description = task.Description,
                IsComplete = task.Cloturee,
                PersonId = task.PersonneId
            };
        }

        internal static TaskUpdateForm ToTaskUpdate(this TaskDomain task)
        {

            return new TaskUpdateForm()
            {
                TaskId = task.Id,
                Title = task.Titre,
                Description = task.Description,
            
            };
        }

        internal static TaskWithPersonForm ToTaskWithPerson(this TaskWithPerson task)
        {
            return new TaskWithPersonForm(task.TaskId, task.Title, task.Description, task.IsCompleted, task.PersonneId, task.Name, task.Surname);
        }
    }
}
