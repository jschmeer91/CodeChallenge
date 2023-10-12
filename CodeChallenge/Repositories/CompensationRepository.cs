using System.Linq;
using System.Threading.Tasks;
using CodeChallenge.Models;
using Microsoft.Extensions.Logging;
using CodeChallenge.Data;

namespace CodeChallenge.Repositories
{
    public class CompensationRespository : ICompensationRepository
    {
        private readonly CompensationContext _compensationContext;
        private readonly ILogger<ICompensationRepository> _logger;

        public CompensationRespository(ILogger<ICompensationRepository> logger, CompensationContext compensationContext)
        {
            _compensationContext = compensationContext;
            _logger = logger;
        }

        public Compensation Add(Compensation compensation)
        {
            Compensation existingCompensation = GetByEmployeeId(compensation.EmployeeId);
            if (existingCompensation != null)
                _compensationContext.Entry(compensation);
            else
                _compensationContext.Compensations.Add(compensation);
            return compensation;
        }

        public Compensation GetByEmployeeId(string id)
        {
            return _compensationContext.Compensations.SingleOrDefault(e => e.EmployeeId == id); 
        }

        public Task SaveAsync()
        {
            return _compensationContext.SaveChangesAsync();
        }
    }
}
