namespace Arch_GestTask.MVC.Models.Tache
{
    public class TaskUpdateForm
    {
        private int _taskId;
        private string _title;
        private string _description;

        public int TaskId { get => _taskId; set => _taskId = value; }
        public string Title { get => _title; set => _title = value; }
        public string Description { get => _description; set => _description = value; }
    }
}
