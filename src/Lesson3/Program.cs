// See https://dotnettutorials.net/course/solid-design-principles/ for more information
Console.WriteLine("Hello, World!");


#region Single Responsibility Principle
/*

  ½ The Single Responsibility Principle is the first principle of SOLID principles.
  ? It is the fundamental principle of object-oriented programming that determines how we should design classes.
  ? The Single Responsibility Principle in C# states that “Each software module or class should have only one reason to change“.
  ? In other words, we can say that each module or class should have only one responsibility to do.
  ? If a class has more than one responsibility, then there will be more than one reason to change the class (code).

  * So we need to design the software in such a way that everything in a class or module should be related to a single responsibility.
  * That does not mean your class should contain only one method or property, you can have multiple members (methods or properties) as long as they are related to a single responsibility or functionality.
  * So, with the help of SRP in C#, the classes become smaller and cleaner and thus easier to maintain.
  * This principle aims to separate behaviours so that if bugs arise as a result of your change, it won’t affect other unrelated behaviours.
  * Amaç; geliştirilen projede bir güncelleme veya değişiklik yapılması istendiğinde kodların içinde kaybolmadan, yalnızca ilgili metoda giderek istenilen değişikliğin yapılmasının sağlanmasıdır.

    + First of all, because many different teams can work on the same project and edit the same class for different reasons, defining unrelated methods in a class, could lead to incompatible modules.
    + Second, it makes version control easier. For example, say we have a persistence class that handles database operations, and we see a change in that file in the GitHub commits. By following the SRP, we will know that it is related to storage or database-related stuff.
    + Third, if a Class has many responsibilities, it increases the possibility of bugs because making changes to one of its responsibilities, could affect the other ones without you knowing.    
*/
#endregion


#region Without using Single Responsibility Principle in C#
/*

  * Let us understand the need for the Single Responsibility Principle in C# with an example.
  * Suppose we need to design 'an Invoice class'.
  * As we know 'an Invoice class' basically used to calculate various amounts based on its data.
  
  * We would be violating the Single Responsibility Principle in C# if we create an Invoice class with four functions: Adding and Deleting Invoices, Error Logging and Sending Emails.
  ! This is because Sending Emails and Error Logging are not a part of the Invoice module.

    public class Invoice
    {
        public long InvAmount { get; set; }
        public DateTime InvDate { get; set; }

        public void AddInvoice()
        {
          try
          {
            + Here we need to write the Code for adding invoice
            + Once the Invoice has been added, then send the  mail
            MailMessage mailMessage = new MailMessage("EMailFrom", "EMailTo", "EMailSubject", "EMailBody");
            this.SendInvoiceEmail(mailMessage);
          }
          catch (Exception ex)
          {
            + Error Logging
            System.IO.File.WriteAllText(@"c:\ErrorLog.txt", ex.ToString());
          }
        }

        public void DeleteInvoice()
        {
          try
          {
            +Here we need to write the Code for Deleting the already generated invoice
          }
          catch (Exception ex)
          {
            + Error Logging
            System.IO.File.WriteAllText(@"c:\ErrorLog.txt", ex.ToString());
          }
        }

        public void SendInvoiceEmail(MailMessage mailMessage)
        {
          try
          {
            + Here we need to write the Code for Email setting and sending the invoice mail
          }
          catch (Exception ex)
          {
            + Error Logging
            System.IO.File.WriteAllText(@"c:\ErrorLog.txt", ex.ToString());
          }
        }
    }
*/
#endregion


#region Implementing the Single Responsibility Principle in C#
/*

  * Now let us discuss how to implement the above functionalities in such a way that, it should follow the Single Responsibility Principle.
  * Now, we are going to create three classes.
  * In the invoice class, only the invoice-related functionalities are going to be implemented.
  * The Logger class is going to be used only for logging purposes.
  * Similarly, the Email class is going to handle Email activities.
  ½ Now each class having only its own responsibilities, as a result, it follows the Single Responsibility Principle in C#.
*/
public class Invoice
{
    public long InvAmount { get; set; }
    public DateTime InvDate { get; set; }
    private ILogger fileLogger;
    private MailSender emailSender;
    public Invoice()
    {
        fileLogger = new Logger();
        emailSender = new MailSender();
    }
    public void AddInvoice()
    {
        try
        {
            fileLogger.Info("Add method Start");
            // Here we need to write the Code for adding invoice
            // Once the Invoice has been added, then send the  mail
            emailSender.EMailFrom = "emailfrom@xyz.com";
            emailSender.EMailTo = "emailto@xyz.com";
            emailSender.EMailSubject = "Single Responsibility Princile";
            emailSender.EMailBody = "A class should have only one reason to change";
            emailSender.SendEmail();
        }
        catch (Exception ex)
        {
            fileLogger.Error("Error Occurred while Generating Invoice", ex);
        }
    }
    public void DeleteInvoice()
    {
        try
        {
            //Here we need to write the Code for Deleting the already generated invoice
            fileLogger.Info("Delete Invoice Start at @" + DateTime.Now);
        }
        catch (Exception ex)
        {
            fileLogger.Error("Error Occurred while Deleting Invoice", ex);
        }
    }
}

public interface ILogger
{
    void Info(string info);
    void Debug(string info);
    void Error(string message, Exception ex);
}
public class Logger : ILogger
{
    public Logger()
    {
        // here we need to write the Code for initialization 
        // that is Creating the Log file with necesssary details
    }
    public void Info(string info)
    {
        // here we need to write the Code for info information into the ErrorLog text file
    }
    public void Debug(string info)
    {
        // here we need to write the Code for Debug information into the ErrorLog text file
    }
    public void Error(string message, Exception ex)
    {
        // here we need to write the Code for Error information into the ErrorLog text file
    }
}

public class MailSender
{
    public string? EMailFrom { get; set; }
    public string? EMailTo { get; set; }
    public string? EMailSubject { get; set; }
    public string? EMailBody { get; set; }
    public void SendEmail()
    {
        // Here we need to write the Code for sending the mail
    }
}
#endregion