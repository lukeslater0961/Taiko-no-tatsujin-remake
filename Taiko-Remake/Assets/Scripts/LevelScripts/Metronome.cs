using UnityEngine;
using System.Collections;

public class Metronome : MonoBehaviour
{
	[SerializeField] float bpm = 120;
	[SerializeField] float beatDuration;
	[SerializeField] float margin = 80;

	[SerializeField] float lastBeat;
	[SerializeField] float activeBeat = -1;
	[SerializeField] float activeBeatStartPosition;
	[SerializeField] float activeBeatEndPosition;
	[SerializeField] float nextBeatPosition;
	
	void Start()
	{
		//subscribe to game manager start level event
		beatDuration = 60f / bpm * 1000;
		nextBeatPosition = beatDuration;

		activeBeatStartPosition = nextBeatPosition - margin;
		activeBeatEndPosition = nextBeatPosition + margin;

		StartCoroutine(UpdateBeat());
	}//for testing purposes

	void SetupLevel(int newBpm)
	{
		beatDuration = 60f / newBpm * 1000;
		nextBeatPosition = beatDuration;

		activeBeatStartPosition = nextBeatPosition - margin;
		activeBeatEndPosition = nextBeatPosition + margin;

		StartCoroutine(UpdateBeat());
	}//to be called when the level starts

	IEnumerator UpdateBeat()
	{
		while (true)
		{
			float position = Time.time * 1000; //get position in song in ms using AudioSource.time from music player

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
