using System;

namespace NameSorter
{
    public class Name : IComparable
    {
        private  string[] _nameArr;
        private string _fullName;

        public Name(string fullName)
        {
            FullName = fullName;
            _nameArr = fullName.Split(' ');
        }

        public string FullName
        {
            get { return _fullName; }
            set
            {
                _fullName = value;
                _nameArr = value.Split(' ');
                
            }
        }
      
        public string GetLastName()
        {
            return _nameArr[_nameArr.Length - 1];
        }

        public string GetFirstName()
        {
            string firstName = "";
            for (int i = 0; i < _nameArr.Length - 1; i++)
            {
                firstName = firstName + " " + _nameArr[i];

            }
            if (firstName.Length > 0)
                return firstName.Substring(1); //remove first space
            return "";
        }

        // implement IComparable interface
        // this will be use for Array.Sort method
        public int CompareTo(object obj)
        {
            var name = obj as Name;
            if (name != null)
            {
                string lastNameA = this.GetLastName();
                string lastNameB = name.GetLastName();
                var result = String.Compare(lastNameA, lastNameB, StringComparison.InvariantCultureIgnoreCase);

                if (result == 0) //last name is same then check first Name
                {
                    string firstNameA = this.GetFirstName();
                    string firstNameB = name.GetFirstName();
                   
                    result = string.Compare(firstNameA, firstNameB, StringComparison.InvariantCultureIgnoreCase);
                }

                return result;

            }
            throw new ArgumentException("Object is not a Name");
        }

        public override string ToString()
        {
            return _fullName;
        }
    }
}