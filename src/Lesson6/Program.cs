// See https://dotnettutorials.net/course/solid-design-principles/ for more information
Console.WriteLine("Hello, World!");


#region Interface_Segregation Principle
/*

  ? The Interface Segregation Principle states that "Clients should not be forced to implement any methods they don’t use."

    → Rather than one fat interface, numerous little interfaces are preferred based on groups of methods with each interface serving one submodule.
    → This principle aims at splitting a set of actions into smaller sets so that a Class/Interface executes ONLY the set of actions it requires.

    1. First, no class should be forced to implement any method(s) of an interface they don’t use.
    2. Secondly, instead of creating large or you can say fat interfaces, create multiple smaller interfaces with the aim that the clients should only think about the methods that are of interest to them.
  
  ! As per the Single Responsibility Principle of SOLID, like classes, interfaces also should have a single responsibility.

  + Nesne Yönelimli Programlamada herhangi bir sınıf oluşturuyorsak bu sınıfı oluşturmadan önce nesneler arasındaki işbirliği ve iletişim süreçlerinde esnek bağ kurabilmek için Loose Coupling​ Prensibi gereği bu sınıfın abstraction yapılanmasını oluşturmamız gerekir.
  + Bir nesnenin sergilemesi gereken davranışların, o davranışlara odaklanmış özel interface'ler ile eşleşmesini öneren prensiptir.
*/
#endregion


#region Without using the Interface Segregation Principle in C#
/*

    * We have an interface, IPrinterTasks, declared with four methods.
    * Now if any class wants to implement this interface then that class should have to provide the implementation to 'all the four methods' of the IPrinterTasks interface.
    * we have two classes HPLaserJetPrinter and LiquidInkjetPrinter who want the printer service.

    ! But the requirement is the HPLaserJetPrinter wants all the services provided by the IPrinterTasks while the LiquidInkjetPrinter wants only the Print and Scan service of the printer.
    ! As we have declared all the methods within the IPrinterTasks interface, then it is mandatory for the LiquidInkjetPrinter class to provide implementation to Scan and Print methods along with the Fax and PrinctDulex method which are not required by the class.
    ! This is violating the Interface Segregation Principle in C# as we are forcing the class to implement two methods that they don’t require.

        public interface IPrinterTasks
        {
            void Print(string PrintContent);
            void Scan(string ScanContent);
            void Fax(string FaxContent);
            void PrintDuplex(string PrintDuplexContent);
        }

        public class HPLaserJetPrinter : IPrinterTasks { }
        class LiquidInkjetPrinter : IPrinterTasks {}
*/
#endregion


#region With Interface Segregation Principle in C#
/*

  * Now, we have split that big interface into three small interfaces.
  * Each interface now having some specific purpose.

  ? Now if any class wants all the services then that class needs to implement all the three interfaces as shown below.
  ? Now, if any class wants the Scan and Print service, then that class needs to implement only the IPrinterTasks interfaces.
*/
interface IPrinterTasks
{
    void Print(string PrintContent);
    void Scan(string ScanContent);
}
interface IFaxTasks
{
    void Fax(string content);
}
interface IPrintDuplexTasks
{
    void PrintDuplex(string content);
}
class HPLaserJetPrinter : IPrinterTasks, IFaxTasks, IPrintDuplexTasks
{
    public void Print(string PrintContent)
    {
        Console.WriteLine("Print Done");
    }
    public void Scan(string ScanContent)
    {
        Console.WriteLine("Scan content");
    }
    public void Fax(string FaxContent)
    {
        Console.WriteLine("Fax content");
    }
    public void PrintDuplex(string PrintDuplexContent)
    {
        Console.WriteLine("Print Duplex content");
    }
}
class LiquidInkjetPrinter : IPrinterTasks
{
    public void Print(string PrintContent)
    {
        Console.WriteLine("Print Done");
    }
    public void Scan(string ScanContent)
    {
        Console.WriteLine("Scan content");
    }
}
#endregion
