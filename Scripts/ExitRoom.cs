
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ExitRoom : MonoBehaviour
{
    public GameObject exitPromptText;  // "D��ar� ��kmak i�in E tu�una bas" yaz�s�

    private bool nearExit = false;      // Kap�ya yakla�t� m�?
    private bool canShowPrompt = false; // Yaz� g�sterilebilir mi?
    private float enterRoomTime;        // Odaya giri� zaman�

    void Start()
    {
        exitPromptText.SetActive(false);  // Ba�lang��ta yaz� kapal�
        enterRoomTime = Time.time;         // Sahne ba�lama zaman�
        StartCoroutine(EnablePromptAfterDelay(5f));  // 5 saniye sonra yaz� a��labilir
    }

    IEnumerator EnablePromptAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        canShowPrompt = true;

        // E�er kap�daysa ve 5 sn ge�tiyse yaz�y� g�ster
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
            // �nceki sahneye ge�i�
            // �rne�in build settings'deki �nceki sahne indexini kullanabilirsin
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int previousSceneIndex = Mathf.Max(currentSceneIndex - 1, 0);
            SceneManager.LoadScene(previousSceneIndex);
        }
    }
}
