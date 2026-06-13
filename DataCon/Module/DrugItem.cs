namespace ElearingEnglis.DataCon.Module
{
    public class DrugItem:BaseModule
    {
        public Guid DrugId { get; set; }
        public Drug Drug { get; set; }

        public Guid PrescriptionId { get; set; }
        public Prescription Prescription { get; set; }
        public int Dosage { get; set; } 

        public string DosageUnit { get; set; }
        public int TimesPerDay { get; set; } 

        public string? TimingNote { get; set; }
        public int DurationDays { get; set; }

        public string? Instructions { get; set; }

        public string? Notes { get; set; }

    }
}
