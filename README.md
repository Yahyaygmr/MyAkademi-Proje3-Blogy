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
    
