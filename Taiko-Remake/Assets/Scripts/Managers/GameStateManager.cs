using UnityEngine;

public class GameStateManager : MonoBehaviour
{
	public static MenuState menuState = new MenuState();
	public static LevelState levelState = new LevelState();

	private BaseState currentState = null;

	void Start()
	{
		SwitchState();
	}

	public void SwitchState()
	{
		if (currentState != null)
			currentState.OnExit(this);
		if (currentState == menuState)
			currentState = levelState;
		else
			currentState = menuState;
		currentState.OnEnter(this);
	}
}
