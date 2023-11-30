using ArchNet_GestTask.Domains.Commands;
using TaskModel = ArchNet_GestTask.Domains.Entities.Task;
using ArchNet_GestTask.Domains.Queries;
using ArchNet_GestTask.Domains.Repositories;
using ArchNet_GestTask.Domains.Services;
using System.Data.Common;
using System.Data.SqlClient;
using Tools.CQS.Commands;
using Tools.CQS.Queries;

namespace ArchNet_GestTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using(DbConnection connection = new SqlConnection(@"Data Source=GOS-VDI202\TFTIC;Initial Catalog=TaskDB;Integrated Security=True;Connect Timeout=60;Encrypt=False;"))
            {
                IPersonneRepository repository = new PersonneService(connection);
                ITaskRepository taskRepository = new TaskService(connection);

                //IEnumerable<Personne> personnes = repository.Execute(new GetAllPersonneQuery());

                //foreach (Personne p in personnes)
                //{
                //    Console.WriteLine(p.Nom);
                //}

                //CommandResult result = repository.Execute(new CreatePersonneCommand("Woodpecker", "Woody"));
                //if(result.IsSuccess)
                //{
                //    Console.WriteLine("Insertion réussie");
                //}
                //else
                //{
                //    Console.WriteLine($"Un problème est survernu : \n{result.ErrorMessage}");
                //}


                #region Create task
                //CommandResult result = taskRepository.Execute(new CreateTaskCommand("nouvelle tache", "quelque chose"));

                #endregion


                #region GetAll Tasks
                //QueryResult<IEnumerable<TaskModel>> tasks = taskRepository.Execute(new GetAllTaskQuery());
                // if (tasks.IsSuccess)
                // {
                // foreach (var item in tasks.Result!)
                // {
                //     Console.WriteLine(item.Description);
                // }

                // }

                #endregion


                #region Get One Task
                //QueryResult<TaskModel> response = taskRepository.Execute(new GetOneTaskQuery(1));

                //if (response != null)
                //{
                //    Console.WriteLine(response?.Result?.Description);
                //}

                #endregion

                #region Update Task

                //CommandResult response = taskRepository.Execute(new UpdateTaskCommand(1, "refaire les course", "zzz"));

                //if (response.IsSuccess)
                //    Console.WriteLine("ok");

                #endregion

                #region Assign task

                //CommandResult response = taskRepository.Execute(new AssignTaskCommand(6, 2));

                //if (response.IsSuccess)
                //{
                //    Console.WriteLine("ok");
                //}

                #endregion


                #region Finish Task

                CommandResult response = taskRepository.Execute(new FinishTaskCommand(1));

                if (response.IsSuccess)
                    Console.WriteLine("ok");
                

                #endregion
            }         
            

        }
    }
}
