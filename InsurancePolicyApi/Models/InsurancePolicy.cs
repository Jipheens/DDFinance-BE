using System;

namespace InsurancePolicyApi.Models
{
    public class InsurancePolicy
    {
        public int Id { get; set; }
        public string PolicyNumber { get; set; }
        public string PolicyHolderName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal PremiumAmount { get; set; }
        public string CoverageType { get; set; }

      
        public DateTime PostedTime { get; set; } = DateTime.UtcNow; 
        public DateTime? ModifiedTime { get; set; } 
        public DateTime? DeletedTime { get; set; } 
        public string DeletedFlag { get; set; } = "N"; 
    }
}