using UnityEngine;

public class GameStateManager : MonoBehaviour
{


	private BaseState currentState = null;

	public void SwitchState(BaseState state)
	{
		if (currentState != null)
			currentState.OnExit(this);
		currentState = state;
		currentState.OnEnter(this);
	}
}
