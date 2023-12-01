namespace Arch_GestTask.MVC.Models.Tache
{
    public class TaskDisplayDetailsForm
    {

        private int _taskId;
        private string _title;
        private string _description;
        private bool _isComplete;
        private int? _personId;

        public int TaskId { get => _taskId; set => _taskId = value; }
        public string Title { get => _title; set => _title = value; }
        public string Description { get => _description; set => _description = value; }
        public bool IsComplete { get => _isComplete; set => _isComplete = value; }
        public int? PersonId { get => _personId; set => _personId = value; }
    }
}
