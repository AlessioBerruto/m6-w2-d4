using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenu, winPanel, losePanel, playerPanel;

    public void StartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameScene");
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        playerPanel.SetActive(true);        
        
        
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Win()
    {
        playerPanel.SetActive(false);
        winPanel.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Lose()
    {
        playerPanel.SetActive(false);
        losePanel.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ReturnToMenu()
    {        
        SceneManager.LoadScene("MainMenuScene");
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
