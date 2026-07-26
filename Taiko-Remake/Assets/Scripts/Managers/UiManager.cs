using UnityEngine;

public class UiManager : MonoBehaviour
{
	public static UiManager instance;

	[SerializeField] 
	private Canvas _pauseMenu;

    void Awake()
    {
        if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
			Destroy(gameObject);
    }
	
	public void ResetUi()
	{
		_pauseMenu.gameObject.SetActive(false);
	}
	
	public void TogglePauseMenu()
	{
		_pauseMenu.gameObject.SetActive(!_pauseMenu.gameObject.activeSelf);
	}
}
