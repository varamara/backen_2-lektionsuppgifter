using Controllers;

namespace Models;

public class Employee
{
    

    public int Id { get; set; }
    public string? Name { get; set; }
    public double Salary { get; set; }

    public Employee(string name, double salary)
    {
        Name = name;
        Salary = salary;
    }


    // visa information om anställd
    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Salary: {Salary}";
    }

}