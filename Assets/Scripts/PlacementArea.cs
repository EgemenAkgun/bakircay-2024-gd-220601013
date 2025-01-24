using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Placement Area'ya bir obje girdiğinde
        DraggableObject draggable = other.GetComponent<DraggableObject>();

        if (draggable != null)
        {
            Debug.Log($"Obje bırakıldı: {draggable.objectID.id}, Şekil: {draggable.objectID.shape}");

            // Eşleşme kontrolü
            if (IsMatch(draggable))
            {
                Debug.Log("Doğru eşleşme!");
                // Animasyon veya puanlama işlemleri yapılabilir
            }
            else
            {
                Debug.Log("Yanlış eşleşme!");
                // Objeyi geri fırlatma işlemi yapılabilir
                ReturnObject(draggable);
            }
        }
    }

    private bool IsMatch(DraggableObject draggable)
    {
        // Eşleşme kontrolü (örneğin ID ve şekil eşlemesi)
        return draggable.objectID.id == ExpectedID() && draggable.objectID.shape == "Cube"; // Örnek kontrol
    }

    private void ReturnObject(DraggableObject draggable)
    {
        // Objeyi geri fırlatma
        draggable.transform.position = draggable.startPosition; // Objeyi başlangıç pozisyonuna döndür
    }

    private int ExpectedID()
    {
        // Placement Area'nın beklediği ID (örnek olarak)
        return 0;
    }
}
