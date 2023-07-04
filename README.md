# SurveyApp

Proje gereksinimleri: 
  Kullanıcı giriş yaparak anket oluşturabilmeli.
  Kullanıcı oluşturduğu anketi güncelleyebilmeli, silebilmeli ve bir link üzerinden paylaşabilmeli.
  Herhangi bir kullanıcı giriş yapmadan oluşturulan anketleri doldurabilmeli.

Projenin yapısı:
  Arayüz tarafı .net MVC ile yapılmış olup Client ismiyle ayrılmıştır.
  Arkayüz tarafı .net API ile yapılmış olup Server ismiyele ayrılmıştır.

Server:
  Arkayüz projesi için mimari olarak Onion Architecture kullanılmıştır.
  Bu mimari katmanlar içeriden dışarıya halka şeklinde gösterildiği için bu adı almıştır.
  ![onionDiagram](https://github.com/AbdurrahmanVarol/SurveyApp/assets/96303254/90ec6f4a-0990-4b16-8848-931da5b22daa)


Kullanılan paketler:
  ORM: EntityFramework Core
  Validation: Fluent Validation
  Mapping: AutoMapper

API Endpoint'leri:
  


projedeki katmanlar:


Domain Katmanı:
  Value objects, entities gibi nesnelerin tutulduğu en iç katmandır.
  
  veri tabanı diagramı:
  ![DbDiagram](https://github.com/AbdurrahmanVarol/SurveyApp/assets/96303254/e6107473-5a8e-4aa5-bc25-1d394bc8299e)

Application Katmanı:
   Domain ile iş katmanı arasında soyutlama katmadınır.
   Tüm serviz interface'leri burada tanımlanır.
   Bu katmanın amacı veri erişiminde gevşek bağlılığı sağlamaktır.
   Dto, view model,Cqrs patter  validation, mapping gibi işlemlerin yapıldığı katmandır.

   Persistence Katmanı:
     Veritabanı operasyonlarınu yürüten katmandır.
     Application katmanındaki veri tabanı ile ilgibi repository ve servis interface'lerinin concrete classları bu katmanda oluşturulur.
    DbContext, Migration, Configoration, Seeding, Repository ve Servis concrate class'ları bu katmandadır.     

    Infrastricture Katmanı:
      Bu katmanın persistence katmanından farkı sadece veri tabanı dışındaki repository ve servis interface'lerinin concrete classların.
      Email, Payment servisleri örnek verilebilir.

  Presentation Katmanı:
    Kullanıcının uygulamayla iletişime geçtiği katmandır.
    Web API,MVC

Client:
  Kullanılan paketler:
    Http request: Refit

    

  
