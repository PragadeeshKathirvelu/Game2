using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //Touch touch;
    public float speed;
    public Text scoretext;
    public float score;
    public float speeder;
    public Text gameovertext;
    public bool isGameover;
    //public float speedmodifier;
    // Start is called before the first frame update

    private void Awake()
    {
        isGameover = false;
        score = 0;
        if(PlayerPrefs.GetFloat("Highscore")==0)
        {
            PlayerPrefs.SetFloat("Highscore", 0);
        }
        PlayerPrefs.SetFloat("Score", score);
    }
    void Start()
    {
        //score = 0;
        speeder = 4f;
        gameovertext.enabled = false;
        //speedmodifier = 0.01f;
        //GetComponent<Rigidbody>().velocity = new Vector3(0, 0, speed);
    }

    // Update is called once per frame
    void Update()
    {
        if(speeder>0)
        {
            speeder -= Time.deltaTime;
        }
        if(speeder<0)
        {
            speed++;
            speeder = 4f;
        }
        if(isGameover==false)
        {
            score++;
        }
        scoretext.text = "Score: "+score.ToString();
        if (Input.GetKey(KeyCode.LeftArrow) && (transform.position.x > -4f)) //input left button and restrict from moving out of platform
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime); // move left
        }
        if(Input.GetKey(KeyCode.RightArrow) && transform.position.x < 4f) //input right button and restrict from moving out of platform
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime); // move right
        }

        // touch sensitive
        /*if(Input.touchCount>0) // touchcount
        {
            touch = Input.GetTouch(0); // gets the touchcount and stores in touch
            transform.Translate(touch.deltaPosition.x * speedmodifier, 0, 0); // moves along x axis based on which side(left/right) we are touching
        }

        //while touching the x position should not go out of the platform
        else if (transform.position.x > 3.5f)
        {
            transform.position = new Vector3(3.49f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -3.5f)
        {
            transform.position = new Vector3(-3.49f, transform.position.y, transform.position.z);
        }*/
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Enemy")
        {
            isGameover = true;
            StartCoroutine(Wait());
            gameovertext.enabled = true;
            GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponentInChildren<TrailRenderer>().enabled = false;
            if(PlayerPrefs.GetFloat("Highscore")<score)
            {
                PlayerPrefs.SetFloat("Highscore", score);
                PlayerPrefs.SetFloat("Score", score);
            }
            else
            {
                PlayerPrefs.SetFloat("Score", score);
            }
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(1);
        Debug.Log("high score is" + PlayerPrefs.GetFloat("Highscore"));
        Debug.Log("score is" + PlayerPrefs.GetFloat("Score"));
    }
}
