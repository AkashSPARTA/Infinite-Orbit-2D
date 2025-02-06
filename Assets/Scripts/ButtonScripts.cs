using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScripts : MonoBehaviour
{
    private bool isPause = false;
    public GameObject GamePauseImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void TogglePause()
    {
        isPause = !isPause;

        if (isPause )
        {
            Time.timeScale = 0;
            GamePauseImage.SetActive( true );
        }

    }

    public void ToggleResume()
    {
        isPause = !isPause;
        if (!isPause)
        {
            Time.timeScale = 1;
            GamePauseImage.SetActive( false );
        }
        else
        {
            Time.timeScale = 0;
        }
    }

    public void MainMenuButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Assets/Scenes/MainMenuScene.unity");
    }

    public void RestartButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Assets/Scenes/GameScene.unity");
    }
}
