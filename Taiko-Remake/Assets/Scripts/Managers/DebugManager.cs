using UnityEngine;

public class DebugManager : MonoBehaviour
{
	[SerializeField] bool isActive = false;

    void Awake()
    {
		InputManager.confirmPressed += PrintConfirm;
		InputManager.beatPressed += PrintDebug;
		DontDestroyOnLoad(gameObject);
	}

	void PrintConfirm()
	{
		if (isActive)
			Debug.Log("confirm pressed");
	}

	void PrintDebug(int type)
	{
		if (!isActive)
			return;
		switch (type){
			case 0:
				Debug.Log("beat 1 pressed");
				return;
			case 1:
				Debug.Log("beat 2 pressed");
				return;
			default:
				return;
		}
	}
}
