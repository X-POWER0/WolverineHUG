using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
public class ExitMenu : MonoBehaviour {
[SerializeField] private List<Button> ExitMenuBtnList = new List<Button>();
[SerializeField]  private int ExitKeyPhases=0;
[SerializeField]  private int ExitKeyPhasesMax;
[SerializeField] private List<Button> SubmitMenuBtnList = new List<Button>();
[SerializeField]  private int SubmitKeyPhases=0;
[SerializeField]  private int SubmitKeyPhasesMax;
[SerializeField] private KeyCode ExitKey = KeyCode.Escape;
[SerializeField] private KeyCode SubmitKey = KeyCode.Return;
[SerializeField] private List<KeyCode> IncreasNumberSelectKey = new List<KeyCode> {KeyCode.D, KeyCode.RightArrow, KeyCode.W, KeyCode.UpArrow}; 
[SerializeField] private List<KeyCode> DecreasNumberSelectKey = new List<KeyCode> {KeyCode.A, KeyCode.LeftArrow, KeyCode.S, KeyCode.DownArrow}; 
[SerializeField] private List<Button> SelectebMenuBtnList = new List<Button>();
[System.Serializable] public class ButtonList
{
	public List<Button> list= new List<Button>();
} 
public List<ButtonList> SelectebleMenuBtnsLists = new List<ButtonList>();
[SerializeField]  int _selectedMenuBtnNumber=-1;
bool ShowCursor=false;
float ShowCursorTime;
float ShowCursorTimeRate=1.5f;
float ShowCursorX=0f;
float ShowCursorY=0f;
float ShowCursorXlast=0f;
float ShowCursorYlast=0f;
public int SelectedMenuBtnNumber{
    //c#7
	//get => _selectedMenuBtnNumber;
    //set => _selectedMenuBtnNumber = value;
	get { return _selectedMenuBtnNumber;}
    set { _selectedMenuBtnNumber = value;}
}
[SerializeField]  Button _invisibleBtn;
public Button SetinvisibleBtn{
	get { return _invisibleBtn;}
    set { _invisibleBtn = value;}
}
[SerializeField]  private GameObject SelectedMenuBtnFX;
		private bool SelectIncreasKeyUp = true;	
		private bool SelectDecreasKeyUp = true;	
		private bool SubMenuMaxSubmitLvl = false;	
public bool SelectKeysDown(List<KeyCode> PressedKeys){
foreach (KeyCode pressedKey in PressedKeys){ 
if(Input.GetKeyDown(pressedKey)) {
	return true;
	}
}
return false;
}
public bool SelectKeysUp(KeyCode pressedKey){ 
if(Input.GetKeyUp(pressedKey)) return true;
return false;
}
[SerializeField ] private Button _selectedMenuButton=null;
public Button SelectedMenuButton {
	get { return _selectedMenuButton ;}
    set { _selectedMenuButton = value;}
}
		bool ExitKeyUp = true;
		bool SubmitKeyUp = true;
	[SerializeField ] private	ControlPanel controlPanel;
	[SerializeField ] private bool ControlPanelON = false;
public bool SetControlPanelON {
	get { return ControlPanelON;}
    set { ControlPanelON = value;}
}
KeyCode eLast=KeyCode.None;
Array allKeyCodes;
ShowCurs CursorStateHolder;
			float TimePress;
[SerializeField] bool useInputField = false;
public bool USEInputField{
get{return useInputField;}
set{useInputField=value;}

}

void Awake(){
allKeyCodes=System.Enum.GetValues(typeof(KeyCode));
}
	void Start () {
			TimePress=Time.time;
			ShowCursorTime=Time.time;
			CursorStateHolder = GameObject.FindGameObjectWithTag("AudioMain").GetComponent<ShowCurs>();
			if(CursorStateHolder !=null){
ShowCursor=CursorStateHolder.ShowC;
			}		
			if(!ShowCursor){
ShowCursorXlast=ShowCursorX =Input.mousePosition.x;
ShowCursorYlast=ShowCursorY =Input.mousePosition.y;
				Cursor.visible = false;
ShowCursorXlast=ShowCursorX =Input.mousePosition.x;
ShowCursorYlast=ShowCursorY =Input.mousePosition.y;}
			ControlPanel.KeyPressed += OnKeyPressed;
		ControlPanelON = controlPanel.SetControlPanelON;
ExitKeyPhases=0;
	ExitKeyPhasesMax = ExitMenuBtnList.Count-1;
	SubmitKeyPhasesMax = SubmitMenuBtnList.Count-1;
SelectedMenuButton = SubmitMenuBtnList[ExitKeyPhases];
	}
private void OnKeyPressed(PressedKeyCode[] obj){
if(ControlPanelON){ 
	foreach (PressedKeyCode pressedKeyCode in obj){
switch (pressedKeyCode){
	case PressedKeyCode.LeftKeyButtn:
	break;
	case PressedKeyCode.RightKeyButtn:
	break;
	case PressedKeyCode.UpKeyButtn:
	break;
	case PressedKeyCode.DownKeyButtn:
	break;
	case PressedKeyCode.SubmitKeyButtn:
	break;
	case PressedKeyCode.ExitKeyButtn:
	break;
	case PressedKeyCode.PauseKeyButtn:
	break;
	case PressedKeyCode.CameraKeyButtn:
	break;
}
}
	}
}
	void Update () {
// Cursor Not visible if no mouse move START
if(CursorStateHolder!=null){
ShowCursor=CursorStateHolder.ShowC;}
if(ShowCursorTime<Time.time && ShowCursor||Time.timeScale==0 && ShowCursor){
	if(Time.timeScale!=0){
	ShowCursorTime=Time.time+ShowCursorTimeRate*100*Time.deltaTime;
if(ShowCursor && ShowCursorX==ShowCursorXlast &&ShowCursorY==ShowCursorYlast){
ShowCursor=false;
Cursor.visible =false;
ShowCursorXlast=ShowCursorX =Input.mousePosition.x;
ShowCursorYlast=ShowCursorY =Input.mousePosition.y;
}
else{
ShowCursor=true;
Cursor.visible = true;
ShowCursorXlast =Input.mousePosition.x;
ShowCursorYlast=Input.mousePosition.y;
}
	}
	else if(Time.timeScale==0 && ShowCursorTime<=Time.time){
	ShowCursorTime=Time.time+ShowCursorTimeRate;
	if(!ShowCursor){Cursor.visible = false;
}
if(ShowCursor && ShowCursorX==ShowCursorXlast &&ShowCursorY==ShowCursorYlast){
ShowCursor=false;
Cursor.visible = false;
ShowCursorXlast=ShowCursorX =Input.mousePosition.x;
ShowCursorYlast=ShowCursorY =Input.mousePosition.y;
}
ShowCursorXlast =Input.mousePosition.x;
ShowCursorYlast=Input.mousePosition.y;
	}
		}
if(ShowCursorTime>Time.time|| Time.timeScale==0){
	if(Time.timeScale==0 && ShowCursorTime>Time.time){
	ShowCursorTime=ShowCursorTime-(ShowCursorTimeRate*0.01f);
	}
	else if(Time.timeScale!=0){
}
}
if(!ShowCursor){
if(ShowCursorY!=ShowCursorYlast){
if(ShowCursorX!=ShowCursorXlast){
	if(ShowCursorX!=ShowCursorXlast){
		ShowCursor=true;}
else if(ShowCursorX-ShowCursorXlast<-1){
		ShowCursor=true;}
else if(ShowCursorX-ShowCursorXlast>1){
	ShowCursor=true;}}
}
else {if(ShowCursorY==ShowCursorYlast){
	if(ShowCursorX!=ShowCursorXlast){
	if(ShowCursorX-ShowCursorXlast<-1){
		ShowCursor=true;}
else if(ShowCursorX-ShowCursorXlast>1){
	ShowCursor=true;}
	}
}
else if(ShowCursorX==ShowCursorXlast){
	if(ShowCursorY!=ShowCursorYlast){
	if(ShowCursorY-ShowCursorYlast<-1){
		ShowCursor=true;}
else if(ShowCursorY-ShowCursorYlast>1){
	ShowCursor=true;}
}
}
	else if(ShowCursorY-ShowCursorYlast>1){
		ShowCursor=true;}
else if(ShowCursorX-ShowCursorXlast>-1){
	ShowCursor=true;}
else if(ShowCursorY-ShowCursorYlast>-1){
	ShowCursor=true;}
else if(ShowCursorX-ShowCursorXlast>1){
	ShowCursor=true;} 
}
}
if(!ShowCursor){Cursor.visible = false;}
			else if(ShowCursor){Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;}
	ShowCursorX=Input.mousePosition.x;
ShowCursorY=Input.mousePosition.y;
if(CursorStateHolder !=null){
CursorStateHolder.ShowC=ShowCursor;
			}
// Cursor Not visible if no mouse move END
	if (Input.GetButtonDown("Cancel") && ExitKeyUp && ExitKeyPhases<ExitKeyPhasesMax && ExitMenuBtnList[ExitKeyPhases].IsActive()&& TimePress<Time.time&& Time.timeScale!=0 && !useInputField || !useInputField &&  TimePress<Time.time&& Time.timeScale!=0 && ControlPanelON && controlPanel.ExitKeyButtn.isPressed && ExitKeyUp && ExitKeyPhases<ExitKeyPhasesMax && ExitMenuBtnList[ExitKeyPhases].IsActive() || !useInputField && 
	Input.GetButtonDown("Cancel") && ExitKeyUp && ExitKeyPhases<ExitKeyPhasesMax && ExitMenuBtnList[ExitKeyPhases].IsActive()&& Time.timeScale==0 || !useInputField &&  Time.timeScale==0 && ControlPanelON && controlPanel.ExitKeyButtn.isPressed && ExitKeyUp && ExitKeyPhases<ExitKeyPhasesMax && ExitMenuBtnList[ExitKeyPhases].IsActive()){
ExitMenuBtnList[ExitKeyPhases].onClick.Invoke();
			ExitKeyUp = false;
SelectedMenuButton=SubmitMenuBtnList[ExitKeyPhases];
SelectebMenuBtnList = SelectebleMenuBtnsLists [ExitKeyPhases].list;

if(SelectedMenuBtnNumber<=-2){
_selectedMenuBtnNumber=0;
SelectedMenuButton=SelectebMenuBtnList[_selectedMenuBtnNumber];
_selectedMenuBtnNumber=-2;
SubMenuMaxSubmitLvl=true;
}else{
_selectedMenuBtnNumber=0;
		SelectedMenuButton=SelectebMenuBtnList[_selectedMenuBtnNumber];
		SelectedBtnFx();
}
	}
if (Input.GetButtonDown("Cancel")  && ExitKeyUp && ExitKeyPhases==ExitKeyPhasesMax && ExitMenuBtnList[ExitKeyPhases].IsActive()&& TimePress<Time.time && Time.timeScale!=0 && !useInputField || !useInputField &&  TimePress<Time.time && Time.timeScale!=0 && ControlPanelON && controlPanel.ExitKeyButtn.isPressed  && ExitKeyUp && ExitKeyPhases==ExitKeyPhasesMax && ExitMenuBtnList[ExitKeyPhases].IsActive() || !useInputField && 
	Input.GetButtonDown("Cancel")  && ExitKeyUp && ExitKeyPhases==ExitKeyPhasesMax && ExitMenuBtnList[ExitKeyPhases].IsActive()&& Time.timeScale==0 || !useInputField &&  Time.timeScale==0 && ControlPanelON && controlPanel.ExitKeyButtn.isPressed  && ExitKeyUp && ExitKeyPhases==ExitKeyPhasesMax && ExitMenuBtnList[ExitKeyPhases].IsActive() ){
ExitMenuBtnList[ExitKeyPhases].onClick.Invoke();
			ExitKeyUp = false;
	}
if (SelectedMenuButton==ExitMenuBtnList[ExitKeyPhases]){
	if ( Input.GetButtonDown("Submit")  && SubmitKeyUp && ExitKeyPhases<ExitKeyPhasesMax && ExitMenuBtnList[ExitKeyPhases].IsActive()&& TimePress<Time.time && Time.timeScale!=0 || Time.timeScale!=0 && TimePress<Time.time && ControlPanelON && controlPanel.SubmitKeyButtn.isPressed  && SubmitKeyUp && ExitKeyPhases<ExitKeyPhasesMax && ExitMenuBtnList[ExitKeyPhases].IsActive()|| 
	Input.GetButtonDown("Submit")  && SubmitKeyUp && ExitKeyPhases<ExitKeyPhasesMax && ExitMenuBtnList[ExitKeyPhases].IsActive()&& Time.timeScale==0 || Time.timeScale==0 && ControlPanelON && controlPanel.SubmitKeyButtn.isPressed  && SubmitKeyUp && ExitKeyPhases<ExitKeyPhasesMax && ExitMenuBtnList[ExitKeyPhases].IsActive()){
ExitMenuBtnList[ExitKeyPhases].onClick.Invoke(); 
SelectebMenuBtnList = SelectebleMenuBtnsLists [ExitKeyPhases].list;
_selectedMenuBtnNumber=0;
		SelectedMenuButton=SelectebMenuBtnList[_selectedMenuBtnNumber];
SelectedMenuButton=SubmitMenuBtnList[ExitKeyPhases];
SelectedBtnFx();
	}
}
if (SelectedMenuButton==ExitMenuBtnList[ExitKeyPhases]){
	if (  Input.GetButtonDown("Submit")  && SubmitKeyUp && ExitKeyPhases==ExitKeyPhasesMax && ExitMenuBtnList[ExitKeyPhases].IsActive()&& TimePress<Time.time  && Time.timeScale!=0|| TimePress<Time.time && Time.timeScale!=0 && ControlPanelON && controlPanel.SubmitKeyButtn.isPressed  && SubmitKeyUp && ExitKeyPhases==ExitKeyPhasesMax && ExitMenuBtnList[ExitKeyPhases].IsActive() || 
	 Input.GetButtonDown("Submit")  && SubmitKeyUp && ExitKeyPhases==ExitKeyPhasesMax && ExitMenuBtnList[ExitKeyPhases].IsActive()&& Time.timeScale==0 || Time.timeScale==0 && ControlPanelON && controlPanel.SubmitKeyButtn.isPressed  && SubmitKeyUp && ExitKeyPhases==ExitKeyPhasesMax && ExitMenuBtnList[ExitKeyPhases].IsActive()){
ExitMenuBtnList[ExitKeyPhases].onClick.Invoke();
	}
}

//Select menu buttons Start
	if(!useInputField && Input.GetAxisRaw("Horizontal")>0   && SelectIncreasKeyUp && _selectedMenuBtnNumber!=-2 && !SubMenuMaxSubmitLvl&& TimePress<Time.time && Time.timeScale!=0 ||!useInputField && Input.GetAxisRaw("Vertical")>0   && SelectIncreasKeyUp && _selectedMenuBtnNumber!=-2 && !SubMenuMaxSubmitLvl&& TimePress<Time.time && Time.timeScale!=0 || !useInputField && TimePress<Time.time && Time.timeScale!=0 && ControlPanelON && controlPanel.RightKeyButtn.isPressed  && SelectIncreasKeyUp && _selectedMenuBtnNumber!=-2 && !SubMenuMaxSubmitLvl || !useInputField && TimePress<Time.time&& Time.timeScale!=0 && ControlPanelON && controlPanel.UpKeyButtn.isPressed  && SelectIncreasKeyUp && _selectedMenuBtnNumber!=-2 && !SubMenuMaxSubmitLvl||
	!useInputField && Input.GetAxisRaw("Horizontal")>0 && SelectIncreasKeyUp && _selectedMenuBtnNumber!=-2 && !SubMenuMaxSubmitLvl&& Time.timeScale==0 || !useInputField && Input.GetAxisRaw("Vertical")>0   && SelectIncreasKeyUp && _selectedMenuBtnNumber!=-2 && !SubMenuMaxSubmitLvl&& Time.timeScale==0 || !useInputField && Time.timeScale==0 && ControlPanelON && controlPanel.RightKeyButtn.isPressed  && SelectIncreasKeyUp && _selectedMenuBtnNumber!=-2 && !SubMenuMaxSubmitLvl || !useInputField && Time.timeScale==0 && ControlPanelON && controlPanel.UpKeyButtn.isPressed  && SelectIncreasKeyUp && _selectedMenuBtnNumber!=-2 && !SubMenuMaxSubmitLvl){
			SelectebMenuBtnList=SelectebleMenuBtnsLists [ExitKeyPhases].list;
		if(_selectedMenuBtnNumber<SelectebMenuBtnList.Count-1){
		_selectedMenuBtnNumber+=1;
	SelectebMenuBtnList=SelectebleMenuBtnsLists[ExitKeyPhases].list;
	if(SelectebMenuBtnList[_selectedMenuBtnNumber].IsActive()){
		SelectedMenuButton=SelectebMenuBtnList[_selectedMenuBtnNumber];
			}		
		SelectedBtnFx();
					_invisibleBtn.Select();
		SelectDecreasKeyUp = true;
					SubmitKeyUp = true;
					ExitKeyUp = true;}
		else if(_selectedMenuBtnNumber>=SelectebMenuBtnList.Count-1){
			_selectedMenuBtnNumber=0;
			SelectebMenuBtnList=SelectebleMenuBtnsLists[ExitKeyPhases].list;
			if(SelectebMenuBtnList[_selectedMenuBtnNumber].IsActive()){
		SelectedMenuButton=SelectebMenuBtnList[_selectedMenuBtnNumber];}
		SelectedBtnFx();
		SelectDecreasKeyUp = true;
					SubmitKeyUp = true;
					ExitKeyUp = true;
					_invisibleBtn.Select();
		}
	}
	if(!useInputField && Input.GetAxisRaw("Horizontal")>0   && SelectIncreasKeyUp && _selectedMenuBtnNumber<=-2 && SubMenuMaxSubmitLvl&& TimePress<Time.time && Time.timeScale!=0 || !useInputField && Input.GetAxisRaw("Vertical")>0   && SelectIncreasKeyUp && _selectedMenuBtnNumber<=-2 && SubMenuMaxSubmitLvl&& TimePress<Time.time && Time.timeScale!=0 || !useInputField && TimePress<Time.time && Time.timeScale!=0 && ControlPanelON && controlPanel.RightKeyButtn.isPressed  && SelectIncreasKeyUp && _selectedMenuBtnNumber<=-2 && SubMenuMaxSubmitLvl || !useInputField && TimePress<Time.time && Time.timeScale!=0 && ControlPanelON && controlPanel.UpKeyButtn.isPressed  && SelectIncreasKeyUp && _selectedMenuBtnNumber<=-2 && SubMenuMaxSubmitLvl || !useInputField && 
	Input.GetAxisRaw("Horizontal")>0   && SelectIncreasKeyUp && _selectedMenuBtnNumber<=-2 && SubMenuMaxSubmitLvl&& Time.timeScale==0 || !useInputField && Input.GetAxisRaw("Vertical")>0   && SelectIncreasKeyUp && _selectedMenuBtnNumber<=-2 && SubMenuMaxSubmitLvl&& Time.timeScale==0 || !useInputField && Time.timeScale==0 && ControlPanelON && controlPanel.RightKeyButtn.isPressed  && SelectIncreasKeyUp && _selectedMenuBtnNumber<=-2 && SubMenuMaxSubmitLvl || !useInputField && Time.timeScale==0 && ControlPanelON && controlPanel.UpKeyButtn.isPressed  && SelectIncreasKeyUp && _selectedMenuBtnNumber<=-2 && SubMenuMaxSubmitLvl)
{			SelectebMenuBtnList=SelectebleMenuBtnsLists [ExitKeyPhases].list;
		if(-_selectedMenuBtnNumber-2<(SelectebMenuBtnList.Count-1)){
		_selectedMenuBtnNumber-=1;
	SelectebMenuBtnList=SelectebleMenuBtnsLists[ExitKeyPhases].list;
		if(SelectebMenuBtnList[-_selectedMenuBtnNumber-2].IsActive()){
		SelectedMenuButton=SelectebMenuBtnList[-_selectedMenuBtnNumber-2];
		}
		SelectedBtnFx();
		SelectDecreasKeyUp = true;
					SubmitKeyUp = true;
					ExitKeyUp = true;
					_invisibleBtn.Select();
		}
		else if(-_selectedMenuBtnNumber-2>=(SelectebMenuBtnList.Count-1)){
			_selectedMenuBtnNumber=0;
			SelectebMenuBtnList=SelectebleMenuBtnsLists[ExitKeyPhases].list;
			
		if(SelectebMenuBtnList[_selectedMenuBtnNumber].IsActive()){
		SelectedMenuButton=SelectebMenuBtnList[_selectedMenuBtnNumber];
		}
		SelectedBtnFx();
		_selectedMenuBtnNumber=-2;
		SelectDecreasKeyUp = true;
					SubmitKeyUp = true;
					ExitKeyUp = true;
					_invisibleBtn.Select();
		}}
			if( !useInputField && Input.GetAxisRaw("Horizontal")<0  && SelectDecreasKeyUp && _selectedMenuBtnNumber<=-2 && SubMenuMaxSubmitLvl&& TimePress<Time.time&& Time.timeScale!=0 || !useInputField && Input.GetAxisRaw("Vertical")<0  && SelectDecreasKeyUp && _selectedMenuBtnNumber<=-2 && SubMenuMaxSubmitLvl&& TimePress<Time.time&& Time.timeScale!=0 || !useInputField && TimePress<Time.time&& Time.timeScale!=0 && ControlPanelON && controlPanel.LeftKeyButtn.isPressed && SelectDecreasKeyUp && _selectedMenuBtnNumber<=-2 && SubMenuMaxSubmitLvl || !useInputField && TimePress<Time.time&& Time.timeScale!=0 && ControlPanelON && controlPanel.DownKeyButtn.isPressed && SelectDecreasKeyUp && _selectedMenuBtnNumber<=-2 && SubMenuMaxSubmitLvl || !useInputField &&
			Input.GetAxisRaw("Horizontal")<0  && SelectDecreasKeyUp && _selectedMenuBtnNumber<=-2 && SubMenuMaxSubmitLvl&& Time.timeScale==0 || !useInputField && Input.GetAxisRaw("Vertical")<0  && SelectDecreasKeyUp && _selectedMenuBtnNumber<=-2 && SubMenuMaxSubmitLvl&& Time.timeScale==0 || !useInputField && Time.timeScale==0 && ControlPanelON && controlPanel.LeftKeyButtn.isPressed && SelectDecreasKeyUp && _selectedMenuBtnNumber<=-2 && SubMenuMaxSubmitLvl || !useInputField && Time.timeScale==0 && ControlPanelON && controlPanel.DownKeyButtn.isPressed && SelectDecreasKeyUp && _selectedMenuBtnNumber<=-2 && SubMenuMaxSubmitLvl 
)
{			SelectebMenuBtnList=SelectebleMenuBtnsLists [ExitKeyPhases].list;
		if(-_selectedMenuBtnNumber-2>0){
		_selectedMenuBtnNumber+=1;
	SelectebMenuBtnList=SelectebleMenuBtnsLists[ExitKeyPhases].list;
		if(SelectebMenuBtnList[-_selectedMenuBtnNumber-2].IsActive()){
		SelectedMenuButton=SelectebMenuBtnList[-_selectedMenuBtnNumber-2];
		}
		SelectedBtnFx();
		SelectIncreasKeyUp = true;
					SubmitKeyUp = true;
					ExitKeyUp = true;
					_invisibleBtn.Select();
		}
		else if(-_selectedMenuBtnNumber-2<=0){
		_selectedMenuBtnNumber=-(SelectebMenuBtnList.Count-1)-2;
			SelectebMenuBtnList=SelectebleMenuBtnsLists[ExitKeyPhases].list;
		if(SelectebMenuBtnList[-(_selectedMenuBtnNumber+2)].IsActive()){
		SelectedMenuButton=SelectebMenuBtnList[-(_selectedMenuBtnNumber+2)];
		}
		SelectedBtnFx();
		SelectIncreasKeyUp = true;
					SubmitKeyUp = true;
					ExitKeyUp = true;
					_invisibleBtn.Select();
		}}
	if(!useInputField && Input.GetAxisRaw("Horizontal")<0  && SelectDecreasKeyUp && _selectedMenuBtnNumber!=-2 && !SubMenuMaxSubmitLvl&& TimePress<Time.time&& Time.timeScale!=0 || !useInputField && TimePress<Time.time&& Time.timeScale!=0 && Input.GetAxisRaw("Vertical")<0  && SelectDecreasKeyUp && _selectedMenuBtnNumber!=-2 && !SubMenuMaxSubmitLvl || !useInputField && ControlPanelON && controlPanel.LeftKeyButtn.isPressed && SelectDecreasKeyUp && _selectedMenuBtnNumber!=-2 && !SubMenuMaxSubmitLvl&& TimePress<Time.time&& Time.timeScale!=0 || !useInputField && TimePress<Time.time&& Time.timeScale!=0 && ControlPanelON && controlPanel.DownKeyButtn.isPressed && SelectDecreasKeyUp && _selectedMenuBtnNumber!=-2 && !SubMenuMaxSubmitLvl
|| !useInputField &&
Input.GetAxisRaw("Horizontal")<0  && SelectDecreasKeyUp && _selectedMenuBtnNumber!=-2 && !SubMenuMaxSubmitLvl&& Time.timeScale==0 || !useInputField && Time.timeScale==0 && Input.GetAxisRaw("Vertical")<0  && SelectDecreasKeyUp && _selectedMenuBtnNumber!=-2 && !SubMenuMaxSubmitLvl || !useInputField && ControlPanelON && controlPanel.LeftKeyButtn.isPressed && SelectDecreasKeyUp && _selectedMenuBtnNumber!=-2 && !SubMenuMaxSubmitLvl&& Time.timeScale==0 || !useInputField && Time.timeScale==0 && ControlPanelON && controlPanel.DownKeyButtn.isPressed && SelectDecreasKeyUp && _selectedMenuBtnNumber!=-2 && !SubMenuMaxSubmitLvl ){
			SelectebMenuBtnList=SelectebleMenuBtnsLists [ExitKeyPhases].list;
		if(_selectedMenuBtnNumber>0){
	_selectedMenuBtnNumber-=1;
			SelectebMenuBtnList=SelectebleMenuBtnsLists[ExitKeyPhases].list;
		if(SelectebMenuBtnList[_selectedMenuBtnNumber].IsActive()){
		SelectedMenuButton=SelectebMenuBtnList[_selectedMenuBtnNumber];
		}
		SelectedBtnFx();
		SelectIncreasKeyUp = true;
					SubmitKeyUp = true;
					ExitKeyUp = true;
					_invisibleBtn.Select();
		}
		else if(_selectedMenuBtnNumber<=0){
		_selectedMenuBtnNumber=SelectebMenuBtnList.Count-1;
			SelectebMenuBtnList=SelectebleMenuBtnsLists[ExitKeyPhases].list;
		if(SelectebMenuBtnList[_selectedMenuBtnNumber].IsActive()){
		SelectedMenuButton=SelectebMenuBtnList[_selectedMenuBtnNumber];
		}
		SelectedBtnFx();
		SelectIncreasKeyUp = true;
					SubmitKeyUp = true;
					ExitKeyUp = true;
					_invisibleBtn.Select();
		}
	}
//Select menu buttons END
if (SelectedMenuButton==SubmitMenuBtnList[ExitKeyPhases]){
	if (Input.GetButtonDown("Submit")  && SubmitKeyUp && ExitKeyPhases>0 && SubmitMenuBtnList[ExitKeyPhases].IsActive()&& TimePress<Time.time&& Time.timeScale!=0 || TimePress<Time.time&& Time.timeScale!=0 && ControlPanelON && controlPanel.SubmitKeyButtn.isPressed && SubmitKeyUp && ExitKeyPhases>0 && SubmitMenuBtnList[ExitKeyPhases].IsActive()
	||
	Input.GetButtonDown("Submit")  && SubmitKeyUp && ExitKeyPhases>0 && SubmitMenuBtnList[ExitKeyPhases].IsActive()&& Time.timeScale==0 || Time.timeScale==0 && ControlPanelON && controlPanel.SubmitKeyButtn.isPressed && SubmitKeyUp && ExitKeyPhases>0 && SubmitMenuBtnList[ExitKeyPhases].IsActive()
	){
SubmitMenuBtnList[ExitKeyPhases].onClick.Invoke();
			SubmitKeyUp = false;
SelectebMenuBtnList = SelectebleMenuBtnsLists [ExitKeyPhases].list;
SelectedMenuButton=SubmitMenuBtnList[ExitKeyPhases];
if(_selectedMenuBtnNumber<=-2){
SelectedMenuButton=SubmitMenuBtnList[SubmitKeyPhasesMax];
_selectedMenuBtnNumber=-2;
SubMenuMaxSubmitLvl = false;
}else{
_selectedMenuBtnNumber=0;
SelectedMenuButton = SubmitMenuBtnList[ExitKeyPhases];
	}
SelectedBtnFx();
	}}
if (SelectedMenuButton==SubmitMenuBtnList[ExitKeyPhases]){
	if (Input.GetButtonDown("Submit")  && SubmitKeyUp && ExitKeyPhases==0 && SubmitMenuBtnList[ExitKeyPhases].IsActive()&& TimePress<Time.time&& Time.timeScale!=0 || TimePress<Time.time&& Time.timeScale!=0 && ControlPanelON && controlPanel.SubmitKeyButtn.isPressed && SubmitKeyUp && ExitKeyPhases==0 && SubmitMenuBtnList[ExitKeyPhases].IsActive()||
	Input.GetButtonDown("Submit")  && SubmitKeyUp && ExitKeyPhases==0 && SubmitMenuBtnList[ExitKeyPhases].IsActive()&& Time.timeScale==0 || Time.timeScale==0 && ControlPanelON && controlPanel.SubmitKeyButtn.isPressed && SubmitKeyUp && ExitKeyPhases==0 && SubmitMenuBtnList[ExitKeyPhases].IsActive()){
SubmitMenuBtnList[ExitKeyPhases].onClick.Invoke();
SelectedMenuButton=null;
			SubmitKeyUp = false;
_selectedMenuBtnNumber=-1;
SelectebMenuBtnList = SelectebleMenuBtnsLists[0].list;
	}
}
if (SelectedMenuButton!=null && _selectedMenuBtnNumber!=-1 && SelectedMenuButton!=SubmitMenuBtnList[ExitKeyPhases] && SelectedMenuButton!=ExitMenuBtnList[ExitKeyPhases]){
	if (Input.GetButtonDown("Submit")  && SubmitKeyUp&& TimePress<Time.time&& Time.timeScale!=0 || TimePress<Time.time&& Time.timeScale!=0 && ControlPanelON && controlPanel.SubmitKeyButtn.isPressed && SubmitKeyUp ||
	Input.GetButtonDown("Submit")  && SubmitKeyUp&& Time.timeScale==0 || Time.timeScale==0 && ControlPanelON && controlPanel.SubmitKeyButtn.isPressed && SubmitKeyUp){
if(SubmitKeyPhasesMax>ExitKeyPhasesMax && SubmitKeyPhases!=SubmitKeyPhasesMax){
SubmitKeyPhases=SubmitKeyPhasesMax;
SelectedMenuBtnNumber=-2;
SelectedMenuButton.onClick.Invoke();
SelectedMenuButton=SubmitMenuBtnList[SubmitKeyPhasesMax];
		SelectedBtnFx();
}
else{
SelectedMenuButton.onClick.Invoke();
SubMenuMaxSubmitLvl = false;
			SelectebMenuBtnList=SelectebleMenuBtnsLists[ExitKeyPhases].list;
SelectedMenuButton=SelectebMenuBtnList[_selectedMenuBtnNumber];
//recheck had out of range
		SelectedBtnFx();
}
	}
}
//Check is key unpressed, pressed START
        if (Input.anyKey){
      KeyCode curKey= KeyCode.None;
foreach (KeyCode tempKey in allKeyCodes){
	if(Input.GetKeyDown(tempKey)){
		curKey=tempKey;		
	}
}
	    if (curKey!=eLast){
					ExitKeyUp = true;
		SubmitKeyUp = true;
			SelectDecreasKeyUp =true;
						SelectIncreasKeyUp = true;
eLast=curKey;
			if(Time.timeScale!=0){
			TimePress = Time.time+1*Time.deltaTime;}
			if(Input.GetButtonDown("Cancel")){
		ExitKeyUp = false;
		SubmitKeyUp = true;
			SelectDecreasKeyUp = true;
						SelectIncreasKeyUp = true;
						}
			if(Input.GetButtonDown("Submit")){
		ExitKeyUp = true;
		SubmitKeyUp = false;
			SelectDecreasKeyUp = true;
						SelectIncreasKeyUp = true;
						}
			if(Input.GetAxisRaw("Horizontal")<0 || Input.GetAxisRaw("Vertical")<0){
		ExitKeyUp = true;
		SubmitKeyUp = true;
			SelectDecreasKeyUp = false;
						SelectIncreasKeyUp = true;		
						}	
			if(Input.GetAxisRaw("Horizontal")>0  || Input.GetAxisRaw("Vertical")>0 ){
		ExitKeyUp = true;
		SubmitKeyUp = true;
			SelectDecreasKeyUp =true;
						SelectIncreasKeyUp = false;	
						}
	}
		else{eLast=curKey;
			if(Time.timeScale==0){
			if(Input.GetButtonUp("Submit")){
				SubmitKeyUp = true;
			}
			if(Input.GetButtonUp("Cancel")){
				ExitKeyUp = true;
			}
			if(Input.GetAxisRaw("Vertical")==0 && Input.GetAxisRaw("Horizontal")==0 && Time.timeScale!=0){
				SelectIncreasKeyUp = true;
				SelectDecreasKeyUp = true;
			}
		}
		}
		}
		else {
				if(TimePress<Time.time && Time.timeScale!=0){
eLast=KeyCode.None;
		}
			if(Time.timeScale==0){
eLast=KeyCode.None;
	SubmitKeyUp = true;
				ExitKeyUp = true;
		SelectIncreasKeyUp = true;
				SelectDecreasKeyUp = true;	
	}
		}
			if(Input.GetButtonUp("Submit")){
				SubmitKeyUp = true;
			}
			if(Input.GetButtonUp("Cancel")){
				ExitKeyUp = true;
			}
			if(Input.GetAxisRaw("Vertical")==0 && Input.GetAxisRaw("Horizontal")==0 && Time.timeScale!=0){
				SelectIncreasKeyUp = true;
				SelectDecreasKeyUp = true;
			}
	}
//Check is key unpressed, pressed END
public void DecreaseExitKeyPhases(){
	if(ExitKeyPhases>0){
	ExitKeyPhases-=1;
	}
}
public void IncreaseExitKeyPhases(){
	if(ExitKeyPhases<ExitKeyPhasesMax){
	ExitKeyPhases+=1;
	}
}
public void setExitKeyPhases(int vl){
	if(ExitKeyPhases<=ExitKeyPhasesMax){
	ExitKeyPhases=vl;
	}
}
public void SetSubmitKeyPhases(int value){
	if(SubmitKeyPhases<=SubmitKeyPhasesMax){
	SubmitKeyPhases=value;
	}
}
public void setSubmitKeyUp(bool bl){
SubmitKeyUp = bl;
}
public void SetSelectedMenuBtnNumber(int value){	
	SelectedMenuBtnNumber=value;
}
public void setSelectedMenuButton(Button btn){
	SelectedMenuButton=btn;
}
public void setSubMenuMaxSubmitLvl(bool bl){
	SubMenuMaxSubmitLvl=bl;
}
public void SelectedBtnFx(){
if(SelectedMenuBtnFX!=null){
	if(SelectedMenuButton.IsActive()){
	SelectedMenuBtnFX.SetActive(true);
SelectedMenuBtnFX.transform.position=SelectedMenuButton.transform.position;
SelectedMenuBtnFX.transform.localScale = new Vector2(SelectedMenuButton.transform.localScale.x,SelectedMenuBtnFX.transform.localScale.y);
	}
}
}
public void changeBtnInList(Button bl){
	SelectebleMenuBtnsLists[ExitKeyPhases].list[_selectedMenuBtnNumber]=bl;
}
public void changeBtnByNumberInList(Button bl, int nm){
	SelectebleMenuBtnsLists[ExitKeyPhases].list[nm]=bl;
}
public void changeSubmitBtn(Button bl){
	SubmitMenuBtnList[ExitKeyPhases]=bl;
}
}