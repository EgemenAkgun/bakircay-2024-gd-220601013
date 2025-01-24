using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject cubePrefab; // Küp prefab'ı
    public GameObject spherePrefab; // Sphere prefab'ı
    public int pairsCount = 6; // Eşleştirilecek çift sayısı
    public Vector3 spawnArea = new Vector3(10, 0, 10); // Spawn edilecek alan
    public float objectScaleFactor = 0.5f; // Objelerin boyutlarını küçültme faktörü
    public Color[] pairColors; // Her çift için renkler

    private List<GameObject> spawnedObjects = new List<GameObject>();

    void Start()
    {
        if (pairColors.Length != pairsCount)
        {
            Debug.LogError("pairColors dizisinin boyutu " + pairsCount + " olmalı.");
            return;
        }

        SpawnAllObjects();
    }

    void SpawnAllObjects()
    {
        for (int i = 0; i < pairsCount; i++)
        {
            // Aynı renk ve şekilden 2 obje oluştur
            SpawnObject(cubePrefab, pairColors[i], i, "Cube");
            SpawnObject(cubePrefab, pairColors[i], i, "Cube");

            SpawnObject(spherePrefab, pairColors[i], i, "Sphere");
            SpawnObject(spherePrefab, pairColors[i], i, "Sphere");
        }
    }

    void SpawnObject(GameObject objPrefab, Color objColor, int id, string shape)
    {
        // Rastgele pozisyon belirle
        float xPos = Random.Range(-spawnArea.x / 2, spawnArea.x / 2);
        float zPos = Random.Range(-spawnArea.z / 2, spawnArea.z / 2);
        float yPos = 1f;

        Vector3 randomPosition = new Vector3(xPos, yPos, zPos);

        // Obje oluştur
        GameObject spawnedObject = Instantiate(objPrefab, randomPosition, Quaternion.identity);

        // Objeyi boyutlandır
        spawnedObject.transform.localScale = new Vector3(objectScaleFactor, objectScaleFactor, objectScaleFactor);

        // Objeye renk atama
        Renderer objRenderer = spawnedObject.GetComponent<Renderer>();
        if (objRenderer != null)
        {
            objRenderer.material.color = objColor;
        }

        // Objeye kimlik atama
        var objectID = spawnedObject.AddComponent<ObjectID>();
        objectID.id = id; // Kimlik numarası
        objectID.shape = shape; // Şekil bilgisi

        // Listeye ekle
        spawnedObjects.Add(spawnedObject);
    }
}

// Objelerin kimliklerini tutacak sınıf
public class ObjectID : MonoBehaviour
{
    public int id; // Benzersiz kimlik
    public string shape; // Şekil bilgisi
}
