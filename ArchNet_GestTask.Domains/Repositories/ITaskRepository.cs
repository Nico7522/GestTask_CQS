using TaskModel = ArchNet_GestTask.Domains.Entities.Task;
using ArchNet_GestTask.Domains.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.CQS.Queries;
using Tools.CQS.Commands;
using ArchNet_GestTask.Domains.Commands;

namespace ArchNet_GestTask.Domains.Repositories
{
    public interface ITaskRepository : IQueryHandler<GetAllTaskQuery, IEnumerable<TaskModel>>, IQueryHandler<GetOneTaskQuery, TaskModel>, ICommandHandler<CreateTaskCommand>, ICommandHandler<UpdateTaskCommand>, ICommandHandler<AssignTaskCommand>, ICommandHandler<FinishTaskCommand>
    {
    }
}
