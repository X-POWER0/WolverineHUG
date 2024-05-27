using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "ControlPanel", menuName = "ScriptableObjects/ControlPanel")]
public class ControlPanel : ScriptableObject {
	public pressedButton LeftKeyButtn;
	public pressedButton RightKeyButtn;
	public pressedButton UpKeyButtn;
	public pressedButton DownKeyButtn;
	public pressedButton CameraKeyButtn;
	public pressedButton SubmitKeyButtn;
	public pressedButton ExitKeyButtn;
	public pressedButton PauseKeyButtn;
[SerializeField] private bool ControlPanelON=false;
public bool SetControlPanelON {
//c#7
//    get=> _selectedMenuButton;
//    set=> _selectedMenuButton = value;
	get { return ControlPanelON;}
    set { ControlPanelON = value;}

}
private pressedButton[] keyCodes;
public static event Action<PressedKeyCode[]> KeyPressed;
private void Awake(){
	keyCodes = new[]{
LeftKeyButtn,
RightKeyButtn,
UpKeyButtn,
DownKeyButtn,
CameraKeyButtn,
SubmitKeyButtn,
ExitKeyButtn,
PauseKeyButtn,
	};
}
	void FixedUpdate () {
	List<PressedKeyCode> pressedKeyCode = new List<PressedKeyCode>();
	for(int index=0; index < keyCodes.Length; index++)
	{
		pressedButton keyCode = keyCodes[index];
		if(keyCode.isPressed){
			pressedKeyCode.Add((PressedKeyCode)index);
		}
		if(KeyPressed != null)
		KeyPressed(pressedKeyCode.ToArray());

	}
	}
}
