namespace ElearingEnglis.services.Appoinment.DTO;

public class CreateAppoinmentDTO
{
    public DateTime DateTimeAppoinment {get; set;}
    public string? note   {get; set;}
    public Guid DoctorId  {get; set;}
    public Guid PatientId {get; set;}
    public double Deposit {get; set;}
}