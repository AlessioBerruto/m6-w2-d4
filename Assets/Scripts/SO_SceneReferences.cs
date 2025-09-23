using UnityEngine;

[CreateAssetMenu(fileName = "SO_SceneReferences", menuName = "Game/Scene References")]
public class SO_SceneReferences : ScriptableObject
{
    [Header("Scene Names")]
    public string mainMenuScene = "MainMenuScene";
    public string gameScene = "GameScene";   
}
