using System;

namespace Exercise6
{
    public class Dog
    {
        private string _name;
        private string _sex;
        private Dog _mother;
        private Dog _father;

        public Dog(string name, string sex)
        {
            _name = name;
            _sex = sex;
        }

        public void AddParents(Dog mother, Dog father)
        {
            _mother = mother;
            _father = father;
        }

        public bool HasSameMotherAs(Dog otherDog)
        {
            return _mother.GetName() == otherDog._mother.GetName();
        }

        public string GetFathersName()
        {
            return _father == null ? "Unknown" : _father.GetName();
        }

        public string GetName()
        {
            return $"{_name}";
        }

        public string GetSex()
        {
            return $"{_sex}";
        }

        public override string ToString()
        {
            string unknownMother = "Unknown";

            if (_mother != null)
            {
                return $"{_name} {_sex} {_mother.GetName()} {_father.GetFathersName()}";
            }

            return $"Name: {_name}, Sex: {_sex}, Mother: {unknownMother}, Father: {_father.GetFathersName()}.";

        }
    }
}
