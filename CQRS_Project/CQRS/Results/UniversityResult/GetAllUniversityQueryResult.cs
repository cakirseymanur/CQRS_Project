using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS_Project.CQRS.Results.UniversityResult
{
    public class GetAllUniversityQueryResult
    {
        public int UniversityID { get; set; }
        public string Name { get; set; }
        public string Town { get; set; }
    }
}
