using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Interfaces.CarDescriptionInterfaces
{
    public interface ICarDescriptionRepository
    {
        CarDescription GetCarDescription(int carId);
    }
}
