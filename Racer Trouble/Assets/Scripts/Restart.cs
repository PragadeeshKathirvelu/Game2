using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public Text scoretext;
    public Text highscoretext;
    float score;
    float highscore;
    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetFloat("Score");
        highscore = PlayerPrefs.GetFloat("Highscore");
        scoretext.text = "Score: " + score.ToString();
        highscoretext.text = "Highscore: " + highscore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void Mainmenugame()
    {
        SceneManager.LoadScene(2);
    }
}
