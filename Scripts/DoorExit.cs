using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorExit : MonoBehaviour
{
    [Tooltip("D�� sahnedeki karakterin do�aca�� noktan�n koordinatlar�")]
    public Vector3 outsideSpawnPosition;

    [Tooltip("D�� sahnedeki karakterin ba�lang�� rotasyonu")]
    public Vector3 outsideSpawnRotationEuler;

    // Kap�dan karakter ge�erse
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // SpawnManager singleton'�ndan spawn pozisyonunu ayarla
            if (SpawnManager.Instance != null)
            {
                // Quaternion.Euler ile Euler a��lar�n� rotasyona �eviriyoruz
                Quaternion spawnRot = Quaternion.Euler(outsideSpawnRotationEuler);
                SpawnManager.Instance.SetSpawnPosition(outsideSpawnPosition, spawnRot);
            }
            else
            {
                Debug.LogError("SpawnManager bulunamad�!");
            }

            // Yeni sahneye ge�i� (d�� mekan sahnenizin ad�n� yaz�n)
            SceneManager.LoadScene("DisMekanSahneAdi");
        }
    }
}

