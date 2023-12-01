namespace Arch_GestTask.MVC.Models.Personne
{
    public class PersonDisplayForm
    {

        #region Fields
        private int _personId;
        private string _name;
        private string _surname;

        #endregion


        #region Properties
        public int PersonId { get => _personId; set => _personId = value; }
        public string Name { get => _name; set => _name = value; }
        public string Surname { get => _surname; set => _surname = value; }

        #endregion


        #region Ctor
        public PersonDisplayForm(int personId, string name, string surname)
        {
            _personId = personId;
            _name = name;
            _surname = surname;
        }

        #endregion

     
    }
}
