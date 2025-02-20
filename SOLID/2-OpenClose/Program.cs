using OpenClose;

ShowSalaryMontly (new List<Employee>() {
    new EmployeeFullTime("John", 40),
    new EmployeePartTime("Mary", 30),
    new EmployeeFullTime("Peter", 20),
    new EmployeePartTime("Anna", 20),
    new EmployeeFullTime("Paul", 40),
    new EmployeePartTime("Kate", 30),       
    new EmployeeContractor("John", 40),
    new EmployeeContractor("Mary", 30),
});


void ShowSalaryMontly(List<Employee> employees) {
    foreach (var employee in employees) {
        Console.WriteLine($"{employee.Fullname} is working {employee.HoursWorked} hours per month");
        decimal salary = employee.CalculateSalaryMonthly();
        Console.WriteLine($"Salary: {salary:C0}");
    }
}