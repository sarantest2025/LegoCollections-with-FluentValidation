using LegoCollections.Data;
using LegoCollections.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace LegoCollections.LegoLists.Commands
{
    public record DeleteLegoListCommand (int Id) : IRequest;
    
    public class DeleteLegoListHandler : IRequestHandler<DeleteLegoListCommand>
    {
        private readonly LegoDbContext _context;

        public DeleteLegoListHandler(LegoDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteLegoListCommand request, CancellationToken cancellationToken)
        {
            var list = await _context.LegoLists.FindAsync(request.Id);
            if (list == null) throw new KeyNotFoundException("Liste ikke funnet");    
            _context.LegoLists.Remove(list);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
