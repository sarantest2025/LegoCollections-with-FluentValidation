using LegoCollections.Data;
using LegoCollections.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LegoCollections.Commands.LegoFigures
{
    public class DeleteLegoFigureCommand : IRequest
    {
        public DeleteLegoFigureCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }

    public class DeleteLegoFigureCommandHandler : IRequestHandler<DeleteLegoFigureCommand>
    {
        private readonly LegoDbContext _context;

        public DeleteLegoFigureCommandHandler(LegoDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteLegoFigureCommand request, CancellationToken cancellationToken)
        {
            var figure = await _context.LegoFigures.FirstOrDefaultAsync(f => f.Id == request.Id, cancellationToken);

            if (figure == null) throw new KeyNotFoundException();
            _context.LegoFigures.Remove(figure);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }

}
