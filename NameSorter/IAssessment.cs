using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter
{
    interface IAssessment
    {
        List<Name> ReadNameFromFile(string fileLocation);
        void SordName(List<Name> names);
        void PrintName(IEnumerable<Name> names );
        void WriteNameToFile(IEnumerable<Name> names, string fileLocation);
    }
}
