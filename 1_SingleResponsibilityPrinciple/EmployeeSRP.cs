using System.Reflection.Metadata;

namespace SOLIDPrinciple._1_SingleResponsibilityPrinciple
{
    /* S – Single Responsibility Principle(SRP)
    A class should have only one reason to change.
    This means each class should handle only one responsibility.
    If a class has multiple responsibilities, 
    it's harder to maintain and test. */

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
    public interface IEmployeeRepository
    {
        void Add(Employee employee);
        void Update(Employee employee);
        void Delete(int id);
        Employee GetById(int id);
        List<Employee> GetAll();
    }

    public class EmployeeRepository : IEmployeeRepository
    {
        public void Add(Employee employee) { }
        public void Update(Employee employee) { }
        public void Delete(int id) { }
        public Employee GetById(int id) { return new Employee(); }
        public List<Employee> GetAll() { return new List<Employee>(); }
    }

    /*  Bad Example (Violating SRP) */

    public class EmployeeSRP
    {
        public void InsertEmployee()
        {
        }
        public void GetAllEmployee()
        {
        }
        public void CalculateSalary()
        {
        }
        public void UpdateEmployee()
        {
        }
        public void DeleteEmployee()
        {
        }
        public void GetById(int id) { }
    }

    /*  Good Example (Following SRP) */
    public class EmployeeEmailService
    {
        public void SendEmail(Employee employee)
        {

        }
    }
    public class EmployeeMobileService
    {
        public void SendSMS(Employee employee)
        {

        }
    }
    public class EmployeeReportService
    {
        public void GenerateReport(Employee employee)
        {

        }
    }
    public class EmployeeSalaryService
    {
        public decimal CalculateSalary(Employee employee)
        {
            return employee.Salary;

        }
    }
}
