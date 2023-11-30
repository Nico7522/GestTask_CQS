using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.CQS.Commands;

namespace ArchNet_GestTask.Domains.Commands
{
    public class UpdateTaskCommand : ICommandDefinition
    {
        public UpdateTaskCommand(int id, string titre, string description)
        {
            Id = id;
            Titre = titre;
            Description = description;
        }

        public int Id { get; init; }
        public string Titre { get; init; }
        public string Description { get; init; }
    }
}
