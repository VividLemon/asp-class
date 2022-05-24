using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_02.Models
{
    public class Repository
    {
        private static List<CD> CDResponses = new List<CD>();

        public static IEnumerable<CD> GetCds
        {
            get { return CDResponses; }
        }
        public static void AddCd (CD cd)
        {
            CDResponses.Add(cd);
        }
    }
}
