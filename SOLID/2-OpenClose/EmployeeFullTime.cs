namespace OpenClose
{
    public class EmployeeFullTime : Employee
    {
        public decimal HourValue { get; set; } = 30000M;
        public EmployeeFullTime(string fullname, int hoursWorked) : base(fullname, hoursWorked) { }

        public override decimal CalculateSalaryMonthly() {
            decimal salary = HourValue * HoursWorked;
            return salary;
        }

    }
}