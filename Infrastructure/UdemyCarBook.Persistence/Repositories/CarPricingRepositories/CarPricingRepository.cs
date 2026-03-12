using Microsoft.EntityFrameworkCore;
using UdemyCarBook.Application.Interfaces.CarPricingInterfaces;
using UdemyCarBook.Application.ViewModels;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.CarPricingRepositories
{
    public class CarPricingRepository : ICarPricingRepository
    {
        private readonly CarBookContext _context;

        public CarPricingRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<CarPricing> GetCarPricingWithCars()
        {
            var values = _context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Include(x => x.Pricing).Where(z => z.PricingID == 3).ToList();
            return values;
        }

        public List<CarPricing> GetCarPricingWithTimePeriod()
        {
            throw new NotImplementedException();
        }

        public List<CarPricingViewModel> GetCarPricingWithTimePeriod1()
        {
            List<CarPricingViewModel> values = new List<CarPricingViewModel>();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "Select * From (Select Cars.CarID ,Model, Name, CoverImageUrl, PricingID, Amount From CarPricings Inner Join Cars On Cars.CarID = CarPricings.CarID Inner Join Brands On Brands.BrandID = Cars.BrandID) As SourceTable Pivot(Sum(Amount) For PricingID In ([3],[4],[5])) as PivotTable Order by CarID desc;";
                command.CommandType = System.Data.CommandType.Text;
                _context.Database.OpenConnection();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CarPricingViewModel carPricingViewModel = new CarPricingViewModel()
                        {
                            Brand = reader["Name"].ToString(),
                            Model = reader["Model"].ToString(),
                            CoverImageUrl = reader["CoverImageUrl"].ToString(),
                            Amounts = new List<decimal>
                            {
                                Convert.ToDecimal(reader["3"]),
                                Convert.ToDecimal(reader["4"]),
                                Convert.ToDecimal(reader["5"])
                            }
                        };
                        values.Add(carPricingViewModel);
                    }
                }
                _context.Database.CloseConnection();
                return values;
            }
        }
    }
}















//public List<CarPricing> GetCarPricingWithTimePeriod()
//{
//    List<CarPricing> values = new List<CarPricing>();
//    using(var command = _context.Database.GetDbConnection().CreateCommand())
//    {
//        command.CommandText = "Select * From (Select Brands.Name , Model, PricingID, Amount From CarPricings Inner Join Cars On Cars.CarID = CarPricings.CarID Inner Join Brands On Brands.BrandID = Cars.BrandID) As SourceTable Pivot(Sum(Amount) For PricingID In ([3],[4],[5])) as PivotTable;";
//        command.CommandType = System.Data.CommandType.Text;
//        _context.Database.OpenConnection();
//        using(var reader = command.ExecuteReader())
//        {
//            while (reader.Read())
//            {
//                CarPricing carPricing = new CarPricing();
//                Enumerable.Range(1, 3).ToList().ForEach(x =>
//                {
//                    if (DBNull.Value.Equals(reader[x]))
//                    {
//                        carPricing
//                    }
//                    else
//                    {
//                        carPricing.Amount
//                    }
//                });
//                values.Add(carPricing);
//            }
//        }
//        _context.Database.CloseConnection();
//        return values;
//    }
//}


//var values = from x in _context.CarPricings
//             group x by x.PricingID into g
//             select new
//             {
//                 CarId = g.Key,
//                 DailyPrice = g.Where(y => y.CarPricingID == 3).Sum(z => z.Amount),
//                 WeeklyPrice = g.Where(y => y.CarPricingID == 4).Sum(z => z.Amount),
//                 MountlyPrice = g.Where(y => y.CarPricingID == 5).Sum(z => z.Amount)
//             };
//return values.ToList();