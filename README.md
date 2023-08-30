# SurveyApp

## Kurulum
  1. Connection stringin ayarlanması:
  - Vertabanı connection stringi Server\Resentation klasörü altındaki Web Api projetinde bulunan appsettings.json dostasında tutulmaktadır.
  2. Secret Key'in ayarlanması:
  - JWT Secret Key'i Server\ Presentation klasörü altındaki Web Api projetinde bulunan appsettings.json dostasında tutulmaktadır.
  3. Refit Baseadress'in ayarlanması:
  - Refit bir api'a istek atabilmesi için o api'nin çalıştığı adresi bilmesi gerekir.
  - Bu adres Client klasörü altındaki MVC projesinin appsettings.json dosyasında tutulmaktadır.
## Çalıştırma 
1. Komut ile
```
dotnet run --project .\SurveyApp\Server\src\Presentation\SurveyApp.API\SurveyApp.API.csproj
dotnet run --project .\SurveyApp\Client\SurveyApp.MVC\SurveyApp.MVC.csproj
```

2. Solution ayarları:
  - İki ayrı proje çalıştığı için Solution Properties > Common Properties > Startup Project kısmından Multiple startup projects' i işaretledikten sonra SurveyApp.API birinci sıraya, SurveyApp.MVC projesini ikinci sıraya getirdikten sonra Action kısmından bu iki proje için start konumuna getirin.
    
![Ekran görüntüsü 2023-07-07 160615](https://github.com/AbdurrahmanVarol/SurveyApp/assets/96303254/03187ef3-a598-4bd0-9ba4-863c0234c15c)

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
  
![onionDiagram](https://github.com/AbdurrahmanVarol/SurveyApp/assets/96303254/00e7a1c4-de2a-42d5-b1d3-bd8d7d6406ef)


#### Backend projesinde kullanılan paketler:
1. ORM: EntityFramework Core
2. Validation: Fluent Validation
3. Mapping: AutoMapper

#### Veritabanı diagramı:

![DbDiagram](https://github.com/AbdurrahmanVarol/SurveyApp/assets/96303254/ab67c520-fdef-49d3-98f7-2060a10382d0)

## Client:
  #### Kullanılan paketler:
  1. Http request: Refit
  1. Css: Bootstrap
  1. Toast message: AlertifyJs

#### Anasayfa
![Anasayfa](https://github.com/AbdurrahmanVarol/SurveyApp/assets/96303254/593a9607-07e7-4c4d-808c-c4c240eaa344)

#### Anket Oluşturma Sayfası
![AnketOluşturma](https://github.com/AbdurrahmanVarol/SurveyApp/assets/96303254/30a9d9d0-5199-416a-8401-52a88ba4cf4b)

#### Oluşturduğun Anketler Sayfası
![oluşturduğunAnketler](https://github.com/AbdurrahmanVarol/SurveyApp/assets/96303254/e77a3511-bcff-444d-a3b4-79ef3c0bb301)

#### Anket Paylaşma
![Anket paylaşma 1](https://github.com/AbdurrahmanVarol/SurveyApp/assets/96303254/909b6362-dccf-4532-b73a-fabe6e719227)

![Anket paylaşma](https://github.com/AbdurrahmanVarol/SurveyApp/assets/96303254/7a0f5d3b-8171-4197-bb07-110b5e9daefb)

#### Anket Güncelleme Sayfası
![anket güncelle 1](https://github.com/AbdurrahmanVarol/SurveyApp/assets/96303254/15f292cf-2f7d-4eb1-be79-5358147b76d9)

![Anket Güncelleme](https://github.com/AbdurrahmanVarol/SurveyApp/assets/96303254/07c8f94d-f660-44b7-922b-a7b4987cbe61)

#### Anket Silme 
![Anket silme 1](https://github.com/AbdurrahmanVarol/SurveyApp/assets/96303254/9a3e569d-eab2-43f1-914e-53721f1a996b)

![anket silme 2](https://github.com/AbdurrahmanVarol/SurveyApp/assets/96303254/6f6ac888-ca39-4ee6-8001-c3ce753de1ae)

#### Anket Sonuçları Sayfası
![anket sonucları](https://github.com/AbdurrahmanVarol/SurveyApp/assets/96303254/667e43bb-f1e0-4c94-a193-4d1af4c9ed98)

![anket sonucları2](https://github.com/AbdurrahmanVarol/SurveyApp/assets/96303254/68189f48-6023-401b-9489-7169a9698ccb)

#### Anket Doldurma Sayfası

![Anket Detayları sayfası](https://github.com/AbdurrahmanVarol/SurveyApp/assets/96303254/14387d8d-f401-487b-9416-9967321c516e)

    

  
