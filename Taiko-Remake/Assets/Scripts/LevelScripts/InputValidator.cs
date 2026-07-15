using UnityEngine;
using System;

public class InputValidator : MonoBehaviour
{
	public static event Action beatMissed;

	[SerializeField] 
	private int	currentInput;

	private Metronome	_metronome;
	private MusicPlayer _musicPlayer;

    void Start()
    {
		_metronome = FindFirstObjectByType<Metronome>();
		_musicPlayer = FindFirstObjectByType<MusicPlayer>();
		currentInput = -1;
		InputManager.beatPressed += HandleInput;
    }

	void HandleInput(int inputType)
	{
		if (_metronome.activeBeat == -1)
		{
			currentInput = -1;
			return;
		}
		currentInput = inputType;

		//call function in composer to get current beat input with current time by taking marign into account
		//if return value from function(input) is incorrect call event to reset combo
		//beatMissed?.Invoke();
	}
}
