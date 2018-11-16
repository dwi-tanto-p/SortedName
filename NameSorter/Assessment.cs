using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter
{
    class Assessment:IAssessment
    {
        public List<Name> ReadNameFromFile(string fileLocation)
        {
            string line;
            var listName = new List<Name>();

            var file = new StreamReader(fileLocation);

            while ((line = file.ReadLine()) != null)
            {
                if (line.Trim().Length != 0) //make sure that name not empty
                    listName.Add(new Name(line));
            }

            file.Close();
            return listName;
        }

        public void SordName(List<Name> names)
        {
            names.Sort(); // Name is implement IComparable
        }

        public void PrintName(IEnumerable<Name> names)
        {
            foreach (var name in names)
            {
                Console.WriteLine(name.FullName);
            }
        }

        public void WriteNameToFile(IEnumerable<Name> names, string fileLocation)
        {
            using (StreamWriter sw = File.CreateText(fileLocation))
            {
                foreach (var dt in names)
                {
                    sw.WriteLine(dt.FullName);
                }
                sw.Close();
            }
        }

       
    }
}
