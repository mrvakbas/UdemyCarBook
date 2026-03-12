using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Results.CarDescriptionResults
{
    public class GetCarDescriptionQueryResult
    {
        public int CarDescriptionID { get; set; }
        public int CarID { get; set; }
        public string Details { get; set; }
    }
}
