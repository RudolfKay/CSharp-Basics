using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBook
{
    public class PhoneDirectory
    {
        private SortedDictionary<int, PhoneEntry> _data;
        private int _dataCount;

        public PhoneDirectory()
        {
            _data = new SortedDictionary<int, PhoneEntry>();
            _dataCount = 0;
        }

        private int Find(string name)
        {
            for (var i = 0; i < _dataCount; i++)
            {
                if (_data.ElementAt(i).Value.Name.Equals(name))
                {
                    return i;
                }
            }

            return -1;
        }

        public string GetNumber(string name)
        {
            var position = Find(name);

            if (position == -1)
            {
                return null;
            }
            else
            {
                return _data.ElementAt(position).Value.Number;
            }
        }

        public void PutNumber(string name, string number)
        {
            if (name == null || number == null)
            {
                throw new Exception("name and number cannot be null");
            }

            var i = Find(name);

            if (i >= 0)
            {
                _data[i].Number = number;
            }
            else
            {
                var newEntry = new PhoneEntry(name, number);
                _data[_dataCount] = newEntry;
                _dataCount++;
            }
        }

        public void PrintDirectory()
        {
            foreach (int key in _data.Keys)
            {
                Console.WriteLine($"{key} : {_data[key].Name} | {GetNumber(_data[key].Name)}");
            }
        }
    }
}