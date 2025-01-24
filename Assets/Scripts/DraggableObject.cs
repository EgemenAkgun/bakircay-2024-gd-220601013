using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DraggableObject : MonoBehaviour
{
    private Vector3 offset;
    private float zCoord;
    private bool isDragging = false;

    void OnMouseDown()
    {
        // Objeye tıklandığında, fare imleci ile olan mesafeyi hesapla
        zCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        offset = gameObject.transform.position - GetMouseWorldPos();
        isDragging = true;
    }

    void OnMouseUp()
    {
        // Fare bırakıldığında, objenin yerini sabitle
        isDragging = false;
    }

    void Update()
    {
        if (isDragging)
        {
            // Objeyi fare imlecine doğru hareket ettir
            Vector3 mousePosition = GetMouseWorldPos() + offset;
            transform.position = mousePosition;
        }
    }

    // Fare konumunu dünyada (world) almak için bir yardımcı fonksiyon
    Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zCoord; // Kamera ile objenin arasındaki mesafeyi tut
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}

