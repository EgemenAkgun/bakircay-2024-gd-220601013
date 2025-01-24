using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] objectPrefabs; // Eklenecek objelerin prefab'leri
    public Transform spawnArea; // Spawn alanı
    public int objectCount = 12; // Toplam spawn edilecek obje sayısı
    public Camera mainCamera; // Ana kamera

    public float spawnHeight = 5f; // Objelerin spawn yüksekliği

    void Start()
    {
        SpawnObjects();
    }

    void SpawnObjects()
    {
        BoxCollider boxCollider = spawnArea.GetComponent<BoxCollider>();

        if (boxCollider == null)
        {
            Debug.LogError("SpawnArea GameObject'ine bir Box Collider eklenmemiş!");
            return;
        }

        Bounds bounds = boxCollider.bounds;

        // Obje çiftlerini spawn edeceğiz
        List<GameObject> spawnedObjects = new List<GameObject>();

        // Her çiftten iki prefab olacak şekilde objeleri spawn et
        for (int i = 0; i < objectPrefabs.Length; i += 2)
        {
            // Sadece X ve Z pozisyonlarını randomlaştırıyoruz, Y pozisyonunu sabit tutuyoruz
            Vector3 randomPosition1 = new Vector3(
                Random.Range(bounds.min.x, bounds.max.x),
                spawnHeight,  // Objeleri yukarıda sabit bir yükseklikte spawn ediyoruz
                Random.Range(bounds.min.z, bounds.max.z)
            );

            Vector3 randomPosition2 = new Vector3(
                Random.Range(bounds.min.x, bounds.max.x),
                spawnHeight,  // Objeleri yukarıda sabit bir yükseklikte spawn ediyoruz
                Random.Range(bounds.min.z, bounds.max.z)
            );

            // Çift objeleri spawn et
            GameObject prefab1 = objectPrefabs[i];
            GameObject prefab2 = objectPrefabs[i + 1];

            if (!spawnedObjects.Contains(prefab1))
            {
                GameObject spawnedObj1 = Instantiate(prefab1, randomPosition1, Quaternion.identity);
                spawnedObjects.Add(spawnedObj1);
            }

            if (!spawnedObjects.Contains(prefab2))
            {
                GameObject spawnedObj2 = Instantiate(prefab2, randomPosition2, Quaternion.identity);
                spawnedObjects.Add(spawnedObj2);
            }
        }
    }
}
