using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UI : MonoBehaviour
{
    public Text ScoreBox;
    private float time = 0;
    
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void EndGame()
    {
        Application.Quit();
    }
    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("StartScene");
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().name != "StartScene" && Time.timeScale != 0)
        {
            time += Time.deltaTime;
            ScoreBox.text = string.Format("{0:0.0}",time);
        }

    }

}
