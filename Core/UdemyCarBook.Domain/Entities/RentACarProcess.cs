using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UdemyCarBook.Domain.Entities
{
    public class RentACarProcess
    {
        public int RentACarProcessID { get; set; }
        public int CarID { get; set; }
        public Car Car { get; set; }
        public int PicUpLocation { get; set; }
        public int DropOffLocation { get; set; }

        [Column(TypeName = "Date")]
        public DateTime PickUpDate { get; set; }

        [Column(TypeName = "Date")]
        public DateTime DropOffDate { get; set; }

        [DataType(DataType.Date)]
        public TimeSpan PickUpTime { get; set; }

        [DataType(DataType.Date)]
        public TimeSpan DropOffTime { get; set; }
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
        public string PickUpDescription { get; set; }
        public string DropOffDescription { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
