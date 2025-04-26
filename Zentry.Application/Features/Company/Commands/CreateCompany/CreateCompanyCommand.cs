using MediatR;
using Zentry.Application.DTOs.Company;

namespace Zentry.Application.Features.Company.Commands.CreateCompany;

public class CreateCompanyCommand : IRequest<Guid>
{
    
    public string CompanyName { get; set; }
    
    public string CompanyAddress { get; set; }
    
    public string CompanyPhone { get; set; }
    
    public string CompanyEmail { get; set; }
    
    public string Website { get; set; }
    
    public string Description { get; set; }


    public CreateCompanyCommand(CreateCompanyDto dto)
    {
        CompanyName = dto.CompanyName;
        
        CompanyAddress = dto.CompanyAddress;
        
        CompanyPhone = dto.CompanyPhone;
        
        CompanyEmail = dto.CompanyEmail;
        
        Website = dto.Website;
        
        Description = dto.Description;
    }
}