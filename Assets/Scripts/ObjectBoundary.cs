using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBoundary : MonoBehaviour
{
    private float floorHeight = 0f;  // Zemin yüksekliği
    private float boundaryLimitX;
    private float boundaryLimitY;

    void Start()
    {
        // WebGL veya telefon ekranına göre sınırları dinamik ayarla
        boundaryLimitX = Camera.main.orthographicSize * Screen.width / Screen.height;
        boundaryLimitY = Camera.main.orthographicSize;
    }

    void Update()
    {
        // Obje zeminle çarparsa, zemine düşmesini sağlar
        if (transform.position.y < floorHeight)
        {
            // Obje zemine çarptıysa, yere sabitle
            transform.position = new Vector3(transform.position.x, floorHeight, transform.position.z);
        }

        // Obje ekranın dışına çıkarsa, sınırları belirleyip geri döndürelim
        if (Mathf.Abs(transform.position.x) > boundaryLimitX || Mathf.Abs(transform.position.z) > boundaryLimitY)
        {
            // Ekranın dışına çıktıysa, objeyi geri sınır içinde tut
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -boundaryLimitX, boundaryLimitX),
                                             transform.position.y,
                                             Mathf.Clamp(transform.position.z, -boundaryLimitY, boundaryLimitY));
        }
    }
}

