# KelimeEzberleme Projesi

Bu proje, kullanıcıların kelimeleri ezberlemelerini sağlamak için bir uygulama geliştirmeyi amaçlamaktadır. Uygulama, kullanıcıların kelimeleri 6 kez tekrar etmelerini sağlayarak öğrenmelerine yardımcı olur. 6 farklı
zaman aralığında bilinen kelimeleri kullanıcıya sunarak ezberlemeyi kolaylaştırır.

## Özellikler
- **Kullanıcı Kaydı ve Girişi**: Kullanıcılar kayıt olabilir ,kayıt olurken rollerini seçerler ve giriş yapabilir.
- **Kelime Ekleme ve Düzenleme**: Rolü öğretmen olan kullanıcı kelimeleri ekleyebilir ve düzenleyebilir.
- **Kelime Ezberleme Testi**: Rolü öğrenci olan kullanıcı kelimeleri ezberleme testine tabi tutulur.
- **Başarı Raporu**: Kullanıcıların kelime öğrenme ilerlemeleri raporlanır.,öğretmen tüm öğrencilerin raporunu görebilir.
- **Bulmaca Modülü**: 6 defa bilinen kelimelerle ilgili bulmacalar oluşturulabilir.
- **LLM Modülü**: (Henüz geliştirilmedi)

## Kurulum
1. GitHub reposunu klonlayın:
   ```bash
   git clone [https://github.com/Kayaedasu/Kelime_Ezberleme_Uygulamasi]
2. Gerekli bağımlılıkları yükleyin:
   dotnet restore
3. Uygulamayı başlatın:
    dotnet run
Projenin çalışabilmesi için .NET Core'un yüklü olması gerekir.
## Kullanım
Kullanıcı kaydı yapın.

Öğretmen ise öğretmen panelini açın 
Kelime ekleyin veya düzenleyin.
Rapor inceleyin.

Öğrenci ise öğrenci paneli açılır.
Kelime testi i,çin ayar seçin.
Kelime ezberleme testi başlatın.
Tarih değişikliği yapın.
6defa doğru bilirse bulmacaya geçin.
Analiz raporunu inceleyin.

## Teknolojiler
.NET Core: Uygulamanın temel altyapısı.

SQL Server: Veritabanı yönetimi.

SonarQube: Kod kalitesi için statik analiz.

Trello: Scrum ve proje yönetimi
##vTestler
Testleri çalıştırmak için aşağıdaki komutları kullanabilirsiniz:
dotnet test

## Lisans
MIT Lisansı.

