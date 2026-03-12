using MediatR;
using UdemyCarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using UdemyCarBook.Application.Features.Mediator.Results.StatisticsResults;
using UdemyCarBook.Application.Interfaces.StatisticsInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetAvgRentPriceForMounthlyQueryHandler : IRequestHandler<GetAvgRentPriceForMounthlyQuery, GetAvgRentPriceForMounthlyQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetAvgRentPriceForMounthlyQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAvgRentPriceForMounthlyQueryResult> Handle(GetAvgRentPriceForMounthlyQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetAvgRentPriceForMounthly();
            return new GetAvgRentPriceForMounthlyQueryResult
            {
                AvgRentPriceForMounthly = value,
            };
        }
    }
}
