using System.ComponentModel.DataAnnotations;

namespace Blood_Bank_Management.Models
{
    public class BloodBank
    {
        [Key]
        public int BLoodBankId { get; set; }
        public string PatientName { get; set; }
        public int Capacity { get; set; }
        public int QuantityInStock { get; set; }
    }
}
