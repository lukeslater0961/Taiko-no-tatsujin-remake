using UnityEngine;

public class MenuState : BaseState
{
	public override void OnEnter(GameStateManager manager)
	{
		Debug.Log("entered menu state");
	}

	public override void OnExit(GameStateManager manager)
	{
		Debug.Log("exited menu state");
	}
}
