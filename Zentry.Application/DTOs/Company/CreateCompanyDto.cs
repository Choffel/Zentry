namespace Zentry.Application.DTOs.Company;

public class CreateCompanyDto
{
    public Guid Id { get; set; }
    public string CompanyName { get; set; }
    
    public string CompanyAddress { get; set; }
    
    public string CompanyPhone { get; set; }
    
    public string CompanyEmail { get; set; }
    
    public string Website { get; set; }
    
    public string Description { get; set; }
}