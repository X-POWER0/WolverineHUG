using UnityEngine;
using System.Collections;
using  UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class ExKeyToExitM : MonoBehaviour {
//[SerializeField] private List<KeyCode> ExitKey = new List<KeyCode> {KeyCode.Escape, KeyCode.P, KeyCode.M, KeyCode.X}; 
[SerializeField] private Button ExitBtn;
		bool _exitKeyUp = true;
[SerializeField] private Button CamBtn;
		bool _camKeyUp = true;
public bool CamKeyUp{
    //c#7
	//get => _selectedMenuBtnNumber;
    //set => _selectedMenuBtnNumber = value;
	get { return _camKeyUp;}
    set { _camKeyUp = value;}
}
[SerializeField] private List<GameObject> Cameras = new List<GameObject> (); 
private int CameraNumber=0;
[SerializeField] private GameObject UsedCamera;
public bool ExitKeyUp{
	get { return _exitKeyUp;}
    set { _exitKeyUp = value;}

}
		private KeyCode LastKeyCode;
		private KeyCode LastKeyCodeCam;
public bool KeysDown(List<KeyCode> PressedKeys){
foreach (KeyCode pressedKey in PressedKeys){ 
if(Input.GetKeyDown(pressedKey)) {
	return true;
	}
}
return false;
}
public bool KeysUp(KeyCode pressedKey){ 
if(Input.GetKeyUp(pressedKey)) return true;
return false;
}	[SerializeField ] private	ControlPanel controlPanel;
	[SerializeField ] private bool ControlPanelON = false;
public bool SetControlPanelON {
	get { return ControlPanelON;}
    set { ControlPanelON = value;}

}
	void Start () {
		Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
		ControlPanelON = controlPanel.SetControlPanelON;
UsedCamera=Cameras[CameraNumber];
	}
	void Update () {
	if(Input.GetButtonDown("Cancel") && _exitKeyUp && ExitBtn.IsActive() && ExitBtn.enabled  || ControlPanelON && controlPanel.ExitKeyButtn.isPressed  && _exitKeyUp && ExitBtn.IsActive() && ExitBtn.enabled  )
	{
ExitBtn.onClick.Invoke();
			_exitKeyUp = false;
			_camKeyUp = true;
			}
	if(Input.GetButtonDown("Camera") && _camKeyUp   || ControlPanelON && controlPanel.CameraKeyButtn.isPressed   && _camKeyUp   ){
if(CameraNumber<Cameras.Count-1){
Transform TransformCamera=Cameras[CameraNumber].transform;
Cameras[CameraNumber].SetActive(false);
	CameraNumber+=1;
UsedCamera=Cameras[CameraNumber];
Cameras[CameraNumber].SetActive(true);
}
else if(CameraNumber==Cameras.Count-1){
Transform TransformCamera=Cameras[CameraNumber].transform;
Cameras[CameraNumber].SetActive(false);
	CameraNumber=0;
UsedCamera=Cameras[CameraNumber];
Cameras[CameraNumber].SetActive(true);
}
			}
	}
}
