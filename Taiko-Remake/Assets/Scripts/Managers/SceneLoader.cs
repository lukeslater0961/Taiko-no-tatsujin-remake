using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	public static SceneLoader instance;

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
	
	public void LoadScene(int sceneIndex, BaseState state)
	{
		if (sceneIndex < 0 || sceneIndex > SceneManager.sceneCount + 1)
			return;
		StartCoroutine(SceneLoad(sceneIndex, state));
	}

	IEnumerator SceneLoad(int scene, BaseState state)
	{
		AsyncOperation op = SceneManager.LoadSceneAsync(scene);

		while (!op.isDone)
		{
			yield return null;
		}
        GameStateManager.instance.SwitchState(state);
	}
}
