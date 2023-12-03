using Arch_GestTask.MVC.Models.Personne;
using ArchNet_GestTask.Domains.Commands;
using TaskDomain = ArchNet_GestTask.Domains.Entities.Task;
using PersonDomain = ArchNet_GestTask.Domains.Entities.Personne;

namespace Arch_GestTask.MVC.Models.Mappers
{
    internal static class PersonMappers
    {

        internal static PersonDisplayForm ToPersonDisplay(this PersonDomain person)
        {
            return new PersonDisplayForm(person.Id, person.Nom, person.Prenom);
        }

		internal static PersonneEtTacheDisplayForm ToPersonEtTaskDisplay(this PersonDomain person)
		{
			return new PersonneEtTacheDisplayForm(person.Id, person.Nom, person.Prenom);
		}

		internal static CreatePersonneCommand ToCreatePersonneDomaine(this CreatePersonForm person)
        {
            return new CreatePersonneCommand(person.Name, person.Surname);
        }

        internal static UpdatePersonForm ToUpdatePerson(this PersonDomain person)
        {
            return new UpdatePersonForm() { 
            PersonId = person.Id,
            Name = person.Nom,
            Surname = person.Prenom
            };
        }

    }
}
