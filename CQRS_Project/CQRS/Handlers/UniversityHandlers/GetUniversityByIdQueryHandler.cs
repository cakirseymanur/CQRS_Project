using CQRS_Project.CQRS.Queries.UniversityQueries;
using CQRS_Project.CQRS.Results.UniversityResult;
using CQRS_Project.DAL.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_Project.CQRS.Handlers.UniversityHandlers
{
    public class GetUniversityByIdQueryHandler : IRequestHandler<GetUniversityByIdQuery, GetUniversityByIdQueryResult>
    {
        private readonly ProductContext _context;

        public GetUniversityByIdQueryHandler(ProductContext context)
        {
            _context = context;
        }
         
        public async Task<GetUniversityByIdQueryResult> Handle(GetUniversityByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _context.Universities.FindAsync(request.id);
            return new GetUniversityByIdQueryResult
            {
                UniversityID = values.UniversityID,
                City = values.City,
                Name = values.Name,
                Population = values.Population
            };
        }
    }
}
