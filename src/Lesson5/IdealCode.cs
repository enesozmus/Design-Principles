namespace Liskov_Substitution_Principle_IdealCode;

abstract class Cloud2
{
  public abstract void MachineLearning();
}
interface ITranslatable
{
  void Translate();
}
class AWS2 : Cloud2, ITranslatable
{
  public void Translate()
     => Console.WriteLine("AWS Translate");
  override public void MachineLearning()
      => Console.WriteLine("AWS Machine Learning");
}
class Azure2 : Cloud2
{
  override public void MachineLearning()
      => Console.WriteLine("Azure Machine Learning");
}
class Google2 : Cloud2, ITranslatable
{
  public void Translate()
     => Console.WriteLine("Google Translate");

  override public void MachineLearning()
      => Console.WriteLine("Google Machine Learning");
}