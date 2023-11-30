using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchNet_GestTask.Domains.Entities
{
    public class Task
    {
        #nullable disable
        public Task(int id, string titre, string description, bool cloturee, int? personneId )
        {
            Id = id;
            Titre = titre;
            Description = description;
            Cloturee = cloturee;
            PersonneId = personneId;
        }

        public int Id { get; init; }
        public string Titre { get; set; }  
        public string Description { get; set; }
        public bool Cloturee { get; set; }
        public int? PersonneId { get; init; }
    }
}
