using System;

namespace NameSorter
{
    /// <summary>
    /// inherit IComparable so it can be used for sorting
    /// </summary>
    public class Name : IComparable
    {
        private  string[] _nameArr;
        private string _fullName;

        private Name()
        {
            
        }
        /// <summary>
        /// This constructor is to make garancy that Name must have at least 1 name
        /// </summary>
        /// <param name="fullName">Full Name at least 1 name</param>
        public Name(string fullName)
        {
            FullName = fullName;//here will be check existency of full name
        }

        /// <summary>
        /// Will check existancy of Name
        /// and throw IndexOutOfRangeException if empty
        /// </summary>
        public string FullName
        {
            get { return _fullName; }
            set
            {
                var charSeparator = new[] {' '};
                _nameArr = value.Split(charSeparator, StringSplitOptions.RemoveEmptyEntries); //split value and remove empty entry

                if (_nameArr.Length == 0)
                {
                    throw new IndexOutOfRangeException("Name must have at least 1 name");
                }

                _fullName = string.Join(" ", _nameArr);
            }
        }
      
        /// <summary>
        /// Will return last name
        /// </summary>
        /// <returns></returns>
        public string GetLastName()
        {
            return _nameArr[_nameArr.Length - 1];
        }

        /// <summary>
        /// will return all name but last name
        /// (1st-name, 2nd-name, 3rd-name, ...)
        /// </summary>
        /// <returns></returns>
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

       
        /// <summary>
        /// implement IComparable interface
        /// this will be use for Array.Sort method
        /// It will order base on LastName and then by FistName 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
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