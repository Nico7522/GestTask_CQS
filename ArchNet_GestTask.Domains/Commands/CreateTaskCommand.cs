using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.CQS.Commands;

namespace ArchNet_GestTask.Domains.Commands
{
    public class CreateTaskCommand : ICommandDefinition
    {
        public CreateTaskCommand(string titre, string description)
        {
            Titre = titre;
            Description = description;
        }
#nullable disable
        public string Titre { get; init; }
        public string Description { get; init; }

    }
}
