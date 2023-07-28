namespace AngularNetCore401kData.Models
{
    public class Hour
    {
            //public int hoursId { get; set; } 
            public bool isChecked { get; set; }
            public string? memberName { get; set; }
            public string? ssn { get; set; }
            public decimal kHours { get; set; } 
            public decimal kAmount { get; set; } 
            public decimal flex { get; set; } 

            public string fullLocal { get; set; } 
            public DateTime workDate { get; set; } 
            public decimal kRate { get; set; } 
            public decimal flexRate { get; set; } 
            public DateTime? entryDate { get; set; } 


            public string empAccountNum { get; set; } 

            public int empId { get; set; } 
            public int mhrsId { get; set; } 
            public int mbrId { get; set; } 
             
             



        }
    }
 
