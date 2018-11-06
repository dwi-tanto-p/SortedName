using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
              
                Console.WriteLine("Hallo please give me unsorted name list file:");

                var location = Console.ReadLine();

                var listName = GetListName(location); // Read File and return list of Name

                listName.Sort(); //Sort class of Name implements IComparable

                Console.WriteLine("Names after sorting are ...");
                Console.WriteLine("========================================");
                
                //display sorted list
                Display(listName);

                //write sorted list in the file
                CreateFile(listName);

                Console.WriteLine("========================================");

                Console.WriteLine("Names are written in working-folder as sorted-names-list.txt");


                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.Write("Sorry for this convenient |\n" + ex.Message);
                Console.ReadLine();
            }

        }

        static List<Name> GetListName(string fileLocation)
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

        static void Display(IEnumerable<Name> list)
        {
            foreach (var name in list)
            {
                Console.WriteLine(name.FullName);
            }
        }

        static void CreateFile(IEnumerable<Name> list )
        {
             const string file = ".\\sorted-names-list.txt";
          
            using (StreamWriter sw = File.CreateText(file))
            {
                foreach (var dt  in list)
                {
                    sw.WriteLine(dt.FullName);
                }
               sw.Close();
            }


        }
    }
}
