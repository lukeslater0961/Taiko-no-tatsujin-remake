using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
	public static event Action<int> beatPressed;
	public static event Action		confirmPressed;

	private InputAction _left;
	private InputAction _right;
	private InputAction _confirm;

    void Awake()
    {
		_left = InputSystem.actions.FindAction("leftbeat");
		_right = InputSystem.actions.FindAction("rightbeat");
		_confirm = InputSystem.actions.FindAction("enter");
		
		DontDestroyOnLoad(gameObject);
    }

	void OnEnable()
	{
		_left.performed += _ => beatPressed?.Invoke(0);
		_right.performed += _ => beatPressed?.Invoke(1);
		_confirm.performed += _ => confirmPressed?.Invoke();

		_left.Enable();
		_right.Enable();
		_confirm.Enable();
	}
}
