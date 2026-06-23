using System.ComponentModel.DataAnnotations.Schema;

namespace ElearingEnglis.DataCon.Module
{
    public class VitalSign:BaseModule
    {
        public Guid VitalSignMasterId { get; set; }
        public VitalSignMaster VitalSignMaster { get; set; }
        public string Value { get; set; }

        [ForeignKey("Appointment")]
        public Guid AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
    }
}
