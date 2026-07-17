using UnityEngine;

public abstract class BaseState
{
	public abstract void OnEnter(GameStateManager manager);
	public abstract void OnExit(GameStateManager manager);
}
