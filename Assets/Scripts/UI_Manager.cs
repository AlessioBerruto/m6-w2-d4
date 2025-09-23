using UnityEngine;
using UnityEngine.UI;
using TMPro; 


public class UI_Manager : MonoBehaviour
{
    public static UI_Manager Instance;

    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private TextMeshProUGUI timerText;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
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
}
