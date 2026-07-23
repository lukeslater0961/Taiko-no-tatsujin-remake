using UnityEngine;
using System;

public class InputValidator : MonoBehaviour
{
	public static event Action beatMissed;

	[SerializeField] 
	private int	currentInput;

	private Metronome	_metronome;
	private MusicPlayer _musicPlayer;

    void Awake()
    {
		_metronome = FindAnyObjectByType<Metronome>();
		currentInput = -1;
    }

	void OnEnable()
	{
		InputManager.beatPressed += HandleInput;
	}

	void OnDisable()
	{
		InputManager.beatPressed -= HandleInput;
	}

	void HandleInput(int inputType)
	{
		if (_metronome.activeBeat == -1)
		{
			currentInput = -1;
			//reset combo
			return;
		}
		currentInput = inputType;

		//call function in composer to get current beat input with current time by taking margin into account
		//if return value from function(input) is incorrect call event to reset combo
		//beatMissed?.Invoke();
	}
}
