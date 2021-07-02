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
        SceneManager.LoadScene("StartScene");
    }
    private void Update()
    {
        time += Time.deltaTime;
        ScoreBox.text = ""+ time.ToString();
    }

}
