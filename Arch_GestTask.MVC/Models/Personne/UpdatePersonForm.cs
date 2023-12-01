namespace Arch_GestTask.MVC.Models.Personne
{
    public class UpdatePersonForm
    {
        #region Fields
        private int _personId;
        private string _name;
        private string _surname;

     

        #endregion

        public int PersonId { get => _personId; set => _personId = value; }
        #region Properties
        public string Name { get => _name; set => _name = value; }
        public string Surname { get => _surname; set => _surname = value; }

        #endregion

    }
}
