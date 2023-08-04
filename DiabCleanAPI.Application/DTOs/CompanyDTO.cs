namespace DiabCleanAPI.DiabCleanAPI.Application.DTOs
{
   public record CompanyDTO(int id, string Name, string Field, List<EmployeeDTO> Employees);
}