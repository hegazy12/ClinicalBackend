namespace ElearingEnglis.DataCon.Module
{
    public class Prescription:BaseModule
    {

        public Guid PatientId { get; set; }
        public Doctor Doctor { get; set; }
        public string? Diagnosis { get; set; }  

        public string? Notes { get; set; }

        public Guid AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
        public ICollection<DrugItem> Items { get; set; }
       
    }
}
