using UnityEngine;
using System;

public class MusicPlayer : MonoBehaviour
{
	public static MusicPlayer	instance {get; private set;}
	public AudioSource			audioSource {get; private set;}

	[SerializeField] 
	private string		_clipName;
	
	public float currentTime => audioSource.time;

	void Awake()
	{
		if (instance == null)
			instance = this;
		else
			Destroy(gameObject);
		audioSource = GetComponent<AudioSource>();
	}

	void OnEnable()
	{
		Debug.Log("hello muci player");
		LevelManager.setupLevel += SetClip; 
		LevelManager.startLevel += PlaySong;
		LevelManager.pauseLevel += TogglePause;
		LevelManager.stopLevel += StopSong;
	}

	void OnDisable()
	{
		LevelManager.setupLevel -= SetClip; 
		LevelManager.startLevel -= PlaySong;
		LevelManager.pauseLevel -= TogglePause;
		LevelManager.stopLevel -= StopSong;
	}

	public void SetClip(SongData sData)
	{
		audioSource.clip = sData.song;
		_clipName = audioSource.clip.name;
	}

	public void PlaySong()
	{

		Debug.Log("Hello player start--");
		audioSource.Play();
	}

	public void TogglePause()
	{
		if (audioSource.isPlaying)
			audioSource.Pause();
		else
			audioSource.Play();
	}

	public void StopSong()
	{
		Debug.Log("Hello player stop--");
		audioSource.Stop();
	}
}
