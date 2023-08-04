namespace DiabCleanAPI.DiabCleanAPI.Application.DTOs
{
    public record EmployeeDTO(int Id, string Name, string Address, string Phone, string Email, CompanyDTO company);
}
