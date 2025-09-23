using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    public static UI_Manager Instance { get; private set; }

    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject playerHUD;

    [Header("Scene References")]
    [SerializeField] private SO_SceneReferences sceneRefs; 

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        HideAllPanels();
    }

    private void HideAllPanels()
    {
        if (winPanel != null) winPanel.SetActive(false);
        if (losePanel != null) losePanel.SetActive(false);
        if (playerHUD != null) playerHUD.SetActive(true);
    }

    public void UpdateCoinText(int currentCoins)
    {
        int totalCoins = GameManager.Instance.TotalCoinsToWin;
        coinText.text = $"Coins: {currentCoins}/{totalCoins}";
    }

    public void UpdateTimer(float timeRemaining)
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60f);
        int seconds = Mathf.FloorToInt(timeRemaining % 60f);
        timerText.text = $"Time: {minutes:00}:{seconds:00}";
    }

    public void ShowWinScreen()
    {
        playerHUD?.SetActive(false);
        winPanel?.SetActive(true);
        PauseGame();
    }

    public void ShowLoseScreen()
    {
        playerHUD?.SetActive(false);
        losePanel?.SetActive(true);
        PauseGame();
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene(sceneRefs.mainMenuScene);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene(sceneRefs.gameScene);
    }

    private void PauseGame()
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
