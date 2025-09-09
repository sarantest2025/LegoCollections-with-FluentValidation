using FluentValidation;

namespace LegoCollections.Commands.Minifigure
{
    public class CreateMinifigureCommandValidator: AbstractValidator<CreateMinifigureCommand>
    {
         public CreateMinifigureCommandValidator()
       {
          RuleFor(x => x.Name)
             .NotEmpty().WithMessage("Name is required.")
             .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");
       } 
    }
}