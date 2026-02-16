namespace InsuranceCatApiDemo.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // One Category has many Insurance Claims
        public List<InsuranceClaim> Claims { get; set; } = new List<InsuranceClaim>();
    }
}