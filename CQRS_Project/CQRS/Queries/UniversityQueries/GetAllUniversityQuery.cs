using CQRS_Project.CQRS.Results.UniversityResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS_Project.CQRS.Queries.UniversityQueries
{
    public class GetAllUniversityQuery:IRequest<List<GetAllUniversityQueryResult>>
    {
    }
}
