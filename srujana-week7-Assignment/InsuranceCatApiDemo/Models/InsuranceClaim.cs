namespace InsuranceCatApiDemo.Models
{
    public class InsuranceClaim
    {
        public int Id { get; set; }
        public string PolicyholderName { get; set; } = string.Empty;
        public decimal EstimatedPayout { get; set; }
        public string Status { get; set; } = "Pending";

        // Foreign Key linking to the Category
        public int CategoryId { get; set; }

        // The actual Category object
        public Category? Category { get; set; }
    }
}