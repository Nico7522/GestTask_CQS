using TaskModel = ArchNet_GestTask.Domains.Entities.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.CQS.Queries;

namespace ArchNet_GestTask.Domains.Queries
{
    public class GetOneTaskQuery : IQueryDefinition<TaskModel>
    {
        public GetOneTaskQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
