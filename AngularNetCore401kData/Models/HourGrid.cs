namespace AngularNetCore401kData.Models
{
    public class HourGrid
    {
        

        public int HoursID { get; set; } 
        public bool Selected { get; set; } 
        public string? MemberName { get; set; } 
        public string Mbr_PrimarySSN { get; set; } 
        public decimal Mhrs_Hours { get; set; }
        public decimal Amount401  { get; set; } 
        public decimal Flex { get; set; } 
        public string? LocState { get; set; } 
        public string? LocNumber { get; set; } 
        public DateTime WorkDate { get; set; } 
        
        public decimal Rate401 { get; set; } 
        public decimal RateFlex { get; set; } 
        public DateTime? EntryDate { get; set; }
        public string? EmpAccountNum { get; set; } 
        public int RAS_Emp_ID { get; set; } 
        public int RAS_Mhrs_ID { get; set; } 
        public int RAS_Mbr_ID { get; set; } 
        }
    }
 
