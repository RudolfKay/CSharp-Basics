namespace PhoneBook
{
    public class PhoneEntry
    {
        private string _name;
        private string _number;

        public PhoneEntry(string name, string number)
        {
            _name = name;
            _number = number;
        }

        public string Number
        {
            get => _number;
            set => _number = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }
    }
}