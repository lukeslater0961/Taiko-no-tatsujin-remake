using UnityEngine;

public class GameStateManager : MonoBehaviour
{
	public static GameStateManager instance;

	public static MenuState menuState = new MenuState();
	public static LevelState levelState = new LevelState();
	public static SongSelectState songSelectState = new SongSelectState();

	private BaseState currentState = null;

	void Awake()
	{
		instance = this;
		DontDestroyOnLoad(gameObject);
	}

	public void SwitchState(BaseState state)
	{
		if (currentState != null)
			currentState.OnExit(this);
		currentState = state;
		currentState.OnEnter(this);
	}
}
