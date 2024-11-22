using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private Vector3 offset;
    private float zCoord;

    private void OnMouseDown()
    {
        // Mouse tıklandığında nesnenin dünya koordinatındaki Z değeri alınır
        zCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        // Mouse tıklanarak nesnenin başlangıç noktasındaki fark hesaplanır
        offset = gameObject.transform.position - GetMouseWorldPos();
    }

    private void OnMouseDrag()
    {
        // Fareyi hareket ettikçe nesneyi taşı
        transform.position = GetMouseWorldPos() + offset;
    }

    private Vector3 GetMouseWorldPos()
    {
        // Fareyi dünya koordinatlarına dönüştür
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}

