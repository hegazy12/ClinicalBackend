using System.ComponentModel.DataAnnotations;

namespace ElearingEnglis.services.VitalSignMaster.DTOs
{
    public class CreateVitalSignMasterDto
    {
        [Required]
        public string Name { get; set; }
    }
}
