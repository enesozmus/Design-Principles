// See https://dotnettutorials.net/lesson/introduction-to-inversion-of-control/ for more information
// See https://www.tutorialsteacher.com/ioc/inversion-of-control for more information
// See https://www.theserverside.com/definition/inversion-of-control-IoC for more information
// See https://www.gencayyildiz.com/blog/dependency-injection-nedir-nasil-uygulanir/ for more information
// See https://www.gencayyildiz.com/blog/dependency-injectiondi-ninject/ for more information
Console.WriteLine("Hello, World!");


#region Difference between Design Principle and Design Pattern
/*

    ! In the programming world, both 'design principles' and 'design patterns' are not the same. Let’s discuss the differences between them.

    * Design Principles do not provide any implementation and also they are not bound to any programming languages. So, you can use design principles irrespective of the programming languages.
        - For example, the Single Responsibility Principle states that a class should have only one reason to change.
        - This is the high-level statement that we need to keep in mind while designing the classes for our application.
        - The SRP does not provide any specific implementation steps.
        - It’s up to us how we implement the Single Responsibility Principle in our application.
    
    * Design patterns are reusable solutions to the problems that we encounter in our day-to-day programming.
        - There are so many design patterns that are tested by others and are safe to follow.
        - For example, if you want to create a class that can have only one instance for the entire application then you can use the Singleton design pattern which ensures that a class has only one instance for the entire application and provides a global point of access to it.
*/
#endregion


#region What is Control?
/*

    ? Here, control means any extra responsibilities a class has other than its main or fundamental responsibility.
        - For example, control over the flow of an application, control over the dependent object creation, etc.
        - IoC is all about inverting the control.
*/
#endregion


#region Inversion of Control in C#
/*

    ? Inversion of control is a software design principle that asserts a program can benefit in terms of pluggability, testability, usability and loose coupling if the management of an application's flow is transferred to a different part of the application.
    ? The main objective of Inversion of Control in C# is to remove tight coupling between the objects of an application which makes the application more decoupled and maintainable.
    ? The IoC Design Principle suggests the inversion of various types of controls in object-oriented design to achieve loose coupling between the application classes.
    ! It cannot do these alone!

    - IoC design principle does not specify a problem domain within which it is meant to operate.
    - It is not precisely clear what is meant by "control,"
    - IoC does not specify where an application's control is best inverted to.
    - Further, IoC makes no guarantees about the benefits its implementation will have.
    + The IoC design principle simply asserts that benefits may accrue if you invert the flow of an application.


    * To explain this in layman's terms, suppose you drive a car to your work place.
    * This means you control the car.
    * The IoC principle suggests to invert the control, meaning that instead of driving the car yourself, you hire a cab, where another person will drive the car.
    * Thus, this is called inversion of the control.
        - from you to the cab driver.
    * You don't have to drive a car yourself and you can let the driver do the driving so that you can focus on your main work.
*/
#endregion


#region Understanding the Dependency Inversion Principle in C#
/*

    * C# dilindeki Bağımlılık Tersine Çevirme İlkesi, sınıflar arasında gevşek bağlantı elde etmemiz gerektiğini ifade eder.
    * Sınıflar arasında gevşek bağlantı elde etmek için hem DIP hem de IoC'nin birlikte kullanılması şiddetle tavsiye edilir.
    * DIP, yüksek seviyeli modüllerin/sınıfların düşük seviyeli modüllere/sınıflara bağlı olmaması gerektiğini belirtir. Her ikisi de soyutlamalara bağlı olmalıdır.

    ! We can’t accomplish loosely coupled classes by just utilizing IoC in C#.
    ! Along with IoC we additionally need to utilize DIP, DI, and IoC containers to achieve loosely coupled.
*/
#endregion


#region Understanding the Dependency Injection Design Pattern in C#
/*

    ! While Dependency Inversion is a principle for problem solving, Dependency Injection is a Design Pattern that applies this principle.
    * Bağımlılık Enjeksiyonu (DI) Tasarım Modeli, bağımlı nesnelerin oluşturulmasını tersine çevirerek gevşek bağlı kod geliştirmemize izin veren bir yazılım tasarım modelidir.
    * Bağımlılık Enjeksiyonu, yazılım bileşenleri arasındaki sıkı bağlantıyı azaltmanın harika bir yoludur.
    * DI ayrıca, yazılımımızda gelecekteki değişiklikleri ve diğer karmaşıklıkları daha iyi yönetmemizi sağlar.
*/
#endregion


