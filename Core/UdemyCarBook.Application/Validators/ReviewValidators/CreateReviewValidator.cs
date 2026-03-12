using FluentValidation;
using UdemyCarBook.Application.Features.Mediator.Commands.ReviewCommands;

namespace UdemyCarBook.Application.Validators.ReviewValidators
{
    public class CreateReviewValidator : AbstractValidator<CreateReviewCommand>
    {
        public CreateReviewValidator()
        {
            RuleFor(x => x.CustomerName).NotEmpty().WithMessage("Lüften müşteri adını boş geçmeyiniz!");
            RuleFor(x => x.CustomerName).MinimumLength(5).WithMessage("Lüften en az 5 karakter veri girişi yapınız!");
            RuleFor(x => x.RaytingValue).NotEmpty().WithMessage("Lüften puan değerini boş geçmeyiniz");
            RuleFor(x => x.Comment).NotEmpty().WithMessage("Lüften yorum değerini boş geçmeyiniz");
            RuleFor(x => x.Comment).MinimumLength(50).WithMessage("Lüften yorum kısmına en az 50 karakter veri girişi yapınız");
            RuleFor(x => x.Comment).MaximumLength(500).WithMessage("Lüften yorum kısmına en fazla 500 karakter veri girişi yapınız");
        }
    }
}
