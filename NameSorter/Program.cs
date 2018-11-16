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
                IAssessment ass = new Assessment();

              
                Console.WriteLine("Hallo please give me unsorted name list file:");
                var fileToRead = Console.ReadLine();
               
                var listName = ass.ReadNameFromFile(fileToRead);


                ass.SordName(listName); //now sort listname

                Console.WriteLine("this data is after sorting");
                ass.PrintName(listName); //display names

                ass.WriteNameToFile(listName, "sorted-names-list.txt");

                Console.WriteLine("========================================");
                Console.WriteLine("");
                Console.WriteLine("Note: Names are written in working-folder as sorted-names-list.txt");


                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.Write("Sorry for this convenient |\n" + ex.Message);
                Console.ReadLine();
            }

        }

       
    }
}
