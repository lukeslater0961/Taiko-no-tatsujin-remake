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
		LevelManager.setupLevel += SetClip; 
		LevelManager.startLevel += PlaySong;
		LevelManager.pauseLevel += PauseSong;
		LevelManager.stopLevel += StopSong;

		audioSource = GetComponent<AudioSource>();
	}

	public void SetClip(SongData sData)
	{
		audioSource.clip = sData.song;
		_clipName = audioSource.clip.name;
	}

	public void PlaySong()
	{
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
