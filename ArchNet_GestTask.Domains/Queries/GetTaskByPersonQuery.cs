using TaskModel = ArchNet_GestTask.Domains.Entities.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.CQS.Queries;

namespace ArchNet_GestTask.Domains.Queries
{
	public class GetTaskByPersonQuery : IQueryDefinition<IEnumerable<TaskModel>>
	{
        public int PersonId { get; set; }
        public GetTaskByPersonQuery(int personId)
        {
            PersonId = personId;
        }
    }
}
