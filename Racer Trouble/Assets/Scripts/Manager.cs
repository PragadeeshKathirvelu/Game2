using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public Text hightext;
    float highscore;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetFloat("Highscore") == 0)
        {
            PlayerPrefs.SetFloat("Highscore", 0);
            highscore = PlayerPrefs.GetFloat("Highscore");
            hightext.text = "Highscore: " + highscore.ToString();
        }
        else
        {
            //PlayerPrefs.GetFloat("Highscore");
            highscore = PlayerPrefs.GetFloat("Highscore");
            hightext.text = "Highscore: " + highscore.ToString();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Startgame()
    {
        SceneManager.LoadScene(0);
    }
}
