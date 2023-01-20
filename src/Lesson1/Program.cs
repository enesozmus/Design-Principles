// See https://gamedevelopment.tutsplus.com/tutorials/quick-tip-the-oop-principle-of-coupling--gamedev-1935 for more information
// See https://r.je/slutty-software-tight-and-loose-coupling for more information
// See https://hknyvz.medium.com/tight-couplingten-loose-coupling-e-yolculuk-43403ee82742 for more information
// See https://medium.com/life-at-apollo-division/software-development-best-practice-2-loose-coupling-5994e7ce006c for more information
using Loose_Coupling;

Console.WriteLine("Hello, World!");


#region Principle/Prensip nedir?
/*

  ½ Her türlü tartışmanın dışında sayılan öncül, temel inanç, temel düşünce, temel davranış kuralı.
*/
#endregion


#region Design principles
/*

  * Tasarım ilkeleri, yazılım uygulamalarının kalitesinin iyileştirilmesine yardımcı olan yönergelerdir.
  * Tasarım ilkeleri, düzgün bir şekilde ele alınmadığında kötü bir tasarıma yol açan ve yaygın olarak ortaya çıkan sorunlar için tercih edilen çözümlerdir.
*/
#endregion


#region Giriş
/*

  * OOP uygulamalarında yazılımsal operasyonların büyük çoğunluğu nesneler üzerinde gerçekleşir.
  * Projelerde yazılan kodun istenilen işi yapması için birçok sınıf, bu sınıflardan türetilen nesneler ve nesneler yardımıyla kullanılan sınıf üyeleri vardır.
  * Bu nesneler kendi aralarında ilişkiye girerek ve işbirliği yaparak birbirlerine hizmet sunmaktadırlar.
  * Bu işbirliği neticesinde ister istemez bağımlılıklar ortaya çıkmaktadır.

  ? Bir kod parçacığı çalışabilmek için mutlaka içerisindeki spesifik bir nesneye ihtiyaç duyuyorsa bu o nesneye sıkı sıkıya bağlı/bağımlı olduğu anlamına gelir.

  ! Ne yaparsak yapalım nesne varsa bağımlılık ve etkileşim vardır, bu gerçeği değiştiremeyiz.
  ! Bağımlılıkları tamamı ile ortadan kaldırırsak da istenilen işi yaptıramayız çünkü sınıfların bir şekilde birbirlerinden haberleri olması gerekir.
  + Ancak bağımlılıkları yönetebiliriz daha yönetilebilir hale getirebiliriz.
*/
#endregion


#region What Is Coupling?
/*

    ? Coupling looks at the relationship between objects and how closely connected they are.

    ! Coupling, in OOP is inevitable.
    ! One component will always need to communicate with others in some way.
    ! Without coupling either nothing can communicate or everything in the whole application must exist in the same class.
    ! Clearly neither of these are viable solutions.
    * There are two different types of coupling:
    
        1. Tight coupling
        2. Loose coupling.

    * These describe the different types of relationships between objects.
    * Coupling is the principle of "separation of concerns".
    * This means that one object doesn't directly change the state or behavior of another object.

    * A good example of coupling is HTML and CSS.
    * Before CSS, HTML was used for both markup and presentation.
    * This created bloated code that was hard to change and difficult to maintain.
    * With the advent of CSS, HTML became used just for markup, and CSS took over for presentation.
    * This made the code fairly clean and easily changeable.
    * The concerns of presentation and markup were separated.
*/
#endregion


#region Tight coupling
/*

    ? Objects that rely on other objects and can modify the states of other objects are said to be tightly coupled.

    * Tight coupling creates situations where modifying the code of one object also requires changing the code of other objects.
    * Tightly coupled code is also harder to reuse because it can't be separated.
    * A common phrase you'll hear is "strive for low coupling and high cohesion". 
    * This phrase is a helpful reminder that we should strive for code that separates tasks and doesn't rely heavily on each other.
    * Thus, low (or loose) coupling is generally good, while high (or tight) coupling is generally bad.
*/
#endregion


#region Loose coupling
/*

    * Objects that are independent from one another and do not directly modify the state of other objects are said to be loosely coupled.
    * Loose coupling lets the code be more flexible, more changeable, and easier to work with.

    * Loose coupling makes your program far more flexible with little to no extra effort required.
    * Using loose coupling, as the requirements of your project inevitably change it's very easy to implement the updates.

    ? Loose Coupling, “birbiriyle etkileşime giren bileşenlerin, diğer bileşenlerin bilgisine mümkün olduğunca az güvenerek birbirinden bağımsız olması gerektiğini” öne süren bir ilkedir.
    ! Amacı neseneler arasındaki bağımlılıkaları daha yönetilebilir hale getirmektir.

    * * Kod yazarken nesneleriniz arasında bir işbirliği varsa bu işbirliğinden doğacak bağımlılığın yönetilmesinde abstract veya interface'lerin kullanılmasını öngören bir prensip sunar.
*/
#endregion


#region In other words
/*

  ! https://medium.com/life-at-apollo-division/software-development-best-practice-2-loose-coupling-5994e7ce006c
  + If you ever happen to see an angry Developer, with eyes wide open, swearing at everything around, there is a good chance he is trying to update a “spaghetti, tightly coupled code.”
    - Gözleri fal taşı gibi açılmış, etraftaki her şeye küfreden öfkeli bir Developer görürseniz, “spaghetti, tightly coupled code” bir kodu güncellemeye çalışıyor olma ihtimali yüksektir.
  + There are only a few things in the software development world that can get you more upset than when you need to rewrite half of the solution to squeeze in “that simple data source change.”
    - Yazılım geliştirme dünyasında, "o basit veri kaynağı değişikliğini" halledebilmek için çözümün yarısını yeniden yazmanız gerektiğinden daha fazla üzülmenize neden olabilecek yalnızca birkaç şey vardır.
  + Such structured code is very hard to maintain and the change requests are a nightmare to implement.
    - Bu tür yapılandırılmış kodun sürdürülmesi çok zordur ve değişiklik isteklerinin uygulanması tam bir kabustur.
  +  Loose coupling is a principle which avoids writing a tightly coupled spaghetti code, helping to separate the business logic from the infrastructure logic, and encourages writing the code in isolated components with a clearly described interface.
    - Gevşek bağlantı, sıkıca bağlı bir spagetti kodu yazmaktan kaçınan, iş mantığını altyapı mantığından ayırmaya yardımcı olan ve kodun açıkça tanımlanmış bir arayüzle izole bileşenlerde yazılmasını teşvik eden bir ilkedir.

  ? birden çok kaynakta kullanım durumunda kullanım durumuna dönüşebilmeli, yeniden düzenlenebilmeli, ölçeklenebilmeli, genişletilebilmeli ve biçim değiştirebilmelidir.
*/
#endregion


#region App
Surucu surucu = new Surucu(new Otomobil());
Console.WriteLine(surucu.Calistir());
Console.WriteLine(surucu.HareketEt());
Console.ReadLine();

Surucu surucu2 = new Surucu(new Tir());
Console.WriteLine(surucu2.Calistir());
Console.WriteLine(surucu2.HareketEt());
Console.ReadLine();

MailSender sender = new();
sender.Send(new Gmail());
sender.Send(new Hotmail());
Console.ReadLine();
#endregion