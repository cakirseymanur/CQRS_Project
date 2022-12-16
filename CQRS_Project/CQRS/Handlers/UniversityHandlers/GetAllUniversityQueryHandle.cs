using CQRS_Project.CQRS.Queries.UniversityQueries;
using CQRS_Project.CQRS.Results.UniversityResult;
using CQRS_Project.DAL.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_Project.CQRS.Handlers.UniversityHandlers
{
    public class GetAllUniversityQueryHandle:IRequestHandler<GetAllUniversityQuery, List<GetAllUniversityQueryResult>>
    {
        private readonly ProductContext _context;

        public GetAllUniversityQueryHandle(ProductContext context)
        {
            _context = context;
        }

        public async Task<List<GetAllUniversityQueryResult>> Handle(GetAllUniversityQuery request, CancellationToken cancellationToken)
        {
            return await _context.Universities.Select(x =>
            new GetAllUniversityQueryResult
            {
                UniversityID = x.UniversityID,
                Name = x.Name,
                Town = x.City
            }).AsNoTracking().ToListAsync();
        }
    }
}
