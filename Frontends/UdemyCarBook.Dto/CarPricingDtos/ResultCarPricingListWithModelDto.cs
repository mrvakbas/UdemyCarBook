namespace UdemyCarBook.Dto.CarPricingDtos
{
    public class ResultCarPricingListWithModelDto
    {
        public string model { get; set; }
        public decimal dailyAmount { get; set; }
        public decimal weeklyAmount { get; set; }
        public decimal mounthlyAmount { get; set; }
        public string CoverImageUrl { get; set; }
        public string Brand { get; set; }
    }
}
