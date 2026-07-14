using UnityEngine;
using System;

public class MusicPlayer : MonoBehaviour
{
	private AudioSource _audioPlayer;
	[SerializeField] 
	private string		_clipName;
	
	void Start()
	{
		//subscribe to play song event	
		//subscribe to pause song event	
		//subscribe to Stop song event
		//subscribe to SetClip event
		//subscribe to getsongPos event
		_audioPlayer = GetComponent<AudioSource>();
	}
	
	public void SetClip(AudioClip song)
	{
		_audioPlayer.clip = song;
		_clipName = _audioPlayer.clip.name;
	}

	public float GetClipPos()
	{
		return _audioPlayer.time * 1000;
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
