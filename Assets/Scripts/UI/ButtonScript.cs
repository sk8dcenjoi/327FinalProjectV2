using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public AudioClip buttonPress;
    public void GotoMenuScene()
    {
        AudioSource.PlayClipAtPoint(buttonPress, this.transform.position);
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitButton()
    {
        AudioSource.PlayClipAtPoint(buttonPress, this.transform.position);
        Application.Quit();
    }

    public void FirstPersonStart()
    {
        AudioSource.PlayClipAtPoint(buttonPress, this.transform.position);
        SceneManager.LoadScene("FPSMap1");
    }
    public void ThirdPersonStart()
    {
        AudioSource.PlayClipAtPoint(buttonPress, this.transform.position);
        SceneManager.LoadScene("TPSMap1");

    }

}
