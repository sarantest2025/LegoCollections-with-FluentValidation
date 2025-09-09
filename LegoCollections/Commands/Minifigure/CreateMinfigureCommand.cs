using LegoCollections.Data;
using MediatR;
using LegoCollections.Models;

namespace LegoCollections.Commands.Minifigure
{
    public class CreateMinifigureCommand : IRequest<int>
    {
        public string Name { get; set; } = string.Empty;
        public string BrickLinkCode { get; set; } = string.Empty;
        public string Condition { get; set; } = string.Empty;
        public int LegoListId { get; set; }


    }
    public class CreateMinifigureCommandHandler : IRequestHandler<CreateMinifigureCommand, int>
    {
        private readonly LegoDbContext _context;

        public CreateMinifigureCommandHandler(LegoDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateMinifigureCommand request, CancellationToken cancellationToken)
        {
            var figure = new LegoFigure
            {
                Name = request.Name,
                BrickLinkCode = request.BrickLinkCode,
                Condition = request.Condition,
                LegoListId = request.LegoListId
            };

            _context.LegoFigures.Add(figure);
            await _context.SaveChangesAsync(cancellationToken);

            return figure.Id;
        }
    }
}