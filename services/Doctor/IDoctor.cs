using ElearingEnglis.services.Doctor.DTO;
namespace ElearingEnglis.services.Doctor;

public interface IDoctor
{
    public List<DTODoctor> getDoctors();
    public bool CreateDoctor(Guid useid , CreateDoctorDTO dTO);
}
