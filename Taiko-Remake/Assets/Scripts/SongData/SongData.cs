using UnityEngine;
using System.Collections.Generic;
using System;

[Serializable]
public struct Beat{
	public int input;
    public float beatStartPosition;
    public float beatEndPosition;

    public Beat(int input, float timestamp)
    {
        this.input = input;
        this.beatStartPosition = timestamp;
        this.beatEndPosition = timestamp + 160;
    }
}

[CreateAssetMenu]
public class SongData : ScriptableObject 
{
	public string		songName;
	public List<Beat>	beatChart;
	public AudioClip	song;
	public int			bpm;
}