#region IoC Containers in C#:
/*

    * IoC Container, bağımlılıklar oluşturmak ve bunları uygulama boyunca gerektiğinde otomatik olarak enjekte etmek için harika bir framework'tür, böylece yazılım programcıları olarak bizlerin buna ek zaman ve çaba harcamasına gerek kalmaz.
    * İsteğe göre gerekli nesneleri otomatik olarak oluşturur ve gerektiğinde bunları otomatik olarak enjekte eder.

    * There are different IoC Containers available for .NET such as Unity, Ninject, StructureMap, Autofac, etc.
*/
#endregion


#region Inversion of Control using the Dependency Inversion Principle in C#
public class Employee
{
    public int ID { get; set; }
    public string? Name { get; set; }
    public string? Department { get; set; }
    public int Salary { get; set; }
}
public class EmployeeDataAccess
{
    public Employee GetEmployeeDetails(int id)
    {
        // In real-time get the employee details from db
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
public class DataAccessFactory
{
    public static EmployeeDataAccess GetEmployeeDataAccessObj()
    {
        return new EmployeeDataAccess();
    }
}
public class EmployeeBusinessLogic
{
    // !
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
/*

    * In the above example, we implemented the factory design pattern to achieve IoC.
    * But the 'EmployeeBusinessLogic' class uses the concrete 'EmployeeDataAccess' class.
    ! So still our design is tightly coupled even though we have inverted the dependent object creation logic to the 'DataAccessFactory' class.

    ! Let’s use the Dependency Inversion Principle on the 'EmployeeBusinessLogic' and 'EmployeeDataAccess' classes and make them more loosely coupled.
    + As per the DIP definition, “a high-level module should not depend on low-level modules. Both should depend on an abstraction”.

    * So, first, we need to understand which one is the high-level module (class) and which one is the low-level module (class).
        - A high-level module is a module that depends on other modules.
        - In our example, the 'EmployeeBusinessLogic' class depends on 'EmployeeDataAccess' class, so here, the 'EmployeeBusinessLogic' class is the high-level module or class.
        - So, as per the first rule of DIP, the 'EmployeeBusinessLogic' class should not depend on the concrete 'EmployeeDataAccess' class, instead, both classes should depend on abstraction.
        - The second rule in the DIP is “Abstractions should not depend on details. Details should depend on abstractions”.

    ? What is Abstraction?
        - Abstraction means something which is non-concrete.
        - In programming terms, Abstraction is one of the most important features of object-oriented programming languages.
        - Its main goal is to handle complexity by hiding unnecessary details and providing the necessary details to call the object operations.
        - In the above example, 'EmployeeBusinessLogic' and 'EmployeeDataAccess' classes are concrete classes, meaning we can create objects of them.
        - So, abstraction in programming means we need to create either an interface or abstract class which is non-concrete.
        - As per DIP, 'EmployeeBusinessLogic' (high-level module) class should not depend on the concrete 'EmployeeDataAccess' (low-level module) class.
        - Both classes should depend on abstractions, meaning both classes should depend on either the interface or the abstract class.
*/
public interface IEmployeeDataAccess
{
    Employee GetEmployeeDetails(int id);
}
public class EmployeeDataAccess2 : IEmployeeDataAccess
{
    public Employee GetEmployeeDetails(int id)
    {
        // In real time get the employee details from db
        // but here we are hard coded the employee details
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
public class DataAccessFactory2
{
    public static IEmployeeDataAccess GetEmployeeDataAccessObj()
    {
        return new EmployeeDataAccess2();
    }
}
public class EmployeeBusinessLogic2
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
// ! Still, we have not achieved fully loosely coupled classes because the EmployeeBusinessLogic class includes the DataAccessFactory class to get the reference of IEmployeeDataAccess.
// ! This is where the Dependency Injection pattern helps us.
#endregion