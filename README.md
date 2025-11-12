# 📍 AR Menu Resto

`AR Menu Resto` adalah aplikasi Augmented Reality (AR) yang sangat simpel dan praktis untuk memvisualisasikan menu makanan. Aplikasi ini dibuat dengan **Unity**.

Begitu aplikasi dibuka, pengguna akan langsung diminta izin untuk menggunakan kamera. Setelah itu, pengguna hanya perlu mengarahkan kamera smartphone-nya ke salah satu dari empat gambar makanan yang telah disiapkan.

Saat kamera mengenali *marker* gambar tersebut, sebuah model makanan 3D akan langsung muncul di layar, tepat di atas gambar aslinya, seolah-olah "hidup" di dunia nyata.

---
## 📱 Demo Aplikasi



---
## ✨ Fitur Utama

* **Visualisasi 3D:** Menampilkan model 3D makanan (Onigiri, Nasi Lemak, Chicken Paprika, Grilled Sandwich) secara *real-time*.
* **Berbasis Marker:** Menggunakan gambar makanan sebagai target untuk memunculkan AR.
* **Zero-Friction:** Pengalaman pengguna yang sangat sederhana. Tidak ada menu, tidak perlu login, dan tidak ada tombol yang rumit.
* **Instan:** Cukup buka aplikasi, berikan izin kamera, dan langsung gunakan.

---

## 🚀 Cara Menggunakan

1.  Buka aplikasi `AR Menu Resto`.
2.  Saat diminta, berikan izin aplikasi untuk mengakses kamera Anda.
3.  Arahkan kamera Anda ke salah satu gambar **Target Marker** di bawah ini (Anda bisa menampilkannya di layar komputer atau mencetaknya).
4.  Nikmati visualisasi 3D dari menu makanan yang muncul!

---

## 🎯 Target Marker

Untuk mencoba aplikasi, arahkan kamera Anda ke salah satu dari empat gambar di bawah ini.

| Menu | Gambar Marker |
| :--- | :--- |
| **Nasi Lemak** | ![Nasi Lemak](markers/nasi%20lemak.jpg) |
| **Onigiri** | ![Onigiri](markers/onigiri.jpg) |
| **Grilled Sandwich**| ![Grilled Sandwich](markers/grilled%20sandwic.jpg) |
| **Chicken Paprika** | ![Chicken Paprika](markers/chicken%20paprika.jpg) |

---

## 🔧 Dibangun Dengan

* **Unity *(Editor version: 2022.3.62f3)***
* **AR Foundation**
* **model 3D dari [fab](https://www.fab.com/)**

---

## 💻 Setup untuk Developer
### 🛠️ Prasyarat (Penting)

Sebelum membuka proyek ini, pastikan Anda telah menginstal:

1.  **Unity Hub**: [Download di sini](https://unity.com/download)
2.  **Unity Editor Versi**: `2022.3.62f3`
3.  **Modul Android Build Support**:
    * *(Tambahkan modul ini melalui Unity Hub di tab "Installs")*

---

### 🚀 Cara Menjalankan Proyek

1.  **Clone Repositori**
    ```bash
    git clone https://github.com/EgaSulanjana/UTS-ARMenuResto-ARVR.git
    ```

2.  **Buka Proyek di Unity Hub**
    * Buka Unity Hub.
    * Klik tombol **"Open"** atau **"Add project from disk"**.
    * Arahkan ke folder proyek yang baru saja Anda clone (folder yang berisi `Assets`, `Packages`, `ProjectSettings`).
    * Klik **"Open"**.

3.  **Tunggu Impor**
    * Unity akan mengimpor semua aset. Proses ini mungkin memakan waktu beberapa menit saat pertama kali dibuka.

---

### 📱 Cara Testing Aplikasi

Anda bisa menguji aplikasi AR ini dengan dua cara:

### Opsi 1: Build APK (Rekomendasi)

Ini akan membuat file `.apk` yang bisa diinstal di ponsel Android.

1.  Di Unity, buka `File > Build Settings...`.
2.  Pilih platform **Android**, lalu klik **"Switch Platform"**.
3.  Pastikan *scene* Anda sudah ditambahkan ke "Scenes In Build".
4.  Hubungkan ponsel Android Anda yang kompatibel AR.
5.  Klik **"Build and Run"**.

### Opsi 2: Unity Remote (Untuk Debugging Cepat)

Cara ini me-streaming tampilan Editor ke ponsel Anda.

1.  Di ponsel Anda, install aplikasi **"Unity Remote 5"** dari Play Store.
2.  Di ponsel Anda, aktifkan **Opsi Pengembang (Developer Options)** dan **USB Debugging**.
3.  Di Unity Editor, buka `Edit > Project Settings > Editor`.
4.  Pada bagian `Device`, ubah menjadi **"Any Android Device"**.
5.  Hubungkan ponsel Anda ke PC dengan kabel USB.
6.  Tekan tombol **Play** (▶) di Unity Editor.
