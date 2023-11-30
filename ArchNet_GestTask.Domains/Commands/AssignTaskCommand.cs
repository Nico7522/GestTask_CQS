using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.CQS.Commands;
using Tools.CQS.Queries;

namespace ArchNet_GestTask.Domains.Commands
{
    public class AssignTaskCommand : ICommandDefinition
    {
        public AssignTaskCommand(int id, int personId)
        {
            Id = id;
            PersonId = personId;
        }

        public int Id { get; init; }
        public int PersonId { get; init; }
    }
}
