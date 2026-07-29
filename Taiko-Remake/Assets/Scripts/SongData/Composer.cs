using UnityEngine;
using System.Collections.Generic;

public class Composer : MonoBehaviour
{
	[SerializeField]	SongData song;
	[SerializeField]	Metronome metronome;

	void OnEnable()
	{
		LevelManager.setupLevel += SetSong;
		InputManager.beatPressed += GetInput;
		metronome = FindFirstObjectByType<Metronome>();
	}

	void SetSong(SongData songData)
	{
		song = songData;
		songData.beatChart = new List<Beat>(100);
	}

	void GetInput(int type)
	{
		float beatPosition = metronome.activeBeatStartPosition;
		song.beatChart.Add(new Beat(type, beatPosition));
	}
}
