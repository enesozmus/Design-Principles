namespace Loose_Coupling;

#region Loose Coupling Example 1
interface IArac
{
    string Calis();
    string HareketEt();
}

class Surucu
{
    private IArac _arac;
    public Surucu(IArac arac)
    {
        _arac = arac;
    }
    public string Calistir()
    {
        return _arac.Calis();
    }
    public string HareketEt()
    {
        return _arac.HareketEt();
    }
}

class Otomobil : IArac
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

class Tir : IArac
{
    public string Calis()
    {
        return "Tir çaliştiriliyor.";
    }
    public string HareketEt()
    {
        return "Tir istenilen yönde sürülüyor.";
    }
}

class Otobus : IArac
{
    public string Calis()
    {
        return "Otobüs çaliştiriliyor.";
    }
    public string HareketEt()
    {
        return "Otobüs istenilen yönde sürülüyor.";
    }
}
#endregion


#region Loose Coupling Example 2
interface IMailServer
{
    void Send(string to, string body);
}
class MailSender
{
    public void Send(IMailServer mailServer)
    {
        mailServer.Send("ensozmus@gmail.com", "DesignPrinciples");
    }
}
class Gmail : IMailServer
{
    public void Send(string to, string body)
    {
        //...
    }
}
class Hotmail : IMailServer
{
    public void Send(string to, string body)
    {
        //...
    }
}
class Yandex : IMailServer
{
    public void Send(string to, string body)
    {
        //...
    }
}
#endregion