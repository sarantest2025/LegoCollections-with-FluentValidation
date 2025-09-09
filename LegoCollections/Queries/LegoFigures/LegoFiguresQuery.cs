using LegoCollections.Models;
using LegoCollections.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using LegoCollections.Data;

namespace LegoCollections.Queries.LegoFigures;

public record GetFiguresInListQuery(int LegoListId) : IRequest<List<LegoFiguresDTO>>;

public class GetFiguresInListHandler : IRequestHandler<GetFiguresInListQuery, List<LegoFiguresDTO>>
{
    private readonly LegoDbContext _context;
    public GetFiguresInListHandler(LegoDbContext context) => _context = context;

    public async Task<List<LegoFiguresDTO>> Handle(GetFiguresInListQuery request, CancellationToken cancellationToken)
    {
        var Figures = await _context.LegoFigures
            .Where(f => f.LegoListId == request.LegoListId)
            .ToListAsync(cancellationToken);
            
           return Figures.Select(f => new LegoFiguresDTO
        {
            Id = f.Id,
            Name = f.Name,
            BrickLinkCode = f.BrickLinkCode,
            Conditions = f.Condition
        }).ToList();
    }
}
