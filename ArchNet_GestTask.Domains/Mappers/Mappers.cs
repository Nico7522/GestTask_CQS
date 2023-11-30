using TaskModel = ArchNet_GestTask.Domains.Entities.Task;
using PersonModel = ArchNet_GestTask.Domains.Entities.Personne;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchNet_GestTask.Domains.Mappers
{
    internal static class Mappers
    {
        internal static PersonModel ToPersonne(this IDataRecord record)
        {            
            return new PersonModel((int)record["Id"], (string)record["Nom"], (string)record["Prenom"]);
        }

        internal static TaskModel ToTask(this IDataRecord record)
        {
            return new TaskModel((int)record["Id"], (string)record["Titre"], (string)record["Description"], (bool)record["Cloturee"], record["PersonneId"] as int?);
        }
    }
}
