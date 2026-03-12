using MediatR;
using UdemyCarBook.Application.Features.Mediator.Queries.CarFeatureQueries;
using UdemyCarBook.Application.Features.Mediator.Results.CarFeatureResults;
using UdemyCarBook.Application.Interfaces.CarFeatureInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class GetCarFeatureByCarIdQueryHandler : IRequestHandler<GetCarFeatureByCarIdQuery, List<GetCarFeatureByCarIdQueryResult>>
    {
        private readonly ICarFeatureRepository _repository;

        public GetCarFeatureByCarIdQueryHandler(ICarFeatureRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarFeatureByCarIdQueryResult>> Handle(GetCarFeatureByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetCarFeaturesCarID(request.Id);
            return values.Select(x => new GetCarFeatureByCarIdQueryResult
            {
                Availeble = x.Availeble,
                CarFeatureID = x.CarFeatureID,
                FeatureID = x.FeatureID,
                FeatureName = x.Feature.Name,
            }).ToList();
        }
    }
}
