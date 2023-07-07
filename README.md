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

#### Anasayfa
![Anasayfa](https://github.com/AbdurrahmanVarol/SurveyApp/assets/96303254/a941abb4-3142-45a7-83dd-3655b7840c27)

#### Anket Oluşturma Sayfası
![AnketOluşturma](https://github.com/AbdurrahmanVarol/SurveyApp/assets/96303254/beece33a-e445-4e41-8dfc-4b438e66bd3e)

#### Oluşturduğun Anketler Sayfası
![oluşturduğunAnketler](https://github.com/AbdurrahmanVarol/SurveyApp/assets/96303254/43d65930-17fc-438d-a978-5cd177a71400)

#### Anket Paylaşma
![Anket paylaşma 1](https://github.com/AbdurrahmanVarol/SurveyApp/assets/96303254/ed346611-aab2-47b9-8fce-0ecb9b8903a4)

![Anket paylaşma](https://github.com/AbdurrahmanVarol/SurveyApp/assets/96303254/10f7f5c0-f07f-4d75-a19e-1f31415f9fa9)

#### Anket Güncelleme Sayfası
![anket güncelle 1](https://github.com/AbdurrahmanVarol/SurveyApp/assets/96303254/3c6a8152-20d6-4fff-ac5f-7097aedf0b8f)

![Anket Güncelleme](https://github.com/AbdurrahmanVarol/SurveyApp/assets/96303254/cf38fa15-38ce-4c04-90d6-165364179a78)

#### Anket Silme 
![Anket silme 1](https://github.com/AbdurrahmanVarol/SurveyApp/assets/96303254/703ef967-a6b3-4bf8-9858-13ac1a9fe278)

![anket silme 2](https://github.com/AbdurrahmanVarol/SurveyApp/assets/96303254/1b88ee95-2fde-4a76-be7b-5b228a0a38e6)

#### Anket Sonuçları Sayfası
![anket sonucları](https://github.com/AbdurrahmanVarol/SurveyApp/assets/96303254/0665d641-dd73-4857-a202-441d56b6d4b1)
![anket sonucları2](https://github.com/AbdurrahmanVarol/SurveyApp/assets/96303254/51a976d2-f895-4d0c-84ee-a658bec74a79)

#### Anket Doldurma Sayfası
![Anket Detayları sayfası](https://github.com/AbdurrahmanVarol/SurveyApp/assets/96303254/8752e5fa-8a40-4f78-9d06-bea893796e03)


    

  
