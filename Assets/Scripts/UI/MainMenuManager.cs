using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private SO_SceneReferences sceneRefs; 
    public void StartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneRefs.gameScene);
    }

    public void ExitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene(sceneRefs.mainMenuScene);
    }
}
