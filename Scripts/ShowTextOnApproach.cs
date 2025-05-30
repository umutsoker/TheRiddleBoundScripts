using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTextOnApproach : MonoBehaviour
{
    public GameObject pressFText;  // UI yaz�s�
    private bool nearBookshelf = false;

    void Start()
    {
        pressFText.SetActive(false);  // Sahne ba��nda yaz� kapal�
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bookshelf"))
        {
            pressFText.SetActive(true);   // Yakla�t���nda yaz�y� g�ster
            nearBookshelf = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Bookshelf"))
        {
            pressFText.SetActive(false);  // Uzakla��nca yaz�y� gizle
            nearBookshelf = false;
        }
    }
}

