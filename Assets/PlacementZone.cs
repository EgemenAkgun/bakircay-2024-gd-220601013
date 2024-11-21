using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlacementZone : MonoBehaviour
{
    private GameObject currentObject = null; // Yerleştirme alanındaki mevcut nesne
    public Transform placementPoint; // Yerleştirme alanının merkezi
    public float repelForce = 5f; // Savuşturma kuvveti

    private void OnTriggerEnter(Collider other)
    {
        // Sadece "Placeable" tag'ine sahip nesneleri kontrol et
        if (other.CompareTag("Placeable"))
        {
            // Eğer alan doluysa yeni nesneyi savuştur
            if (currentObject != null && currentObject != other.gameObject)
            {
                RepelObject(other.gameObject);
                Debug.Log("Yerleştirme alanı dolu! Yeni nesne kabul edilmedi.");
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // Eğer yerleştirme alanı boşsa ve fare bırakma işlemi gerçekleşirse
        if (Input.GetMouseButtonUp(0) && other.CompareTag("Placeable") && currentObject == null)
        {
            PlaceObject(other.gameObject);
        }
    }

    private void PlaceObject(GameObject obj)
    {
        Debug.Log($"Nesne yerleştirildi: {obj.name}");
        currentObject = obj;

        // Nesneyi yerleştirme noktasına taşı
        obj.transform.position = placementPoint.position;

        // Fizik motorunu devre dışı bırak (varsa Rigidbody'yi isKinematic yap)
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }
    }

    private void RepelObject(GameObject obj)
    {
        Debug.Log($"Nesne savuşturuluyor: {obj.name}");

        // Savuşturma işlemi için Rigidbody kontrolü
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Yerleştirme alanından uzağa bir kuvvet uygula
            Vector3 repelDirection = (obj.transform.position - placementPoint.position).normalized;
            rb.AddForce(repelDirection * repelForce, ForceMode.Impulse);
        }
    }

    private void Update()
    {
        // Fare ile mevcut nesneyi kaldırma
        if (Input.GetMouseButton(0) && currentObject != null)
        {
            // Fare tıklamasıyla nesneyi "currentObject" referansından ayır
            RemoveCurrentObject();
        }
    }

    private void RemoveCurrentObject()
    {
        Debug.Log($"Kullanıcı nesneyi alıyor: {currentObject.name}");

        // Fizik motorunu tekrar aktif hale getir
        Rigidbody rb = currentObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false;
        }

        // PlacementZone'u boşalt
        currentObject = null;
    }
}

