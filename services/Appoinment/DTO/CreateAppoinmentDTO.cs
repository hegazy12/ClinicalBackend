namespace ElearingEnglis.services.Appoinment.DTO;

public class CreateAppoinmentDTO
{
    public DateOnly DateAppoinment {get; set;}
    public string? note   {get; set;}
    public string DoctorId  {get; set;}
    public string PatientId {get; set;}
    public double Deposit {get; set;}
}