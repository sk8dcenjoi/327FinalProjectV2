using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PandaHP : MonoBehaviour
{
    public int badCoinCount = 0;
    public int coinCount = 0;
    public Slider healthBar;
    public bool Powerup = false;
    public Text countText;
    public AudioClip death;
    public AudioClip power;
    public AudioClip win;
    public AudioClip pickupSound;
    public AudioClip pickupSoundBad;
    public AudioClip pickupSoundSpecial;


    // Use this for initialization
    void Start()
    {
        countText = GetComponent<Text>();
         Powerup = false;
}
    // Update is called once per frame
    void LateUpdate()
    {
        if(healthBar.value == 0)
        {
            countText.text = "Score: " + coinCount;
            Debug.Log("you should die here");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            StartCoroutine(Loser());

        }
    }
    private void OnCollisionEnter(Collision col)
    {



        if (col.gameObject.tag == "badCoin")
        {
            AudioSource.PlayClipAtPoint(pickupSoundBad, this.transform.position);
            badCoinCount++;
            Debug.Log("Bad coins = "+badCoinCount);

            if (Powerup == false)
            {
                healthBar.value -= 20;
            }
            if (Powerup == true)
            {
                healthBar.value += 100;

            }
            Debug.Log(Powerup + "lost hp?");

        }


        if (col.gameObject.tag == "goodCoin")
        {
            AudioSource.PlayClipAtPoint(pickupSound, this.transform.position);
            coinCount++;
            Debug.Log("good coins = " + coinCount);

            if (healthBar.value + 20 > healthBar.maxValue) { 
                healthBar.value = 100;

            }

        else
        {
                healthBar.value += 20;
                Debug.Log("gain hp");


            }
            if (coinCount >= 20)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Debug.Log("you should win here");
                StartCoroutine(Winner());
            }

        }

        if (col.gameObject.tag == "specialCoin")
        {
            AudioSource.PlayClipAtPoint(pickupSoundSpecial, this.transform.position);
            healthBar.value = 100;

            StartCoroutine(PowerUp());
        }
    }

    private IEnumerator PowerUp()
    {
        Powerup = true;
        Debug.Log("timer initiated");
        AudioSource.PlayClipAtPoint(power, this.transform.position);
        yield return new WaitForSeconds(5);
        Debug.Log("timer complete");
        AudioSource.DestroyImmediate(power, true);
        Powerup = false;

    }

    private IEnumerator Winner()
    {
        AudioSource.PlayClipAtPoint(win, this.transform.position);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("GameOver");
    }
    private IEnumerator Loser()
    {
        Debug.Log("dead?");
        AudioSource.PlayClipAtPoint(death, this.transform.position);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("GameOver");
    }
}
