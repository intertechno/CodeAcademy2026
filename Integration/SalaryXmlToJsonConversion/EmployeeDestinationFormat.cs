public class EmployeeDestinationFormat
{
    public string personName { get; set; } = "";
    public Salary salary { get; set; } = new Salary();
    public string hireDate { get; set; } = "";

    public class Salary
    {
        public double monthly { get; set; } = 0.0;
    }
}
