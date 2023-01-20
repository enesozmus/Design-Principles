namespace Tight_Coupling;


#region Tight Coupling Example 1
/*

  * Consider an instance wherein you have created two classes in a program: A and B.
  * When a method of Class A calls the method of Class B or uses variable instances defined in Class B, both classes are tightly coupled.
  * However, when Class A depends on the interface of Class B instead of the methods defined in Class B, both classes are loosely coupled.


  + MailSender class'ı, içerisinde Gmail class'ını kullanıyorsa MailSender class'ı Gmail class'ına sıkı sıkıya bağlı/bağımlıdır deriz.

      1. Bu durumda MailSender class'ı, Gmail class'ı varlığını yitirdiği takdirde artık bir anlam ifade etmediği bir yere sürüklenmektedir.
      2. Gmail class'ında meydana gelebilecek yapısal herhangi bir değişiklik MailSender class'ını doğrudan etkileyecektir.
      3. İçerisinde Hotmail veya Yandex class'larının çalışır bir vaziyette kullanılabilmesi şu şartlarda sadece şart bloklarıyla sağlanabilir.
          ½ Bu da bağımlılıkların yönetilme yollarının iyi olanlarından biri değildir.
*/
public class MailSender
{
  public void Send()
  {
    /*

        ! MailSender, Gmail nesnesini kendi içerisinde bir yerde direkt kullanıyorsa biz buna bağımlılık/dependency diyoruz.
        ! Gmail nesnesi Constructor'ın içerisinde olsaydı yine bağımlılık mıydı?
            - Evet, bağımlılıktı!
        ! Gmail nesnesi Static Constructor'ın içerisinde olsaydı yine bağımlılık mıydı?
            - Evet, bağımlılıktı!
        ! Gmail nesnesi Destructor'ın içerisinde olsaydı yine bağımlılık mıydı?
            - Evet, bağımlılıktı!
        ! Gmail nesnesi bir method'un parametresi içerisinde olsaydı yine bağımlılık mıydı?
            - Evet, bağımlılıktı!
    */
    Gmail gmail = new();
    gmail.Send();
    // gmail.Send("gyildizmail@gmail.com");
    // gmail.Send("ensozmus@gmail.com");
    Hotmail hotmail = new();
    Yandex yandex = new();
  }
}

class Gmail
{
  public void Send()
  // ! Gmail'de yapılan onarım/bakım/değişiklik MailSender'da doğrudan revize gerektirir.
  // public void Send(string to)
  {
    //...
  }
}

public class Hotmail { }
class Yandex { }
#endregion



#region Tight Coupling Example 2
class Otomobil
{
  public string Calis()
  {
    return "Otomobil çaliştiriliyor.";
  }
  public string HareketEt()
  {
    return "Otomobil istenilen yönde sürülüyor.";
  }
}

class Surucu
{
  /*

    ! Surucu sınıfında Otomobil sınıfı new’lenerek sınıfın metotları kullanılıyor. Yani Surucu sınıfı Otomobil sınıfına sıkı sıkıya bağlıdır.
    * Sürücü sınıfı, otomobil sınıfı olmadan bir iş yapamıyor. Tek başına işe yaramaz durumda.
    * Otomobil sınıfında yapılan yapısal değişiklikler sürücü sınıfını etkileme olasılığı yüksek.
    * Sürücü sınıfı, başka bir modülde kullanılmak istendiğinde otomobil sınıfıyla birlikte kullanılmak zorunda kalacaktır. Bağımlılığı yüzünden kod tekrarına sebebiyet verecek.
    * Sürücü sınıfına başka bir araç kulladırmak istendiğinde mesela tır, kullanamayacak sadece otomobil kullanabilir durumda.
    * İçeriye yazılan şart bloklarıyla bu belki sağlanabilir ancak daha kolay yolu, bağımlılıkların azaltılmasıdır.
  */

  Otomobil otomobil = new Otomobil();
  public string Calistir()
  {
    return otomobil.Calis();
  }
  public string Sur()
  {
    return otomobil.HareketEt();
  }
}
#endregion