
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ExitRoom : MonoBehaviour
{
    public GameObject exitPromptText;  // dışarı çıkmak için e tusuna basın yazısı.

    private bool nearExit = false;      // Kapiya yaklaştı mı?
    private bool canShowPrompt = false; // Yazi gösterilebilir mi?
    private float enterRoomTime;        // Odaya giris zamani

    void Start()
    {
        exitPromptText.SetActive(false);  // baslangicta yazi kapalı olsun
        enterRoomTime = Time.time;         // Sahne baslama zamani
        StartCoroutine(EnablePromptAfterDelay(5f));  // 5 saniye sonra yazi acilabilir
    }

    IEnumerator EnablePromptAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        canShowPrompt = true;

        // Eðer kapýdaysa ve 5 sn geçtiyse yazýyý göster
        if (nearExit)
            exitPromptText.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ExitDoor"))
        {
            nearExit = true;
            if (canShowPrompt)
            {
                exitPromptText.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ExitDoor"))
        {
            nearExit = false;
            exitPromptText.SetActive(false);
        }
    }

    void Update()
    {
        if (nearExit && canShowPrompt && Input.GetKeyDown(KeyCode.E))
        {
            // Önceki sahneye gecis
            
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int previousSceneIndex = Mathf.Max(currentSceneIndex - 1, 0);
            SceneManager.LoadScene(previousSceneIndex);
        }
    }
}
