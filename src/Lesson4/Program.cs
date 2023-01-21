// See https://dotnettutorials.net/course/solid-design-principles/ for more information
Console.WriteLine("Hello, World!");

Invoice FInvoice = new FinalInvoice();
Invoice PInvoice = new ProposedInvoice();
Invoice RInvoice = new RecurringInvoice();
double FInvoiceAmount = FInvoice.GetInvoiceDiscount(10000);
double PInvoiceAmount = PInvoice.GetInvoiceDiscount(10000);
double RInvoiceAmount = RInvoice.GetInvoiceDiscount(10000);
Console.WriteLine(FInvoiceAmount);
Console.WriteLine(PInvoiceAmount);
Console.WriteLine(RInvoiceAmount);
Console.ReadLine();


Open_Closed_Principle_IdealCode.ParaGonderici paraGonderici = new();
paraGonderici.Gonder(new Open_Closed_Principle_IdealCode.Garanti(), 100, "asd");
paraGonderici.Gonder(new Open_Closed_Principle_IdealCode.Halkbank(), 100, "asd");
// paraGonderici.Gonder(new Open_Closed_Principle_IdealCode.FalancaBank(), 100, "asd");
Console.ReadLine();

#region Open-Closed Principle in C#
/*

  * The Open-Closed Principle states that “software entities such as modules, classes, functions, etc. should be open for extension, but closed for modification“.
  * This means that a class should be extendable without modifying the class itself.
  * If you want the Class to perform more functions, the ideal approach is to add to the functions that already exist NOT change them.
  + This principle aims to extend a Class’s behaviour without changing the existing behaviour of that Class.
  + This is to avoid causing bugs wherever the Class is being used.
  * Here we need to understand two things:

    1. Open for extension

      - 'The Open for extension' means we need to design the software modules/classes in such a way that the new responsibilities or functionalities should be added easily when new requirements come.
      - The reason for this is, we have already developed a class/module and it has gone through the unit testing phase.
      - So we should not have to change this as it affects the existing functionalities.
      - In simple words, we can say that we should develop one module/class in such a way that it should allow its behavior to be extended without altering its source code.

    2. Closed for modification

  + Kodun Değiştirilmesi: Var olan kodun yeni gereksinime göre değişime uğratılmasıdır.
  + Kodun Genişletilmesi: Var olan kodu değiştirmeksizin yeni gereksinime göre gelecek olan davranışın uygulamaya eklenebilmesidir.
*/
#endregion


#region Problems of Not following the Open-Closed Principle in C#: 
/*

  1. If you allow a class or function to add new logic then as a developer you need to test the entire functionalities which include the old functionalities as well as new functionalities of the application.
  2. If you are implementing all the functionalities in a single class, then the maintenance of the class becomes very difficult.
  3. If you are not following the Open-Closed Principle, then it also breaks the Single Responsibility Principle as the class or module is going to perform multiple responsibilities. 
*/
#endregion


#region Implementation Guidelines for the Open-Closed Principle (OCP) in C#
/*

  1. The easiest way to implement the Open-Closed Principle in C# is to add the new functionalities by creating new derived classes which should be inherited from the original base class.
  2. Another way is to allow the client to access the original class with an abstract interface.
*/
#endregion


#region Implementing the Single Responsibility Principle in C#
/*

  1. Within the Invoice class we have created the GetInvoiceDiscount() method.
  2. As part of that GetInvoiceDiscount() method, we are calculating the final amount based on the Invoice type.
  3. As of now, we have two Invoice Types as the FinalInvoice and the ProposedInvoice.
  4. So we have implemented the logic using if-else. 
  5. Tomorrow, if one more Invoice Type comes into the picture then we need to modify the GetInvoiceDiscount() method logic by adding another else if block to the source code.
  6. As we are changing the source code for the new requirement, we are violating the Open-Closed principle in C#.
  ! If we are changing the Invoice class again and again then we need to ensure that the previous functionalities along with the new functionalities are working properly by testing both the functionalities again.
*/
namespace Without.Open.Closed.Principle
{
    public class Invoice
    {
        public double GetInvoiceDiscount(double amount, InvoiceType invoiceType)
        {
            double finalAmount = 0;
            if (invoiceType == InvoiceType.FinalInvoice)
            {
                finalAmount = amount - 100;
            }
            else if (invoiceType == InvoiceType.ProposedInvoice)
            {
                finalAmount = amount - 50;
            }
            // ! Tomorrow, if one more Invoice Type comes into the picture then we need to modify the GetInvoiceDiscount() method logic by adding another else if block to the source code.
            return finalAmount;
        }
    }
    public enum InvoiceType
    {
        FinalInvoice,
        ProposedInvoice
    };
}
#endregion


#region With Open-Closed Principle in C#
/*

  * We have created three classes 'FinalInvoice', 'ProposedInvoice', and 'RecurringInvoice'.
  * All these three classes are inherited from the base class Invoice and if they want then they can override the GetInvoiceDiscount() method.
  * Tomorrow if another Invoice Type needs to be added then we just need to create a new class by inheriting it from the Invoice class.
  ! The point that you need to keep the focus on is we are not changing the code of the Invoice class.

  + Now, the Invoice class is closed for modification.
  + But it is open for the extension as it allows creating new classes deriving from the Invoice class which clearly follows the Open-Closed Principle in C#. 
*/
public class Invoice
{
    public virtual double GetInvoiceDiscount(double amount)
    {
        return amount - 10;
    }
}

public class FinalInvoice : Invoice
{
    public override double GetInvoiceDiscount(double amount)
    {
        return base.GetInvoiceDiscount(amount) - 50;
    }
}
public class ProposedInvoice : Invoice
{
    public override double GetInvoiceDiscount(double amount)
    {
        return base.GetInvoiceDiscount(amount) - 40;
    }
}
public class RecurringInvoice : Invoice
{
    public override double GetInvoiceDiscount(double amount)
    {
        return base.GetInvoiceDiscount(amount) - 30;
    }
}
#endregion