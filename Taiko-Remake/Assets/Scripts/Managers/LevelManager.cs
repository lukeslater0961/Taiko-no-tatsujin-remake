using UnityEngine;
using System;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
	public static LevelManager instance;

	public static event Action<SongData> setupLevel;
	public static event Action startLevel;
	public static event Action pauseLevel;
	public static event Action stopLevel;

	[SerializeField]
	private int _score;
	[SerializeField]
	private int _combo;

	[SerializeField]
	private List<SongData> songCollection;

	void Awake()
	{
		instance = this;
		_score = 0;
		_combo = 0;
		InputValidator.beatMissed += ResetCombo;
	}

	void StartLevel()
	{
		setupLevel?.Invoke(songCollection[0]);
		startLevel?.Invoke();
	}

	void ResetCombo()
	{
		_combo = 0;
	}
}
