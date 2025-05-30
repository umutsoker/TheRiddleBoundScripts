using UnityEngine;
using UnityEngine.SceneManagement;

public class ToBeContinued : MonoBehaviour
{
    void Start()
    {
        // Fareyi etkinle�tir
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // 5 saniye sonra otomatik olarak ada sahnesine d�n
        Invoke("ReturnToAdaScene", 5f);
    }

    void Update()
    {

        // Herhangi bir tu�a bas�ld���nda hemen ada sahnesine d�n
        if (Input.anyKeyDown)
        {
            ReturnToAdaScene();
        }
    }

    private void ReturnToAdaScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}