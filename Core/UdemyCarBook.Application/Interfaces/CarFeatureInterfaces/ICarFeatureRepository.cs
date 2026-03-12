using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Interfaces.CarFeatureInterfaces
{
    public interface ICarFeatureRepository
    {
        List<CarFeature> GetCarFeaturesCarID(int carID);
        void ChangeCarFeatureAvailableToFalse(int id);
        void ChangeCarFeatureAvailableToTrue(int id);
        void CreateCarFeatureByCar(CarFeature carFeature);
    }
}
