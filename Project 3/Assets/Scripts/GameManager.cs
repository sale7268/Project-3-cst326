using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Score UI")]
    public GameObject score;

    [Header("HighScore UI")]
    public GameObject hscore;

    private int currentScore = 0;
    private int highScore = 0;
    public int currentEnemies = 20;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void PlayerScored(int s)
    {
        currentScore += s;
        currentEnemies--;
        if (currentScore < 100)
        {
            score.GetComponent<TMPro.TextMeshProUGUI>().text = "00" + currentScore.ToString();
            score.GetComponent<TMPro.TextMeshProUGUI>().color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        }
        else if (currentScore >= 100 && currentScore < 1000)
        {
            score.GetComponent<TMPro.TextMeshProUGUI>().text = "0" + currentScore.ToString();
            score.GetComponent<TMPro.TextMeshProUGUI>().color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        }
        else if (currentScore >= 1000)
        {
            score.GetComponent<TMPro.TextMeshProUGUI>().text = currentScore.ToString();
            score.GetComponent<TMPro.TextMeshProUGUI>().color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        }
    }

    private void Update()
    {
        if(currentEnemies == 0)
        {
            Debug.Log("You Win");
            if(highScore < currentScore)
            {
                highScore = currentScore;
                if (highScore < 100)
                {
                    hscore.GetComponent<TMPro.TextMeshProUGUI>().text = "00" + highScore.ToString();
                    hscore.GetComponent<TMPro.TextMeshProUGUI>().color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
                }
                else if (highScore >= 100 && currentScore < 1000)
                {
                    hscore.GetComponent<TMPro.TextMeshProUGUI>().text = "0" + highScore.ToString();
                    hscore.GetComponent<TMPro.TextMeshProUGUI>().color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
                }
                else if (highScore >= 1000)
                {
                    hscore.GetComponent<TMPro.TextMeshProUGUI>().text = highScore.ToString();
                    hscore.GetComponent<TMPro.TextMeshProUGUI>().color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
                }
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Invoke("Restart", 5.0f);
        }

    }
    void Restart()
    {
        SceneManager.LoadScene(0);
    }

}
