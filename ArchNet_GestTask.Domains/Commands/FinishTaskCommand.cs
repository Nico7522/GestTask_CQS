using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.CQS.Commands;

namespace ArchNet_GestTask.Domains.Commands
{
    public class FinishTaskCommand : ICommandDefinition
    {
        public int Id { get; set; }

        public FinishTaskCommand(int id)
        {
            Id = id;
        }
    }
}
