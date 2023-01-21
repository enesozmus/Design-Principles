// See https://dotnettutorials.net/course/solid-design-principles/ for more information
using Liskov_Substitution_Principle_Unideal;
using Liskov_Substitution_Principle_IdealCode;

Console.WriteLine("Hello, World!");


// Unideal
Cloud cloud = new AWS();
cloud.MachineLearning();
cloud.Translate();

cloud = new Google();
cloud.MachineLearning();
cloud.Translate();

cloud = new Azure();
cloud.MachineLearning();
// cloud.Translate();    // !
// if (cloud is not Azure)
// {
//   cloud.Translate();
// }
Console.ReadLine();

// Ideal
Cloud2 cloud2 = new AWS2();
cloud2.MachineLearning();
(cloud2 as ITranslatable)?.Translate();

cloud2 = new Google2();
cloud2.MachineLearning();
(cloud2 as ITranslatable)?.Translate();

cloud2 = new Azure2();
cloud2.MachineLearning();
(cloud2 as ITranslatable)?.Translate();
Console.ReadLine();


#region Liskov Substitution Principle
/*

  ? The Liskov Substitution Principle is a Substitutability principle in object-oriented programming Language.

    → This principle states that, if S is a subtype of T, then objects of type T must be able to be replaced with the objects of type S.
    → This means that every subclass or derived class should be substitutable for their base or parent class.

  * If you have a Class and create another Class from it, it becomes a parent and the new Class becomes a child.
  * The child Class should be able to do everything the parent Class can do.
  ? This process is called Inheritance.
  ! When a child Class cannot perform the same actions as its parent Class, this can cause bugs.
  ! The child Class should be able to process the same requests and deliver the same result as the parent Class or it could deliver a result that is of the same type.

  ½ Goal:
    → This principle aims to enforce consistency so that the parent Class or its child Class can be used in the same way without any errors.
*/
#endregion


#region Without using the Liskov Substitution Principle in C#
/*

  * Let us first understand one example without using the Liskov Substitution Principle in C#.
  * In the following example, first, we create the 'Apple' class with the method GetColor().
  * Then we create the Orange class which inherits the 'Apple' class as well as overrides the GetColor() method of the Apple class.
  + Apple is the base class and Orange is the child class... There is a Parent-Child relationship.

  * So, we can store the child class object in the Parent Reference variable.
  * and when we call the GetColor i.e. apple.GetColor(), then we are getting the color of the Orange not the color of Apple.

       - Apple apple = new Orange();
       - Console.WriteLine(apple.GetColor());

  ! That means once the child object is replaced i.e. Apple storing the Orange object, the behavior is also changed.
  ! This is against the LSP Principle.
  ! The point is that an Orange cannot be replaced by an Apple, which results in printing the color of the apple as Orange as shown in the below example.
*/
Apple apple = new Orange();
Console.WriteLine(apple.GetColor());
class Apple
{
    public virtual string GetColor()
    {
        return "Red";
    }
}

class Orange : Apple
{
    public override string GetColor()
    {
        return "Orange";
    }
}
#endregion


#region With Liskov Substitution Principle in C#
/*

  * Let’s modify the previous example to follow the Liskov Substitution Principle.
  * Here, first, we need a generic base class such as 'Fruit' which is going to be the base class for both 'Apple' and 'Orange'.
  * Now you can replace the 'Fruit' class object with its subtypes either 'Apple' and 'Orage' and it will behave correctly.
  + Now, you can see in the below code, we created the super 'Fruit' class as an abstract class with the GetColor() abstract method and then the 'Apple' and 'Orange' class inherited from the 'Fruit' class and implement the GetColor() method. 
*/

public abstract class Fruit
{
    public abstract string GetColor();
}
public class Apple2 : Fruit
{
    public override string GetColor()
    {
        return "Red";
    }
}
public class Orange2 : Fruit
{
    public override string GetColor()
    {
        return "Orange";
    }
}
#endregion