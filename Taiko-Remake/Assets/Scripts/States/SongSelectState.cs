using UnityEngine;

public class SongSelectState : BaseState
{
	public override void OnEnter(GameStateManager manager)
	{
		Debug.Log("entered SongSelect state");
	}

	public override void OnExit(GameStateManager manager)
	{
		Debug.Log("exited SongSelect state");
	}
}
