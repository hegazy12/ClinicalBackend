using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
namespace ElearingEnglis.DataCon.Module;

public class Appointment : BaseModule
{
        [Required]
        public Doctor Doctor { get; set; }
        [Required]
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }
        [Required]
        public DateOnly AppointmentDate { get; set; }
        [Required]
        [StringLength(50)]
        public string Status { get; set; } = "Pending"; 
        [StringLength(500)]
        public string? Notes { get; set; }
        [Required]
        public double Deposit {get; set;}

    public Prescription? Prescription {get; set;}
    public List<VitalSign>? VitalSigns { get; set; } = new();




}