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
	
	/*void Awake()
	{
		beatDuration = 60f / bpm * 1000;
		nextBeatPosition = beatDuration;

		activeBeatStartPosition = nextBeatPosition - margin;
		activeBeatEndPosition = nextBeatPosition + margin;
		to be removed

		LevelManager.setupLevel += SetupLevel;
		LevelManager.startLevel += StartMetronome;
		LevelManager.stopLevel += StopMetronome;

		StartCoroutine(UpdateBeat());
		//to be removed	
	}*/

	void OnEnable()
	{
		Debug.Log("Hello metro");
		LevelManager.setupLevel += SetupLevel;
		LevelManager.startLevel += StartMetronome;
		LevelManager.stopLevel += StopMetronome;
	}

	void OnDisable()
	{
		LevelManager.setupLevel -= SetupLevel;
		LevelManager.startLevel -= StartMetronome;
		LevelManager.stopLevel -= StopMetronome;
	}

	void SetupLevel(SongData song)
	{
		beatDuration = 60f / song.bpm * 1000;
		nextBeatPosition = beatDuration;

		activeBeatStartPosition = nextBeatPosition - margin;
		activeBeatEndPosition = nextBeatPosition + margin;
	}//to be called when the level starts

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
			float position = MusicPlayer.instance.audioSource.time * 1000; 

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
