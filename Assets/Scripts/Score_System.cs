using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_System : MonoBehaviour
{
    public int Score = 0;
    public Text ScoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().isGameOver)
        {
            if(PlayerPrefs.GetInt("High Score") < Score)
            {
                PlayerPrefs.SetInt("High Score", Score);
                Debug.Log("New High Score :"+ Score);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Saver"))
        {
            Score++;
            ScoreText.text = " Score : " + Score;
            Destroy(collision.gameObject);
            Debug.Log("Score");   
        }
    }
}
