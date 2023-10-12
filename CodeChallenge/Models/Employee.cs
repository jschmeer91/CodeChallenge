using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallenge.Models
{
    public class Employee
    {
        public String EmployeeId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Position { get; set; }
        public String Department { get; set; }
        public List<Employee> DirectReports { get; set; }

        public int GetTotalDirectReports() {
            int totalDirectReports = 0; //initially 0
            if (DirectReports != null)
            {
                totalDirectReports += DirectReports.Count; //add in count of direct reports to this employee
                totalDirectReports += DirectReports.Where(report => report != null).Sum(report => report.GetTotalDirectReports()); //foreach of the direct reports check their direct reports and return total count
            }
            return totalDirectReports;
        }
    }
}
