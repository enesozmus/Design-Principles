namespace Open_Closed_Principle_IdealCode;

interface IBanka
{
  bool ParaTransferi(int tutar, string hesapNo);
}
class ParaGonderici
{
  public void Gonder(IBanka banka, int tutar, string hesapNo)
  {
    banka.ParaTransferi(tutar, hesapNo);
  }
}
class Garanti : IBanka
{
  public string? HesapNo { get; set; }
  public void ParaGonder(int tutar)
  {
    //...
  }

  public bool ParaTransferi(int tutar, string hesapNo)
  {
    try
    {

      HesapNo = hesapNo;
      ParaGonder(tutar);
      return true;
    }
    catch
    {
      return false;
    }
  }
}
class Halkbank : IBanka
{
  public void GonderilecekHesapNo(string hesapNo)
  {
    //...
  }
  public void Gonder(int tutar)
  {
    //...
  }

  public bool ParaTransferi(int tutar, string hesapNo)
  {
    try
    {
      GonderilecekHesapNo(hesapNo);
      Gonder(tutar);
      return true;
    }
    catch
    {
      return false;
    }
  }
}
class FalancaBank : IBanka
{
  public bool ParaTransferi(int tutar, string hesapNo)
  {
    throw new NotImplementedException();
  }
}