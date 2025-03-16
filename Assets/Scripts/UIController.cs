using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIController : MonoBehaviour
{
    public static UIController instance;
    
    public GameObject deathScreen;
    public GameObject victoryScreen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        deathScreen.SetActive(false);
        victoryScreen.SetActive(false);
    }
    public void OpenDeathScreen()
    {
        deathScreen.SetActive(true);
    }
    public void OpenVictoryScreen()
    {
        victoryScreen.SetActive(true);
    }
    public void ReturnToTitle()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main");
    }
    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("navigationTestScene");
    }
}
