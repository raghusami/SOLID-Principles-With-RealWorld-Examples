namespace SOLIDPrinciple
{
    /*1. Employee Management System
    ✅ SRP: Separate services for employee data, salary calculation, and reporting.
    ✅ OCP: Support different salary structures (fixed, hourly, contract).
    ✅ LSP: Use different employee types (FullTimeEmployee, PartTimeEmployee).
    ✅ ISP: Define interfaces for payroll, attendance, and performance evaluation.
    ✅ DIP: Inject dependencies for flexibility (e.g., IEmployeeRepository).*/

    // -------------------- SRP: Separate Responsibilities -------------------- //
    // Employee Model
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    // Salary Calculation Service
    public interface ISalaryCalculator
    {
        double CalculateSalary(Employee employee, double hoursWorked);
    }

    public class FixedSalaryCalculator : ISalaryCalculator
    {
        public double CalculateSalary(Employee employee, double hoursWorked)
        {
            return 50000; // Fixed salary
        }
    }

    public class HourlySalaryCalculator : ISalaryCalculator
    {
        public double CalculateSalary(Employee employee, double hoursWorked)
        {
            return hoursWorked * 20; // $20 per hour
        }
    }

    public class ContractSalaryCalculator : ISalaryCalculator
    {
        public double CalculateSalary(Employee employee, double hoursWorked)
        {
            return hoursWorked * 30; // $30 per hour
        }
    }

    // -------------------- LSP: Substitutable Employee Types -------------------- //
    public class FullTimeEmployee : Employee
    {
        public void GetFullTimeBenefits()
        {
            Console.WriteLine("Full-time employee benefits applied.");
        }
    }

    public class PartTimeEmployee : Employee
    {
        public void GetPartTimeBenefits()
        {
            Console.WriteLine("Part-time employee benefits applied.");
        }
    }

    // -------------------- ISP: Interface Segregation -------------------- //
    public interface IAttendance
    {
        void MarkAttendance(Employee employee);
    }

    public interface IPerformanceEvaluator
    {
        void EvaluatePerformance(Employee employee);
    }

    public class AttendanceService : IAttendance
    {
        public void MarkAttendance(Employee employee)
        {
            Console.WriteLine($"Attendance marked for {employee.Name}");
        }
    }

    public class PerformanceService : IPerformanceEvaluator
    {
        public void EvaluatePerformance(Employee employee)
        {
            Console.WriteLine($"Performance evaluated for {employee.Name}");
        }
    }

    // -------------------- DIP: Inject Dependencies -------------------- //
    public interface IEmployeeRepository
    {
        void AddEmployee(Employee employee);
        Employee GetEmployee(int id);
    }

    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Dictionary<int, Employee> _employees = new Dictionary<int, Employee>();

        public void AddEmployee(Employee employee)
        {
            _employees[employee.Id] = employee;
            Console.WriteLine($"Employee {employee.Name} added to the system.");
        }

        public Employee GetEmployee(int id)
        {
            return _employees.ContainsKey(id) ? _employees[id] : null;
        }
    }

    //class EmployeeProgram
    //{
    //    static void Main()
    //    {
    //        IEmployeeRepository employeeRepository = new EmployeeRepository();
    //        IAttendance attendanceService = new AttendanceService();
    //        IPerformanceEvaluator performanceService = new PerformanceService();

    //        Employee emp1 = new FullTimeEmployee { Id = 1, Name = "Alice" };
    //        Employee emp2 = new PartTimeEmployee { Id = 2, Name = "Bob" };

    //        employeeRepository.AddEmployee(emp1);
    //        employeeRepository.AddEmployee(emp2);

    //        attendanceService.MarkAttendance(emp1);
    //        performanceService.EvaluatePerformance(emp2);

    //        ISalaryCalculator salaryCalculator = new HourlySalaryCalculator();
    //        Console.WriteLine($"{emp2.Name}'s Salary: ${salaryCalculator.CalculateSalary(emp2, 40)}");
    //    }
    //}
}
