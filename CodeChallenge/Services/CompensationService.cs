using System;
using CodeChallenge.Models;
using Microsoft.Extensions.Logging;
using CodeChallenge.Repositories;

namespace CodeChallenge.Services
{
    public class CompensationService : ICompensationService
    {
        private readonly ICompensationRepository _compensationRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<CompensationService> _logger;

        public CompensationService(ILogger<CompensationService> logger, ICompensationRepository compensationRepository, IEmployeeRepository employeeRepository)
        {
            _compensationRepository = compensationRepository;
            _logger = logger;
            _employeeRepository = employeeRepository;
        }

        public Compensation Create(Compensation compensation)
        {
            Employee employee = _employeeRepository.GetById(compensation.EmployeeId);

            if (employee != null && compensation != null)
            {
                _compensationRepository.Add(compensation);
                _compensationRepository.SaveAsync().Wait();

                return compensation;
            }
            return null;
        }

        public Compensation GetByEmployeeId(string id)
        {
            if(!String.IsNullOrEmpty(id))
            {
                return _compensationRepository.GetByEmployeeId(id);
            }

            return null;
        }
    }
}
