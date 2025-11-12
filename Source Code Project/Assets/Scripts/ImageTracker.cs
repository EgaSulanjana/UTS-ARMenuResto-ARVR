using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

// Script ini membutuhkan komponen ARTrackedImageManager
[RequireComponent(typeof(ARTrackedImageManager))]
public class ImageTracker : MonoBehaviour
{
    // Class kecil untuk membantu kita mengatur prefab di Inspector
    [Serializable]
    public class TrackedImagePrefab
    {
        // Nama gambar (harus SAMA PERSIS dengan nama di Reference Image Library)
        public string imageName;
        // Prefab yang akan dimunculkan untuk gambar tersebut
        public GameObject prefab;
    }

    // Daftar semua pasangan gambar-prefab Anda
    public TrackedImagePrefab[] trackedImagePrefabs;

    // Referensi ke manager
    private ARTrackedImageManager trackedImageManager;

    // Dictionary untuk menyimpan prefab yang sudah dimunculkan (Instantiated)
    // Key: nama gambar, Value: prefab yang sudah dimunculkan
    private Dictionary<string, GameObject> spawnedPrefabs = new Dictionary<string, GameObject>();

    void Awake()
    {
        // Mendapatkan komponen manager saat script dimulai
        trackedImageManager = GetComponent<ARTrackedImageManager>();
    }

    void OnEnable()
    {
        // Mulai mendengarkan event 'trackedImagesChanged'
        trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    void OnDisable()
    {
        // Berhenti mendengarkan event saat script dimatikan
        trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    // Fungsi ini akan dipanggil setiap kali ada perubahan (gambar ditemukan, hilang, atau update)
    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        // 1. Cek gambar yang BARU DITEMUKAN (added)
        foreach (var newImage in eventArgs.added)
        {
            var prefabToSpawn = GetPrefabForImage(newImage.referenceImage.name);
            
            if (prefabToSpawn != null)
            {
                // Munculkan (Instantiate) prefab sebagai 'child' dari gambar yang terdeteksi
                GameObject newInstance = Instantiate(prefabToSpawn, newImage.transform);
                // Simpan prefab yang baru muncul ini ke dictionary
                spawnedPrefabs.Add(newImage.referenceImage.name, newInstance);
                Debug.Log($"Memunculkan prefab untuk: {newImage.referenceImage.name}");
            }
        }

        // 2. Cek gambar yang TERLIHAT/HILANG (updated)
        foreach (var updatedImage in eventArgs.updated)
        {
            // Jika gambar ada di dictionary kita...
            if (spawnedPrefabs.TryGetValue(updatedImage.referenceImage.name, out GameObject spawnedPrefab))
            {
                // Cek apakah gambar sedang dilacak (terlihat) atau tidak
                if (updatedImage.trackingState == TrackingState.Tracking)
                {
                    // Gambar terlihat -> Aktifkan prefab
                    spawnedPrefab.SetActive(true);
                }
                else
                {
                    // Gambar hilang dari pandangan -> Sembunyikan prefab
                    spawnedPrefab.SetActive(false);
                }
            }
        }

        // 3. Cek gambar yang DIHAPUS/HILANG SELAMANYA (removed)
        foreach (var removedImage in eventArgs.removed)
        {
            // Jika gambar ada di dictionary kita...
            if (spawnedPrefabs.TryGetValue(removedImage.referenceImage.name, out GameObject spawnedPrefab))
            {
                // Hancurkan prefab dari scene
                Destroy(spawnedPrefab);
                // Hapus dari dictionary
                spawnedPrefabs.Remove(removedImage.referenceImage.name);
                Debug.Log($"Menghapus prefab untuk: {removedImage.referenceImage.name}");
            }
        }
    }

    // Fungsi bantuan untuk mencari prefab yang benar berdasarkan nama gambar
    private GameObject GetPrefabForImage(string imageName)
    {
        foreach (var item in trackedImagePrefabs)
        {
            if (item.imageName == imageName)
            {
                return item.prefab;
            }
        }
        // Tidak ditemukan prefab yang cocok
        Debug.LogWarning($"Tidak ada prefab yang diatur untuk gambar: {imageName}");
        return null;
    }
}