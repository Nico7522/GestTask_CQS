using TaskModel = ArchNet_GestTask.Domains.Entities.Task;
using ArchNet_GestTask.Domains.Mappers;
using ArchNet_GestTask.Domains.Queries;
using ArchNet_GestTask.Domains.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.CQS.Queries;
using Tools.Database;
using Tools.CQS.Commands;
using ArchNet_GestTask.Domains.Commands;
using ArchNet_GestTask.Domains.Entities;

namespace ArchNet_GestTask.Domains.Services
{
    public class TaskService : ITaskRepository
    {
        private readonly DbConnection _dbConnection;

        public TaskService(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public QueryResult<IEnumerable<TaskModel>> Execute(GetAllTaskQuery query)
        {
            try
            {
                _dbConnection.Open();
                return QueryResult<IEnumerable<TaskModel>>.Success(_dbConnection.ExecuteReader("SELECT Id, Titre, [Description], Cloturee, PersonneId FROM Tache;", record => record.ToTask()));
            }
            catch (Exception ex)
            {

               return QueryResult<IEnumerable<TaskModel>>.Failure(ex.Message);
            }
          
        }

        public CommandResult Execute(CreateTaskCommand command)
        {
            try
            {
                _dbConnection.Open();
                int newTaskId = (int)_dbConnection.ExecuteScalar("INSERT INTO Tache (Titre, [Description]) OUTPUT inserted.Id VALUES (@Titre, @Description)", parameters: command);
                if (newTaskId < 1)
                    return CommandResult.Failure("Erreur dans le nombre de ligne affectées");

                return CommandResult.Success(newTaskId);
            }
            catch (Exception ex)
            {

                return CommandResult.Failure(ex.Message);
            }
        }

        public QueryResult<TaskModel> Execute(GetOneTaskQuery query)
        {
            try
            {
                _dbConnection.Open();
                TaskModel task = _dbConnection.ExecuteReader("SELECT Id, Titre, [Description], Cloturee, PersonneId FROM Tache WHERE Id = @Id;", record => record.ToTask(), parameters: new { Id = query.Id }).SingleOrDefault();
                if (task == null)
                    return QueryResult<TaskModel>.Failure("Tache non trouvé");

                return QueryResult<TaskModel>.Success(task);


            }
            catch (Exception ex)
            {

               return QueryResult<TaskModel>.Failure("Erreur" + ex.Message);
            }
        }

        public CommandResult Execute(UpdateTaskCommand command)
        {
            try
            {
                _dbConnection.Open();
               int isUpdated = _dbConnection.ExecuteNonQuery("UPDATE Tache SET Titre = @Titre, [Description] = @Description WHERE Id = @Id", parameters: command);


                if (isUpdated != 1)
                    return CommandResult.Failure("Erreur");

                return CommandResult.Success(); 
            }
            catch (Exception)
            {

                return CommandResult.Failure("Erreur");
            }
        }

        public CommandResult Execute(AssignTaskCommand command)
        {
            try
            {
                _dbConnection.Open();
                int isUpdated = _dbConnection.ExecuteNonQuery("UPDATE Tache SET PersonneId = @PersonneId WHERE Id = @Id", parameters: new {Id = command.Id, PersonneId = command.PersonId});

              

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
              
                return CommandResult.Failure(ex.Message);
            }
        }

        public CommandResult Execute(FinishTaskCommand command)
        {
            try
            {
            _dbConnection.Open();
           int isUpdated = _dbConnection.ExecuteNonQuery("UPDATE Tache SET Cloturee = 1 WHERE Id = @Id", parameters: command);

            if (isUpdated != 1)
                return CommandResult.Failure("Erreur");

            return CommandResult.Success();

            }
            catch (Exception ex)
            {

                return CommandResult.Failure(ex.Message);
            }
        }

        public QueryResult<IEnumerable<TaskWithPerson>> Execute(GetAllTaskWithPersonQuery query)
        {
            try
            {
                _dbConnection.Open();
                string dbQuery = "SELECT * FROM Tache t LEFT JOIN Personne p ON t.PersonneId = p.Id;";
                return QueryResult<IEnumerable<TaskWithPerson>>.Success(_dbConnection.ExecuteReader(dbQuery, (t => t.ToTaskWithPerson())));
            }
            catch (Exception ex)
            {
                return QueryResult<IEnumerable<TaskWithPerson>>.Failure(ex.Message);
            }
        }

		public QueryResult<IEnumerable<TaskModel>> Execute(GetTaskByPersonQuery query)
		{
			try
			{
				_dbConnection.Open();
				return QueryResult<IEnumerable<TaskModel>>.Success(_dbConnection.ExecuteReader("SELECT Id, Titre, [Description], Cloturee, PersonneId FROM Tache WHERE PersonneId = @Id;", record => record.ToTask(), parameters: new { Id = query.PersonId }));
			}
			catch (Exception ex)
			{
				return QueryResult<IEnumerable<TaskModel>>.Failure("Erreur" + ex.Message);
			}

		}
	}
}
