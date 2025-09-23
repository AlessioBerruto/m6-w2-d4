using UnityEngine;
using UnityEngine.Events;

public class LevelTimer : MonoBehaviour
{
    [SerializeField] private float timeLimit = 180f;
    [SerializeField] private UnityEvent onTimeUp;

    private float timer;

    void Start() => timer = timeLimit;

    void Update()
    {
        timer -= Time.deltaTime;
        UI_Manager.Instance.UpdateTimer(timer);

        if (timer <= 0f)
        {
            onTimeUp.Invoke();
            enabled = false;
        }
    }
}
