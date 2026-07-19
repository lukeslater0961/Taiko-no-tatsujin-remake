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
	
	void Start()
	{
		/*
		beatDuration = 60f / bpm * 1000;
		nextBeatPosition = beatDuration;

		activeBeatStartPosition = nextBeatPosition - margin;
		activeBeatEndPosition = nextBeatPosition + margin;
		to be removed*/

		LevelManager.setupLevel += SetupLevel;
		LevelManager.startLevel += StartMetronome;
		LevelManager.stopLevel += StopMetronome;

		//StartCoroutine(UpdateBeat());
		//to be removed	
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
		StartCoroutine(UpdateBeat());
	}

	public void StopMetronome()
	{
		StopCoroutine(UpdateBeat());
	}

	IEnumerator UpdateBeat()
	{
		while (true)
		{
		//	float position = Time.time * 1000; 
			float position = MusicPlayer.instance.audioSource.time; 
			//get position in song in ms using AudioSource.time from music player

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
