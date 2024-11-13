using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoCodeFactory.DataAccess.Contracts.Employee
{
    public class EmployeeFilterDto
    {
        public  string FirstName { get; init; }
        public  string LastName { get; init; }
        public  string Email { get; init; }
        public int ItemsPerPage { get; init; }
        public int Page { get; init; }
    }
}
