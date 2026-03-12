using UdemyCarBook.Application.Interfaces.CarDescriptionInterfaces;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.CarDescriptionRepositories
{
    public class CarDescriptionRepository : ICarDescriptionRepository
    {
        private readonly CarBookContext _context;

        public CarDescriptionRepository(CarBookContext context)
        {
            _context = context;
        }

        public CarDescription GetCarDescription(int carId)
        {
            var values = _context.CarDescriptions.Where(x => x.CarID == carId).FirstOrDefault();
            return values;
        }
    }
}
