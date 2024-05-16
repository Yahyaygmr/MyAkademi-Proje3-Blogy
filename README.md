# BLOGY
## Prpjeye Genel Bakış
Asp .Net Core 6.0 ile hazırladığım broje admin ve yazar panelli bir blog sitesidir.
### UI
- Bu alan blogların kullanıcıya sunulduğu alandır.
- Bu alanda kullanıcılar blog detayları, blogun yazarı, yazarın diğer blogları gibi bilgilere erişebilirler.
- Ayrca blaglar içinde blog başlığına göre arama yapabilirler.
- Bloglara yorum yapabilirler.
- Sistemde karşılaştıkları aksaklıklar veye soru, görüş ve önerileri için iletişim panelinden sayfa adminine mesajlarını iletebilirler.
- Yazar olmak isteyenler için kayıt paneli ve yazar, admin girişleri bu alanda bulunmaktadır.

### Writer
- UI tarafında kayıt işlemini tamamlayan yazar Admin tarafından yetkilendirmesi yapılınca writer paneline erişim sağlayabilir.
- Admin tarafından yetkilendirmesi yapılıncaya kadar giriş yaptığında 403 sayfası ile karşılaşacaktır.
- Bu panelde yazar blog ekleyebilir,
- Kendi bloglarına yapılmış olan ve admin tarafından yayınlanmasınanizin verilen yorumları görüntüleyebilir,
- Diğer yazarlar va admin ile mesajlaşabilir,
- Admine destek talebini iletebilir,
- Admin tarafından yayınlanan duyuruları görüntüleyebilirler.
- Dashboard alanında Rapif Api ve OpenWeather Apiden bulunduğu bölgeniz anlık ve 7 günlük hava durumuna ulaşabilir
- Sistemle ve kendi yazdığı bloglarla ilgili istetistiklere ulaşabilir.
- Ayrıca İstatistik sayfasında da daha ayrıntılı istetistiklere ve kategoriler ve kategorilere ait blogları Google Pie Chart üzerinde görüntüleyebilirler.
- Profil ayarları alanında profil fotoğrafı ve şifre değiştirme işlemlerini yapabilirler.
- So menü için 5 Ayrı dil desteği bulunmaktadır.(Türkçe,İngilizce,Almanca,Fransızca,İspanyolca)

  ### Admin
  - Bu panelde admin tarafından ön yüzde bulunan statik sayfaların (Hakkımızda, İletişim,Sosyal Meday Hesapları vb.) yönetimi ve düzenlenmasi yapılabilabilir.
  - Bu panelde yazarlara ve diğer kullanıcılara atanacak rollerin yönetimi yapılır.
  - Yazarların onaylanması,
  - Bloglara yapılan yorumların onaylanması ve yönetimi,
  - Sistemi kullanan yazarlar ile mesajlaşma,
  - Gelen destek taleplerini karşılama,
  - UI tafafında gelen mesajların yönetimi,
  - Duyuru yayınlama,
  - Blogların yönetimi gibi işlemleri yapabilir.
  - Dashboard alanında yazr bulunduğu bölgenin anlık hava durumunu ve sistemle ilgili bazı istatistikleri görüntüleyebilir.

## Kullanılan Teknolojiler
- Asp .Net Core Mvc 6.0
- Repository Pattern
- MsSql
- EntityFramework
- Rapid Api
- Microsoft Identity Core
- Rol bazlı yetkilendirme ve authentication
- Fluent Validation
- Localization (5 Ayrı dil desteği)
  
## Projeye Ait Görseller
### Video
----------

