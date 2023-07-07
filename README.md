# SurveyApp

## Kurulum
  1. Connection stringin ayarlanması:
  - Vertabanı connection stringi Server\Resentation klasörü altındaki Web Api projetinde bulunan appsettings.json dostasında tutulmaktadır.
  2. Secret Key'in ayarlanması:
  - JWT Secret Key'i Server\Resentation klasörü altındaki Web Api projetinde bulunan appsettings.json dostasında tutulmaktadır.
  3. Refit Baseadress'in ayarlanması:
  - Refit bir api'a istek atabilmesi için o api'nin çalıştığı adresi bilmesi gerekir.
  - Bu adres Client klasörü altındaki MVC projesinin appsettings.json dosyasında tutulmaktadır.
  4. Solution ayarları:
  - İki ayrı proje çalıştığı için Solution Properties > Common Properties > Startup Project kısmından Multiple startup projects' i işaretledikten sonra SurveyApp.API birinci sıraya, SurveyApp.MVC projesini ikinci sıraya getirdikten sonra Action kısmından bu iki proje için start konumuna getirin.
    
![Ekran görüntüsü 2023-07-07 160615](https://github.com/AbdurrahmanVarol/SurveyApp/assets/96303254/fca6d682-648c-4819-87b7-6c240ae10a8c)


### Proje gereksinimleri: 
 - Kullanıcı giriş yaparak anket oluşturabilmeli.
 - Kullanıcı oluşturduğu anketi güncelleyebilmeli, silebilmeli ve bir link üzerinden paylaşabilmeli.
 - Herhangi bir kullanıcı giriş yapmadan oluşturulan anketleri doldurabilmeli.

### Projenin yapısı:
 - Frontend tarafı .Net MVC ile yapılmış olup Client ismiyle ayrılmıştır.
 - Backend tarafı .Net API ile yapılmış olup Server ismiyele ayrılmıştır.

### Server:
- Backent projesinde mimari olarak Onion Architecture kullanılmıştır.
- Bu mimari katmanlar içeriden dışarıya halka şeklinde gösterildiği için bu adı almıştır.

![onionDiagram](https://github.com/AbdurrahmanVarol/SurveyApp/assets/96303254/90ec6f4a-0990-4b16-8848-931da5b22daa)

#### Backend projesinde kullanılan paketler:
1. ORM: EntityFramework Core
2. Validation: Fluent Validation
3. Mapping: AutoMapper

#### Veritabanı diagramı:

![DbDiagram](https://github.com/AbdurrahmanVarol/SurveyApp/assets/96303254/e6107473-5a8e-4aa5-bc25-1d394bc8299e)

## Client:
  #### Kullanılan paketler:
  1. Http request: Refit
  1. Css: Bootstrap
  1. Toast message: AlertifyJs


    

  
