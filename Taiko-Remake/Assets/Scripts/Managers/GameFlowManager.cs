using UnityEngine;

public class GameFlowManager : MonoBehaviour
{
	void Start()
	{
		GoToMenu();
		DontDestroyOnLoad(gameObject);
	}

    public void GoToMenu()
    {
        GameStateManager..instance.SwitchState(GameStateManager.menuState);
    }

    public void GoToSelection()
    {
        GameStateManager.instance.SwitchState(GameStateManager.songSelectState);
    }

    public void GoToLevel()
    {
        GameStateManager..instance.SwitchState(GameStateManager.levelState);
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
