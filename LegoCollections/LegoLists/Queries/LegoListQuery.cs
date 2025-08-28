//using LegoCollections.Models;
using LegoCollections.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using LegoCollections.Data;

namespace LegoCollections.LegoLists.Queries
{
    public class LegoListQuery
    {
        public record GetAllListsQuery() : IRequest<List<LegoListsDTO>>;

        public class GetAllListsHandler : IRequestHandler<GetAllListsQuery, List<LegoListsDTO>>
        {
            private readonly LegoDbContext _context;

            public GetAllListsHandler(LegoDbContext Context)
            {
                _context = Context;
            }
                public async Task<List<LegoListsDTO>> Handle(GetAllListsQuery request, CancellationToken cancellationToken)
            {
                return await _context.LegoLists
                    .Select(l => new LegoListsDTO { Id = l.Id, Name = l.Name })
                    .ToListAsync(cancellationToken);
            }
        }
    }
}





