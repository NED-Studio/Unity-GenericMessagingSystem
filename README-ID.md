# Generic Messaging System
------
**Generic Messaging System** adalah messaging system untuk Unity game engine untuk menangani interaksi antar objek dengan menggunakan messaging yang menggunakan generic untuk menyimpan objek dari handler.

## Penggunaan
1. Download *.unitypackage dari [Halaman Release](../../releases)
2. Import ke project unity anda
3. Buat kelas baru yang meng-extend kelas `BaseMessagingManager`
4. Overite abstract method `BaseMessagingManager.CreateAllStorage()` dan `BaseMessagingManager.DestroyAllStorage()` dan dengan menggunakan fungsi dibawah ini untuk membuat/menghapus penyimpanan objek :
	```
	Kelas : BaseMessagingManager
	
	public void CreateStorage<D, I>() where D : IMessageDomain where I : IMessageListener
	
	public void DestroyStorage<D, I>() where D : IMessageDomain where I : IMessageListener
	```

5. Buat interface baru yang meng-extend `IMessageListener`
6. Buat interface baru yang meng-extend `IMessageDomain` untuk membuat domain baru atau gunakan `GlobalDomain` yang telah ada
7. Buat kelas baru yang mengimplementasikan `IMessageListener` sebagai kelas yang akan menangani message (handler)
8. Tambah/hapus handler ke/dari manager dengan memanggil fungsi Add/Remove dari kelas yang meng-extend `BaseMessagingManager`:
	```
	Kelas : BaseMessagingManager
	
	public void Broadcast<D, I>(Action<I> action) where D : IMessageDomain where I : IMessageListener
	
	public IEnumerator BroadcastAsync<D, I>(Action<I> action) where D : IMessageDomain where I : IMessageListener
	```
9. Broadcast message dengan menggunkan fungsi:
	```
	class : BaseMessagingManager
	
	public void Broadcast<D, I>(Action<I> action) where D : IMessageDomain where I : IMessageListener
	
	public IEnumerator BroadcastAsync<D, I>(Action<I> action) where D : IMessageDomain where I : IMessageListener
	```

Untuk lebih detail, silahkan liat pada contoh scene yang sudah ada.

## Contribution
Silahkan baca [CONTRIBUTION.md](./CONTRIBUTION.md) untuk informasi lebih detail untuk ikut berkontribusi.

## Licenses
Silahkan baca [LICENSE](./LICENSE) untuk informasi lebih tentang license.

## Bahasa
* [README(ENGLISH)](./README.md)
* [README(BAHASA)](./README-ID.md)
