using MediatR;
using Microservices.Employee.Repository.Model;
using Microservices.Employee.Repository.Request;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microservices.Employee.Repository.RequestHandler
{
    public class GetEmployeeHandler : IRequestHandler<GetEmployee, List<EmployeeModel>>
    {
        public async Task<List<EmployeeModel>> Handle(GetEmployee request, CancellationToken cancellationToken)
        {
            var employee = JsonConvert.DeserializeObject<List<EmployeeModel>>(await File.ReadAllTextAsync(".\\Data\\EmployeeData.json"));
            return employee.Where(emp => (request.EmployeeId>0 || request.EmployeeId == emp.EmployeeId) || 
                                     (string.IsNullOrWhiteSpace(request.EmailAddress) ||   request.EmailAddress == emp.EmailAddress) ||
                                     (string.IsNullOrWhiteSpace(request.FirstName) || request.FirstName == emp.FirstName) ||
                                     (string.IsNullOrWhiteSpace(request.MiddleName)  || request.MiddleName == emp.MiddleName) ||
                                     (string.IsNullOrWhiteSpace(request.PhoneNumber) || request.PhoneNumber == emp.PhoneNumber) ||
                                     (string.IsNullOrWhiteSpace(request.PhoneNumber) || request.Title == emp.Title)).ToList();
        }
    }
}
