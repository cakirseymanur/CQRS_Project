using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS_Project.CQRS.Queries.StudentQueries
{
    public class GetStudentByIDQuery
    {
        public GetStudentByIDQuery(int id)
        {
            this.id = id;
        }

        public int id { get; set; }
    }
}
