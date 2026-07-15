using UnityEngine;
using System;

public class MusicPlayer : MonoBehaviour
{
	public AudioSource _audioPlayer {get; private set;}
	[SerializeField] 
	private string		_clipName;
	
	void Start()
	{
		LevelManager.startLevel += PlaySong;
		LevelManager.pauseLevel += PauseSong;
		LevelManager.stopLevel += StopSong;
		//subscribe to SetClip event
		_audioPlayer = GetComponent<AudioSource>();
	}
	
	public void SetClip(AudioClip song)
	{
		_audioPlayer.clip = song;
		_clipName = _audioPlayer.clip.name;
	}

	public void PlaySong()
	{
		_audioPlayer.Play();
	}

	public void PauseSong()
	{
		_audioPlayer.Pause();
	}

	public void StopSong()
	{
		_audioPlayer.Stop();
	}
}
