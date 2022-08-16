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
            return _mother.GetName() == otherDog.GetMothersName();
        }

        public string GetFathersName()
        {
            return _father == null ? "Unknown" : _father.GetName();
        }

        public string GetMothersName()
        {
            return _mother == null ? "Unknown" : _mother.GetName();
        }

        public string GetName()
        {
            return _name;
        }

        public string GetSex()
        {
            return _sex;
        }

        public override string ToString()
        {
            return $"Name: {_name}, Sex: {_sex}, Mother: {_mother.GetMothersName()}, Father: {_father.GetFathersName()}.";
        }
    }
}
