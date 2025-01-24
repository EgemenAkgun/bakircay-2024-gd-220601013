using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private float distance;
    private Vector3 offset;
    private Rigidbody rb;

    void Start()
    {
        // Rigidbody'yi al
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;  // Graviteyi devre dışı bırakabiliriz
    }

    void OnMouseDown()
    {
        // Fare ile objeye tıklandığında, mesafeyi hesapla
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        offset = transform.position - GetMouseWorldPos();
    }

    void OnMouseDrag()
    {
        // Pivot noktasını merkeze göre ayarlayarak objeyi hareket ettir
        Vector3 targetPosition = GetMouseWorldPos() + offset;
        transform.position = targetPosition;
    }

    Vector3 GetMouseWorldPos()
    {
        // Fare pozisyonunu 3D dünya koordinatlarına dönüştür
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = distance;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}





