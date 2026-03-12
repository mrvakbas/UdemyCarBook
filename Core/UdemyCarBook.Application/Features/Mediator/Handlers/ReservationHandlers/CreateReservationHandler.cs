using MediatR;
using UdemyCarBook.Application.Features.Mediator.Commands.ReservationCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.ReservationHandlers
{
    public class CreateReservationHandler : IRequestHandler<CreateReservationCommand>
    {
        private readonly IRepository<Reservation> _repository;

        public CreateReservationHandler(IRepository<Reservation> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Reservation
            {
                Age = request.Age,
                CarID = request.CarID,
                Description = request.Description,
                DriverLicenseYear = request.DriverLicenseYear,
                DropOffLocationID = request.DropOffLocationID,
                Email = request.Email,
                Name = request.Name,
                Phone = request.Phone,
                PickUpLocationID = request.PickUpLocationID,
                Surname = request.Surname,
                Status = "Rezervasyon Alındı",
            });
        }
    }
}
