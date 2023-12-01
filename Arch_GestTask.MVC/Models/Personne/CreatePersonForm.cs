namespace Arch_GestTask.MVC.Models.Personne
{
    public class CreatePersonForm
    {
        #region Fields
        private string _name;
        private string _surname;

        #endregion

        #region Properties
        public string Name { get => _name; set => _name = value; }
        public string Surname { get => _surname; set => _surname = value; }

        #endregion




    }
}