### Veritabanı
![Ekran görüntüsü 2024-05-16 120120](https://github.com/Yahyaygmr/Proje3-Blogy/assets/101245826/a74b7f30-deea-40b1-9c88-9bffb3f693f0)
### UI
![Ekran görüntüsü 2024-05-16 104735](https://github.com/Yahyaygmr/Proje3-Blogy/assets/101245826/1295e38f-140f-4de4-8396-77902c10d14f)
![Ekran görüntüsü 2024-05-16 104813](https://github.com/Yahyaygmr/Proje3-Blogy/assets/101245826/aa0c1091-832d-4a6d-8dd6-192cd0af7841)
![Ekran görüntüsü 2024-05-16 104837](https://github.com/Yahyaygmr/Proje3-Blogy/assets/101245826/490efa54-ca6b-4b30-842c-2151a16c6ac3)
![Ekran görüntüsü 2024-05-16 104859](https://github.com/Yahyaygmr/Proje3-Blogy/assets/101245826/51c4b8a2-56a4-4f0b-bece-2866ae7a79f2)
![Ekran görüntüsü 2024-05-16 104551](https://github.com/Yahyaygmr/Proje3-Blogy/assets/101245826/83e0589c-b8c8-4d76-8e68-8dcab5c3704c)
![Ekran görüntüsü 2024-05-16 104634](https://github.com/Yahyaygmr/Proje3-Blogy/assets/101245826/c80d4658-3890-4907-bab0-1125b58bedd5)
![Ekran görüntüsü 2024-05-16 104710](https://github.com/Yahyaygmr/Proje3-Blogy/assets/101245826/47a5102b-6d59-4e28-ad2f-56dc428df133)


### Yazar Paneli
![Ekran görüntüsü 2024-05-16 105416](https://github.com/Yahyaygmr/Proje3-Blogy/assets/101245826/1aea48dc-3c9d-4ded-b0ea-b3a9240d1009)
![Ekran görüntüsü 2024-05-16 105507](https://github.com/Yahyaygmr/Proje3-Blogy/assets/101245826/e7392b8f-8d60-42e0-858d-21f82feab9ba)
![Ekran görüntüsü 2024-05-16 105606](https://github.com/Yahyaygmr/Proje3-Blogy/assets/101245826/2c78e409-ae74-426f-b3f3-c424d62ce985)
![Ekran görüntüsü 2024-05-16 105225](https://github.com/Yahyaygmr/Proje3-Blogy/assets/101245826/a7f89727-c3bc-4c30-a221-01d76ca5bf1d)
![Ekran görüntüsü 2024-05-16 105246](https://github.com/Yahyaygmr/Proje3-Blogy/assets/101245826/94fdd129-9884-4fe9-9dad-048c677a6b08)
![Ekran görüntüsü 2024-05-16 105320](https://github.com/Yahyaygmr/Proje3-Blogy/assets/101245826/1a8bacc8-1f21-4531-9b72-e9a00788c59c)
![Ekran görüntüsü 2024-05-16 105345](https://github.com/Yahyaygmr/Proje3-Blogy/assets/101245826/9ccee9a5-c465-4681-9d89-903e567b3489)


### Admin Paneli
![Ekran görüntüsü 2024-05-16 103915](https://github.com/Yahyaygmr/Proje3-Blogy/assets/101245826/1869b45a-4e25-430c-99d5-d796594559ee)
![Ekran görüntüsü 2024-05-16 104946](https://github.com/Yahyaygmr/Proje3-Blogy/assets/101245826/258b858e-6a5c-4c18-b83c-c3b59b410f7f)
![Ekran görüntüsü 2024-05-16 105014](https://github.com/Yahyaygmr/Proje3-Blogy/assets/101245826/40dfd587-dcce-4fd2-80c2-e290b13377ff)
![Ekran görüntüsü 2024-05-16 105052](https://github.com/Yahyaygmr/Proje3-Blogy/assets/101245826/30eaff5e-ed4e-4ae6-af34-bd53de631b28)
![Ekran görüntüsü 2024-05-16 105115](https://github.com/Yahyaygmr/Proje3-Blogy/assets/101245826/19489c33-0811-4b35-bd71-04ba736e821d)
![Ekran görüntüsü 2024-05-16 105644](https://github.com/Yahyaygmr/Proje3-Blogy/assets/101245826/51107389-5df7-4b06-893c-bd201c8c039a)
![Ekran görüntüsü 2024-05-16 105703](https://github.com/Yahyaygmr/Proje3-Blogy/assets/101245826/24ae2032-059b-4328-8e55-cb6a9c9ad814)

### Hata Sayfaları
![Ekran görüntüsü 2024-05-16 105759](https://github.com/Yahyaygmr/Proje3-Blogy/assets/101245826/f78e826e-92b1-4285-9e44-f8f2e5be36fc)
![Ekran görüntüsü 2024-05-16 105835](https://github.com/Yahyaygmr/Proje3-Blogy/assets/101245826/57b8be84-c6df-4706-b2e3-70e9af8b0254)

