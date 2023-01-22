// See https://dotnettutorials.net/lesson/dependency-injection-design-pattern/ for more information
Console.WriteLine("Hello, World!");


#region What is Dependency Injection?
/*

    ? Whenever we are injecting an instance of a class into a class that depends on it, it is called dependency injection.
    ? The Dependency Injection (DI) design pattern is a software design pattern that is used to implement Inversion of Control (IoC) where it allows the creation of dependent objects outside of a class and provides those objects to a class in different ways.

    * Using the Dependency Injection design pattern, we can move the dependent object creation and binding outside of the class that depends on it.
    * DI is a great way to reduce the tight coupling between software components.
    * DI also enables us to better manage future changes and other complexity in our software.

    * The dependency Injection design pattern involves 3 types of classes.

        1. Client Class: The class which depends on the service class is called the Client Class or dependent class.
        2. Service Class: The class which provides the service to the client class is called a Service Class or dependency class
        3. Injector Class: The class which is used to inject the service class object into the client class is called an Injector class.

    * The injector class creates an object of the service class and injects that object into a client class, and the client class then uses that service class object.
    * In this way, the Dependency Injection Design pattern separates the logic or responsibility of creating an object of the service class (Dependency class) out of the client class (dependent class).
*/
#endregion


#region Types of Dependency Injection
/*

    * The injector class injects dependencies broadly in three ways:
    
        1. through a constructor,
            - In the constructor injection, the injector class supplies the service object (i.e. dependency object) through the client class constructor.
        2. through a property,
            - In the property injection or we can say setter Injection, the injector class supplies the dependency object (i.e. Service object) through a public property of the client class.
        3. through the method.
           - In method injection, the client class implements an interface that declares the method(s) to supply dependency and the injector class uses this interface to supply dependency to the client class.
*/
#endregion


#region The Constructor Injection
EmployeeBusinessLogic_2 employeeBusinessLogic_2 = new EmployeeBusinessLogic_2(new EmployeeDataAccess());
Employee employeeDetails = employeeBusinessLogic_2.GetEmployeeDetails(1);

Console.WriteLine("\n\nEmployee Details:");
Console.WriteLine("The Constructor Injection");
Console.WriteLine("ID : {0}, Name : {1}, Department : {2}, Salary : {3}",
                               employeeDetails.ID, employeeDetails.Name, employeeDetails.Department,
                               employeeDetails.Salary);
Console.WriteLine("Press any key to continue");
Console.ReadKey();
#endregion


#region The Property Injection
EmployeeBusinessLogic_3 employeeBusinessLogic_3 = new();
employeeBusinessLogic_3.EmpDataAccess = new EmployeeDataAccess();
Employee employeeDetails2 = employeeBusinessLogic_3.GetEmployeeDetails(1);

Console.WriteLine("\n\nEmployee Details:");
Console.WriteLine("The Property Injection");
Console.WriteLine("ID : {0}, Name : {1}, Department : {2}, Salary : {3}",
                    employeeDetails2.ID, employeeDetails2.Name, employeeDetails2.Department,
                    employeeDetails2.Salary);
Console.WriteLine("Press any key to continue");
Console.ReadKey();
#endregion


#region The Method Injection
EmployeeBusinessLogic_4 employeeBusinessLogic_4 = new();
employeeBusinessLogic_4.SetDependency(new EmployeeDataAccess());
Employee employeeDetails3 = employeeBusinessLogic_4.GetEmployeeDetails(1);

Console.WriteLine("\n\nEmployee Details:");
Console.WriteLine("The Method Injection");
Console.WriteLine("ID : {0}, Name : {1}, Department : {2}, Salary : {3}",
                    employeeDetails2.ID, employeeDetails2.Name, employeeDetails2.Department,
                    employeeDetails2.Salary);
Console.WriteLine("Press any key to exist.");
Console.ReadKey();
#endregion


#region The Problem
/*

    ! The problem with the below example is that we used the DataAccessFactory class inside the EmployeeBusinessLogic class.
    
    + The dependency injection design pattern solves the above problem by injecting dependent objects via a constructor, property, or method.
*/
public interface IEmployeeDataAccess
{
    Employee GetEmployeeDetails(int id);
}
public class EmployeeDataAccess : IEmployeeDataAccess
{
    public Employee GetEmployeeDetails(int id)
    {
        // In real time get the employee details from db
        // but here we are hard coded the employee details
        Employee emp = new Employee()
        {
            ID = id,
            Name = "David",
            Department = "IT",
            Salary = 10000
        };
        return emp;
    }
}
public class DataAccessFactory
{
    public static IEmployeeDataAccess GetEmployeeDataAccessObj()
    {
        return new EmployeeDataAccess();
    }
}
public class EmployeeBusinessLogic
{
    // !
    IEmployeeDataAccess _EmployeeDataAccess;
    public EmployeeBusinessLogic()
    {
        _EmployeeDataAccess = DataAccessFactory.GetEmployeeDataAccessObj();
    }
    public Employee GetEmployeeDetails(int id)
    {
        return _EmployeeDataAccess.GetEmployeeDetails(id);
    }
}
#endregion


#region The Constructor Injection
/*

    * In the case of constructor injection, the injector class supplies the service object (i.e. dependency object) through the client class constructor.
*/
public class EmployeeBusinessLogic_2
{
    // +
    private readonly IEmployeeDataAccess _EmployeeDataAccess;
    public EmployeeBusinessLogic_2(IEmployeeDataAccess dataAccess)
    {
        _EmployeeDataAccess = dataAccess;
    }
    public Employee GetEmployeeDetails(int id)
    {
        return _EmployeeDataAccess.GetEmployeeDetails(id);
    }
}
#endregion


#region The Property Injection
/*

    * In the property injection or we can say setter Injection, the injector class supplies the dependency object (i.e. Service object) through a public property of the client class.
*/
public class EmployeeBusinessLogic_3
{
    public IEmployeeDataAccess EmpDataAccess { get; set; }
    public Employee GetEmployeeDetails(int id)
    {
        return EmpDataAccess.GetEmployeeDetails(id);
    }
}
#endregion


#region The Method Injection
/*

    * In the method injection, dependencies are provided through methods.
*/
interface IEmployeeDataAccessDependency
{
    void SetDependency(IEmployeeDataAccess employeeDataAccess);
}
public class EmployeeBusinessLogic_4 : IEmployeeDataAccessDependency
{
    public IEmployeeDataAccess EmpDataAccess { get; set; }
    public Employee GetEmployeeDetails(int id)
    {
        return EmpDataAccess.GetEmployeeDetails(id);
    }
    public void SetDependency(IEmployeeDataAccess employeeDataAccess)
    {
        EmpDataAccess = employeeDataAccess;
    }
}
// ! In real-time projects, there would be many dependent clauses, and implementing these patterns would be time-consuming.
// ! Hence IoC Container helps us in such a scenario.
#endregion


public class Employee
{
    public int ID { get; set; }
    public string? Name { get; set; }
    public string? Department { get; set; }
    public int Salary { get; set; }
}
