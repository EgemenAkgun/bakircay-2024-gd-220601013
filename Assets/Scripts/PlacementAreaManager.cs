using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementAreaManager : MonoBehaviour
{
    public Transform placementPoint; // Placement alanının merkezi
    private GameObject currentObject; // Placement alanındaki mevcut nesne

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Placeable"))
        {
            if (currentObject == null)
            {
                PlaceObject(other.gameObject);
            }
            else
            {
                RejectObject(other.gameObject);
            }
        }
    }

    private void PlaceObject(GameObject obj)
    {
        currentObject = obj;
        currentObject.transform.position = placementPoint.position;
        currentObject.transform.rotation = placementPoint.rotation;

        // Rigidbody ayarlarını değiştir
        Rigidbody rb = currentObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true; // Yer çekiminden etkilenmesini durdur
        }
    }

    private void RejectObject(GameObject obj)
    {
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false; // Yer çekimini etkinleştir
            rb.AddForce(Vector3.up * 5 + Vector3.back * 5, ForceMode.Impulse); // Kuvvet uygula
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (currentObject != null && other.gameObject == currentObject)
        {
            currentObject = null;
        }
    }
}


