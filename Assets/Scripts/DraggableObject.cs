using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    private Vector3 offset;
    public Vector3 startPosition; // Objeyi geri döndürmek için başlangıç pozisyonu
    public ObjectID objectID; // Objenin kimlik bilgisi

    private void Start()
    {
        // Başlangıç pozisyonunu kaydet
        startPosition = transform.position;

        // ObjectID bileşenini al
        objectID = GetComponent<ObjectID>();
        if (objectID == null)
        {
            Debug.LogError("ObjectID bileşeni eksik! Obje: " + gameObject.name);
        }
    }

    private void OnMouseDown()
    {
        // Fare ile objeyi sürükleme için ofseti hesapla
        offset = transform.position - GetMouseWorldPosition();
    }

    private void OnMouseDrag()
    {
        // Objeyi fare imlecine göre hareket ettir
        transform.position = GetMouseWorldPosition() + offset;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPosition);
    }

    private void OnMouseUp()
    {
        // Fare bırakıldığında işlemler
        Debug.Log($"Obje bırakıldı: {objectID.id}, Şekil: {objectID.shape}");
    }
}


