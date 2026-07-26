using UnityEngine;

public class LevelState : BaseState
{
	public override void OnEnter(GameStateManager manager)
	{
		Debug.Log("entered Level state");
		LevelManager.instance.StartLevel();
	}

	public override void HandleEscape()
	{
		Debug.Log("Toggling pause menu in level state");
		UiManager.instance.TogglePauseMenu();
		LevelManager.instance.PauseLevel();
	}

	public override void OnExit(GameStateManager manager)
	{
		Debug.Log("exited Level state");
		LevelManager.instance.StopLevel();
	}
}
