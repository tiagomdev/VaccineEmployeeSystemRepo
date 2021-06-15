using VaccineEmployeeSystem.Core.Domain.Models.Employees;
using VaccineEmployeeSystem.Core.Infra.Data.Context;

namespace VaccineEmployeeSystem.Core.Infra.Data.Repositories.Employees
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(VaccineEmployeeDbContext context) : base(context)
        {
        }
    }
}
