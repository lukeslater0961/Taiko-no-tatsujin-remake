using UnityEngine;
using System;

public class MusicPlayer : MonoBehaviour
{
	public static MusicPlayer	instance {get; private set;}
	public AudioSource			audioSource {get; private set;}

	[SerializeField] 
	private string		_clipName;
	
	public float CurrentTime => audioSource.time;

	void Awake()
	{
		instance = this;
		audioSource = GetComponent<AudioSource>();
	}

	void OnEnable()
	{
		Debug.Log("hello muci player");
		LevelManager.setupLevel += SetClip; 
		LevelManager.startLevel += PlaySong;
		LevelManager.pauseLevel += PauseSong;
		LevelManager.stopLevel += StopSong;
	}

	void OnDisable()
	{
		LevelManager.setupLevel -= SetClip; 
		LevelManager.startLevel -= PlaySong;
		LevelManager.pauseLevel -= PauseSong;
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

	public void PauseSong()
	{
		audioSource.Pause();
	}

	public void StopSong()
	{
		audioSource.Stop();
	}
}
