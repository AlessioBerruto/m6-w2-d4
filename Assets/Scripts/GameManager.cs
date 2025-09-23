using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private int coinsToWin = 10;
    [SerializeField] private UnityEvent onWin;
    [SerializeField] private GameObject winPoint;

    private int collectedCoins = 0;
    public int TotalCoinsToWin => coinsToWin;


    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        if (winPoint != null)
            winPoint.SetActive(false); 
    }

    public void AddCoins(int amount)
    {
        collectedCoins += amount;
        UI_Manager.Instance.UpdateCoinText(collectedCoins);

        if (collectedCoins >= coinsToWin && winPoint != null)
        {
            winPoint.SetActive(true); 
        }
    }

    public void TriggerWin()
    {
        onWin.Invoke(); 
    }
}
