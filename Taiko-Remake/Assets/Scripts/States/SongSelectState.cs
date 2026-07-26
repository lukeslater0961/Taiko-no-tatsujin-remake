using UnityEngine;

public class SongSelectState : BaseState
{
	public override void OnEnter(GameStateManager manager)
	{
		Debug.Log("entered SongSelect state");
		UiManager.instance.ResetUi();
	}

	public override void HandleEscape()
	{
		Debug.Log("Going back to main menu from select");
		SceneLoader.instance.LoadScene(0, null);
	}

	public override void OnExit(GameStateManager manager)
	{
		Debug.Log("exited SongSelect state");
	}
}
