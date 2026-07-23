using UnityEngine;

public class GameFlowManager : MonoBehaviour
{
	void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}

	void Start()
	{
		QualitySettings.vSyncCount = 1;
        GameStateManager.instance.SwitchState(GameStateManager.menuState);
	}

    public void GoToMenu()
    {
		SceneLoader.instance.LoadScene(0, GameStateManager.menuState);
    }

    public void GoToSelection()
    {
		SceneLoader.instance.LoadScene(1, GameStateManager.songSelectState);
    }

    public void GoToLevel()
    {
		SceneLoader.instance.LoadScene(2, GameStateManager.levelState);
    }

    public void QuitGame()
    {
		#if UNITY_EDITOR
            UnityEditor.EditorApplication.ExitPlaymode();
		#else
			Application.Quit();
		#endif	
	}
}
