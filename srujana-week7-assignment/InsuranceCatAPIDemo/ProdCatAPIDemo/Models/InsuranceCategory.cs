using System.ComponentModel.DataAnnotations;

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace InsuranceCatAPIDemo.Models
{
    public class InsuranceCategory
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public string Description { get; set; }

        [JsonIgnore]
        public ICollection<InsurancePolicy>? Policies { get; set; }
    }
}
