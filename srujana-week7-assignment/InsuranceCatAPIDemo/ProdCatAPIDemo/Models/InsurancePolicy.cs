using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceCatAPIDemo.Models
{
    public class InsurancePolicy
    {
        public int Id { get; set; }


        [Required]
        public string PolicyName { get; set; }

        public decimal PremiumAmount { get; set; }

        public int DurationInYears { get; set; }

        public int InsuranceCategoryId { get; set; }

        public InsuranceCategory? InsuranceCategory { get; set; }
    }
}
