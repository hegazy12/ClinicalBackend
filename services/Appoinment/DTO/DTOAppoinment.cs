using ElearingEnglis.services.Doctor.DTO;

namespace ElearingEnglis.services.Appoinment.DTO;

public class DTOAppoinment
{
    public Guid Id                      {get; set;}
    public DateOnly AppoinmentDate      {get; set;}
    public DTODoctor? Doctor            {get; set;}  
    public double Deposit               {get; set;}
    public  string? note                {get; set;}
}