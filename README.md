# 📚 Kütüphane Otomasyonu Web Uygulaması

Modern, kullanıcı dostu bir kütüphane yönetim sistemi. ASP.NET Core MVC ile geliştirilmiştir.

## 🚀 Özellikler

- **Dashboard**: Anlık istatistikler (Toplam Kitap, Üye, Aktif Ödünç, Geciken Kitaplar)
- **Kitap Yönetimi**: Kitap ekleme, düzenleme, silme ve kopya yönetimi
- **Üye Yönetimi**: Üye kayıt ve listeleme
- **Ödünç İşlemleri**: Kitap ödünç verme ve iade alma
- **Raporlar**: En çok okunan kitaplar, üye bazında ödünç raporu

## 🛠️ Teknoloji Stack

| Katman | Teknoloji |
|--------|-----------|
| Backend | C# ASP.NET Core MVC |
| ORM | Entity Framework Core (Database First) |
| Frontend | Bootstrap 5, DataTables |
| Database | Microsoft SQL Server |
| Test | xUnit |

## 📋 Gereksinimler

- .NET 8.0 SDK veya üzeri
- SQL Server (LocalDB, Express veya Full)
- Visual Studio 2022 veya VS Code

## ⚙️ Kurulum

### 1. Projeyi Klonlayın (Opsiyonel)

Git kullanıyorsanız:
```bash
git clone <repository-url>
cd KutuphaneOtomasyonu
```

### 2. Veritabanını Oluşturun ⚠️ ÖNEMLİ

SQL Server Management Studio (SSMS) veya Azure Data Studio'yu açın ve `Database/setup_database.sql` dosyasını çalıştırın:

**Adımlar:**
1. SSMS'i açın ve SQL Server'a bağlanın
2. `File > Open > File...` ile `Database/setup_database.sql` dosyasını açın
3. `Execute` (F5) butonuna basın
4. "VERİTABANI KURULUMU TAMAMLANDI!" mesajını görene kadar bekleyin

**Bu script şunları oluşturur:**
- `KutuphaneDB` veritabanı
- 5 tablo (books, copies, members, loans, loan_history)
- 7 stored procedure
- Örnek veriler (10 kitap, 7 üye, 13 kopya)

### 3. Connection String'i Kontrol Edin

`appsettings.json` dosyasındaki connection string'i kendi ortamınıza göre düzenleyin:

**Windows Authentication (Varsayılan):**
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=KutuphaneDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true"
  }
}
```

**SQL Server Authentication:**
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=KutuphaneDB;User Id=sa;Password=YourPassword;TrustServerCertificate=True;MultipleActiveResultSets=true"
  }
}
```

### 4. Projeyi Derleyin ve Çalıştırın

```bash
cd KutuphaneOtomasyonu
dotnet restore
dotnet build
dotnet run --project KutuphaneOtomasyonu.Web
```

Uygulama varsayılan olarak şu adreste çalışacaktır:
- http://localhost:5231 (veya konsoldaki adresi kontrol edin)

## 🧪 Testleri Çalıştırın

```bash
dotnet test
```

## 📁 Proje Yapısı

```
KutuphaneOtomasyonu/
├── Database/
│   └── setup_database.sql      # Veritabanı kurulum scripti
├── KutuphaneOtomasyonu.Web/
│   ├── Controllers/            # MVC Controller'lar
│   │   ├── HomeController.cs
│   │   ├── BooksController.cs
│   │   ├── MembersController.cs
│   │   ├── LoansController.cs
│   │   └── ReportsController.cs
│   ├── Models/
│   │   ├── Entities/           # EF Core Entity'leri
│   │   ├── ViewModels/         # View Model'ler
│   │   └── KutuphaneDbContext.cs
│   ├── Services/               # Business Logic Layer
│   ├── Views/                  # Razor View'ları
│   └── wwwroot/                # Static dosyalar
├── KutuphaneOtomasyonu.Tests/  # Unit Test'ler
├── .gitignore
└── README.md
```

## 🔧 Stored Procedure'ler

Uygulama aşağıdaki stored procedure'leri kullanmaktadır:

| Procedure | Açıklama |
|-----------|----------|
| `sp_AddBook` | Yeni kitap ekleme |
| `sp_UpdateBook` | Kitap güncelleme |
| `sp_DeleteBook` | Kitap silme |
| `sp_AddCopy` | Kitap kopyası ekleme |
| `sp_AddMember` | Yeni üye ekleme |
| `sp_LoanBook` | Kitap ödünç verme |
| `sp_ReturnBook` | Kitap iade alma |

## 📊 Veritabanı Şeması

```
┌─────────────┐     ┌─────────────┐     ┌─────────────┐
│   books     │────<│   copies    │────<│    loans    │
├─────────────┤     ├─────────────┤     ├─────────────┤
│ book_id     │     │ copy_id     │     │ loan_id     │
│ isbn        │     │ book_id     │     │ copy_id     │
│ title       │     │ shelf_loc   │     │ member_id   │
│ author      │     │ status      │     │ loaned_at   │
│ ...         │     │ ...         │     │ due_at      │
└─────────────┘     └─────────────┘     │ returned_at │
                                        └──────┬──────┘
                    ┌─────────────┐            │
                    │   members   │────────────┘
                    ├─────────────┤
                    │ member_id   │
                    │ full_name   │
                    │ email       │
                    │ ...         │
                    └─────────────┘
```

## 🐛 Sık Karşılaşılan Hatalar

### "Invalid object name 'books'" Hatası
Bu hata veritabanının oluşturulmadığı anlamına gelir. `Database/setup_database.sql` dosyasını SQL Server'da çalıştırın.

### "Cannot open database 'KutuphaneDB'" Hatası
SQL Server servisinin çalıştığından ve connection string'in doğru olduğundan emin olun.

## 👥 Ekip

- İbrahim Ünal
- Burak Çelik

## 📄 Lisans

Bu proje eğitim amaçlı geliştirilmiştir.

---

**VTYS Projesi - 2025**
