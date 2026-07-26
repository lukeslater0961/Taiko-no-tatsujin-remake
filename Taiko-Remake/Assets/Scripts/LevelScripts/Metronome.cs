using UnityEngine;
using System.Collections;

public class Metronome : MonoBehaviour
{
	[SerializeField] float bpm = 120;
	[SerializeField] float beatDuration;
	[SerializeField] float margin = 80;

	[SerializeField] float lastBeat;
	public float activeBeat { get; private set; } = -1f;
	[SerializeField] float activeBeatStartPosition;
	[SerializeField] float activeBeatEndPosition;
	[SerializeField] float nextBeatPosition;
	
	void OnEnable()
	{
		LevelManager.setupLevel += SetupLevel;
		LevelManager.startLevel += StartMetronome;
		LevelManager.pauseLevel += StopMetronome;
		LevelManager.stopLevel += StopMetronome;
	}

	void OnDisable()
	{
		LevelManager.setupLevel -= SetupLevel;
		LevelManager.startLevel -= StartMetronome;
		LevelManager.pauseLevel -= StopMetronome;
		LevelManager.stopLevel -= StopMetronome;
	}

	void SetupLevel(SongData song)
	{
		bpm = song.bpm;
		beatDuration = 60f / song.bpm * 1000;
		nextBeatPosition = beatDuration;

		activeBeatStartPosition = nextBeatPosition - margin;
		activeBeatEndPosition = nextBeatPosition + margin;
	}

	public void StartMetronome()
	{
		Debug.Log("Hello metro start--");
		StartCoroutine(UpdateBeat());
	}

	public void StopMetronome()
	{
		Debug.Log("Hello metro stop--");
		StopCoroutine(UpdateBeat());
	}

	IEnumerator UpdateBeat()
	{
		while (true)
		{
			float position = MusicPlayer.instance.CurrentTime * 1000; 

			if (position >= activeBeatStartPosition)
			{
				lastBeat  = (lastBeat + 1) % 4;
				activeBeat = lastBeat;
				nextBeatPosition += beatDuration;
				activeBeatStartPosition = nextBeatPosition - margin;
			}

			if (position >= activeBeatEndPosition)
			{
				activeBeat = -1;
				activeBeatEndPosition = nextBeatPosition + margin;
			}
			yield return null;
		}
	}
}
