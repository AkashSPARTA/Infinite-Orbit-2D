using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float runSpeed;
    public bool isGameOver = false;
    public Animator anim;
    public GameObject Fire1, Fire2;
    public Text FinalHighScore, HighScore;
    public int maxHeart= 3;
    public int currentHearts;
    public Text HeartCount;
    public GameObject GameOverImage, HeartImage, ScoreImage, PauseButton;
    public AudioSource BGAudio;
    
    // Start is called before the first frame update
    void Start()
    {
        BGAudio.Play();
        currentHearts = maxHeart;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine("IncreaseGameSpeed");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            transform.position = Vector3.right * runSpeed * Time.deltaTime + transform.position;
        }

    }

    public void PlayerUp()
    {
        transform.position = Vector3.up * runSpeed * Time.deltaTime + transform.position;
    }

    public void PlayerDown()
    {
        transform.position = Vector3.down * runSpeed * Time.deltaTime + transform.position;
    }
    public void Loseheart()
    {
        if (currentHearts > 0)
        {
            currentHearts--;
            HeartCount.text = " = " + currentHearts;
            if (currentHearts <= 0)
            {
                GameOver();
            }
        }

    }
    public void GameOver()
    {
        isGameOver = true;
        Fire1.SetActive(false);
        Fire2.SetActive(false);
        anim.SetTrigger("PlayerBlast");
        BGAudio.Stop();
        StartCoroutine("ShowGameOverPanel");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            Loseheart();
            Debug.Log("GameOver");
        }
    }

    
    IEnumerator IncreaseGameSpeed()
    {
        while(true)
        {
            yield return new WaitForSeconds(10);
            if(runSpeed < 10)
            {
                runSpeed += 0.2f;
            }
            
        }
    }

    IEnumerator ShowGameOverPanel()
    {
        yield return new WaitForSeconds(2);
        GameOverImage.SetActive(true);
        HeartImage.SetActive(false);
        ScoreImage.SetActive(false);
        PauseButton.SetActive(false);

        FinalHighScore.text = "Score : " + GameObject.Find("Player").GetComponent<Score_System>().Score;
        HighScore.text = "High Score : " + PlayerPrefs.GetInt("High Score");
        
    }


}
