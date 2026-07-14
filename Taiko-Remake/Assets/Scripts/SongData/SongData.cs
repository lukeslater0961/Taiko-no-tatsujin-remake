using UnityEngine;
using System.Collections.Generic;
using System;

[Serializable]
public struct Beat{
	public int input;
    public float timestamp;

    public Beat(int input, float timestamp)
    {
        this.input = input;
        this.timestamp = timestamp;
    }
}

[CreateAssetMenu]
public class SongData : ScriptableObject 
{
	public string songName;
	public List<Beat> beatChart;
	public AudioClip song;
}
