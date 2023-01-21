// See https://dotnettutorials.net/course/solid-design-principles/ for more information
Console.WriteLine("Hello, World!");


#region Dependency Inversion Principle in C#
/*

    ? The Dependency Inversion Principle (DIP) states that high-level modules/classes should not depend on low-level modules/classes. Both should depend upon abstractions.
    ? Secondly, abstractions should not depend upon details. Details should depend upon abstractions.

    * The most important point that you need to remember while developing real-time applications, always to try to keep the High-level module and Low-level module as loosely coupled as possible.
    * When a class knows about the design and implementation of another class, it raises the risk that if we do any changes to one class will break the other class.
    * So we must keep these high-level and low-level modules/classes loosely coupled as much as possible.

    + Bir sınıfın herhangi bir türe olan bağımlılık durumuna dikkat çeken bir prensiptir.
    + Bağımlılıkların olabildiğinde tersine çevrilmesini önerir.
*/
#endregion


#region Without Dependency Inversion Principle in C#
/*

    * Create a class file with the name 'Employee'.
    * 'Employee' is a simple class having 4 properties.

    * Create a class file with the name 'EmployeeBusinessLogic'.
    * This class has one constructor that is used to create an instance of 'EmployeeDataAccess'.
    * Here, within the constructor we call the static GetEmployeeDataAccessObj() method on the 'DataAccessFactory' class which will return an instance of 'EmployeeDataAccess' and we initialize the _EmployeeDataAccess property with the return instance.
    * We have also one method, GetEmployeeDetails(), which is used to call the GetEmployeeDetails method on the 'EmployeeDataAccess' instance to get the employee detail by employee id.

    * Create a class file with the name 'DataAccessFactory'.
    * This class contains one static method which is returning an instance of the 'EmployeeDataAccess' class.

    * Create a class file with the name 'EmployeeDataAccess'.
    * This class contains one method which takes the employee id and returns that Employee information.

    ! As per the Dependency Inversion Principle definition, “a high-level module should not depend on low-level modules. Both should depend on the abstraction”.

        1. So, first, we need to figure out which one is the high-level module (class) and which one is the low-level module (class) in our example.
        2. A high-level module is a module that always depends on other modules.
        3. In our example, the 'EmployeeBusinessLogic' class depends on 'EmployeeDataAccess' class.
        4. So here the 'EmployeeBusinessLogic' class is the high-level module.
        5. So, as per the first rule of the Dependency Inversion Principle in C#, the 'EmployeeBusinessLogic' class/module should not depend on the concrete 'EmployeeDataAccess' class/module, instead, both the classes should depend on abstraction.
*/
class Employee
{
    public int ID { get; set; }
    public string? Name { get; set; }
    public string? Department { get; set; }
    public int Salary { get; set; }
}
class EmployeeBusinessLogic
{
    // ! unideal
    EmployeeDataAccess _EmployeeDataAccess;
    public EmployeeBusinessLogic()
    {
        _EmployeeDataAccess = DataAccessFactory.GetEmployeeDataAccessObj();
    }
    public Employee GetEmployeeDetails(int id)
    {
        return _EmployeeDataAccess.GetEmployeeDetails(id);
    }
}
class DataAccessFactory
{
    public static EmployeeDataAccess GetEmployeeDataAccessObj()
    {
        return new EmployeeDataAccess();
    }
}
class EmployeeDataAccess
{
    public Employee GetEmployeeDetails(int id)
    {
        // In real time get the employee details from db
        //but here we are hard coded the employee details
        Employee emp = new Employee()
        {
            ID = id,
            Name = "Pranaya",
            Department = "IT",
            Salary = 10000
        };
        return emp;
    }
}
#endregion


#region What is Abstraction?
/*

    ? In simple words, we can say that Abstraction means something which is non-concrete.

    * So, abstraction in programming means we need to create either an interface or abstract class which is non-concrete so that we can not create an instance of it.
    * In our example, the EmployeeBusinessLogic and EmployeeDataAccess are concrete classes that mean we can create objects of it.
    * As per the Dependency Inversion Principle in C#, the EmployeeBusinessLogic (high-level module) should not depend on the concrete EmployeeDataAccess (low-level module) class.
    * Both classes should depend on abstractions, meaning both classes should depend on either an interface or an abstract class.
*/
#endregion


#region With Dependency Inversion Principle in C#
interface IEmployeeDataAccess
{
    Employee GetEmployeeDetails(int id);
}

class EmployeeBusinessLogic2
{
    IEmployeeDataAccess _EmployeeDataAccess;
    public EmployeeBusinessLogic2()
    {
        _EmployeeDataAccess = DataAccessFactory2.GetEmployeeDataAccessObj();
    }
    public Employee GetEmployeeDetails(int id)
    {
        return _EmployeeDataAccess.GetEmployeeDetails(id);
    }
}

class DataAccessFactory2
{
    public static IEmployeeDataAccess GetEmployeeDataAccessObj()
    {
        return new EmployeeDataAccess2();
    }
}

class EmployeeDataAccess2 : IEmployeeDataAccess
{
    public Employee GetEmployeeDetails(int id)
    {
        // In real time get the employee details from db
        // but here we are hardcoded the employee details
        Employee emp = new Employee()
        {
            ID = id,
            Name = "Pranaya",
            Department = "IT",
            Salary = 10000
        };
        return emp;
    }
}
#endregion


#region Another Example
#region Without Dependency Inversion Principle in C#
class MailService
{
    public void SendMail(Gmail gmail)
    {
        gmail.Send("...");
    }
}

class Gmail
{
    public void Send(string mail)
    {
        //...Send Mail...
    }
}
class Yandex
{
    public void SendMail(string mail, string to)
    {
        //...Send Mail...
    }
}
class Hotmail
{
    public void Send(string mail)
    {
        //...Send Mail...
    }
}
#endregion
#region Wit Dependency Inversion Principle in C#
interface IMailServer
{
    void Send(string to, string body);
}

class MailService2
{
    public void SendMail(IMailServer mailServer, string to, string body)
    {
        mailServer.Send(to, body);
    }
}

class Gmail2 : IMailServer
{
    public void Send(string to, string body)
    {
        //...Send Mail...
    }
}
class Yandex2 : IMailServer
{
    public void Send(string to, string body)
    {
        //...Send Mail...
    }
}
class Hotmail2 : IMailServer
{
    public void Send(string to, string body)
    {
        //...Send Mail...
    }
}
#endregion
#endregion