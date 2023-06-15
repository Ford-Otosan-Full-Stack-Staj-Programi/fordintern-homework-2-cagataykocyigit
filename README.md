[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-24ddc0f5d75046c5622901739e7c5dd533143b0c8e959d652212380cedb1ea36.svg)](https://classroom.github.com/a/3bErTxjD)
Person contoller uzerindeki tum actionlarda sessiondaki account id degerine gore
filtreleme yapilmali maddesi için Homework2 altında BlockAttribute altında AccountIdFilter sınıfını oluşturdum. Filtreleme işlemini accountId üzerinden yapabilmesi için OnActionExecuting altında accountId keyine route data yı eklemiş oldum .


Account controller uzerindeki POST methodu sadece Admin rolundeki kullanicilar
tarafindan kullanilabilmeli maddesi için  oluşturmuş olduğum AccountControllerda post metdou üstüne Role sınıfından aldığım  [Authorize(Roles = $"{Role.Admin}")] admin bilgisini authorize içinde vererek  admine özel hale getirdim.


AccountController ve PersonController daki tum actionlar [Authorize] attibute ile
calismali ve yetkisiz api cagrimi olmalalı maddesi için controllerda [authorize] ları gerekli yerlerde belirttim.


Jwt İşlemleri için öncelikle jwt confige parametreleri ekledim. Bu sınıfın karşılığı olarak application settingse config eklendi ki her yerden çalışabilmesi sağlansın (dependency injection)
Daha sonrasında startup içine static olarak eklemesini yaptım. Tokencontroller üzerinde login işlemi yapıldı. TokenManagementService içinde ise rollere bağlı olarak claimler belirlendi ve GenerateAccessToken ve Generatetoken şlemleri yapıldı.


Person modeli uzerindeki AccountId alani request den yani client dan alinmamali maddesi için odel üzerine gidip BindNever kullanarak request tarafından accountid engellemesi yapıldı.
