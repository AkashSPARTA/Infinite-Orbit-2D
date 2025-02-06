using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Text HighScoreText;
    // Start is called before the first frame update
    void Start()
    {
        HighScoreText.text = "High Score : " + PlayerPrefs.GetInt("High Score");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButtonScene()
    {
        SceneManager.LoadScene("Assets/Scenes/GameScene.unity");
    }

    public void QuitButtonScene()
    {
        Application.Quit();
    }
}
