namespace Liskov
{
    public class EmployeeFullTime : Employee
    {
        public decimal Extrahours { get; set; }
        public EmployeeFullTime(string fullname, int hoursWorked, int extrahours) : base(fullname, hoursWorked)
        {
            this.Extrahours = extrahours;
        }

        public override decimal CalculateSalary(){
            decimal hourValue = 50M;
            decimal salary = hourValue *  (HoursWorked + Extrahours);
            return salary;
        }
    }
}